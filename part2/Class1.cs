using System;
using System.Collections.Generic;
using System.Text;

namespace part2
{
    partial class Kysil
    {
        class Student
        {
            public string SurName { get; set; }
            public string FirstName { get; set; }
            public string Patronymic { get; set; }
            public char Sex { get; set; }
            public string DateOfBirth { get; set; }
            public char MathematicsMark { get; set; }
            public char PhysicsMark { get; set; }
            public char InformaticsMark { get; set; }
            public int Scholarship { get; set; }

            public Student(string surName, string firstName, string patronymic, char sex, string dateOfBirth, char mathematicsMark, char physicsMark, char informaticsMark, int scholarship)
            {
                SurName = surName;
                FirstName = firstName;
                Patronymic = patronymic;
                Sex = sex;
                DateOfBirth = dateOfBirth;
                MathematicsMark = mathematicsMark;
                PhysicsMark = physicsMark;
                InformaticsMark = informaticsMark;
                Scholarship = scholarship;
            }

            public override string ToString()
            {
                return $"{SurName} {FirstName} {Patronymic} {Sex} {DateOfBirth} {MathematicsMark} {PhysicsMark} {InformaticsMark} {Scholarship}";
            }

            public static Student Parse(string lineWithAllData)
            {
                string[] data = lineWithAllData.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (data.Length < 9)
                {
                    throw new ArgumentException("Некоректна кiлькiсть даних у рядку");
                }

                string surName = data[0];
                string firstName = data[1];
                string patronymic = data[2];

                if (!IsNameValid(surName) || !IsNameValid(firstName) || !IsNameValid(patronymic))
                {
                    throw new ArgumentException("Некоректнi данi для iмен студента");
                }

                char sex = Convert.ToChar(data[3]);

                if (!IsSexValid(sex))
                {
                    throw new ArgumentException("Некоректна стать");
                }

                string dateOfBirth = data[4];

                if (!IsDateOfBirthValid(dateOfBirth))
                {
                    throw new ArgumentException("Некоректна дата народження");
                }

                char mathematicsMark = Convert.ToChar(data[5]);
                char physicsMark = Convert.ToChar(data[6]);
                char informaticsMark = Convert.ToChar(data[7]);

                if (!AreMarksValid(mathematicsMark, physicsMark, informaticsMark))
                {
                    throw new ArgumentException("Некоректнi оцiнки");
                }

                int scholarship = int.Parse(data[8]);

                if (!IsScholarshipValid(scholarship))
                {
                    throw new ArgumentException("Некоректна стипендiя");
                }

                return new Student(surName, firstName, patronymic, sex, dateOfBirth, mathematicsMark, physicsMark, informaticsMark, scholarship);
            }

            private static bool IsNameValid(string name)
            {
                return !string.IsNullOrWhiteSpace(name);
            }

            private static bool IsSexValid(char sex)
            {
                return sex == 'M' || sex == 'F' || sex == 'Ч' || sex == 'Ж' || sex == 'm' || sex == 'f' || sex == 'ч' || sex == 'ж';
            }

            private static bool IsDateOfBirthValid(string dateOfBirth)
            {
                if (dateOfBirth.Length != 10)
                {
                    return false;
                }

                DateTime parsedDate;
                if (!DateTime.TryParseExact(dateOfBirth, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    return false;
                }

                return true;
            }

            private static bool AreMarksValid(params char[] marks)
            {
                foreach (char mark in marks)
                {
                    if (mark != '-' && (mark < '2' || mark > '5'))
                    {
                        return false;
                    }
                }

                return true;
            }

            private static bool IsScholarshipValid(int scholarship)
            {
                return scholarship == 0 || (scholarship >= 1234 && scholarship <= 4321);
            }
        }
    }
}