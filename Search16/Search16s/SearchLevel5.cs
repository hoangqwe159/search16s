using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Search16s
{
    // Search for an exact match of a DNA query string.  (level 5)
    // The solution is based on a sequential file scan. Display all matching sequence-ids to the console. 
    // SearchLevel 5 class is a child class of SequenceSearch class
    class SearchLevel5 : SequenceSearch
    {

        // Initialize SearchLevel5 using contructors from parent class
        public SearchLevel5(string[] args, List<string> species, List<string> DNA) : base(args, species, DNA)
        {
            // check if there is any error or not
            // if no errors detected, we do the search.
            string error = base.CheckError();
            if (error.Length == 0)
            {
                bool checkFound = false; // a variable to check if the string is found or not
                string dnaString = args[2];

                // a loop to search through the DNA list
                for (int index = 0; index < DNA.Count; index++)
                {

                    if (DNA[index].Contains(dnaString))

                    {
                        List<string> codes = ExtractCode(species[index]);
                        foreach (string code in codes)
                        {
                            Console.WriteLine(code);
                        }
                        checkFound = true;

                    }

                }

                // if string is not found, print error message.
                if (checkFound == false)
                {
                    Console.WriteLine("No sequence was found.");
                }
            }
            // if any errors detected, we display error message to the console.
            else
                Console.Write(error);


        }
    }
}
