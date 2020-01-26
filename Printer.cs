using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    class Printer
    {
        public event EventHandler <OutOfPaperEventArgs> OutOfPaperEvent;
        public event EventHandler <OutOfInkEventArgs> OutOfInkEvent;
        private int _paperCount;
        private int _inkCount;
        Random a = new Random();
        public void Print(int pageNumber)
        {
            if (_paperCount == 0)
            {
                OutOfPaperEvent?.Invoke(this,
                new OutOfPaperEventArgs (pageNumber));
                return;
            }
               else
            {
                Console.WriteLine("Printing...");
                --_paperCount;

            }
            if (_inkCount < 0)
            {
                OutOfInkEvent?.Invoke(this,new OutOfInkEventArgs());
                return;
               
            }
            else
            {
                _inkCount -= a.Next(10);
            }
           
        }
        private void OutOfInkEventHandler (object sender, EventArgs args)
        {
            Console.WriteLine($"[Printer log] {DateTime.Now.ToShortDateString()}" + " " + $"{DateTime.Now.ToShortTimeString()} Out of ink" );
        }
        private void OutOfPaperEventHandler(object sender,EventArgs args)
        {
            Console.WriteLine($"[Printer log] {DateTime.Now.ToShortDateString()}" + " " + $"{DateTime.Now.ToShortTimeString()}  Out of paper");
        }
        public Printer (int paperCount) :this()
        {
            _paperCount = paperCount;
        }

        public Printer()
        {
            OutOfPaperEvent += OutOfPaperEventHandler;
        }
        public class OutOfPaperEventArgs :EventArgs
        {
            private object pageNumber;

            public OutOfPaperEventArgs(object pageNumber)
            {
                this.pageNumber = pageNumber;
            }

            public int PageNumber { get; set; }
        }
    }
}
