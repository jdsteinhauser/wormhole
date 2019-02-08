using System;
namespace Wormhole
{
    public static class Utility
    {
        public static T Identity<T>(T val) => val;

        public static int Inc(int i) => i + 1;

        public static int Dec(int i) => i - 1;
    }
}
