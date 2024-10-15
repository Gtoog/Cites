using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CitiesGame
{
    class Program
    {

        static void PlayGame(List<string> cities)
        {
            Random random = new Random();
            bool player = true; bool exit = false;
            string currentCity = cities[random.Next(cities.Count)];
            List<string> usedCities = new List<string>();
            Console.WriteLine("Для поражения напишите гг");
            Console.WriteLine($"Начальный город: {currentCity}");
            usedCities.Add(currentCity);
            while (!exit)
            {
                if(player)
                    Console.WriteLine("Игрок один");
                else
                    Console.WriteLine("Игрок два");
                Console.WriteLine($"Должно быть слово на букву {char.ToUpper(currentCity[currentCity.Length - forechTryCity(cities, currentCity, 1)])}");
                Console.Write("Введите город: ");
                string userCity = Console.ReadLine();
                if(userCity == "гг")
                {
                    exit = true;
                    break;
                }
                if (cities.Contains(userCity, StringComparer.OrdinalIgnoreCase))
                {
                    if (char.ToUpper(userCity[0]) == char.ToUpper(currentCity[currentCity.Length - forechTryCity(cities, currentCity, 1)]))
                    {
                        if (!usedCities.Contains(userCity))
                        {
                            Console.WriteLine("Правильно!");
                            currentCity = userCity;
                            usedCities.Add(userCity);
                            cities.Remove(userCity);
                            player = !player;
                        }
                        else
                        {
                            Console.WriteLine("Такой город уже был");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Города нету");
                }
            }
            if (player)
                Console.WriteLine("Победил игрок 2");
            else
                Console.WriteLine("Победил игрок 1");
        }
        static int forechTryCity(List<string> city, string currentCity,int index)
        {
            foreach(string cityItem in city)
            {
                if (cityItem[0] == char.ToUpper(currentCity[currentCity.Length - index]))
                {
                    return index;
                }
            }
            return forechTryCity(city, currentCity, index + 1);
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            string filename = "city.txt"; 
            List<string> cities = new List<string>();
            using (StreamReader reader = new StreamReader(filename, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    cities.Add(line);
                }
            }
            PlayGame(cities);
        }
    }
}
