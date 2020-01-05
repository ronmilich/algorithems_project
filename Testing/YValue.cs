using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class YValue : IComparable<YValue>
    {
        private const int MAX_COUNT = 50;

        public XValue XReferance { get; set; }
        public double YSize { get; set; }
        public TimeDataNode<YValue> TimeDataNode { get; set; }
        public int Count { get; set; }

        public YValue(double y)
        {
            YSize = y;
        }

        public void UpdateCount(int num)
        {
            if(num > MAX_COUNT)
            {
                Count = MAX_COUNT;
                Console.WriteLine($"{num} is bigger than the maximum amount of boxes in stock ({MAX_COUNT}).\n" +
                    $"Numbers of boxes is set to {Count}. {num - MAX_COUNT} boxes returned.");
            }
            else
            {
                Count = num;
            }
        }

        public override string ToString()
        {
            return YSize.ToString();
        }

        public int CompareTo(YValue that)
        {
            return this.YSize.CompareTo(that.YSize);
        }
    }
}
