using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
    internal class MapLoader
    {
        public Map LoadTestMap()
        {
            Map testmap = new Map();
            testmap.mapWidth = 8;
            testmap.mapTiles = new int[] {
            2, 2, 2, 2, 2, 2, 2, 2,
            2, 1, 1, 2, 1, 1, 1, 2,
            2, 1, 1, 2, 1, 1, 1, 2,
            2, 1, 1, 1, 1, 1, 2, 2,
            2, 2, 2, 2, 1, 1, 1, 2,
            2, 1, 1, 1, 1, 1, 1, 2,
            2, 2, 2, 2, 2, 2, 2, 2 };
            return testmap;
        }

        public void TestFileReading(string filename)
        {
            using (StreamReader reader = File.OpenText(filename))
            {
                Console.WriteLine("File contents:");
                Console.WriteLine();

                string line;
                while (true)
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        break; // End of file
                    }
                    Console.WriteLine(line);
                }
            }
        }

        //alkuperäinen
        public Map LoadMapFromFile(string filename)
        {
            // Check that file exists
            //if (fileFound == false)
            //{
             //   Console.WriteLine($"File {filename} not found");
              //  return LoadTestMap(); // Return the test map as fallback
            //}

            string fileContents;

            using (StreamReader reader = File.OpenText(filename))
            {
                fileContents = reader.ReadToEnd();
            }

            Map loadedMap = JsonConvert.DeserializeObject<Map>(fileContents);
            
            return loadedMap;
        }
    }

}
