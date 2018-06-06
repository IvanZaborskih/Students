using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogicLibrary1
{
    public class ClassFile
    {
        string PathFileInput { get; set; }

        public ClassFile(string fname)
        {
            PathFileInput = fname;
        }
        delegate void Operation(StreamReader r1, StreamReader r2, StreamWriter writer);

        public void StringToFile(string s)
        {
            File.WriteAllText(PathFileInput, s);
        }

        public string FileToString()
        {
            string s = File.ReadAllText(PathFileInput);
            return s;
        }

        public void SaveStudent(List<Student> students, string PathFileSave)
        {
            FileStream aFile = new FileStream(PathFileSave, FileMode.Create);
            BinaryWriter f = new BinaryWriter(aFile, Encoding.Unicode);
            f.Write(students.Count);
            foreach (Student std in students)
            {
                f.Write(std.FIO);
                f.Write(Convert.ToString(std.Year));
                f.Write(std.MedB.Length);
                foreach (double b in std.MedB)
                {
                    f.Write(b);
                }
                f.Write(std.Kurs);
                f.Write(std.Group);
            }
            f.Close();
            aFile.Close();
        }
        public List<Student> ReadStudent()
        {
            FileStream aFile = new FileStream(PathFileInput, FileMode.Open);
            BinaryReader f = new BinaryReader(aFile, Encoding.Unicode);
            int n = f.ReadInt32();
            //Student[] students = new Student[n];
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string fio = f.ReadString();
                DateTime year = Convert.ToDateTime(f.ReadString());
                int count = f.ReadInt32();
                double[] medb = new double[count];
                for (int j = 0; j < count; j++)
                {
                    medb[j] = f.ReadDouble();
                }
                byte kurs = f.ReadByte();
                byte group = f.ReadByte();
                Student student = new Student { FIO = fio, Year = year, MedB = medb, Kurs = kurs, Group = group };
                students.Add(student);
            }
            return students;
        }


        public void SeparateFileTo2(string FNameSave1, string FNameSave2, int positionSeparate)
        {

            FileStream fo = new FileStream(PathFileInput, FileMode.Open);
            StreamReader reader = new StreamReader(fo);
            FileStream fs1 = new FileStream(FNameSave1, FileMode.Create);
            StreamWriter write1 = new StreamWriter(fs1);
            FileStream fs2 = new FileStream(FNameSave2, FileMode.Create);
            StreamWriter write2 = new StreamWriter(fs2);
            string line;
            line = reader.ReadLine();
            while (line != null)
            {
                write1.WriteLine(line.Substring(0, positionSeparate));
                write2.WriteLine(line.Substring(positionSeparate));
                line = reader.ReadLine();
            }
            reader.Close(); write1.Close(); write2.Close();
        }

        //public bool FileToMyQueue(MyQueue DecFromFile)
        //{
        //    try
        //    {
        //        FileStream f = new FileStream(PathFileInput, FileMode.Open);
        //        StreamReader r = new StreamReader(f);
        //        // DecFromFile = new MyQueue();
        //        string str = r.ReadLine();
        //        while (str != null)
        //        {
        //            double v = Convert.ToDouble(str);
        //            DecFromFile.InQueue(v);
        //            str = r.ReadLine();
        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public void MyQueueToFile(MyQueue q)
        //{
        //    FileStream f3 = new FileStream(PathFileInput, FileMode.Create);
        //    StreamWriter writer = new StreamWriter(f3);
        //    while (!q.QueueIsEmpty())
        //    {
        //        writer.WriteLine(Convert.ToString(q.OutQueue()));
        //    }
        //    writer.Close();
        //    f3.Close();
        //}

        public int Join2Files(string pathFileInput2, string pathFileOutput)
        {
            FileStream f11 = new FileStream(PathFileInput, FileMode.Open);
            StreamReader reader11 = new StreamReader(f11);
            FileStream f22 = new FileStream(pathFileInput2, FileMode.Open);
            StreamReader reader22 = new StreamReader(f22);
            FileStream f3 = new FileStream(pathFileOutput, FileMode.Create);
            StreamWriter writer = new StreamWriter(f3);
            int c = UpDownSort(reader11, reader22);
            //if (c == -2||c==-3||c==0) return 0; //ошибка
            Operation choiceOf2 = new Operation(Vozr);
            if (c == -1)
                choiceOf2 = (Ybuv);
            reader11.Close();
            reader22.Close();
            f11.Close();
            f22.Close();
            FileStream f1 = new FileStream(PathFileInput, FileMode.Open);
            StreamReader reader1 = new StreamReader(f1);
            FileStream f2 = new FileStream(pathFileInput2, FileMode.Open);
            StreamReader reader2 = new StreamReader(f2);
            //double currentLine1 =Convert.ToDouble(reader1.ReadLine());
            //double currentLine2 = Convert.ToDouble(reader2.ReadLine());
            //bool t=true;
            //while (t)

            choiceOf2.Invoke(reader1, reader2, writer);

            reader1.Close(); reader2.Close(); writer.Close();
            f1.Close(); f2.Close(); f3.Close();
            return 1;

        }
        private void Vozr(StreamReader r1, StreamReader r2, StreamWriter writer)
        {
            //Sort(r2, r1, writer);
            double current1 = Convert.ToDouble(r1.ReadLine());
            double current2 = Convert.ToDouble(r2.ReadLine());
            bool t = true;
            while (t)
            {
                if (current1 < current2)
                    t = Sort(r1, r2, writer, ref current1, ref current2);
                else
                    t = Sort(r2, r1, writer, ref current2, ref current1);
            }

            //        writer.WriteLine(current1);
            //        string str = r2.ReadLine();
            //        if (str == null)
            //        {
            //            writer.WriteLine(current1);
            //            prewrite(writer, r1);
            //            t = false;
            //        }
            //        current1 = Convert.ToDouble(str);
            //    }
            //    else
            //    {
            //        writer.WriteLine((current2));
            //        string str = r1.ReadLine();
            //        if (str == null)
            //        {
            //            writer.WriteLine(current2);
            //            prewrite(writer, r2);
            //            t = false;
            //        }
            //        current2 = Convert.ToDouble(str);
            //    }
        }

        private void Ybuv(StreamReader r1, StreamReader r2, StreamWriter writer)
        {
            //Sort(r1, r2, writer);
            double current1 = Convert.ToDouble(r1.ReadLine());
            double current2 = Convert.ToDouble(r2.ReadLine());
            bool t = true;
            while (t)
            {
                if (current1 < current2)
                    t = Sort(r2, r1, writer, ref current2, ref current1);
                else
                    t = Sort(r1, r2, writer, ref current1, ref current2);
            }//        writer.WriteLine(current2);
             //        string str = r2.ReadLine();
             //        if (str == null)
             //        {
             //            writer.WriteLine(current1);
             //            prewrite(writer, r1);
             //            t = false;
             //        }
             //        current2 = Convert.ToDouble(str);
             //    }
             //    else
             //    {
             //        writer.WriteLine((current1));
             //        string str = r1.ReadLine();
             //        if (str == null)
             //        {
             //            writer.WriteLine(current2);
             //            prewrite(writer, r2);
             //            t = false;
             //        }
             //        current1 = Convert.ToDouble(str);
             //    }
        }
        private bool Sort(StreamReader r1, StreamReader r2, StreamWriter writer, ref double value1, ref double value2)
        {
            writer.WriteLine(value1);
            string str = r1.ReadLine();
            if (str == null)
            {
                writer.WriteLine(value2);
                prewrite(writer, r2);
                return false;
            }
            value1 = Convert.ToDouble(str);
            return true;
        }



        private void prewrite(StreamWriter writer, StreamReader reader)
        {
            string str = reader.ReadLine();
            while (str != null)
            {
                writer.WriteLine(str);
                str = reader.ReadLine();
            }

        }
        public int open()
        {
            FileStream fo = new FileStream(PathFileInput, FileMode.Open);
            StreamReader reader = new StreamReader(fo);
            return IsUpOrDown(reader);

        }
        private int UpDownSort(StreamReader r1, StreamReader r2)
        {
            int res1 = IsUpOrDown(r1);
            int res2 = IsUpOrDown(r2);
            if ((res1 == 1 && res2 == 1) || (res1 == 1 && res2 == 0) || (res1 == 0 && res2 == 1)) return 1;  // сортировать по возрастанию
            else if ((res1 == -1 && res2 == -1) || (res1 == 0 && res2 == -1) || (res1 == -1 && res2 == 0)) return -1;//конечную последовательность сортировать по убыванию
            else if (res1 == 0 && res2 == 0) return 0;//невозможно определить как сортировать последовательности
            else if (res1 == -2 || res2 == -2) return -2;//в одном из потоков встретились недопустимый символ
            else if (res1 == -3 || res2 == -3) return -3;//пустой поток
            return -4;
        }
        private int IsUpOrDown(StreamReader r)
        {
            double line = 0, nextLine = 0;
            try
            {
                string lines = r.ReadLine();
                if (lines == null) return -3; // в файле нет ни одной строки
                line = Convert.ToDouble(lines);
                string lines2;
                lines2 = r.ReadLine();
                if (lines == null) return 0; //в файле всего одина строка>-все эл-ты одинаковые
                nextLine = Convert.ToDouble(lines2);
                string nextnext = r.ReadLine();
                while (line == nextLine && nextnext != null)
                {
                    nextLine = Convert.ToDouble(nextnext);
                    nextnext = r.ReadLine();
                }
                r.BaseStream.Position = 0;
            }
            catch (FormatException)
            {
                return -2; //в файле нашлись недопустимые символы 
            }
            if (line < nextLine) return 1; //возрастающая
            else if (line > nextLine) return -1; //убывающая
            else return 0; //все элементы одинаковые
        }
    }
}
