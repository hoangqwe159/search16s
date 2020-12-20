using System;
using System.Collections.Generic;
using System.IO;


namespace Search16s
{   
    // a class to do the required search and check if there is any error
    public class SequenceSearch
    {
        public string[] args;
        public List<string> species;
        public List<string> DNA;
        
        //class constructors
        public SequenceSearch(string[] args, List<string> species, List<string> DNA)
        {
            this.args = args;
            this.species = species;
            this.DNA = DNA;
        }

        // a method to do the search based on the level user inputted
        public void SearchAllLevels()
        {
            try
            {
                if (args[0] == "-level1")
                {
                    SearchLevel1 search = new SearchLevel1(args, species, DNA);
                    
                }
                else if (args[0] == "-level2")
                {
                    SearchLevel2 search = new SearchLevel2(args, species, DNA);

                }
                else if (args[0] == "-level3")
                {
                    SearchLevel3 search = new SearchLevel3(args, species, DNA);

                }
                else if (args[0] == "-level4")
                {
                    SearchLevel4 search = new SearchLevel4(args, species, DNA);
                }
                else if (args[0] == "-level5")
                {
                    SearchLevel5 search = new SearchLevel5(args, species, DNA);
                }
                else if (args[0] == "-level6")
                {
                    SearchLevel6 search = new SearchLevel6(args, species, DNA);
                }
                else if (args[0] == "-level7")
                {
                    SearchLevel7 search = new SearchLevel7(args, species, DNA);
                }
                else
                    Console.WriteLine("Error, invalid level input.");
            }
            catch (Exception ex)
            {
                if (species.Count == 0)
                    Console.WriteLine("Error, no data file inputted.");
                else if (ex is IndexOutOfRangeException)
                    Console.WriteLine("Error, not enough arguments input to call searching method.");
            }
            
        }

        // a method to extrace sequence-ID from corresponed specie string
        public List<string> ExtractCode(string specie)
        {
            string[] line;
            List<string> codes = new List<string>();
            List<string> sequenceList = new List<string>();
            line = specie.Split(' ');

            // a loop to add ID in the list
            for (int index = 0; index < line.Length; index++)
            {
                if (line[index].Contains(">"))
                {
                    codes.Add(line[index].Substring(1));
                }
            }
            return codes;
        }     

        // a method to check if the input arguments contain any error:
        // check the number of arguments is satisfied
        // check the data is parsed or not
        // check the file is in correct format
        // check error based on each level

        public string CheckError()
        {
            if (species.Count == 0)
                return "No data inputted.\n";
            else if (args[0] == "-level1")
            {
                try
                {
                    int line = Convert.ToInt32(args[2]);
                    int numberOfLine = Convert.ToInt32(args[3]);
                    int start = (line + 1) / 2 - 1, end = start + numberOfLine;
                    
                    if (args.Length != 4)
                    {
                        return "Error, invalid number of arguments input.\n";
                    }
                    else if ((line <= 0) || (numberOfLine <= 0))
                    {
                        return "Error, the line number and number of lines must be positive integer.\n";
                    }
                    else if (end > DNA.Count)
                    {
                        return "Error, the number of lines you enterd is exceeded.\n";
                    }
                    else if (line % 2 != 1)
                    {
                        return "Error, the line number must be an odd number.\n";
                    }
                    else
                        return "";
                }

                catch (Exception ex)
                {
                    if (species.Count == 0)
                        return "No data inputted.\n";
                    else if (ex is FormatException)
                        return "Error, please enter integers for line number and number of lines.\n";
                    else if (ex is OverflowException)
                        return "Error, line number or number of lines is too large.\n";
                    else if (ex is IndexOutOfRangeException)
                        return "Error, invalid number of arguments input.\n";
                    else
                        return "Some errors occur.";
                }
            }
            else if (args[0] == "-level2")
            {
                if (args.Length != 3)                
                    return "Error, invalid number of arguments input.\n";                
                else
                    return "";
            }
            else if (args[0] == "-level3")
            {
                if (args.Length != 4)
                    return "Error, invalid number of arguments input.\n";

                else if (!File.Exists(args[2]))
                    return string.Format("Cannot find file \'{0}\'", args[2]);

                else if (!args[2].EndsWith(".txt") || !args[3].EndsWith(".txt")) 
                    return "The output or input file has invalid format.\n";

                else
                    return "";
            }
            else if (args[0] == "-level4")
            {
                if (args.Length != 5)
                    return "Error, invalid number of arguments input.\n";

                else if (!File.Exists(args[2]))
                    return string.Format("Error, cannot find file \'{0}\'\n", args[2]);
                else if (!File.Exists(args[3]))
                    return string.Format("Error, cannot find file \'{0}\'\n", args[3]);

                else if (!args[3].EndsWith(".txt") || !args[4].EndsWith(".txt")) 
                    return "Error, the output or input file has invalid format.\n";

                else
                    return "";
            }
            else if (args[0] == "-level5" || args[0] == "-level6" || args[0] == "-level7")
            {
                if (args.Length != 3)
                    return "Error, invalid number of arguments input.\n";
                else
                    return "";
            }
            else
                return "";
        }
    }
}
