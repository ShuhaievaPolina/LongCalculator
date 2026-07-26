
namespace Kyrsova_2_sem
{
    public static class OpCounter
    {
        public static long Steps { get; private set; }
        public static void Reset()
        {
            Steps = 0;
        }

        public static void Add(long count = 1)
        {
            Steps += count;
        }
    }
}
