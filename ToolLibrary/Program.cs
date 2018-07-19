using System;
using System.Collections.Generic;

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
                MenuItems[0].Selected = true;
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

