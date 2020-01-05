using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class TimeDataNode<T>
    {
        public T YValue { get; set; }
        public DateTime Time { get; set; }
        public TimeDataNode<T> Previous { get; set; }
        public TimeDataNode<T> Next { get; set; }

        public TimeDataNode(T yValue)
        {
            YValue = yValue;
            Time = DateTime.Now;
        }

    }
}
