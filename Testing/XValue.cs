using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class XValue : IComparable<XValue>
    {
        public double XSize { get; set; }
        public BST<YValue> BSTYValues { get; set; }

        public XValue(double x)
        {
            XSize = x;
            BSTYValues = new BST<YValue>();
        }

        public void ShowYValues()
        {
            BSTYValues.PrintInOrder(Console.Write);
        }

        public int CompareTo(XValue that)
        {
            return this.XSize.CompareTo(that.XSize);
        }

        public override string ToString()
        {
            return XSize.ToString();
        }
    }
}
