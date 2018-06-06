using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.ForSudent
{
    public class WorkWithStudents2
    {
        public List<Kurs> GetListsOtchisl(List<Student> students)
        {
            List<Kurs> kurses = SeparateAtKurs(students);
            List<Kurs> otchislit = new List<Kurs>();
            foreach (Kurs kurs in kurses)
            {
                otchislit.Add(Otchislit(kurs));
            }
            return otchislit;
        }

        private Kurs Otchislit(Kurs kurs)
        {
            Kurs Otchisl = new Kurs() { NumberKurs = kurs.NumberKurs, Students = new List<Student>() };
            foreach (Student vasya in kurs.Students)
            {
                if (vasya.MedB[vasya.MedB.Length - 1] < 25)
                {
                    Otchisl.Students.Add(vasya);
                }
            }
            //if ((double)Otchisl.Count/group.Count>0.2)
            int maxOtch = kurs.Students.Count / 5;
            if (Otchisl.Students.Count > maxOtch)
                Otchisl = SelectWorstOfTheWorst(Otchisl, maxOtch);
            return Otchisl;
        }

        private List<Kurs> SeparateAtKurs(List<Student> students)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            List<Kurs> kurses = new List<Kurs>();
            Kurs kurs = new Kurs {NumberKurs= students[0].Kurs,Students=new List<Student>()};
            kurs.Students.Add(students[0]);
            kurses.Add(kurs);
            int countGroup = 0;
            dictionary.Add(students[0].Kurs, countGroup);
            countGroup++;
            for (int i = 1; i < students.Count; i++)
            {
                if (dictionary.ContainsKey(students[i].Kurs))
                {
                    kurses[dictionary[students[i].Kurs]].Students.Add(students[i]);
                }
                else
                {
                     Kurs newkurs = new Kurs() {NumberKurs=students[i].Kurs, Students = new List<Student>() };
                    newkurs.Students.Add(students[i]);
                    dictionary.Add(students[i].Kurs, countGroup);
                    countGroup++;
                    kurses.Add(newkurs);
                }
            }
            return kurses;
        }

        private Kurs SelectWorstOfTheWorst(Kurs std, int n)
        {
            if (n >= std.Students.Count)
                return std;
            List<double> medBStd = new List<double>();
            foreach (Student s in std.Students)
            {
                double r = 0;
                foreach (double ball in s.MedB)
                {
                    r += ball;
                }
                medBStd.Add(r / s.MedB.Length);
            }
            medBStd.Sort();
            Kurs TheWorseStd = new Kurs() { NumberKurs = std.NumberKurs, Students = new List<Student>() };
            foreach (Student s in std.Students)
            {
                double r = 0;
                foreach (double ball in s.MedB)
                {
                    r += ball;
                }
                r = (double)r / s.MedB.Length;
                if (r < medBStd[n])
                    TheWorseStd.Students.Add(s);
            }
            return TheWorseStd;
        }

        public List<Student> GetRamdom(int n)
        {
            string[] names = new string[] { "Александр","Иван","Алексей","Евгений","Олег","Дмитрий","Анатолий", "Владимир", "Юрий", "Светлана", "Ольга", "Елена", "Марина", "Надежда" };
            string[] otchestva = new string[] { "Александрович", "Иванович", "Константинович", "Дмитриевич", "Юрьевич", "Олегович", "Максимович", "Петрович", };
            string[] familii = new string[] { "Зинин", "Сычов", "Картонкин", "Зырянов", "Чиркин", "Гудимов", "Козлов", "Заборских", "Лавлинский", "Боровин", "Ушаков", "Колчак", "Добрынин", "Николаев", "Лопахин", "Котенев", "Зуев", "Каштанов", "Мещеряков" };
            Random rnd = new Random();
            List<Student> std = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string fio = names[rnd.Next(0, names.Length)] + " " + otchestva[rnd.Next(0, otchestva.Length)] + " " + familii[rnd.Next(0, familii.Length)];
                DateTime year = GenRandomDateTime(Convert.ToDateTime("20.07.1995 0:00:00"), Convert.ToDateTime("20.07.2001 0:00:00"),rnd);
                byte kurs =(byte)rnd.Next(1, 5);
                double[] medb = new double[kurs*2];
                for (int j = 0; j < 2 * kurs; j++)
                {
                    medb[j] = rnd.Next(0, 50);
                }
                byte group = (byte) rnd.Next(1, 8);
                Student vasya = new Student() { FIO = fio, Year = year, Kurs = kurs, MedB = medb, Group = group };
                std.Add(vasya);
            }
            return std;
        }
        private DateTime GenRandomDateTime(DateTime from, DateTime to, Random random = null)
        {
            if (from >= to)
            {
                throw new Exception("Параметр \"from\" должен быть меньше параметра \"to\"!");
            }
            if (random == null)
            {
                random = new Random();
            }
            TimeSpan range = to - from;
            var randts = new TimeSpan((long)(random.NextDouble() * range.Ticks));
            return from + randts;
        }
    }
}