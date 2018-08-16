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


        public class Adress
        {
            private string Region;
            private string City;
            private string Street;
            private string House;
            private string Flat;
            public Adress()
            {
                Region = "Пермский край";
                City = "Пермь";
            }
            public Adress(string region, string city, string street, string house, string flat)
            {
                if ((region == "") || (region == "Не удалось распознать регион"))
                {
                    this.Region = "Пермский край";
                }
                else this.Region = region;

                if ((city == "") || (city == "Не удалось распознать город"))
                {
                    this.City = "Пермь";
                }
                else this.City = city;

                this.Street = street;

                this.House = house;

                this.Flat = flat;
            }
            public void PrintAdress()
            {
                Console.WriteLine("Результат распознавания региона: " + Region);
                Console.WriteLine("Результат распознавания города: " + City);
                Console.WriteLine("Результат распознавания улицы: " + Street);
                Console.WriteLine("Результат распознавания дома: " + House);
                Console.WriteLine("Результат распознавания квартиры: " + Flat);
            }
            public string region
            {
                get
                {
                    return this.Region;
                }
                set
                {

                }
            }
            public string city
            {
                get
                {
                    return this.City;
                }
                set
                {

                }
            }

            public string street
            {
                get
                {
                    return this.Street;
                }
                set
                {

                }
            }

            public string house
            {
                get
                {
                    return this.House;
                }
                set
                {

                }
            }
            public string flat
            {
                get
                {
                    return this.Flat;
                }
                set
                {

                }
            }
        }












        /* ДАЛЕЕ СЛЕДУЕТ ТА ЧАСТЬ ПРОГРАММЫ, КОТОРУЮ НЕОБХОДИМО ПЕРЕМЕСТИТЬ В БИБЛИОТЕКУ
         * 
         * 
        */

        public static string CompileAdress(string index,string region,string city, string street, string house, string flat)
        {
            string adress="";
            adress += index + ", " + region + ", г. " + city + ", ул. " + street + ", д. " + house + ", кв. " + flat;
            return adress;
        }

        public static string CompileAdress(string index, string region, string area, string city, string street, string house, string flat)
        {
            string adress = "";
            adress += index + ", " + region + ", " + area + ", г. " + city + ", ул. " + street + ", д. " + house + ", кв. " + flat;
            return adress;
        }





        private static string Street(string s)
        {

            //string s = ""  д-м.15 ,    Улица Лео нова ,  г-д Пе рмь ,кв-ра 4 , облЙошкар Олинская"";
            string street = "Не удалось распознать улицу";

            // Regex regex1 = new Regex(@"(?:у|У)(?:[А-я]|-)*(?:\.|\s)+((?:[А-я]|-)+)\s*,+.*");
            Regex regex1 = new Regex(@",\s*(?:у|У)(?:[а-я]|-)*(?:\.|\s)+((?:[А-я]|-|\s)+)\s*,+.*");
            Regex regex2 = new Regex(@",\s*(?:у|У)(?:[а-я]|-)*\s*([А-Я](?:[А-я]|-|\s)+)\s*,+.*"); //парсим по заглавной букве - заменить на \w?
            MatchCollection matches = regex1.Matches(s);

            if (matches.Count > 0)
            {
                //Console.WriteLine("Работает цикл по точке!");
                foreach (Match match in matches)
                {
                    //Console.WriteLine(match.Groups[1].Value);
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
                //else
                //    street = "Совпадений не найдено!";
            }
            return street;
        }

        private static string City(string s)
        {

            //string s = "кв4,дом 15,улКрасильникова,гСинулул,";
            string city = "Не удалось распознать город";

            Regex regex1 = new Regex(@",\s*(?:г|Г)(?:[а-я]|-)*(?:\.|\s)+((?:[А-я]|-|\s)+)\s*,+.*");
            Regex regex2 = new Regex(@",\s*(?:г|Г)(?:[а-я]|-)*\s*([А-Я](?:[А-я]|-|\s)+)\s*,+.*"); //парсим по заглавной букве - заменить на \w?
            MatchCollection matches = regex1.Matches(s);


            if (matches.Count > 0)
            {
                //Console.WriteLine("Работает цикл по точке!");
                foreach (Match match in matches)
                {
                    //Console.WriteLine(match.Groups[1].Value);
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
                        //Console.WriteLine(match.Groups[2].Value);
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

            //string s = "кв4,дом 15,улКрасильникова,гСинулул,";
            string house = "Не удалось распознать дом";

            Regex regex1 = new Regex(@",\s*(?:д|Д)(?:[А-я]|-)*(?:\.|\s)*(\d+(?:/|\s|[А-я])?\d*)\s*,+.*");
            MatchCollection matches = regex1.Matches(s);


            if (matches.Count > 0)
            {
                //Console.WriteLine("Работает цикл по точке!");
                foreach (Match match in matches)
                {
                    //Console.WriteLine(match.Groups[1].Value);
                    house = match.Groups[1].Value;
                }
            }
            //else
            //{
            //    MatchCollection matches2 = regex2.Matches(s);
            //    if (matches2.Count > 0)
            //    {
            //        foreach (Match match in matches2)
            //        {
            //            //Console.WriteLine(match.Groups[2].Value);
            //            house = match.Groups[2].Value;
            //        }
            //    }
            //else
            //    city = "Совпадений не найдено!";
            //}
            return house;
        }


        private static string Flat(string s)
        {

            //string s = "кв4,дом 15,улКрасильникова,гСинулул,";
            string flat = "Не удалось распознать квартиру";

            Regex regex1 = new Regex(@",\s*(?:к|К)(?:[А-я]|-)*(?:\.|\s)*(\d+)\s*,+.*");
            MatchCollection matches = regex1.Matches(s);


            if (matches.Count > 0)
            {
                //Console.WriteLine("Работает цикл по точке!");
                foreach (Match match in matches)
                {
                    //Console.WriteLine(match.Groups[1].Value);
                    flat = match.Groups[1].Value;
                }
            }
            //else
            //{
            //    MatchCollection matches2 = regex2.Matches(s);
            //    if (matches2.Count > 0)
            //    {
            //        foreach (Match match in matches2)
            //        {
            //            //Console.WriteLine(match.Groups[2].Value);
            //            house = match.Groups[2].Value;
            //        }
            //    }
            //else
            //    city = "Совпадений не найдено!";
            //}
            return flat;
        }


        private static string Region(string s)
        {
            string region = "Не удалось распознать регион";

            //  Regex regex1 = new Regex(@"(?:кр|Кр|КР|о)(?:[А-я]|-)*(?:\.|\s)+((?:[А-я]|-)+)\s*,+.*");
            //  Regex regex1 = new Regex(@",\s*(?:кр|Кр|КР|о)(?:[а-я]|-)*(?:\.|\s)+((?:[А-я]|-|\s)+)\s*,+.*");
            Regex regex2 = new Regex(@",\s*(?:кр|Кр|КР|о)(?:[а-я]|-)*\s*([А-Я](?:[А-я]|-|\s)+)\s*,+.*"); //парсим по заглавной букве - заменить на \w?
                                                                                                         //Regex regex1 = new Regex(@",\s*([А-я]*\s*(?:кр|КР|Кр|кР|о)+[А-я]*\s*[А-я]*),+.*");
            Regex regex1 = new Regex(@",(\s*(?:[А-я]|-)*\s*(?:кр|КР|Кр|кР|о)+[А-я]*\s*(?:[А-я]|-)*)+\s*,+.*");
            MatchCollection matches = regex1.Matches(s);

            if (matches.Count > 0)
            {
                //Console.WriteLine("Работает цикл по точке!");
                foreach (Match match in matches)
                {
                    //Console.WriteLine(match.Groups[1].Value);
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
            //string adress = "Йошкар-Олинская область, г. Пермь., ул. Хрустальная, д. 8А ";
            adress = "," + adress + ",";

            Adress adr1 = new Adress(Region(adress), City(adress), Street(adress), House(adress), Flat(adress));

            Console.WriteLine("Исходная строка: " + adress);
            adr1.PrintAdress();
            Console.WriteLine("Адрес, собранный из отдельных частей: " + CompileAdress("614000", Region(adress), City(adress), Street(adress), House(adress), Flat(adress)));
            Console.WriteLine("Адрес, собранный из отдельных частей: "+ CompileAdress("614000", Region(adress),"Пермский район", City(adress), Street(adress), House(adress), Flat(adress)));
            Console.ReadLine();
        }
    }
}