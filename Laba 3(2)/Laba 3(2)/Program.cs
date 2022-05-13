using System;
using System.Collections.Generic;

// 25 Варіант

namespace laba
{
    class Perevisnuk
    {
        public int maxweight { get; set; }  // створюємо гетери і сетери для полів базового класу
        public string name { get; set; }
        public int capacity { get; set; }
        public int year { get; set; }
        public int fuel { get; set; }
    }

    class Sydno1 : Perevisnuk { } // створюємо класи-спадкоємців
    class Sydno2 : Perevisnuk { }
    class Sydno3 : Perevisnuk { }
    class Sydno4 : Perevisnuk { }
    class Sydno5 : Perevisnuk { }
    class Sydno6 : Perevisnuk { }

    class Program
    {
        static void Main(string[] args)
        {
            var Sydno1 = new Sydno1 // створюємо об'єкти класів-спадкоємців
            {
                name = "A Symphony", // ім'я
                maxweight = 500, // максимальна вантажопідйомність
                capacity = 4, // вмісткість
                year = 1980, // рік створення
                fuel = 140, // кількість тисяч літрів витраченого за годину
            };

            var Sydno2 = new Sydno2
            {
                name = "A-One",
                maxweight = 520,
                capacity = 5,
                year = 1977,
                fuel = 160,
            };

            var Sydno3 = new Sydno3
            {
                name = "Evergreen",
                maxweight = 450,
                capacity = 3,
                year = 1960,
                fuel = 130,
            };

            var Sydno4 = new Sydno4
            {
                name = "Knock Nevis",
                maxweight = 600,
                capacity = 6,
                year = 1990,
                fuel = 200,
            };

            var Sydno5 = new Sydno5
            {
                name = "Ecotancer",
                maxweight = 560,
                capacity = 4,
                year = 1985,
                fuel = 150,
            };

            var Sydno6 = new Sydno6
            {
                name = "White Whale",
                maxweight = 590,
                capacity = 5,
                year = 1981,
                fuel = 145,
            };

            Console.WriteLine("What do you want to know?");
            Console.WriteLine("1 - The scale of spending fuel by ships");
            Console.WriteLine("2 - The capacity of all ships");
            Console.WriteLine("3 - The weight that the ships can transport together");
            Console.WriteLine("4 - The year of ship by writing a range");
            Console.WriteLine();

            int @int = int.Parse(Console.ReadLine());

            switch (@int) // за допомогою свічу реалізовуємо вибір користувача
            {
                case 1: Sort(); break;
                case 2: Capacity(); break;
                case 3: Maxweight(); break;
                case 4: Year(); break;

            }

            void Sort() // метод сортування за кількістю пального
            {
                int n;
                int[] ages = { Sydno1.fuel, Sydno2.fuel, Sydno3.fuel, Sydno4.fuel, Sydno5.fuel, Sydno6.fuel };
                string[] names = { Sydno1.name, Sydno2.name, Sydno3.name, Sydno4.name, Sydno5.name, Sydno6.name };

                for (int i = 0; i < ages.Length - 1; i++)
                {
                    for (int j = i + 1; j < ages.Length; j++)
                    {
                        if (ages[i] > ages[j])
                        {
                            n = ages[i];
                            ages[i] = ages[j];
                            ages[j] = n;
                        }
                    }
                }

                var sort = new Dictionary<string, int>(); // створюємо словник для імен кораблів та кількості пального

                sort.Add(Sydno1.name, Sydno1.fuel);
                sort.Add(Sydno2.name, Sydno2.fuel);
                sort.Add(Sydno3.name, Sydno3.fuel);
                sort.Add(Sydno4.name, Sydno4.fuel);
                sort.Add(Sydno5.name, Sydno5.fuel);
                sort.Add(Sydno6.name, Sydno6.fuel);

                Console.WriteLine("Amount of fuel per hour : ");
                Console.WriteLine();

                foreach (var d in sort.OrderBy(pair => pair.Value)) // створюємо цикл з сортуванням ключа і значення
                {
                    Console.WriteLine($"{d.Key} spends {d.Value} thousands litres per hour");
                    Console.WriteLine();
                }
            }

            void Capacity() // метод для визначення загальної вмісткості
            {
                int allcapacity = 0;
                int[] capacity = { Sydno1.capacity, Sydno2.capacity, Sydno3.capacity, Sydno4.capacity, Sydno5.capacity, Sydno6.capacity };
                for (int i = 0; i < capacity.Length; i++)
                {
                    allcapacity += capacity[i];
                }
                Console.WriteLine("The capacity of all ships = " + allcapacity + " millions barels of oil ");
            }

            void Maxweight() // метод для визначення максимальної вантажопідйомності
            {
                int maxweight = 0;
                int[] weight = { Sydno1.maxweight, Sydno2.maxweight, Sydno3.maxweight, Sydno4.maxweight, Sydno5.maxweight, Sydno6.maxweight };
                for (int i = 0; i < weight.Length; i++)
                {
                    maxweight += weight[i];
                }
                Console.WriteLine("The maximum weight which all ships can transport = " + maxweight + " tons");
            }

            void Year() // метод для виводу діапазону років кораблів
            {
                Console.WriteLine("Enter range of the years : ");
                int i = int.Parse(Console.ReadLine());
                int j = int.Parse(Console.ReadLine());

                Console.WriteLine("Your range is from " + i + " to " + j);

                var name = new Dictionary<string, int>(); // словник для імені й року
                name.Add(Sydno1.name, Sydno1.year); // додаємо імена та роки
                name.Add(Sydno2.name, Sydno2.year);
                name.Add(Sydno3.name, Sydno3.year);
                name.Add(Sydno4.name, Sydno4.year);
                name.Add(Sydno5.name, Sydno5.year);
                name.Add(Sydno6.name, Sydno6.year);

                foreach (var pair in name.OrderBy(pair => pair.Value)) // сортуємо за роком і відповідною назвою кораблів
                {
                    if (pair.Value >= i && pair.Value <= j)
                        Console.WriteLine($"Ship's name is {pair.Key}, Year {pair.Value}");
                }
            }
        }
    }
}
