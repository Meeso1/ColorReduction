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

        private static Color FindClosest(Color input, IEnumerable<Color> palette)
        {
            double Distance(Color a, Color b)
            {
                return Math.Sqrt((a.R - b.R) * (a.R - b.R) + (a.G - b.G) * (a.G - b.G) + (a.B - b.B) * (a.B - b.B));
            }

            return palette.OrderBy(c => Distance(c, input)).First();
        }

        public override Bitmap Reduce(Bitmap image)
        {
            var tree = new ColorTree();
            var palette = tree.GetPalette(image, _numOfColors);

            var output = new Bitmap(image.Width, image.Height);
            using var bitmap = new FastBitmap(output);

            for (var y = 0; y < bitmap.Height; y++)
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var color = image.GetPixel(x, y);
                    var newColor = FindClosest(color, palette);
                    output.SetPixel(x, y, newColor);
                }

            return output;
        }

        private sealed class ColorTree
        {
            private readonly List<Node> _leaves = new List<Node>();
            private readonly Node _root;

            public ColorTree()
            {
                _root = new Node(0, null, _leaves);
            }

            public List<Color> GetPalette(Bitmap bitmap, int number)
            {
                for (var y = 0; y < bitmap.Height; y++)
                    for (var x = 0; x < bitmap.Width; x++)
                        _root.Add(bitmap.GetPixel(x, y), _leaves);

                _leaves.Sort((a, b) => a.Count - b.Count);
                return _leaves.Take(number).Select(l => l.Color!.Value).ToList();
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
                public Color? Color { get; }

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
            }
        }
    }
}