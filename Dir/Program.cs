
namespace Dir
{
    class Program
    {
        public static void Main(String[] args)
        {
            string dir = @"C:\Users\Dori\Pictures";
            var b = new Dir(dir);
            b.GetAverageSize();
            b.GetFrequencyByType();

        }
    }
}