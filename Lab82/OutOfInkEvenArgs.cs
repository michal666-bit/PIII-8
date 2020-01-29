using System;
using System.Collections.Generic;
using System.Text;

namespace Lab82
{
    public class OutOfInkEventArgs : EventArgs
    {
        public OutOfInkEventArgs(string color)
        {
            Color = color;
        }
        public string Color { get; set; }
    }
}