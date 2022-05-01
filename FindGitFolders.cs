using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGitFolders
{
    internal class FindGitFolders
    {
        private List<string> _folders;

        /// <summary>
        ///
        /// </summary>
        public FindGitFolders()
        {
            _folders = new List<string>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="folder"></param>
        public void Start(string startFolder)
        {
            Console.WriteLine($"Starting in folder {startFolder}");

            Recursefolders(startFolder);

            PrintFolders();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="folder"></param>
        private void AddFolderToList(string folder)
        {
            //remove the .git from the name
            string fixedFolder = folder.Replace(".git", "");

            _folders.Add(fixedFolder);
        }

        /// <summary>
        ///
        /// </summary>
        private void PrintFolders()
        {
            if (_folders.Count > 0)
            {
                foreach (string folder in _folders)
                {
                    Console.WriteLine(folder);
                }
            }
            else
            {
                Console.WriteLine("No Git Folders Found!");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="startFolder"></param>
        /// <returns></returns>
        private void Recursefolders(string startFolder)
        {
            try
            {
                foreach (string folder in Directory.GetDirectories(startFolder))
                {
                    if (folder.EndsWith(".git"))
                    {
                        AddFolderToList(folder);
                    }

                    Recursefolders(folder);
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }
    }
}