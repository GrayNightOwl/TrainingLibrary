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
            Console.WriteLine("�������� ������: " + adress);
            Console.WriteLine("��������� ������������� �������: " + Region(adress));
            Console.WriteLine("��������� ������������� ������: " + City(adress));
            Console.WriteLine("��������� ������������� �����: " + Street(adress));
            Console.WriteLine("��������� ������������� ����: " + House(adress));
            Console.WriteLine("��������� ������������� ��������: " + Flat(adress));
            Console.WriteLine("��������� ������");
            Console.ReadLine();
        }
    }
}