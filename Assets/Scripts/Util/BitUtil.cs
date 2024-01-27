namespace Util
{
    public static class BitUtil
    {
        public static bool hasFlags(int bits, int flags)
        {
            return (bits & flags) != 0;
        }

        public static void addFlags(int bits, int flags)
        {
            bits |= flags;
        }

        public static void removeFlags(int bits, int flags)
        {
            bits &= ~flags;
        }
    }
}