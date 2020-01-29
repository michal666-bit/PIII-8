using System;
using System.Collections.Generic;
using System.Text;

namespace Lab82
{
    public class OutOfPaperEventArgs : EventArgs
    {
        public OutOfPaperEventArgs(int PNumber)
        {
            this.PNumber = PNumber;
        }

        public int PNumber { get; set; }
    }
}