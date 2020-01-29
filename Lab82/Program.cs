using System;

namespace Lab82
{
    class Program
    {
        static bool PrinterOK = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Paper level in Printer:");
            int lv = Convert.ToInt32(Console.ReadLine());

            var printer = new Printer(lv);
            printer.OutOfPaperEvent += OutOfPaperEventHandler2;
            printer.OutOfInkEvent += OutOfInkEventHandler2;
            for (int i = 0; i < 50; i++)
            {
                printer.Print(i);
                if (!PrinterOK)
                {
                    return;
                }
            }
        }
        static void OutOfPaperEventHandler2(object sender, OutOfPaperEventArgs args)
        {
            Console.WriteLine($"Refill paper. Continue from page " + args.PNumber);
            PrinterOK = false;
        }

        static void OutOfInkEventHandler2(object sender, OutOfInkEventArgs args)
        {
            Console.WriteLine("Refill [" + args.Color + "] Ink");
            PrinterOK = false;
        }
    }
}