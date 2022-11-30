using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FastBitmapLib;

namespace ColorReduction.Reducers
{
    public class PopularityAlgorithmReducer : ColorReducer
    {
        private readonly int _numOfColors;

        public PopularityAlgorithmReducer(int numOfColors)
        {
            _numOfColors = numOfColors;
        }

        public override Bitmap Reduce(Bitmap image)
        {
            var tree = new ColorTree(image, _numOfColors);
            tree.InitPalette();

            var output = new Bitmap(image.Width, image.Height);
            using var bitmap = new FastBitmap(output);

            for (var y = 0; y < bitmap.Height; y++)
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var color = image.GetPixel(x, y);
                    var newColor = tree.ReduceColor(color);
                    output.SetPixel(x, y, newColor);
                }

            return output;
        }

        private sealed class ColorTree
        {
            private readonly Bitmap _bitmap;
            private readonly List<Node> _leaves = new List<Node>();
            private readonly int _paletteSize;
            private readonly Node _root;
            private List<Color>? _palette;

            public ColorTree(Bitmap bitmap, int paletteSize)
            {
                _root = new Node(0, null, _leaves);
                _bitmap = bitmap;
                _paletteSize = paletteSize;
            }

            public void InitPalette()
            {
                if (_palette is { }) return;

                for (var y = 0; y < _bitmap.Height; y++)
                    for (var x = 0; x < _bitmap.Width; x++)
                        _root.Add(_bitmap.GetPixel(x, y), _leaves);

                _leaves.Sort((a, b) => a.Count - b.Count);
                _palette = _leaves.Take(_paletteSize).Select(l => l.Color!.Value).ToList();
                foreach (var leaf in _leaves.Skip(_paletteSize)) leaf.Clear();
            }

            public Color ReduceColor(Color color)
            {
                var leaf = _root.FindLeaf(color);
                if (leaf.Color is { }) return leaf.Color.Value;
                var reduced = FindClosest(color);
                leaf.Set(reduced);
                return color;
            }

            private Color FindClosest(Color input)
            {
                if (_palette is null) throw new InvalidOperationException("Palette of color tree was uninitialized");

                double Distance(Color a, Color b)
                {
                    return (a.R - b.R) * (a.R - b.R) + (a.G - b.G) * (a.G - b.G) + (a.B - b.B) * (a.B - b.B);
                }

                return _palette.OrderBy(c => Distance(c, input)).First();
            }

            private sealed class Node
            {
                private readonly Node?[] _children;
                private readonly int _depth;

                public Node(int depth, Color? color, ICollection<Node> leaves)
                {
                    _depth = depth;

                    if (depth == 8)
                    {
                        Color = color ?? throw new ArgumentException("Leaf must have color");
                        Count = 1;
                        _children = Array.Empty<Node?>();
                        leaves.Add(this);
                        return;
                    }

                    _children = new Node?[] { null, null, null, null, null, null, null, null };
                }

                public int Count { get; private set; }
                public Color? Color { get; private set; }

                public void Add(Color color, ICollection<Node> leaves)
                {
                    if (_depth == 8)
                    {
                        Count++;
                        return;
                    }

                    var index = 0;
                    if ((color.R & (128 >> _depth)) > 0) index += 4;
                    if ((color.G & (128 >> _depth)) > 0) index += 2;
                    if ((color.B & (128 >> _depth)) > 0) index += 1;

                    _children[index] ??= new Node(_depth + 1, color, leaves);
                    _children[index]!.Add(color, leaves);
                }

                public void Clear()
                {
                    Color = null;
                }

                public void Set(Color color)
                {
                    Color = color;
                }

                public Node FindLeaf(Color color)
                {
                    if (_depth == 8) return this;

                    var index = 0;
                    if ((color.R & (128 >> _depth)) > 0) index += 4;
                    if ((color.G & (128 >> _depth)) > 0) index += 2;
                    if ((color.B & (128 >> _depth)) > 0) index += 1;

                    return _children[index]?.FindLeaf(color) ??
                           throw new InvalidOperationException("Attempted to find unregistered color");
                }
            }
        }
    }
}