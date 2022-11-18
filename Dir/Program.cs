
namespace Dir
{
    class Program
    {
        public static void Main(String[] args)
        {
            string dir = @"C:\Users\Dori\Pictures";


            if (Directory.Exists(dir))
            {
                List<string> allSubdirectories = new List<string>();
                List<string> allFiles = new List<string>();

                void getChildren(string path)
                {
                    allSubdirectories.AddRange(Directory.GetDirectories(path));
                    allFiles.AddRange(Directory.GetFiles(path));

                    foreach (var subdir in Directory.GetDirectories(path))
                    {
                        getChildren(subdir);
                    }

                }

                getChildren(dir);

                foreach (var subdir in allSubdirectories)
                {
                    Console.WriteLine(subdir);

                }
                
                foreach (var file in allFiles)
                {
                    Console.WriteLine(file);
                    var inf = new FileInfo(file);
                    Console.WriteLine(inf.Extension);
                    Console.WriteLine(inf.Length);
                    
                }

                
            }


        




    }
    }
}