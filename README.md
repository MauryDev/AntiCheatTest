# AntiCheatTest

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void OnCheatDetected()
        {
            Console.WriteLine("Cheat Detected");
            for (int i = 0; i < 10; i++)
            {
                Console.Beep();
                System.Threading.Thread.Sleep(100);
            }
            Environment.Exit(0);

        }
        static void Main(string[] args)
        {
            ObscuredInt c = 65432;
            ObscuredInt c2 = 65432;

            Console.WriteLine(c2.Value);
            ObscuredInt.OnCheatDetected(new Action(OnCheatDetected));
            while (true)
            {
                Console.WriteLine("Aumentado");

                Console.ReadLine();
                c++;
                c2++;
                c.IsValidChanged();
                c2.IsValidChanged();
            }

        }
    }
}

```
