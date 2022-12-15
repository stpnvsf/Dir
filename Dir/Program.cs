
namespace Dir
{
    class Program
    {
        static void printTree(string str, int count)
        {
            Console.WriteLine(new String(' ', (count - 1) * 4) + str);
        }
        static void tree(Dir dir, int level)
        {
            if (dir.Subdirectories.Any())
            {
                ++level;
                foreach (var subdir in dir.Subdirectories)
                {
                    //Console.WriteLine(subdir.Name);
                    printTree(subdir.Name, level);
                    tree(subdir, level);
                }
            }
        }
        public static void Main(String[] args)
        {
            string dir = @"C:\Users\Dori\Pictures";
            var b = new Dir(dir);

            tree(b, 0);

        }
    }
}