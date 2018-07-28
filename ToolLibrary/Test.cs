using UsefulStuff;
using System;
using static UsefulStuff.Menus;
using System.Collections.Generic;

namespace TestUsefulStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Menu menu = new Menu();
            MenuItem menuItem;

            menu.MenuItems = new List<MenuItem>();

            for (int i = 0; i < 12; ++i)
            {
                menuItem = new MenuItem();
                menuItem.Selected = false;
                menuItem.DisplayName = "File Directory" + (i + 1);
                menuItem.ID = i;
                menuItem.strVal = null;
                menuItem.numVal = random.Next(1, 11);

                menu.MenuItems.Add(menuItem);
            }

            menu.DispTableMenu(4);
        }
    }
}
