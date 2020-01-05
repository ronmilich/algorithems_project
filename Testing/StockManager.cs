using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class StockManager
    {
        private BST<XValue> _xBST;
        private QueueLinkedLists<YValue> _dataTimeList;

        public StockManager()
        {
            _xBST = new BST<XValue>();
            _dataTimeList = new QueueLinkedLists<YValue>();
        }

        // this function creates tree node of type XValue and return the XValue object of that node.
        // that creates a node of type YValue in his BSTYValues property. the XValue object creates calls to a function.
        // than it sets the initial number of boxes in the Count Property of the yValue.
        public void AddBox(double x, double y, int numberOfBoxes)
        {
            XValue xValue = _xBST.Add(new XValue(x));
            YValue yValue = xValue.BSTYValues.Add(new YValue(y));
            yValue.UpdateCount(numberOfBoxes);
            yValue.TimeDataNode = _dataTimeList.AddLast(ref yValue);
            yValue.XReferance = xValue;

            Console.WriteLine($"Box {xValue}/{yValue} ({yValue.Count} in stock) added successfully\n\n");
        }

        public void DisplayALLXVaules()
        {
            Console.WriteLine("Sizes of the boxes base(x value)");
            Console.WriteLine("--------------------------------");
            _xBST.PrintInOrder(Console.Write);
            Console.WriteLine("\n");
        }

        public void FindBox(double x, double y)
        {
            XValue xValue = (XValue)_xBST.Find(new XValue(x));

            if (xValue != null)
            {
                YValue yValue = (YValue)xValue.BSTYValues.Find(new YValue(y));
                if (yValue != null)
                    DisplayBoxDimentions(xValue, yValue);
                else
                    Console.WriteLine("Box dosen't exist");
            }
            else
            {
                Console.WriteLine("Box dosen't exist");
            }
        }

        public void FindBoxesWithXValue(double x)
        {
            XValue xValue = (XValue)_xBST.Find(new XValue(x));

            if (xValue != null)
            {
                Console.Write($"All Boxes with {xValue} base size: ");
                xValue.BSTYValues.PrintInOrder(Console.Write);
            }
            else
            {
                Console.WriteLine("Boxes dosen't exist");
            }
            
        }

        public void RemoveBox(double x, double y)
        {
            XValue xValue = (XValue)_xBST.Find(new XValue(x));

            if (xValue != null)
            {
                xValue.BSTYValues.Remove(new YValue(y));

                if (xValue.BSTYValues.CountLevels() == 0)
                    _xBST.Remove(xValue);
            }
            else
            {
                Console.WriteLine("Box dosen't exist");
            }

        }


        private void DisplayBoxDimentions(XValue x, YValue y)
        {
            Console.WriteLine($"X: {x} / Y: {y}\n{y.Count} in stock");
        }

        public string DisplayQueue()
        {
            return _dataTimeList.ToString();
        }


        public void FindClosestBox(double x, double y, int amount)
        {
            XValue xValue = _xBST.FindClosest(new XValue(x));

            if (xValue != null && xValue.XSize >= x && xValue.XSize <= x + 2)
            {
                YValue yValue = xValue.BSTYValues.FindClosest(new YValue(y));

                if (yValue != null && yValue.YSize >= y && yValue.YSize <= y + 2)
                {
                    if (yValue.Count <= amount)
                    {
                        _dataTimeList.Remove(ref yValue);
                        RemoveBox(xValue.XSize, yValue.YSize);
                        Console.WriteLine("Purchase have been made: All available boxes of the current dimensions were bought.");

                        if (xValue.BSTYValues.CountLevels() == 0)
                            _xBST.Remove(xValue);
                    }
                    else
                    {
                        yValue.Count = yValue.Count - amount;
                        _dataTimeList.Remove(ref yValue);
                        yValue.TimeDataNode = _dataTimeList.AddLast(ref yValue);
                        Console.WriteLine($"Purchase have been made: {amount} boxes of size {xValue.XSize}/{yValue.YSize}, {yValue.Count} boxes left.");
                    }
                }
                else
                {
                    Console.WriteLine("No suitable boxes in stock");
                }
            }
            else
            {
                Console.WriteLine("No suitable boxes in stock");
            }
        }

        public void RemoveOldData()
        {
            List<YValue> listOfYValues = _dataTimeList.RemoveOldData();

            foreach (var item in listOfYValues)
            {
                Console.WriteLine($"box ({item.XReferance.XSize}/{item.YSize}) didn't purchased for more than 20 seconds");
                RemoveBox(item.XReferance.XSize, item.YSize);
            }
        }
    }
}
