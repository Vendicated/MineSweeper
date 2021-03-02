using System;

namespace Minesweeper
{
    public static class Field
    {
        private static bool HasBit(this BitField value, BitField flag)
        {
            return (value & flag) != 0;
        }

        public static BitField Reveal(this BitField value) => value | BitField.Revealed;
        public static BitField Flag(this BitField value) => value | BitField.Flagged;

        public static bool IsMine(this BitField value) => value.HasBit(BitField.Mine);
        public static bool IsRevealed(this BitField value) => value.HasBit(BitField.Revealed);
        public static bool IsFlagged(this BitField value) => value.HasBit(BitField.Flagged);

        public static BitField FromInt(int value) => (BitField)(1 << value);

        public static char ToChar(this BitField value)
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