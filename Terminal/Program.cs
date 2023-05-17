using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Terminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int balance = 299;
            //string username;
            getdata();
            //Console.SetWindowSize(100,25);
            var banknotes = new Dictionary<int, int>
            {
                [100] = 20,
                [50] = 15,
                [20] = 10,
                [10] = 5
            };
            Console.Write("Введите сумму: ");
            var amount = int.Parse(Console.ReadLine());
            var toIssue = new Dictionary<int, int>();
            var left = amount;
            foreach (var nominal in banknotes.Keys.OrderByDescending(x => x))
            {
                var count = Math.Min(left / nominal, banknotes[nominal]);
                toIssue[nominal] = count;
                left -= count * nominal;
            }
            if (left <= 0)
            {
                Console.WriteLine("Невозможно выдать введенную сумму!");
            }
            else
            {
                Console.WriteLine("Выдаем:");
                foreach (var nominal in toIssue.Keys.OrderByDescending(x => x))
                {
                    Console.WriteLine($"Купюр номиналом {nominal} — {toIssue[nominal]} штук");
                    banknotes[nominal] -= toIssue[nominal];
                }
            }
        }

        static void getdata()
        {
                DateTime dateTime = DateTime.Now;
                Console.SetCursorPosition(85, 21);
                Console.WriteLine(dateTime.ToLongDateString());
                 Console.SetCursorPosition(87, 22);
                 Console.WriteLine(dateTime.ToLongTimeString());
                 Console.SetCursorPosition(87, 23);
                Console.WriteLine(dateTime.DayOfWeek);
                Console.SetCursorPosition(0, 0);            
        }
    }
}
