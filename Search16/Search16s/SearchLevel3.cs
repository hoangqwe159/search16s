using System;
using System.Collections.Generic;
using System.IO;


namespace Search16s
{
    // Sequential access to find a set of sequence-ids given in a query file, and writing the output to a specified result file.  (level 3)
    // The program writes out all matching sequences to the specified results file (not to the console).  
    // Sequence-ids that are not found should however be output to the console with a suitable error message.
    // SearchLevel 3 class is a child class of SequenceSearch class
    class SearchLevel3 : SequenceSearch
    {
        // Initialize SearchLevel3 using contructors from parent class
        public SearchLevel3(string[] args, List<string> species, List<string> DNA) : base(args, species, DNA)         
        {
            // check if there is any error or not
            // if no errors detected, we do the search.
            string error = base.CheckError();
            if (error.Length == 0)
            {
                var linesQuery = File.ReadAllLines(args[2]);
                FileStream outFile = new FileStream(args[3], FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);
                List<string> foundQuery = new List<string>(); // a list to store queries that are founded


                for (int index = 0; index < DNA.Count; index++)
                {
                    // a loop to find sequence in fasta file
                    foreach (var line in linesQuery)
                    {
                        if (species[index].Contains(">" + line + " "))
                        {
                            // writing found sequences in result.txt
                            writer.WriteLine(species[index]);
                            writer.WriteLine(DNA[index]);
                            foundQuery.Add(line);

                        }
                    }
                }
                writer.Close();
                // a loop to check if any queries are not found
                foreach (var line in linesQuery)
                {
                    if (!foundQuery.Contains(line)) // if the sequence is not found, display error message
                    {
                        Console.WriteLine("Error, sequence \'{0}\' not found.", line);
                    }
                }

            }
            // if any errors detected, we display error message to the console.
            else
                Console.WriteLine(error);
        }

        
    }
}
