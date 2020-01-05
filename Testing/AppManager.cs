using System;

namespace Testing
{
    class AppManager
    {
        private StockManager _stockManager;

        private bool _appIsRunning;

        public AppManager()
        {
            _appIsRunning = true;
            _stockManager = new StockManager();
            GenerateStock(3);
        }

        public void RunApp() => DisplayOptions();

        private void DisplayOptions()
        {
            while (_appIsRunning)
            {
                Console.WriteLine("Choose One of the options below:");
                Console.WriteLine("--------------------------------");
                Console.WriteLine(
                    "1 - Add box to stock\n" +
                    "2 - Display all boxes base sizes\n" +
                    "3 - Display all height values of boxes with a specific base size\n" +
                    "4 - Find specific box\n" +
                    "5 - Make a purchase\n" +
                    "6 - Clear Display\n" +
                    "7 - Exit application");

                int optoins = int.Parse(Console.ReadLine());

                switch (optoins)
                {
                    case 1:
                        AddBox();
                        break;
                    case 2:
                        DisplayALLXVaules();
                        break;
                    case 3:
                        FindBoxesWithXValue();
                        break;
                    case 4:
                        FindBox();
                        break;
                    case 5:
                        Purchase();
                        break;
                    case 6:
                        ClearDisplay();
                        break;
                    case 7:
                        ExitApp();
                        break;
                    default:
                        Console.WriteLine("The number you chose didn't exist in the options.");
                        break;
                }
            }
        }

        private void ExitApp() => _appIsRunning = false;

        private void DisplayALLXVaules() => _stockManager.DisplayALLXVaules();

        private void ClearDisplay() => Console.Clear();

        private void AddBox()
        {
            Console.Write("\nEnter the base size of the box: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter the height size of the box: ");
            double y = double.Parse(Console.ReadLine());
            Console.Write("Enter box amount: ");
            int numberOfBoxes = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            _stockManager.AddBox(x, y, numberOfBoxes);
            Console.WriteLine("\n");
        }

        private void FindBox()
        {
            Console.Write("\nEnter the base size of the box: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter the height size of the box: ");
            double y = double.Parse(Console.ReadLine());
            _stockManager.FindBox(x, y);
        }

        private void FindBoxesWithXValue()
        {
            Console.Write("Enter the base size of the box: ");
            double x = double.Parse(Console.ReadLine());

            _stockManager.FindBoxesWithXValue(x);
        }

        private void Purchase()
        {
            Console.Write("\nEnter the base size of the box: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter the height size of the box: ");
            double y = double.Parse(Console.ReadLine());
            Console.Write("Enter box amount: ");
            int numberOfBoxes = int.Parse(Console.ReadLine());
            _stockManager.FindClosestBox(x , y, numberOfBoxes);
            Console.WriteLine("");
            _stockManager.RemoveOldData();
        }

        private void GenerateStock(int numberOfTrees)
        {
            for (int i = 0; i < numberOfTrees; i++)
            {
                GenerateTree();
            }
        }

        private void GenerateTree()
        {
            Random x = new Random();
            Random y = new Random();
            Random amount = new Random();
            int currentX = x.Next(1, 100);

            for (int i = 0; i < 10; i++)
                _stockManager.AddBox(currentX, y.Next(1, 50), amount.Next(1, 50));
        }
    }
    
}
