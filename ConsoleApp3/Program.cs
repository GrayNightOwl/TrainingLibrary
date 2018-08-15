using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Func;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    class Program
    {
        private static string Street(string s)
        {
            string street = "Не удалось распознать улицу";
            Regex regex1 = new Regex(@",\s*(?:у|У)(?:[а-я]|-)*(?:\.|\s)+((?:[А-я]|-|\s)+)\s*,+.*");
            Regex regex2 = new Regex(@",\s*(?:у|У)(?:[а-я]|-)*\s*([А-Я](?:[А-я]|-|\s)+)\s*,+.*");
            MatchCollection matches = regex1.Matches(s);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    street = match.Groups[1].Value;
                }
            }
            else
            {
                MatchCollection matches2 = regex2.Matches(s);
                if (matches2.Count > 0)
                {
                    foreach (Match match in matches2)
                    {
                        street = match.Groups[1].Value;
                    }
                }
            }
            return street;
        }

        private static string City(string s)
        {
            
            string city = "Не удалось распознать город";
            Regex regex1 = new Regex(@",\s*(?:г|Г)(?:[а-я]|-)*(?:\.|\s)+((?:[А-я]|-|\s)+)\s*,+.*");
            Regex regex2 = new Regex(@",\s*(?:г|Г)(?:[а-я]|-)*\s*([А-Я](?:[А-я]|-|\s)+)\s*,+.*"); 
            MatchCollection matches = regex1.Matches(s);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    city = match.Groups[1].Value;
                }
            }
            else
            {
                MatchCollection matches2 = regex2.Matches(s);
                if (matches2.Count > 0)
                {
                    foreach (Match match in matches2)
                    {
                        city = match.Groups[1].Value;
                    }
                }
                else
                    city = "Пермь";
            }
            return city;
        }

        private static string House(string s)
        {
            
            string house = "Не удалось распознать дом";

            Regex regex1 = new Regex(@",\s*(?:д|Д)(?:[А-я]|-)*(?:\.|\s)*(\d+(?:/|\s|[А-я])?\d*)\s*,+.*");
            MatchCollection matches = regex1.Matches(s);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    house = match.Groups[1].Value;
                }
            }
            return house;
        }


        private static string Flat(string s)
        {
            string flat = "Не удалось распознать квартиру";
            Regex regex1 = new Regex(@",\s*(?:к|К)(?:[А-я]|-)*(?:\.|\s)*(\d+)\s*,+.*");
            MatchCollection matches = regex1.Matches(s);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    flat = match.Groups[1].Value;
                }
            }
            return flat;
        }


        private static string Region(string s)
        {
            string region = "Не удалось распознать регион";
            Regex regex2 = new Regex(@",\s*(?:кр|Кр|КР|о)(?:[а-я]|-)*\s*([А-Я](?:[А-я]|-|\s)+)\s*,+.*"); //парсим по заглавной букве - заменить на \w?
            Regex regex1 = new Regex(@",(\s*(?:[А-я]|-)*\s*(?:кр|КР|Кр|кР|о)+[А-я]*\s*(?:[А-я]|-)*)+\s*,+.*");
            MatchCollection matches = regex1.Matches(s);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    region = match.Groups[1].Value;
                }
            }
            else
            {
                MatchCollection matches2 = regex2.Matches(s);
                if (matches2.Count > 0)
                {
                    foreach (Match match in matches2)
                    {
                        Console.WriteLine("Вторая ветвь");
                        region = match.Groups[1].Value;
                    }
                }
                else
                    region = "Пермский край";
            }
            return region;
        }




        static void Main(string[] args)
        {
            string adress = "ул Синяя,    г Пермь,кв4 , дом 15";
            adress = "," + adress + ",";
            Console.WriteLine("Исходная строка: "+adress);
            Console.WriteLine("Результат распознавания региона: " + Region(adress));
            Console.WriteLine("Результат распознавания города: " + City(adress));
            Console.WriteLine("Результат распознавания улицы: "+Street(adress));
            Console.WriteLine("Результат распознавания дома: " + House(adress));
            Console.WriteLine("Результат распознавания квартиры: " + Flat(adress));
            Console.WriteLine("Окончание работы");
            Console.ReadLine();
        }
    }
}