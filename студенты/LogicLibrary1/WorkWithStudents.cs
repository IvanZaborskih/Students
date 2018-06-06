using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Сформировать списки отчисления для каждого курса. Студена отчисляют, если средний балл за последний семестр
//    меншье 25. При этом может быть отчислено не более 20% студентов от общего числа студентов на курсе.
//    Если студентов, подлежащих отчислению более чем 20%, то в первую очередь отчисляются студенты 
//    с наименьшим средним баллом за все семестры.


//составить список 5 студентов с максимальным средним баллом
namespace LogicLibrary1
{
    public class WorkWithStudents
    {
        public List<List<Student>> GetListsOtchisl(List<Student> students)
        {
            List<List<Student>> groups = SeparateAtKurs(students);
            List<List<Student>> otchislit = new List<List<Student>>();
            foreach (List<Student> group in groups)
            {
                otchislit.Add(Otchislit(group));
            }
            return otchislit;
        }

        private List<Student> Otchislit(List<Student> group)
        {
            List<Student> Otchisl = new List<Student>();
            foreach (Student vasya in group)
            {
                if (vasya.MedB[vasya.MedB.Length - 1] < 25)
                {
                    Otchisl.Add(vasya);
                }
            }
            //if ((double)Otchisl.Count/group.Count>0.2)
            int maxOtch = group.Count / 5;
            if (Otchisl.Count > maxOtch)
                Otchisl = SelectWorstOfTheWorst(Otchisl, maxOtch);
            return Otchisl;
        }

        private List<List<Student>> SeparateAtKurs(List<Student> students)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            List<Student> group = new List<Student>();
            group.Add(students[0]);
            int countGroup = 0;
            dictionary.Add(students[0].Kurs, countGroup);
            countGroup++;
            List<List<Student>> csf = new List<List<Student>>();
            csf.Add(group);
            for (int i = 1; i < students.Count; i++)
            {
                if (dictionary.ContainsKey(students[i].Kurs))
                {
                    csf[dictionary[students[i].Kurs]].Add(students[i]);
                }
                else
                {
                    List<Student> newgroup = new List<Student>();
                    newgroup.Add(students[i]);
                    dictionary.Add(students[i].Kurs, countGroup);
                    countGroup++;
                    csf.Add(newgroup);
                }
            }
            return csf;
        }

        private List<Student> SelectWorstOfTheWorst(List<Student> std, int n)
        {
            if (n >= std.Count)
                return std;
            List<double> medBStd = new List<double>();
            foreach (Student s in std)
            {
                double r = 0;
                foreach (double ball in s.MedB)
                {
                    r += ball;
                }
                medBStd.Add(r / s.MedB.Length);
            }
            medBStd.Sort();
            List<Student> TheWorseStd = new List<Student>();
            foreach (Student s in std)
            {
                double r = 0;
                foreach (double ball in s.MedB)
                {
                    r += ball;
                }
                r = (double)r / s.MedB.Length;
                if (r < medBStd[n])
                    TheWorseStd.Add(s);
            }
            return TheWorseStd;
        }
    }
}
