using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Search16s
{
    // Search for a sequence meta-data containing a given word (level 6)
    // The solution is based on a sequential file scan. Display all matching sequence-ids to the console. 
    // SearchLevel 6 class is a child class of SequenceSearch class
    class SearchLevel6 : SequenceSearch
    {

        // Initialize SearchLevel6 using contructors from parent class
        public SearchLevel6(string[] args, List<string> species, List<string> DNA) : base(args, species, DNA)
        {

            // check if there is any error or not
            // if no errors detected, we do the search.
            string error = base.CheckError();           
            if (error.Length == 0)
            {
                bool checkFound = false; // a variable to check if the given word is found or not
                string queryWord = args[2];

                // a loop to search through the species list
                for (int index = 0; index < species.Count; index++)
                {

                    if (species[index].Contains(queryWord))

                    {
                        List<string> codes = ExtractCode(species[index]);
                        foreach (string code in codes)
                        {
                            Console.WriteLine(code);
                        }
                        checkFound = true;
                    }

                }

                // if given word is not found, print error message.
                if (checkFound == false)
                {
                    Console.WriteLine("No sequences found.");
                }
            }
            // if any errors detected, we display error message to the console.
            else
                Console.Write(error);

        }
    }
}
