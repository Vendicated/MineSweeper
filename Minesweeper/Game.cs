using System.Text;
using System;

namespace Minesweeper
{
    public class Game
    {
        private readonly Random random = new Random();
        private readonly BitField[,] Map;
        public readonly int Width;
        public readonly int Height;
        public readonly int Mines;

        public Game(int width = 10, int height = 10, int mines = 10)
        {
            Width = width;
            Height = height;
            Mines = mines;
            Map = new BitField[height, width];
            PlaceMines();
            GenerateMap();
        }

        public void GenerateMap()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (Field.IsMine(Map[i, j])) continue;

                    Map[i, j] = Field.FromInt(CalculateMineCount(i, j));
                }
            }
        }

        private void PlaceMines()
        {
            for (int i = 0; i < Mines; i++)
            {
                int x;
                int y;

                do
                {
                    x = random.Next(Height);
                    y = random.Next(Width);
                } while (Field.IsMine(Map[x, y]));

                Map[x, y] = BitField.Mine;
            }

        }

        private int CalculateMineCount(int x, int y)
        {
            int mineCount = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                if (i < 0 || i > Height - 1) continue;

                for (int j = y - 1; j < y + 2; j++)
                {
                    if (j < 0 || j > Width - 1) continue;

                    if (Field.IsMine(Map[i, j])) mineCount++;
                }
            }


            return mineCount;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                if (i != 0) builder.AppendLine().AppendLine(new String('-', Width * 4 - 1));
                builder.Append(' ');

                for (int j = 0; j < Width; j++)
                {
                    builder.Append(Field.ToChar(Map[i, j]));

                    if (j != Width - 1) builder.Append(" | ");
                }
            }

            return builder.ToString();
        }

    }
}