using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MiaLukashyk_Lab03
{
    internal class Program
    {
        static int days_in_month(int month)
        {
            if(month >= 0 && month <= 12)
            {
                switch (month)
                {
                    case 2:
                        return 28;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        return 30;
                    default:
                        return 31;
                }
            }
            throw new ArgumentException("Invalid month");
        }

        public class Person
        {
            private string name;
            private DateTime birthDate;
            public string Name 
            { 
                get 
                { 
                    return name; 
                }
            }
            public DateTime BirthDate
            {
                get
                {
                    return birthDate;
                }
            }
            public Person(string name, DateTime birthDate)
            {
                this.name = name;
                this.birthDate = birthDate;
            }
            public Person() : this("Mia", new DateTime(2006, 3, 9))
            {
            }
            public int Age()
            {
                return DateTime.Now.Year - birthDate.Year;
            }
            public void Input()
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                Console.Write("Enter birth date: ");
                while(!DateTime.TryParse(Console.ReadLine(), out this.birthDate))
                {
                    Console.WriteLine("Try again: ");
                }
            }
            public override string ToString()
            {
                return $"{Name}, {birthDate}";
            }
            public void Output()
            {
                Console.WriteLine(this);
            }
            static public bool operator==(Person a, Person b)
            {
                return a.Name == b.Name;
            }
            static public bool operator!=(Person a, Person b)
            {
                return a.Name != b.Name;
            }
            public void ChangeName(string newName)
            {
                name = newName;
            }
        }

        static void Main(string[] args)
        {
            //Console.Write("Enter your text: ");
            //string text = Console.ReadLine();
            //int a_counter = 0;
            //int o_counter = 0;
            //int i_counter = 0;
            //int e_counter = 0;
            //foreach(char symbol in text)
            //{
            //    if (symbol == 'a')
            //    {
            //        ++a_counter;
            //    }
            //    else if (symbol == 'o')
            //    {
            //        ++o_counter;
            //    }
            //    else if (symbol == 'i')
            //    {
            //        ++i_counter;
            //    }
            //    else if (symbol == 'e')
            //    {
            //        ++e_counter;
            //    }
            //}
            //Console.WriteLine($"a: {a_counter}; o: {o_counter}; i: {i_counter}; e: {e_counter}");

            //int month;
            //Console.Write("Enter month: ");
            //while(!int.TryParse(Console.ReadLine(), out month))
            //{
            //    Console.WriteLine("Invalid month try again: ");
            //}
            //Console.WriteLine(days_in_month(month));

            //int[] arr = new int[10];
            //for(int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write("Enter value: ");
            //    while(!int.TryParse(Console.ReadLine(), out arr[i]))
            //    {
            //        Console.WriteLine("Invalid number");
            //    }
            //}
            //bool compute_sum = true;
            //for(int i = 0; i < arr.Length / 2; i++)
            //{
            //    if (arr[i] < 0)
            //    {
            //        compute_sum = false;
            //        break;
            //    }
            //}
            //if(compute_sum)
            //{
            //    int sum = 0;
            //    for (int i = 0; i < arr.Length / 2; i++)
            //    {
            //        sum += arr[i];
            //    }
            //    Console.WriteLine(sum);
            //}
            //else
            //{
            //    int mult = 1;
            //    for (int i = arr.Length / 2; i < arr.Length; i++)
            //    {
            //        mult *= arr[i];
            //    }
            //    Console.WriteLine(mult);
            //}

            Person[] classroom = new Person[6];
            for(int i = 0; i < classroom.Length; ++i)
            {
                classroom[i] = new Person();
            }
            foreach(Person p in classroom)
            {
                Console.Write(p + " ");
                Console.WriteLine(p.Age());
            }
            foreach(Person person in classroom)
            {
                person.Input();
            }
            foreach (Person p in classroom)
            {
                if(p.Age() < 16)
                {
                    p.ChangeName("very young");
                }
            }
            foreach (Person p in classroom)
            {
                Console.WriteLine(p);
            }
            for (int i = 0; i < classroom.Length; i++)
            {
                bool printFirst = false;
                for(int j = i + 1; j < classroom.Length; j++)
                {
                    if (classroom[i] == classroom[j])
                    {
                        if(!printFirst)
                        {
                            Console.WriteLine(classroom[i]);
                        }
                        Console.WriteLine(classroom[j]);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
