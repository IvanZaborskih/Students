using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
    public class Student
    {
        public string FIO { get; set; }
        public DateTime Year { get; set; }
        public double[] MedB { get; set; }
        public byte Kurs { get; set; }
        public byte Group { get; set; }

        //public Student (string fio, DateTime year,double[] medb,byte kurs,byte group)
        //{
        //    FIO = fio;
        //    Year = year;
        //    MedB = medb;
        //    Kurs = kurs;
        //    Group = group;
        //}

    }
}
