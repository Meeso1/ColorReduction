using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FastBitmapLib;

namespace ColorReduction.Reducers
{
    public sealed class PopularityAlgorithmReducer : IColorReducer
    {
        private readonly int _numOfColors;

        public PopularityAlgorithmReducer(int numOfColors)
        {
            _numOfColors = numOfColors;
        }

        public Bitmap Reduce(Bitmap image)
        {
            var tree = new ColorTree(image, _numOfColors);
            tree.ConstructColorPalette();

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
            private readonly List<Leaf> _leaves = new List<Leaf>();
            private readonly int _paletteSize;
            private readonly Node _root;
            private List<Color>? _palette;

            public ColorTree(Bitmap bitmap, int paletteSize)
            {
                if (paletteSize < 1)
                    throw new ArgumentException($"Palette size must be positive, but {paletteSize} was supplied");

                _root = Node.CreateRoot();
                _bitmap = bitmap;
                _paletteSize = paletteSize;
            }

            public void ConstructColorPalette()
            {
                if (_palette is { }) return;

                for (var y = 0; y < _bitmap.Height; y++)
                    for (var x = 0; x < _bitmap.Width; x++)
                        _root.Add(_bitmap.GetPixel(x, y), _leaves);

                _leaves.Sort((a, b) => b.Count - a.Count);
                _palette = _leaves.Take(_paletteSize).Select(l =>
                {
                    l.SetReduction(l.Color);
                    return l.Color;
                }).ToList();
            }

            public Color ReduceColor(Color color)
            {
                var leaf = _root.FindLeaf(color) ??
                           throw new InvalidOperationException("Attempted to find unregistered color");
                if (leaf.Reduced) return leaf.Color;
                var reduced = FindClosest(color);
                leaf.SetReduction(reduced);
                return color;
            }

            private Color FindClosest(Color input)
            {
                if (_palette is null) throw new InvalidOperationException("Palette of color tree was uninitialized");

                double Distance(Color a, Color b)
                {
                    return (a.R - b.R) * (a.R - b.R) + (a.G - b.G) * (a.G - b.G) + (a.B - b.B) * (a.B - b.B);
                }

                var minDistance = _palette.Min(c => Distance(c, input));
                return _palette.First(c => Distance(c, input) <= minDistance);
            }

            private class Node
            {
                private readonly Node?[] _children;
                private readonly int _depth;

                protected Node(int depth, Node?[] children)
                {
                    _depth = depth;
                    _children = children;
                }

                private Node(int depth) : this(depth, new Node?[] { null, null, null, null, null, null, null, null })
                {
                }

                public static Node CreateRoot()
                {
                    return new Node(0);
                }

                private static Node Create(int depth, Color color, ICollection<Leaf> leaves)
                {
                    if (depth != 8) return new Node(depth);
                    var leaf = new Leaf(depth, color);
                    leaves.Add(leaf);
                    return leaf;
                }

                public virtual void Add(Color color, ICollection<Leaf> leaves)
                {
                    var index = 0;
                    if ((color.R & (128 >> _depth)) > 0) index += 4;
                    if ((color.G & (128 >> _depth)) > 0) index += 2;
                    if ((color.B & (128 >> _depth)) > 0) index += 1;

                    _children[index] ??= Create(_depth + 1, color, leaves);
                    _children[index]!.Add(color, leaves);
                }

                public virtual Leaf? FindLeaf(Color color)
                {
                    var index = 0;
                    if ((color.R & (128 >> _depth)) > 0) index += 4;
                    if ((color.G & (128 >> _depth)) > 0) index += 2;
                    if ((color.B & (128 >> _depth)) > 0) index += 1;

                    return _children[index]?.FindLeaf(color);
                }
            }

            private sealed class Leaf : Node
            {
                public Leaf(int depth, Color color) : base(depth, Array.Empty<Node?>())
                {
                    Color = color;
                }

                public int Count { get; private set; }
                public Color Color { get; private set; }
                public bool Reduced { get; private set; }

                public void SetReduction(Color reduced)
                {
                    Color = reduced;
                    Reduced = true;
                }

                public override void Add(Color color, ICollection<Leaf> leaves)
                {
                    Count++;
                }

                public override Leaf FindLeaf(Color color)
                {
                    return this;
                }
            }
        }
    }
}