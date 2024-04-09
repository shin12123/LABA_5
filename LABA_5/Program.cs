
using System.Diagnostics;
//Створити суперклас Домашня тварина і підкласи Собака, Кішка, Папуга, Птах. 
//Подумати, які з вищенаведених підкласів також можуть бути суперкласами.  //Например к єтому заданию подходят подклассы Птица, Попугай может быть суперклассом для разных видов попугаев
//За допомогою конструктора встановити ім'я кожної тварини і його характеристики.                                                                                 (домашние, не домашние)
//Вивести на екран голос, який подає домашня тварина
namespace LABA_5
{
    abstract class Pet //— это просто вид суперкласса, который не предполагает создания его экземпляров напрямую и может содержать абстрактные методы
    {// которые должны быть реализованы в подклассах.
        public string Name { get; private set; }
        protected string SoundPath;
        protected string Voice;

        //конструктор
        public Pet(string name, string soundFileName, string voice)
        {
            Name = name;
            SoundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Sounds\", soundFileName);
            Voice = voice;
        }

        public void MakeSound()//для вівода звука 
        {
           
            Console.WriteLine($"{Name} издает звук: {Voice}");

            try
            {
                Console.WriteLine($"Попытка воспроизвести файл: {SoundPath}");

              
                Process.Start(new ProcessStartInfo
                {
                    FileName = SoundPath,
                    UseShellExecute = true
                });
            }
        finally
            { 
            }
        }


        class Dog : Pet
        {
            public Dog(string name) : base(name, "dog.wav", "Гав") { }
        }

        class Cat : Pet
        {
            public Cat(string name) : base(name, "cat.wav", "Мяу") { }
        }

        class Parrot : Pet
        {
            public Parrot(string name) : base(name, "parrot.wav", "Чеку-Чеку") { }
        }

        class Bird : Pet
        {
            public Bird(string name) : base(name, "bird.wav", "Чирик") { }
        }

        class Program
        {
            static void Main()
            {
                Pet pet = GetUserChoice();
                if (pet != null)
                {
                    Console.WriteLine($"Вы выбрали: {pet.Name}");
                    pet.MakeSound();
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы выйти...");
                Console.ReadKey(); 
            }

            static Pet GetUserChoice()
            {
                Console.WriteLine("Выберите животное для воспроизведения его звука:");
                Console.WriteLine("1. Собака");
                Console.WriteLine("2. Кошка");
                Console.WriteLine("3. Попугай");
                Console.WriteLine("4. Птица");
                Console.Write("Введите номер: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        return new Dog("Патрик");
                    case "2":
                        return new Cat("Мурка");
                    case "3":
                        return new Parrot("Одноглазый Джо");
                    case "4":
                        return new Bird("Митя");
                    default:
                        Console.WriteLine("Неправильный выбор.");
                        return null;
                }
            }
        }
    }
}

