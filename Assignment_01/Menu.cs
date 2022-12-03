
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    public class Menu
    {   
        public int ColPos { get; set; }
        public int RowPos { get; set; }


        public List<MenuItem > MenuItems { get; set; }

        public int SelectedItem { get; set; }

        public Menu()
        {
            ColPos = 15;
            RowPos = 5;
            SelectedItem = 0;
            MenuItems = new List<MenuItem>
            {
                new MenuItem("File",true),
                new MenuItem("Edit",false),
                new MenuItem("View",false),
                new MenuItem("Help",false),
                new MenuItem("Quit",false)

            };
        }
        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.Clear();
            Console.CursorVisible = false;
            bool running = true;
            while (running) {
                Console.SetCursorPosition(ColPos, RowPos);
                //Console.WriteLine("Hellow Menu");
                for (int i = 0; i < MenuItems.Count; i++)
                {
                   
                    Console.SetCursorPosition(ColPos, RowPos + i);
                    if (MenuItems[i].IsSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine(MenuItems[i].Title);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(MenuItems[i].Title);
                    }
                           
                }
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem +1)%MenuItems.Count;

                    MenuItems[SelectedItem].IsSelected = true;

                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = SelectedItem - 1;
                    if (SelectedItem < 0)
                    {
                        SelectedItem = MenuItems.Count - 1;
                    }
                    MenuItems[SelectedItem].IsSelected = true;

                }
                if(key.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(2, 0);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor= ConsoleColor.White;
                    Console.WriteLine($"You selected {MenuItems[SelectedItem].Title}");
                    if(MenuItems[SelectedItem].Title == "Quit")
                    {
                        running = false;
                    }
                }
            }

        }
    }
}
