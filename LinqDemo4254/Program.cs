using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo4254
{
    /// <summary>
    /// Должность
    /// </summary>
    class Job
    {
        // member или property ?
        //private int _id;
        //public int Id => _id;

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public int Salary { get; set; }        
    }


    /// <summary>
    /// Сотрудник
    /// </summary>
    class Employee
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public Job Job { get; set; }
    }

    /// <summary>
    /// База данных
    /// </summary>
    class Database
    {
        /// <summary>
        /// Должности
        /// </summary>
        public List<Job> Jobs { get; set; }

        /// <summary>
        /// Сотрудники
        /// </summary>
        public List<Employee> Employees { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Database()
        {
            Jobs = new List<Job>
            {
                new Job
                {
                    Id = 1,
                    Title = "Директор",
                    Salary = 100000
                },
                new Job
                {
                    Id = 2,
                    Title = "Бухгалтер",
                    Salary = 40000
                },
                new Job
                {
                    Id = 3,
                    Title = "Охранник",
                    Salary = 25000
                }
            };

            Employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Алексей", Job = Jobs[0]},
                new Employee { Id = 2, Name = "Светлана", Job = Jobs[1]},
                new Employee { Id = 3, Name = "Юлия", Job = Jobs[1]},
                new Employee { Id = 4, Name = "Денис", Job = Jobs[2]},
                new Employee { Id = 5, Name = "Марк", Job = Jobs[2]},
                new Employee { Id = 6, Name = "Василий", Job = Jobs[2]},
            };
        }
    }


    class Program
    {
        static bool IsBuhgalter(Employee e)
        {
            return e.Job.Id == 2;
        }

        static void Main(string[] args)
        {
            var db = new Database();


            // 1
            Console.WriteLine("Первое задание.");
            var min = db.Jobs.Min(e => e.Salary);
            var max = db.Jobs.Max(e => e.Salary);
            var avg = db.Jobs.Average(e => e.Salary);
            var sum = db.Jobs.Sum(e => e.Salary);
            Console.WriteLine($"Минимальная зарплата [{min}].");
            Console.WriteLine($"Максимальная зарплата [{max}].");
            Console.WriteLine($"Средняя зарплата [{avg}].");
            Console.WriteLine($"Полная зарплата [{sum}].");

            // 2
            Console.WriteLine("Второе задание.");
            Console.WriteLine("Список сотрудников:");
            foreach (var employee in db.Employees.GroupBy(e => e.Name).Select(e => new { Name = e.Key }))
            {
                Console.WriteLine($"{employee.Name};");
            }

            // 1. Вывести минимальную, максимальную, среднюю и итоговую зарплату на фирме (Min, Max, Average, Sum)
            // 2. Вывести всех сотрудников по алфавиту OrderBy(имя)
            // 3. Вывести трёх наиболее оплачиваемых сотрудников OrderByDescending(зарплата).Take(3)
            // 4. Вывести количество бухглатеров   Where(должность).Count(), Count(должность) 
            // 5. Проверить, есть ли на фирме директор?  Count(директор) > 0, Any(директор)            

            /*

            foreach (var d in db.Employees.GroupBy(x => x.Job).
                Select(x => new { JobTitle = x.Key.Title, Count = x.Count(), TotalSalary = x.Sum(y => y.Job.Salary) }).
                OrderBy(x => x.Count))
            {
                Console.WriteLine($"{d.JobTitle} : {d.Count} ({d.TotalSalary})");
            }*/

            /*
            foreach (var e in db.Employees.GroupBy(x => x.Name).Select(x => new { Name = x.Key, Count = x.Count() }))
            {
                Console.WriteLine($"{e.Name} {e.Count}");
            }*/
            if (Console.ReadKey(true).Key !== ConsoleKey.Escape) return;
        }
    }
}
