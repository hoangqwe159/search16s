using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Search16s
{
    // Search for a sequence containing wild cards (level 7)
    // A “*” stands for any number of characters in the same position.  Display all matching sequences to the screen
    // SearchLevel 7 class is a child class of SequenceSearch class
    class SearchLevel7 : SequenceSearch
    {

        // Initialize SearchLevel7 using contructors from parent class
        public SearchLevel7(string[] args, List<string> species, List<string> DNA) : base(args, species, DNA)
        {
            // check if there is any error or not
            // if no errors detected, we do the search.
            string error = base.CheckError();
            if (error.Length == 0)
            {
                string wildCard = args[2];
                string patern = wildCard.Replace("*", ".*"); // change the input string to regex pattern
                bool checkFound = false; // a variable to check if the input string is found or not

                // a loop to search through DNA list
                for (int index = 0; index < DNA.Count; index++)
                {
                    // if the patern is matched, print the sequence to the console
                    if (Regex.IsMatch(DNA[index], patern))
                    {
                        checkFound = true;
                        Console.WriteLine(species[index]);
                        Console.WriteLine(DNA[index]);
                    }
                }
                // if the input string is not found, print error message.
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
