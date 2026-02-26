
namespace DevMetrics.Application.Practice
{
    public class Delegates
    {
        // 1. Define the delegate type (the button shape)
        public delegate void GreetDelegate(string name);

        // 2. A method that matches the delegate signature
        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        public void SayHi(string name)
        {
            Console.WriteLine($"Hi there, {name}!");
        }

        // 3. Use it
        public void Run()
        {
            GreetDelegate greet = SayHello;
            greet("John");

            greet = SayHi;
            greet("John");
        }

        public delegate int MathOperation(int a, int b);

        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;

        public int Calculate(int a, int b, MathOperation operation)
        {
            return operation(a, b);
        }

        // Usage
        public void UsageExamples()
        {
            int result1 = Calculate(10, 5, Add);       // 15
            int result2 = Calculate(10, 5, Subtract);  // 5
            int result3 = Calculate(10, 5, Multiply);  // 50

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
        }

        public delegate void Notify(string message);

        public void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }

        public void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }

        public void LogToFile(string message)
        {
            Console.WriteLine($"Logged: {message}");
        }

        private Notify notify;

        public Delegates()
        {
            notify = SendEmail;
            notify += SendSMS;
            notify += LogToFile;
        }

        public delegate bool FilterDelegate(int number);

        public List<int> FilterNumbers(List<int> numbers, FilterDelegate filter)
        {
            List<int> result = new List<int>();
            foreach (int number in numbers)
            {
                if (filter(number))
                    result.Add(number);
            }

            return result ?? new List<int>();
        }


        public bool IsEven(int number) => number % 2 == 0;
        public bool IsGreaterThanTen(int number) => number > 10;

        private List<int> numbers = new List<int> { 1, 4, 7, 12, 18, 3, 15 };

        public List<int> EvenNumbers => FilterNumbers(numbers, IsEven);
        public List<int> BigNumbers => FilterNumbers(numbers, IsGreaterThanTen);

    }

    public class Delegate2
    {
        public delegate string FormatDelegate(string text);

        public string MakeUpperCase(string text) => text.ToUpper();
        public string MakeLowerCase(string text) => text.ToLower();
        public string AddExclamation(string text) => text + "!";

        public string FormatMessage(string text, FormatDelegate formatter)
        {
            return formatter(text);
        }

        public void UsageExamples()
        {
            string result1 = FormatMessage("hello world", MakeUpperCase);
            string result2 = FormatMessage("HELLO WORLD", MakeLowerCase);
            string result3 = FormatMessage("hello world", AddExclamation);

            Console.WriteLine(result1);  // HELLO WORLD
            Console.WriteLine(result2);  // hello world
            Console.WriteLine(result3);  // hello world!
        }




    }

    public class Delegate3
    {
        public delegate double DoubleDelegate(double number);

        List<double> prices = new List<double> { 10.0, 25.0, 50.0, 100.0, 200.0 };

        public double TenPercent(double price) => price - (price * 0.10);
        public double FiftyPercent(double price) => price - (price * 0.50);

        public List<double> DoubleMethod(List<double> numbers, DoubleDelegate delegatehandler)
        {
            var list = new List<double>();
            foreach (var num in numbers)
            {
                list.Add(delegatehandler(num));
            }
            return list;
        }

        public void Usage()
        {
            List<double> tenPercentResult = DoubleMethod(prices, TenPercent);
            List<double> fiftyPercentResult = DoubleMethod(prices, FiftyPercent);

            foreach (var price in tenPercentResult)
                Console.WriteLine(price);
            foreach (var price in fiftyPercentResult)
                Console.WriteLine(price);
        }


    }

    public class GenericDelegates
    {
        //making use of Action<data type>, func<> and Predicate
        public delegate void PrintDelegate(string message);
        //new way
        public void UsageExamples()
        {
            Action<string, int> printAge = (name, age) =>
                Console.WriteLine($"{name} is {age} years old");

            printAge("John", 25);  // John is 25 years old
        }
    }
}