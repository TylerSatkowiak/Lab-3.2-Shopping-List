using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
namespace Lab_3._2_Shopping_List
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, decimal> items = new Dictionary<string, decimal>();
            items["apple"] = 5.00M;
            items["banana"] = .90M;
            items["avacado"] = 1.59M;
            items["cauliflower"] = .99M;
            items["raspberries"] = 2.00M;
            items["lettuce"] = 1.09M; 
            items["spinach"] = .99M;
            items["kale"] = .99M;
            items["strawberries"] = 1.29M;
            
            ArrayList Cart = new ArrayList();
            ArrayList Prices = new ArrayList();
            bool isValid = true;
            decimal total = 0;

            Console.WriteLine(String.Format("{0,15} {1,15}", "Item", "Price"));
            Console.WriteLine(String.Format("{0,15} {1,15}", "=====", "====="));
            foreach (var key in items.Keys)
            {
                Console.WriteLine(String.Format("{0,15} {1,15}", key, items[key]));
            }

            while (isValid)
            {
                Console.WriteLine("Which item would you like to add to your cart?");
                string entry = Console.ReadLine().ToLower();

                if (items.ContainsKey(entry))
                {
                    Cart.Insert(0, entry);
                    Prices.Insert(0, items[entry]);
                    Console.WriteLine($"Succesfully added {entry} to your cart.");

                    Console.WriteLine("View your cart below:");
                    for (int i = 0; i < Cart.Count; i++)
                    {
                        Console.WriteLine(Cart[i]);
                        Console.WriteLine(Prices[i]);
                    }
                    Console.WriteLine($"You have {Cart.Count} item(s) in your cart");
                    Console.WriteLine("Would you like to add more or proceed to checkout (1/2)?");
                    string checkout = Console.ReadLine().ToLower();
                    if (checkout != "1" && checkout != "2")
                    {
                        Console.WriteLine("Sorry, please try inputting again.");
                        continue;
                    }

                    else if(checkout == "1")
                    {
                        Console.WriteLine(String.Format("{0,15} {1,15}", "Item", "Price"));
                        Console.WriteLine(String.Format("{0,15} {1,15}", "=====", "====="));
                        foreach (var key in items.Keys)
                        {
                            Console.WriteLine(String.Format("{0,15} {1,15}", key, items[key]));
                        }
                    }
                    else if (checkout == "2")
                    {
                        Console.WriteLine("Thanks for your order! Here is your completed cart.");
                        Console.WriteLine(String.Format("{0,15} {1,15}", "Item", "Price"));
                        for (int i = 0; i < Cart.Count; i++)
                        {
                            Console.WriteLine(String.Format("{0,15} {1,15}", Cart[i], Prices[i]));
                            total = total + (decimal)Prices[i];
                        }
                        Console.WriteLine($"Here is your total: {total}");
                        Console.WriteLine($"Here is the average of all items in your cart: {total / Prices.Count}");
                        break;
                    }
                }
                else if(!items.ContainsKey(entry))
                {
                    Console.WriteLine("Sorry, please try inputting again.");
                } 
                else
                {
                    isValid = false;
                }
            }
        }
    }
}
