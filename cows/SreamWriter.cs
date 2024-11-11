
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        
            {
                Console.WriteLine($" Выбериеь пункт в меню");
                Console.WriteLine($"1)Угадай число");
                Console.WriteLine($"2) Быки и коровы");
                Console.WriteLine($"3) Рассчитай премию");
                Console.WriteLine($"4)Дежурства");
                Console.WriteLine($"0)Выход");
               
                var choice = Console.ReadLine();
                switch (choice)
                {
                   case "1":
                    var guessNumGame = new GuessNum();
                    guessNumGame.Play();
                    break;

                   case "2":
                    var bullCows = new BullCows();
                    bullCows.Play(); 
                    break;

                    case "3":            
                    var emplover = new Emplover();
                    emplover.GetBonusPay();
                    break;

                case "4":
                    var student  = new Student();
                    student.Play();
                    break;

                case "0":
                    return;
                    default:
                    Console.WriteLine("Неверно");
                    break;
                }
        }

        
    }
   
}

internal class Emplover
{
    public Emplover()
    {
    }

    internal void GetBonusPay()
    {
        throw new NotImplementedException();
    }
}

internal class BullCows
{
    public BullCows()
    {
    }

    internal void Play()
    {
        throw new NotImplementedException();
    }
}

internal class GuessNum
{
    public GuessNum()
    {
    }

    internal void Play()
    {
        throw new NotImplementedException();
    }
}

class GuessNumber
{
    public void Play()
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101);
        int attempts = 0;
        Console.WriteLine("угадайте число от 1 до 101");
        while (true)
        {
            attempts++;
            int userGuess = int.Parse(Console.ReadLine());
            if (userGuess < secretNumber)
            {
                Console.WriteLine("больше!");
            }

            else if (userGuess > secretNumber)
            {
                Console.WriteLine("меньше");
                break;
            }
            if (attempts <= 3)
                Console.WriteLine("Вы молодец! Угадали за {0} попыток", attempts);
            else if (attempts <= 5)
            {
                Console.WriteLine("Хорошо!.Угадали {0} попыток", attempts);
            }
            else
            {
                Console.WriteLine("Пропробуйте еще раз. Угадали {0} попыток", attempts);
            }
        }

    }
    class BullCows
    {
        public void Play()
        {
            Random random = new Random();
            string secretNumber = GeneratNumber(random);
            int attempts = 0;
            Console.ReadLine();
            Console.WriteLine("Угадайте четырех значное число");
            while (true)
            {
                attempts++;
                string userGuess = Console.ReadLine();
                if (userGuess.Length != 4 || !Unique(userGuess))
                {
                    Console.WriteLine("Введите ");
                    continue;
                }
                int bulls = GetBulls(secretNumber, userGuess);
                int cows = GetCows(secretNumber, userGuess) - bulls;
                if (bulls == 4)
                {
                    Console.WriteLine("вы {0} {1}", secretNumber, attempts);
                    break;

                }
                Console.WriteLine("{0} быков, {1} коров", bulls, cows);
            }
            if (attempts >= 7)
            {
                Console.WriteLine("вы хороши в этой игре");
            }
            else
            {
                Console.WriteLine("вам нужно тренироваться");

            }

        }

        private string GeneratNumber(Random random)
        {
            throw new NotImplementedException();
        }

        private string GeneratNum(Random random)
        {
            HashSet<int> digits = new HashSet<int>();
            string num = "";
            while (num.Length < 4)
            {
                int digit = random.Next(0, 10);
                if (digits.Add(digit))
                { num += digit.ToString(); }

            }
            return num;

        }
        private bool Unique(string num)
        {
            HashSet<char> digits = new HashSet<char>();
            foreach (var digit in num)
            {
                if (!digits.Add(digit)) ;



            }
            return true;
        }
        private int GetBulls(string secret, string guess)
        {
            int bulls = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                    bulls++;
            }
            return bulls;
        }
        private int GetCows(string secret, string guess)
        {
            int cows = 0;
            foreach (var digit in guess)
            {
                int bulls = 0;
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == guess[i])
                    {
                        bulls++;
                    }

                }
            }
            return cows;
        }
        private int GetBull(string secret, string guess)
        {
            int bull = 0;
            foreach (var digit in guess)
            {
                if (secret.Contains(digit))
                    bull++;

            }

            return bull;
        }

    }


    class Emplover
    {
        public void GetBonus()
        {
            Console.Write("Введите фамилию ");
            string lastname = Console.ReadLine();

            Console.WriteLine("Ведите стаж");
            int exper = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите почасовую оплпату");
            int hour = int.Parse(Console.ReadLine());

            Console.WriteLine("Ведите колво отработанных часов");
            int worked = int.Parse(Console.ReadLine());

            double bonus = Calculat(exper, hour, worked);
            Console.WriteLine($"premia{lastname}:{bonus}");
        }
        private double Calculat(int exper, double hour, double worked)
        {
            double salary = hour * worked;
            if (exper > 5)
                return salary * 0.2;//20%
            else
                return salary * 0.1;//10

        }
    }
    class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DutuCount { get; set; }
        public Student(string firstName, string lastName)

        {
            Name = firstName;
            LastName = lastName;
            DutuCount = 0;
        }
    }
    class StudentDuty
    {
        private List<Student> students;
        public StudentDuty()
        {
            students = LoadStudent();
        }
        public void Manage()
        {
            Console.WriteLine("enter last name student");
            var input = Console.ReadLine().Split(',');
            foreach (var name in input)
            {
                var student = students.Find(s => s.Name.Trim() == name.Trim() || s.LastName.Trim() == name.Trim());
                if (student != null)
                {
                    student.DutuCount++;
                    Console.WriteLine($"{student.Name} {student.LastName} {student.DutuCount}");
                }
                else
                {
                    Console.WriteLine($"student{name.Trim()} not found");

                }
            }
            SaveStudentToFile();
        }
        private List<Student> LoadStudent()
        {
            var students = new List<Student>();
            if (File.Exists("students.txt"))
            {
                var lines = File.ReadAllLines("students.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    students.Add(new Student(parts[0], parts[1]) { DutuCount = int.Parse(parts[2]) });
                }
            }
            return students;
        }
        private void SaveStudentToFile()
        {
            using (var fs = File.Create("students.txt"))
          using(var writer = new StreamWriter(fs))
            {
                foreach(var student in students)
                {
                    writer.WriteLine($"{student.Name} {student.LastName}{student.DutuCount}");
                }
            }
        }
    }
}


