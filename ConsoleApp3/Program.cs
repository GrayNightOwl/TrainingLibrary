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
                Region = "�������� ����";
                City = "�����";
            }
            public Adress(string region, string city, string street, string house, string flat)
            {
                if ((region == "") || (region == "�� ������� ���������� ������"))
                {
                    this.Region = "�������� ����";
                }
                else this.Region = region;

                if ((city == "") || (city == "�� ������� ���������� �����"))
                {
                    this.City = "�����";
                }
                else this.City = city;

                this.Street = street;

                this.House = house;

                this.Flat = flat;
            }
            public void PrintAdress()
            {
                Console.WriteLine("��������� ������������� �������: " + Region);
                Console.WriteLine("��������� ������������� ������: " + City);
                Console.WriteLine("��������� ������������� �����: " + Street);
                Console.WriteLine("��������� ������������� ����: " + House);
                Console.WriteLine("��������� ������������� ��������: " + Flat);
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












        /* ����� ������� �� ����� ���������, ������� ���������� ����������� � ����������
         * 
         * 
        */

        public static string CompileAdress(string index,string region,string city, string street, string house, string flat)
        {
            string adress="";
            adress += index + ", " + region + ", �. " + city + ", ��. " + street + ", �. " + house + ", ��. " + flat;
            return adress;
        }

        public static string CompileAdress(string index, string region, string area, string city, string street, string house, string flat)
        {
            string adress = "";
            adress += index + ", " + region + ", " + area + ", �. " + city + ", ��. " + street + ", �. " + house + ", ��. " + flat;
            return adress;
        }





        private static string Street(string s)
        {

            //string s = ""  �-�.15 ,    ����� ��� ���� ,  �-� �� ��� ,��-�� 4 , ��������� ��������"";
            string street = "�� ������� ���������� �����";

            // Regex regex1 = new Regex(@"(?:�|�)(?:[�-�]|-)*(?:\.|\s)+((?:[�-�]|-)+)\s*,+.*");
            Regex regex1 = new Regex(@",\s*(?:�|�)(?:[�-�]|-)*(?:\.|\s)+((?:[�-�]|-|\s)+)\s*,+.*");
            Regex regex2 = new Regex(@",\s*(?:�|�)(?:[�-�]|-)*\s*([�-�](?:[�-�]|-|\s)+)\s*,+.*"); //������ �� ��������� ����� - �������� �� \w?
            MatchCollection matches = regex1.Matches(s);

            if (matches.Count > 0)
            {
                //Console.WriteLine("�������� ���� �� �����!");
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
                //    street = "���������� �� �������!";
            }
            return street;
        }

        private static string City(string s)
        {

            //string s = "��4,��� 15,���������������,��������,";
            string city = "�� ������� ���������� �����";

            Regex regex1 = new Regex(@",\s*(?:�|�)(?:[�-�]|-)*(?:\.|\s)+((?:[�-�]|-|\s)+)\s*,+.*");
            Regex regex2 = new Regex(@",\s*(?:�|�)(?:[�-�]|-)*\s*([�-�](?:[�-�]|-|\s)+)\s*,+.*"); //������ �� ��������� ����� - �������� �� \w?
            MatchCollection matches = regex1.Matches(s);


            if (matches.Count > 0)
            {
                //Console.WriteLine("�������� ���� �� �����!");
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
                    city = "�����";
            }
            return city;
        }

        private static string House(string s)
        {

            //string s = "��4,��� 15,���������������,��������,";
            string house = "�� ������� ���������� ���";

            Regex regex1 = new Regex(@",\s*(?:�|�)(?:[�-�]|-)*(?:\.|\s)*(\d+(?:/|\s|[�-�])?\d*)\s*,+.*");
            MatchCollection matches = regex1.Matches(s);


            if (matches.Count > 0)
            {
                //Console.WriteLine("�������� ���� �� �����!");
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
            //    city = "���������� �� �������!";
            //}
            return house;
        }


        private static string Flat(string s)
        {

            //string s = "��4,��� 15,���������������,��������,";
            string flat = "�� ������� ���������� ��������";

            Regex regex1 = new Regex(@",\s*(?:�|�)(?:[�-�]|-)*(?:\.|\s)*(\d+)\s*,+.*");
            MatchCollection matches = regex1.Matches(s);


            if (matches.Count > 0)
            {
                //Console.WriteLine("�������� ���� �� �����!");
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
            //    city = "���������� �� �������!";
            //}
            return flat;
        }


        private static string Region(string s)
        {
            string region = "�� ������� ���������� ������";

            //  Regex regex1 = new Regex(@"(?:��|��|��|�)(?:[�-�]|-)*(?:\.|\s)+((?:[�-�]|-)+)\s*,+.*");
            //  Regex regex1 = new Regex(@",\s*(?:��|��|��|�)(?:[�-�]|-)*(?:\.|\s)+((?:[�-�]|-|\s)+)\s*,+.*");
            Regex regex2 = new Regex(@",\s*(?:��|��|��|�)(?:[�-�]|-)*\s*([�-�](?:[�-�]|-|\s)+)\s*,+.*"); //������ �� ��������� ����� - �������� �� \w?
                                                                                                         //Regex regex1 = new Regex(@",\s*([�-�]*\s*(?:��|��|��|��|�)+[�-�]*\s*[�-�]*),+.*");
            Regex regex1 = new Regex(@",(\s*(?:[�-�]|-)*\s*(?:��|��|��|��|�)+[�-�]*\s*(?:[�-�]|-)*)+\s*,+.*");
            MatchCollection matches = regex1.Matches(s);

            if (matches.Count > 0)
            {
                //Console.WriteLine("�������� ���� �� �����!");
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
                        Console.WriteLine("������ �����");
                        region = match.Groups[1].Value;
                    }
                }
                else
                    region = "�������� ����";
            }
            return region;
        }











        static void Main(string[] args)
        {

            string adress = "�� �����,    � �����,��4 , ��� 15";
            //string adress = "������-�������� �������, �. �����., ��. �����������, �. 8� ";
            adress = "," + adress + ",";

            Adress adr1 = new Adress(Region(adress), City(adress), Street(adress), House(adress), Flat(adress));

            Console.WriteLine("�������� ������: " + adress);
            adr1.PrintAdress();
            Console.WriteLine("�����, ��������� �� ��������� ������: " + CompileAdress("614000", Region(adress), City(adress), Street(adress), House(adress), Flat(adress)));
            Console.WriteLine("�����, ��������� �� ��������� ������: "+ CompileAdress("614000", Region(adress),"�������� �����", City(adress), Street(adress), House(adress), Flat(adress)));
            Console.ReadLine();
        }
    }
}