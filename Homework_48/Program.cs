using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Zoo zoo = new Zoo();
        Menu menu = new Menu(zoo);
        menu.work();
    }
}

class Menu
{
    private Zoo _zoo;

    public Menu(Zoo zoo)
    {
        _zoo = zoo;
    }

    public void work()
    {
        const string CommandShowAllAviary = "1";
        const string CommandSearchAviares = "2";
        const string CommandExit = "3";

        bool isWork = true;

        Console.WriteLine("Добро пожаловать в зоопарк!");
        
        while (isWork)
        {
            Console.WriteLine($"{CommandShowAllAviary} - Показать всех животных.\n{CommandSearchAviares} - Поиск вольера.\n{CommandExit} - Выход.");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandShowAllAviary:
                    _zoo.ShowAllAviaries();
                    break;

                case CommandSearchAviares:
                    _zoo.SearchAviaries();
                    break;

                case CommandExit:
                    isWork = false;
                    break;

                default:
                    Console.WriteLine("Ошибка! Нет такой команды.");
                    break;
            }
        }
    }
}

class Zoo
{
    private List<Aviary> _aviaries = new List<Aviary>();
    private Random _random = new Random();

    public Zoo()
    {
        AddAviaries();
    }

    public void ShowAllAviaries()
    {
        for (int i = 0; i < _aviaries.Count; i++)
        {
            Console.WriteLine($"№{i + 1}. Вольер: {_aviaries[i].Name}");
        }
    }

    public void SearchAviaries()
    {
        Console.WriteLine("Укажите номер вольера:");

        bool isNumber = int.TryParse(Console.ReadLine(), out int index);

        if (isNumber == true && index - 1 < _aviaries.Count && index > 0)
        {
            ShowSpecificAviary(index);
        }
        else
        {
            Console.WriteLine("Нет такого вольера");
        }
    }

    private void ShowSpecificAviary(int index)
    {
        _aviaries[index - 1].ShowAllAnimals();
    }

    private void AddAviaries()
    {
        _aviaries.Add(new Aviary(_random, "Волки", "Волк", "Скулит"));
        _aviaries.Add(new Aviary(_random, "Обезъяны", "Обезъяна", "у-у"));
        _aviaries.Add(new Aviary(_random, "Львы", "Лев", "Рычит"));
        _aviaries.Add(new Aviary(_random, "Снежные барсы", "Снежный барс", "Мяукает"));
    }
}

class Aviary
{
    private List<Animals> _animals = new List<Animals>();

    public Aviary(Random random, string nameAviary, string nameAnimals, string sound)
    {
        Name = nameAviary;
        AddAnimals(random, nameAnimals, sound);
    }

    public string Name { get; private set; }

    public void ShowAllAnimals()
    {
        Console.WriteLine($"Вольер: {Name}. Список животных:");

        for (int i = 0; i < _animals.Count; i++)
        {
            _animals[i].ShowInfo();
        }
    }

    private void AddAnimals(Random random, string name, string sound)
    {
        int numberAnimalsMaximum = 9;
        int numberAnimalsMinimum = 4;

        for (int i = 0; i < random.Next(numberAnimalsMinimum, numberAnimalsMaximum); i++)
        {
            _animals.Add(new Animals(name, SelectRandomGender(random), sound));
        }
    }

    private string SelectRandomGender(Random random)
    {
        string femaleGender = "Женский";
        string maleGender = "Мужской";

        int percent = 100;
        int probability = 50;

        if (random.Next(percent) <= probability)
        {
            return femaleGender;
        }
        else
        {
            return maleGender;
        }
    }
}

class Animals
{
    public Animals(string name, string gender, string sound)
    {
        Name = name;
        Gender = gender;
        Sound = sound;
    }

    public string Name { get; private set; }

    public string Gender { get; private set; }

    public string Sound { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name}. Пол - {Gender}. Звук - {Sound}.");
    }
}