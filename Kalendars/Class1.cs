using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalendars
{
    internal class Class1
    {
        private DateTime date;
        private string activity;

        public Class1(DateTime date)
        {
            this.date = date;
        }

        public DateTime Date
        {
            get { return date; }
        }

        public string Activity
        {
            get { return activity; }
            set
            {
                activity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Activity)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
