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
        /// Simple class to travers folders and display folder that 
        /// contain a .git folder
        /// </summary>
        public FindGitFolders()
        {
            //create module level collection to store results.
            _folders = new List<string>();
        }

        /// <summary>
        ///  Entry point into this class
        /// </summary>
        /// <param name="folder"></param>
        public void Start(string startFolder)
        {
            //display simple message
            Console.WriteLine($"Starting in folder {startFolder}");

            //recurse from starting folder
            Recursefolders(startFolder);

            //print folders in our collection
            PrintFolders();
        }



        /// <summary>
        /// Add the folder to our collection
        /// </summary>
        /// <param name="folder"></param>
        private void AddFolderToList(string folder)
        {
            //Since the folder name is like \src\myapp\.git
            //remove the .git from the name
            string fixedFolder = folder.Replace(".git", "");

            //add the corrected name to the collection
            _folders.Add(fixedFolder);
        }



        /// <summary>
        ///  Display the folders in our collection to the screen
        /// </summary>
        private void PrintFolders()
        {

            //first ensure we have at least one folder to display
            if (_folders.Count > 0)
            {
                foreach (string folder in _folders)
                {
                    Console.WriteLine(folder);
                }
            }
            else
            {
                //if nothing in the collection the display simple message
                Console.WriteLine("No Git Folders Found!");
            }
        }

        /// <summary>
        /// Recursivly travers all the folders from the starting folder
        /// </summary>
        /// <param name="startFolder"></param>
        /// <returns></returns>
        private void Recursefolders(string startFolder)
        {
            try
            {
                //Loop every folder from the starting folder
                foreach (string folder in Directory.GetDirectories(startFolder))
                {
                    //if the folder name ends with .git then add this folder to our collection
                    if (folder.EndsWith(".git"))
                    {
                        AddFolderToList(folder);
                    }

                    //now call ourself recursivly to travers every branch.
                    Recursefolders(folder);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}