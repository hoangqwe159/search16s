using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexSequence16s
{
    // The program creates a sequenceid index to the fasta file.The index supports direct access to sequences, by sequenceid.  
    // Specifically, the program creates an index file. Each line consists of a sequenceid and file-offset.
    class Program
    {
        // a method to generate offset and save it as a list
        public static List<long> GenerateOffsets(string dataFile)
        {
            int checkLine = 0; // a varible to check if the line is the species line
            List<long> offsets = new List<long>();
            offsets.Add(0);
            FileStream fs = new FileStream(dataFile, FileMode.Open, FileAccess.Read);

            // a loop to read through fasta file and add offset of species lines into a list
            for (long offset = 0; offset <= fs.Length; offset++)
            {

                if (fs.ReadByte() == '\n')
                {
                    checkLine++;
                    if (checkLine == 2)
                    {
                        offsets.Add(offset + 1);
                        checkLine = 0;
                    }
                }

            }

            return offsets;

        }

        // a method to generate species ID and save it as a list
        public static List<List<string>> GenerateSpecies(string dataFile)
        {
            List<List<string>> species = new List<List<string>>();
            var lines = File.ReadAllLines(dataFile);

            // a loop to read through fasta file and add ID of species into a list
            foreach (var line in lines)
            {
                if (line.Contains(">"))
                {
                    string[] sequence;
                    List<string> sequenceList = new List<string>();
                    sequence = line.Split(' ');

                    // a loop to determine ID of species in the line
                    for (int i = 0; i < sequence.Length; i++)
                    {
                        if (sequence[i].Contains(">"))
                        {
                            sequenceList.Add(sequence[i].Substring(1));
                        }
                    }
                    species.Add(sequenceList);
                }
            }

            return species;
      
        }

        // a method to generate an index file based on an offset list and a specie-ID list
        public static void GenerateIndexFile(string indexFile, List<long> offsets, List<List<string>> species)
        {
            FileStream outFile = new FileStream(indexFile, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);
            for (int i = 0; i < offsets.Count; i++)
            {
                for (int j = 0; j < species[i].Count; j++)
                {
                    writer.WriteLine(species[i][j] + ' ' + offsets[i]);
                }
            }

            writer.Close();
        }

        //main program
        public static void Main(string[] args)
        {
            try // check if there is any error
            {
                if (args[0].EndsWith(".fasta") && args[1].EndsWith(".index"))
                {
                    string dataFile = args[0];
                    string indexFile = args[1];
                    List<long> offsets = new List<long>();
                    List<List<string>> species = new List<List<string>>();

                    if (File.Exists(dataFile)) // check if data file exists
                    {
                        offsets = GenerateOffsets(dataFile);
                        species = GenerateSpecies(dataFile);
                        GenerateIndexFile(indexFile, offsets, species);
                    }
                    else
                        Console.WriteLine("Error, cannot find file.");
                }
                else
                    Console.WriteLine("Error, the files have invalid format.");
            }
            catch(Exception ex) // print messagte if some errors occur.
            {
                if (ex is IndexOutOfRangeException)
                {
                    Console.WriteLine("The number of argument is invalid");
                }
                else
                    Console.WriteLine("Something went wromg");
            }
        }

            

            

    }
}
