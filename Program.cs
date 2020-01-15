using System;

namespace Lab8
{
    class Program
    {
        static bool PrinterOk = true;
        static void Main(string[] args)
        {
           
            var printer = new Printer(100);
            printer.OutOfPaperEvent += OutOfPaperEventHandler2;
            for (int i =0;i <250;i++)
            {
               printer.Print(i);
                if (!PrinterOk)
                {
                    return;
                }
            }
            
          
        }
        static void OutOfPaperEventHandler2(object sender, EventArgs args)
        {
            Console.WriteLine($"Please refill paper!");
            PrinterOk = false;
        }
    }
}
