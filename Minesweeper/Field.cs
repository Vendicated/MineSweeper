using System;

namespace Minesweeper
{
    public static class Field
    {
        private static bool HasBit(BitField value, BitField flag)
        {
            return (value & flag) != 0;
        }

        public static bool IsMine(BitField value)
        {
            return HasBit(value, BitField.Mine);
        }

        public static BitField Reveal(BitField value)
        {
            return value | BitField.Revealed;
        }

        public static bool IsRevealed(BitField value)
        {
            return HasBit(value, BitField.Revealed);
        }

        public static BitField Flag(BitField value)
        {
            return value | BitField.Flagged;
        }

        public static bool IsFlagged(BitField value)
        {
            return HasBit(value, BitField.Flagged);
        }

        public static BitField FromInt(int value)
        {
            return (BitField)(1 << value);
        }

        public static char ToChar(BitField value)
        {
            // Remove Revealed and Flagged bit
            switch (value & ~(BitField.Revealed | BitField.Flagged))
            {
                case BitField.Zero:
                    return '0';
                case BitField.One:
                    return '1';
                case BitField.Two:
                    return '2';
                case BitField.Three:
                    return '3';
                case BitField.Four:
                    return '4';
                case BitField.Five:
                    return '5';
                case BitField.Six:
                    return '6';
                case BitField.Seven:
                    return '7';
                case BitField.Eight:
                    return '8';
                case BitField.Mine:
                    return 'X';
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }
    }

    public enum BitField
    {
        Zero = 1 << 0,
        One = 1 << 1,
        Two = 1 << 2,
        Three = 1 << 3,
        Four = 1 << 4,
        Five = 1 << 5,
        Six = 1 << 6,
        Seven = 1 << 7,
        Eight = 1 << 8,
        Mine = 1 << 9,
        Revealed = 1 << 10,
        Flagged = 1 << 11
    }
}