using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search16s
{
    // Sequential access to a specific sequence by sequence-id.  (level 2)
    // The program will respond by displaying to the console the respective sequence lines, or a suitable error message if not found.
    // SearchLevel 2 class is a child class of SequenceSearch class

    class SearchLevel2 : SequenceSearch
    {
        // Initialize SearchLevel2 using contructors from parent class
        public SearchLevel2(string[] args, List<string> species, List<string> DNA) : base(args, species,DNA)
        {
            // check if there is any error or not
            // if no errors detected, we do the search.
            string error = base.CheckError();
            if (error.Length == 0)
            {
                int length = DNA.Count, check = 0;
                string inputID = ">" + args[2] + " ";
                // a loop to find the specific sequence
                for (int index = 0; index < length; index++)
                {                    
                    if (species[index].Contains(inputID))
                    {
                        Console.WriteLine(species[index]);
                        Console.WriteLine(DNA[index]);
                        check++;
                    }
                }
                if (check == 0) // if sequence is not found, print error message
                {
                    Console.WriteLine("Error, sequence {0} not found.", args[2]);
                }
            }
            // if any errors detected, we display error message to the console.
            else
            {
                Console.Write(error);
            }
        }               
    }
}
