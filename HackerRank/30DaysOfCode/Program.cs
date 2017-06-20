using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _30DaysOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day2();
            //Day4();
            //Day5();
            //Day6();
            //Day10_BinaryNumbers();
            //Day11_2DArrays();
            //Day12_Inheritance();
            //Day13_AbstractClasses();
            //Day18_QueuesAndStacks();
            Day25_Running_Time_Complexity();
            Console.ReadKey();
        }

        private static void Day25_Running_Time_Complexity()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] input = new int[n];
            for (int i = 0; i < n; i++)
            {
                input[i] = Convert.ToInt32(Console.ReadLine());
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < n; i++)
            {
                bool prime = true;

                for (int j = 2; j * j <= input[i]; j++)
                {
                    if (input[i] % j == 0)
                    {
                        prime = false;
                        break;
                    }
                }

                if (input[i] == 1) prime = false;
                Console.WriteLine(prime ? "Prime" : "Not prime");
            }
            stopWatch.Stop();
            Console.WriteLine("Time: " + stopWatch.Elapsed.TotalMilliseconds);
        }

        private static void Day18_QueuesAndStacks()
        {

        }

        private static void Day13_AbstractClasses()
        {
            String title = Console.ReadLine();
            String author = Console.ReadLine();
            int price = Int32.Parse(Console.ReadLine());
            Book new_novel = new MyBook(title, author, price);
            new_novel.display();
        }

        private static void Day12_Inheritance()
        {
            string[] inputs = Console.ReadLine().Split();
            string firstName = inputs[0];
            string lastName = inputs[1];
            int id = Convert.ToInt32(inputs[2]);
            int numScores = Convert.ToInt32(Console.ReadLine());
            inputs = Console.ReadLine().Split();
            int[] scores = new int[numScores];
            for (int i = 0; i < numScores; i++)
            {
                scores[i] = Convert.ToInt32(inputs[i]);
            }

            Student s = new Student(firstName, lastName, id, scores);
            s.printPerson();
            Console.WriteLine("Grade: " + s.Calculate() + "\n");
        }

        private static void Day11_2DArrays()
        {
            int[][] arr = new int[6][];//array of arrays
            for (int arr_i = 0; arr_i < 6; arr_i++)
            {
                string[] arr_temp = Console.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }

            int maxSum = Int32.MinValue;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {

                    int sum = 0;
                    for (int m = i; m <= i + 2; m++)
                    {
                        for (int n = j; n <= j + 2; n++)
                        {
                            sum += arr[m][n];
                        }
                    }
                    sum = (sum - arr[i + 1][j] - arr[i + 1][j + 2]);

                    if (sum > maxSum)
                        maxSum = sum;
                }
            }

            Console.WriteLine(maxSum);
        }

        private static void Day10_BinaryNumbers()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            //string binary = Convert.ToString(n, 2);

            string binary = ConvertToBase(n, 2);
            Console.WriteLine(FindMaxConsecutives(binary));
        }

        private static int FindMaxConsecutives(string binary)
        {
            int max = 1, counter;

            if (binary.Length > 0)
            {
                for (int i = 0; i < binary.Length; i++)
                {
                    counter = 1;
                    char hold = binary[i];
                    for (int j = i + 1; j < binary.Length; j++)
                    {
                        char next = binary[j];
                        if (hold == next)
                            counter++;
                        else
                            break;
                    }

                    if (counter > max)
                        max = counter;
                }
            }
            else return 0;

            return max;
        }

        private static string ConvertToBase(int n, int toBase)
        {
            int remainder;
            string result = String.Empty;
            while (n > 0)
            {
                remainder = n % toBase;
                n /= toBase;
                result = remainder.ToString() + result;
            }
            return result;
        }

        private static void Day6()
        {
            int n = Int32.Parse(Console.ReadLine());
            string[] input = new string[n];
            for (int i = 0; i < n; i++)
            {
                input[i] = Console.ReadLine();
            }

            string even = String.Empty, odd = String.Empty;
            for (int j = 0; j < n; j++)
            {
                even = odd = String.Empty;
                for (int k = 0; k < input[j].Length; k++)
                {
                    if (k % 2 == 0)
                    {
                        even += input[j][k];
                    }
                    else
                    {
                        odd += input[j][k];
                    }
                }
                Console.WriteLine(even + " " + odd);
            }
        }

        private static void Day2()
        {
            double price = Convert.ToDouble(Console.ReadLine());
            int tip = Convert.ToInt32(Console.ReadLine());
            int tax = Convert.ToInt32(Console.ReadLine());

            Meal meal = new Meal(price, tip, tax);

            Console.WriteLine(meal.GetTotalCost());
        }

        private static void Day4()
        {
            int T = int.Parse(Console.In.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int age = int.Parse(Console.In.ReadLine());
                Personn p = new Personn(age);
                p.AmIOld();
                for (int j = 0; j < 3; j++)
                {
                    p.YearPasses();
                }
                p.AmIOld();
                Console.WriteLine();
            }
        }

        private static void Day5()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(String.Format("{0} x {1} = {2}", n, i, n * i));
            }
        }

        public class Meal
        {
            public double MealPrice { get; set; }
            public int TipPercent { get; set; }
            public int TaxPercent { get; set; }
            public double TotalCost { get; set; }

            public Meal(double price, int tip, int tax)
            {
                MealPrice = price;
                TipPercent = tip;
                TaxPercent = tax;
                CalculateTotalCost();
            }

            public void CalculateTotalCost()
            {
                TotalCost = MealPrice + (MealPrice * TipPercent / 100) + (MealPrice * TaxPercent / 100);
            }

            public string GetTotalCost()
            {
                return String.Format("The total meal cost is {0} dollars.", (int)Math.Round(TotalCost));
            }
        }

        public class Personn
        {
            public int Age { get; set; }

            public Personn(int initialAge)
            {
                if (initialAge < 0)
                {
                    Console.WriteLine("Age is not valid, setting age to 0.");
                    Age = 0;
                }
                else
                    Age = initialAge;
            }

            public void YearPasses()
            {
                Age++;
            }

            public void AmIOld()
            {
                if (Age < 13)
                    Console.WriteLine("You are young.");
                else if (Age >= 13 && Age < 18)
                    Console.WriteLine("You are teenager.");
                else
                    Console.WriteLine("You are old.");
            }
        }

        public class Person
        {
            protected string firstName;
            protected string lastName;
            protected int id;

            public Person() { }
            public Person(string firstName, string lastName, int identification)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.id = identification;
            }
            public void printPerson()
            {
                Console.WriteLine("Name: " + lastName + ", " + firstName + "\nID: " + id);
            }
        }

        class Student : Person
        {
            private int[] testScores;

            /*	
            *   Class Constructor
            *   
            *   Parameters: 
            *   firstName - A string denoting the Person's first name.
            *   lastName - A string denoting the Person's last name.
            *   id - An integer denoting the Person's ID number.
            *   scores - An array of integers denoting the Person's test scores.
            */
            // Write your constructor here
            public Student(string firstName, string lastName, int id, int[] scores) : base(firstName, lastName, id)
            {
                this.testScores = scores;
            }
            /*	
            *   Method Name: Calculate
            *   Return: A character denoting the grade.
            */
            // Write your method here
            public char Calculate()
            {
                decimal avg = 0, sum = 0;
                char grade = '\0';

                for (int i = 0; i < testScores.Length; i++)
                {
                    sum += testScores[i];
                }

                avg = (decimal)sum / testScores.Length;

                if (avg < 40)
                    grade = 'T';
                else if (40 <= avg && avg < 55)
                    grade = 'D';
                else if (55 <= avg && avg < 70)
                    grade = 'P';
                else if (70 <= avg && avg < 80)
                    grade = 'A';
                else if (80 <= avg && avg < 90)
                    grade = 'E';
                else if (90 <= avg && avg <= 100)
                    grade = 'O';

                return grade;
            }
        }

        abstract class Book
        {

            protected String title;
            protected String author;

            public Book(String t, String a)
            {
                title = t;
                author = a;
            }
            public abstract void display();
        }

        class MyBook : Book
        {
            private int price;

            public MyBook(string title, string author, int price) : base(title, author)
            {
                this.price = price;
            }

            public override void display()
            {
                Console.WriteLine($"Title: {title}\nAuthor: {author}\nPrice: {price}");
            }
        }
    }
}
