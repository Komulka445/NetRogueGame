using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Rogue
{
    internal class Game
    {
        MapLoader loader = new MapLoader();
        int PosX = 1;
        int PosY = 1;
        int FormerX = 1;
        int FormerY = 1;
        Map level01;
        Map mapproxy;
        MapLoader mapLoader;
        
        public void CharacterCreation()
        {
            PlayerCharacter player = new PlayerCharacter();
            Console.WriteLine("What is your name?");
            player.name = Console.ReadLine();
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Select race\n" + string.Join("\n", Enum.GetValues(typeof(Race)).Cast<Race>()));
                string ans = Console.ReadLine();
                if (ans == Race.Human.ToString() || ans == Race.Elf.ToString() || ans == Race.Orc.ToString() || ans == Race.Dwarf.ToString())
                {
                    //raceAnswer = (Race) player.rotu;
                    //player.rotu = raceAnswer;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Race");
                }
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Select class\n" + EnumHelper.ClassAlternatives);
                string ans = Console.ReadLine();

                if (EnumHelper.IsValidClass(ans))
                {
                    //Console.Clear();
                    //Console.WriteLine(ans, player);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Class");
                }
            }
        }

        public void Player()
        {
        }

        public void CheckTile()
        {
            if (mapproxy.mapTiles[PosX + PosY * 8] == 1)
            {
                Console.SetCursorPosition(PosX, PosY);
            }
            else
            {
                PosX = FormerX;
                PosY = FormerY;
            }
        }

        public void Run()
        {
            //DEBUG
            
            //DEDEBUG
            CharacterCreation();
            //Console.Clear();
            Console.Clear();

            level01 = loader.LoadTestMap();
            mapproxy = level01;
            //Draw();
            loader.LoadMapFromFile("Maps/mapfile.json");
            int indeksi = PosX + (PosY * 8);
            int numero = mapproxy.mapTiles[indeksi];


            bool game_running = true;
            while (game_running)
            {
                Console.CursorVisible = false;
                //Draw();
                //uus alla
                Console.Clear();
                loader.LoadMapFromFile("Maps/mapfile.json");
                Console.SetCursorPosition(PosX, PosY);
                Console.Write("@");

                FormerX = PosX;
                FormerY = PosY;

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.NumPad9:
                        PosX = PosX + 1;
                        PosY = PosY - 1;
                        CheckTile();
                        //player.Move(1, -1);
                        break;
                    case ConsoleKey.NumPad8:
                        PosY = PosY - 1;
                        CheckTile();
                        //player.Move(0, -1);
                        break;
                    case ConsoleKey.NumPad7:
                        PosX = PosX - 1;
                        PosY = PosY - 1;
                        CheckTile();
                        //player.Move(-1, -1);
                        break;
                    case ConsoleKey.NumPad6:
                        PosX = PosX + 1;
                        CheckTile();
                        //player.Move(1, 0);
                        break;
                    case ConsoleKey.NumPad4:
                        PosX = PosX - 1;
                        CheckTile();
                        //player.Move(-1, 0);
                        break;
                    case ConsoleKey.NumPad3:
                        PosX = PosX + 1;
                        PosY = PosY + 1;
                        CheckTile();
                        //player.Move(1, 1);
                        break;
                    case ConsoleKey.NumPad2:
                        PosY = PosY + 1;
                        CheckTile();
                        //player.Move(0, 1);
                        break;
                    case ConsoleKey.NumPad1:
                        PosX = PosX - 1;
                        PosY = PosY + 1;
                        CheckTile();
                        //player.Move(-1, 1);
                        break;
                    case ConsoleKey.Escape:
                        game_running = false;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        //draw.GenerateMap();
                        //draw.DrawMap();
                        break;
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        //draw.DrawMap();
                        break;
                    default:
                        break;
                }
                
            }
        }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Gray; 
            int mapHeight = mapproxy.mapTiles.Length / mapproxy.mapWidth; 
            for (int y = 0; y < mapHeight; y++) 
            {
                for (int x = 0; x < mapproxy.mapWidth; x++) 
                {
                    int index = x + y * mapproxy.mapWidth; 
                    int tileId = mapproxy.mapTiles[index]; 

                   
                    Console.SetCursorPosition(x, y);
                    switch (tileId)
                    {
                        case 1:
                            Console.Write("."); 
                            break;
                        case 2:
                            Console.Write("#"); 
                            break;
                        default:
                            Console.Write(" ");
                            break;
                    }
                }
            }
        }
    }
}
