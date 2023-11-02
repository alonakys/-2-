using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace part2
{
    partial class Kysil
    {
        public void Mainn()
        {
            List<Student> students = ReadData("data.txt", out bool invalid);
            Menu(students);
            if (invalid)
            {
                Console.WriteLine("Зчитано не весь файл, файл мiстить некоректнi данi");
            }
        }

        static void Menu(List<Student> students)
        {
            foreach (Student st in students)
            {
                if (st.MathematicsMark == '-' && st.PhysicsMark == '-' && st.InformaticsMark == '-')
                {
                    Console.WriteLine(st.SurName);
                }
            }
        }

        static List<Student> ReadData(string fileName, out bool invalid)
        {
            string[] data = File.ReadAllLines(fileName, Encoding.UTF8);
            List<Student> list = new List<Student>();
            invalid = false;
            for (int i = 0; i < data.Length; i++)
            {
                try
                {
                    Student student = Student.Parse(data[i]);
                    list.Add(student);
                }
                catch (ArgumentException)
                {
                    invalid = true;
                }
            }
            return list;
        }
    }
}
