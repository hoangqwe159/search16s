using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Search16s
{
    // a class to parse data from fasta file into 2 lists: species and DNA.
    class DataParser
    {
        // class constructors
        public List<string> species = new List<string>();
        public List<string> DNA = new List<string>();

        public void Parse(string[] args)
        {
            if (args.Length >= 2) // check if the number of arguments is satisfied, we continue.
            {
                string dataFile = args[1];
                if (!dataFile.EndsWith(".fasta") && !dataFile.EndsWith(".txt")) // check data file is correctly formatted
                    Console.WriteLine("Error, the data file has invalid format.");


                else if (File.Exists(dataFile)) //check if the fasta file exists
                {
                    var lines = File.ReadAllLines(dataFile); // read lines in fasta file
                    foreach (var line in lines)
                    {
                        if (line.Contains(">"))
                            this.species.Add(line); // add ID into species list
                        else
                            this.DNA.Add(line); // add DNA into DNA list
                    }
                }

                else
                {
                    Console.WriteLine("Error, cannot find data file {0}", dataFile);
                }
            }
            else 
            {
                Console.Write("");
            }
        }

    }
}
