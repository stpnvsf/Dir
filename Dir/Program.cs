namespace Dir
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Dori\Pictures\Saved Pictures\scr";

            Dir dir = new Dir(path);

            foreach(var i in dir.GetAllAncestors())
            {
                Console.WriteLine(i);
            }
        }
    }
}
