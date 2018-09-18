using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    class Program
    {
        //T1 delegate that receives and returns a valid number
        public delegate double Number(double x);

        //T1 create Tabulation method
        public static void Tabulation(Number del, double a, double b, int n)
        {
            for (int k = 0; k <= n; k++)
            {
                double x = a + k * (b - a) / n;
                Console.WriteLine($"{x} {del(x)}");
            }
        }

        public static double Sin(double x)
        {
            return Math.Sin(x);
        }

        public static double Function(double x)
        {
            return 2 * Math.Pow(x, 2) + 3 * x * Math.Cos(Math.Pow(x, 3));
        }        

        static void Main(string[] args)
        {
            //T1 call the tabulation method for the function tab
            Number del = Sin;

            Tabulation(del, 1.25, 3, 6);
            Console.WriteLine("----------------");

            Number delSin = Function;
            Tabulation(delSin, 1.25, 3, 6);
            Console.WriteLine("----------------");

            //T2 call methods and output
            Student student = new Student();
            Parent parent = new Parent();
            AccountingDepartment reject = new AccountingDepartment();

            student.MarkChange += new MyDel(parent.OnMarkChange);
            student.MarkChange += new MyDel(reject.ScholarshipPayment);
            student.AddMark(5);
            student.AddMark(3);
            student.AddMark(3);
                       
            Console.ReadKey();
        }
    }
    //T2 create delegate void MyDel (int m)
    public delegate void MyDel(int m);

    //T2 create class Student
    public class Student
    {
        //T2 create fields name and marks (such as list <int>)
        public string name = "Anonymous";
        public List<int> marks = new List<int>();

        //T2 create event MarkChange
        public event MyDel MarkChange;

        //T2 create method AddMark
        public void AddMark(int i)
        {
            marks.Add(i);

            if (MarkChange != null)
            {
                MarkChange(i);
            }
        }
    }
    //T2 create class Parent with the OnMarkChange method
    public class Parent
    {
        public void OnMarkChange(int e)
        {
            Console.WriteLine("New mark is " + e);
        }
    }

    //T2 create class AccountingDepartment with the ScholarshipPayment method
    public class AccountingDepartment
    {
        public string studentName = "Anonymous";
        public List<int> studentMarks = new List<int>();

        public void ScholarshipPayment(int i)
        {
            studentMarks.Add(i);
            if (studentMarks.Average() >= 4d)
            {
                Console.WriteLine("Scholarship is approved.");
            }
            else
            {
                Console.WriteLine("Scholarship rejected.");
            }
        }
    }
}
