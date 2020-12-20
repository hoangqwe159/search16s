using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search16s
{
    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            // parse the data
            DataParser data = new DataParser();
            data.Parse(args);

            // use the parsed data to begin the search
            SequenceSearch search = new SequenceSearch(args, data.species, data.DNA);
            search.SearchAllLevels();
        }
    }
}
