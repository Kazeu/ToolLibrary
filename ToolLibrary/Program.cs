using System;
using System.Collections.Generic;
using ToolLibrary;

namespace UsefulStuff
{
    public class Menus
    {
        public class Menu
        {
            public List<MenuItem> MenuItems;

            private int selectedItem;
            public int SelectedItem
            {
                get
                {
                    return selectedItem;
                }

                set
                {
                    if (value < MenuItems.Count && value >= 0)
                    {
                        MenuItems[SelectedItem].Selected = false;
                        selectedItem = value;
                        MenuItems[SelectedItem].Selected = true;
                    }
                }
            }

            public MenuItem DispVertMenu(int selected = 0)
            {
                bool cursorVisible = Console.CursorVisible;
                ConsoleKey input;
                Console.Clear();
                SelectedItem = selected;
                MenuItems[selected].Selected = true;
                Console.CursorVisible = false;

                do
                {
                    Console.SetCursorPosition(0, 0);

                    foreach (MenuItem item in MenuItems)
                    {
                        Console.Write(item.Selected ? ">{0}" : " {0}", item.DisplayName);
                        Console.WriteLine();
                    }

                    input = Console.ReadKey().Key;

                    switch (input)
                    {
                        case ConsoleKey.UpArrow:
                            BackSelect();
                            break;
                        case ConsoleKey.DownArrow:
                            NextSelect();
                            break;
                        case ConsoleKey.Enter:
                            Console.CursorVisible = cursorVisible;
                            Console.Clear();
                            return MenuItems[SelectedItem];
                    }

                } while (input != ConsoleKey.Enter);

                Console.CursorVisible = cursorVisible;
                Console.Clear();

                return MenuItems[SelectedItem];
            }

            public void NextSelect()
            {
                if (SelectedItem + 1 < MenuItems.Count)
                {
                    MenuItems[SelectedItem].Selected = false;
                    MenuItems[++SelectedItem].Selected = true;
                }
            }
            public void BackSelect()
            {
                if (SelectedItem > 0)
                {
                    MenuItems[SelectedItem].Selected = false;
                    MenuItems[--SelectedItem].Selected = true;
                }
            }

            public MenuItem DispTableMenu(int col = 5, int selected = 0)
            { 
                ConsoleKey input;
                int cellSize = 0;

                bool initCursorVisible = Console.CursorVisible;
                int initWidth = Console.WindowWidth;
                SelectedItem = selected;
                MenuItems[selected].Selected = true;
                Console.CursorVisible = false;

                Console.Clear();

                foreach (MenuItem item in MenuItems)
                {
                    if (item.DisplayName.Length > cellSize)
                    {
                        cellSize = item.DisplayName.Length;
                    }
                }

                do
                {
                    for (int i = 0; i < Math.Ceiling(d: MenuItems.Count / col); ++i)
                    {

                    }

                    input = Console.ReadKey().Key;

                    switch (input)
                    {
                        case ConsoleKey.LeftArrow:
                            BackSelect();
                            break;
                        case ConsoleKey.RightArrow:
                            NextSelect();
                            break;
                        case ConsoleKey.UpArrow:
                            if (SelectedItem >= col)
                            {
                                SelectedItem -= col;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (SelectedItem + col < MenuItems.Count)
                            {
                                SelectedItem += col;
                            }
                            break;
                        case ConsoleKey.Enter:
                            Console.CursorVisible = initCursorVisible;
                            Console.Clear();
                            return MenuItems[SelectedItem];
                    }
                } while (input != ConsoleKey.Enter);

                Console.CursorVisible = initCursorVisible;
                Console.Clear();

                return MenuItems[SelectedItem];
            }
        }

        public class MenuItem
        {
            public bool Selected { get; set; }
            public string DisplayName { get; set; }
            public int ID { get; set; }
            public string strVal { get; set; }
            public decimal numVal { get; set; }
        }
    }
}

