using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Search16s
{
    // Direct access to sequences.  (level 4)
    // The program writes out all matching sequences to the specified results file (not to the console).  
    // Sequence-ids that are not found should however be output to the console with a suitable error message.
    // Instead of using a sequential file scan, it uses the index, specified with the additional index filename
    // SearchLevel 4 class is a child class of SequenceSearch class
    class SearchLevel4 : SequenceSearch
    {

        // Initialize SearchLevel4 using contructors from parent class
        public SearchLevel4(string[] args, List<string> species, List<string> DNA) : base(args, species, DNA)
        {
            // check if there is any error or not
            // if no errors detected, we do the search.
            string error = base.CheckError();            
            if (error.Length == 0) 
            {
                int countLine = 0; //this varible is used to determine the odd and even line
                var linesQuery = File.ReadAllLines(args[3]);
                var indexedQuery = File.ReadAllLines(args[2]);

                FileStream outFile = new FileStream(args[4], FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                FileStream fs = new FileStream(args[1], FileMode.Open, FileAccess.Read);


                List<string> foundQuery = new List<string>(); // a list to store query that can be founded in fasta file
                List<long> offsets = new List<long>(); // a list to store offset of ID that are founded

                // a loop to read through index file
                for (int index = 0; index < indexedQuery.Length; index++)
                {
                    // a loop to find sequences that match fasta file and store them and their offset in two lists
                    foreach (var line in linesQuery)
                    {

                        if (line.Contains("NR_") && indexedQuery[index].Contains(line + " "))
                        {
                            offsets.Add(Convert.ToInt64(indexedQuery[index].Split(' ')[1]));
                            foundQuery.Add(line);

                        }
                    }
                }

                // a loop to direct access to sequence by using offset list
                for (int index = 0; index < offsets.Count; index++)
                {
                    fs.Seek(offsets[index], SeekOrigin.Begin);
                    countLine = 0;                    
                    while (true)
                    {
                        writer.Write(Convert.ToChar(fs.ReadByte()));
                        fs.Position -= 1;

                        if (fs.ReadByte() == '\n')
                        {
                            countLine++;

                        }
                        // break the while loop when two lines (1 sequence) are printed
                        if (countLine == 2)
                            break;
                    }
                }
                writer.Close();




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
                Console.Write(error);

        }       
    }
}
