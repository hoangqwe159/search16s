using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search16s
{
    // Sequential access using a starting position in the file. (level 1)  
    // Given a starting line, the program lists the required number of sequences to the screen, 
    // starting from the given line number, and shows both lines that correspond to the sequence.
    // SearchLevel 1 class is a child class of SequenceSearch class
    class SearchLevel1 : SequenceSearch
    {
        // Initialize SearchLevel1 using contructors from parent class
        public SearchLevel1(string[] args, List<string> species, List<string> DNA) : base(args, species, DNA)
        {
            // check if there is any error or not
            // if no errors detected, we do the search.
            string error = base.CheckError();
            if (error.Length == 0)
            {
                //print the sequences from the starting index to ending index
                int start = (Convert.ToInt32(args[2]) + 1) / 2 - 1, end = start + Convert.ToInt32(args[3]);
                for (int index = start; index < end; index++)
                {
                    Console.WriteLine(species[index]);
                    Console.WriteLine(DNA[index]);
                }
            }

            // if any errors detected, we display error message to the console.
            else
                Console.Write(error);
        }

       
    }
}
