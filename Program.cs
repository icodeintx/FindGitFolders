namespace FindGitFolders;

public class Program
{
    public static void Main(string[] args)
    {
        string startFolder = "";

        //if no argument passed in then use current folder
        if (args.Length == 0)
        {
            startFolder = Environment.CurrentDirectory;
        }
        else
        {
            //if argument is passed in then test
            try
            {
                if (Directory.Exists(args[0]))
                {
                    startFolder = args[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //create new instance of FindGitFolder class
        FindGitFolders gf = new();
        gf.Start(startFolder);
    }
}