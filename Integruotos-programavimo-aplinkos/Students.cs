﻿using Integruotos_programavimo_aplinkos.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integruotos_programavimo_aplinkos
{
    class Students
    {

        public void SortStudents()
        {
            //Program.students.Sort();
            try
            {
                Program.students = Program.students.OrderBy(o => o.name).OrderBy(o => o.surname).ToList();
                Program.good_guys = Program.good_guys.OrderBy(o => o.name).OrderBy(o => o.surname).ToList();
                Program.bad_guys = Program.bad_guys.OrderBy(o => o.name).OrderBy(o => o.surname).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not sort: " + ex);
                Console.WriteLine("Try again? [yes / no]");
                if (Console.ReadLine().Contains("yes"))
                    SortStudents();
            }
        }

        public void AddStudent(Student stud)
        {
            if(!Program.students.Contains(stud))
                Program.students.Add(stud);

            if (Formulas.Galutinis(stud.grade, stud.exam) < 5.0)
            {
                Program.bad_guys.Add(stud);
            }
            else if (Formulas.Galutinis(stud.grade, stud.exam) >= 5.0)
            {
                Program.good_guys.Add(stud);
            }
        }

        public void RemoveStudent(string name, string surname)
        {
            foreach (var item in Program.students)
            {
                if (item.name.Equals(name) && item.surname.Equals(surname))
                {
                    Program.students.Remove(item);
                    break;
                }
            }
        }
        #region unused
        /*
        public void ChangeExamGrade(string name, string surname, double grade)
        {
            foreach (var item in students)
            {
                if (item.name.Equals(name) && item.surname.Equals(surname))
                {
                    item.ExamGrade = grade;
                    break;
                }
            }
        }

        public void ChangeGrade(string name, string surname, double grade)
        {
            foreach (var item in students)
            {
                if (item.name.Equals(name) && item.surname.Equals(surname))
                {
                    item.Grade = grade;
                    break;
                }
            }
        }
        */
        #endregion


        public void AddStudent(string name, string surname, double grade, double exam, List<double> grades)
        {
            try
            {
                Student student = new Student(name, surname, grade, exam, grades);
                Program.students.Add(student);

                if(Formulas.Galutinis(student.grade, student.exam) < 5.0)
                {
                    Program.bad_guys.Add(student);
                }
                else if(Formulas.Galutinis(student.grade, student.exam) >= 5.0)
                {
                    Program.good_guys.Add(student);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bad student data: " + ex);
            }
        }

        #region unused
        /*
        public void ChangeStudentName(string name, string surname, string newname)
        {
            foreach (var item in students)
            {
                if (item.name.Equals(name) && item.surname.Equals(surname))
                {
                    item.name = newname;
                    break;
                }
            }
        }

        public void ChangeStudentSurname(string name, string surname, string newsurname)
        {
            foreach (var item in students)
            {
                if (item.name.Equals(name) && item.surname.Equals(surname))
                {
                    item.surname = newsurname;
                    break;
                }
            }
        }*/
        #endregion
    }
}
