using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
    internal class Map
    {
        new MapLoader maploader;
        new Game gameDrawer;
        public int mapWidth;
        public int[] mapTiles;
        public void Draw()
        {
            int mapWidth = 8;
            int[] mapTiles = new int[] {
            2, 2, 2, 2, 2, 2, 2, 2,
            2, 1, 1, 2, 1, 1, 1, 2,
            2, 1, 1, 2, 1, 1, 1, 2,
            2, 1, 1, 1, 1, 1, 2, 2,
            2, 2, 2, 2, 1, 1, 1, 2,
            2, 1, 1, 1, 1, 1, 1, 2,
            2, 2, 2, 2, 2, 2, 2, 2 };
            maploader.LoadTestMap();


        }

        //ylim og on paikoillaan ja sitä ei käytetä atm
        // nvm ÄKLÄ KÄYTÄT TÄTÄ
        public void LoadMapFromFile(string filename)
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

            //gameDrawer.Draw();
            //return loadedMap;
        }
    }
}
