using System;
using System.Collections.Generic;
using System.Text;

namespace Lab82
{
    public class Printer
    {
        public event EventHandler<OutOfPaperEventArgs> OutOfPaperEvent;
        public event EventHandler<OutOfInkEventArgs> OutOfInkEvent;

        private List<Ink> _inks;

        private int _paperCount;
        // private int _inkCount;

        Random a = new Random();
        //private Random a;
        public void Print(int PNumber)
        {
            if (_paperCount == 0)
            {
                OutOfPaperEvent?.Invoke(this, new OutOfPaperEventArgs(PNumber));
                return;
            }
            else
            {
                foreach (var ink in _inks)
                {
                    if (ink.Level <= 0)
                    {
                        OutOfInkEvent.Invoke(this, new OutOfInkEventArgs(ink.Color));
                    }
                }
                Console.WriteLine("Printing...");
                --_paperCount;

                foreach (var ink in _inks)
                {
                    ink.Level -= a.Next(10);
                }
            }

            /* if (_inkCount < 0)
              {
                  OutOfInkEvent?.Invoke(this, new OutOfInkEventArgs());
                  return;
              }
              else
              {
                  _inkCount -= a.Next(10);
              }*/
        }

        private void OutOfPaperEventHandler(object sender, OutOfPaperEventArgs args)
        {
            Console.WriteLine($"[Printer Log] {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} Out of Paper");
        }

        private void OutOfInkEventHandler(object sender, OutOfInkEventArgs args)
        {
            Console.WriteLine($"[Printer Log] {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} Out of [" + args.Color + "] Ink");
        }

        public Printer(int paperCount) : this()
        {
            _paperCount = paperCount;
        }

        private Printer()
        {
            int inkLV = 200;

            OutOfPaperEvent += OutOfPaperEventHandler;
            OutOfInkEvent += OutOfInkEventHandler;
            _inks = new List<Ink>()
            {
                new Ink("Black",inkLV),
                new Ink("Cyan",inkLV),
                new Ink("Magenta",inkLV),
                new Ink("Yellow",inkLV)
            };
        }
    }
}

