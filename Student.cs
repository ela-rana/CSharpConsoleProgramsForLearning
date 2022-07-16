// A class named “Student” with private data members: studentId(int), studentFname(string), studentLname(string), studentGrade(char)
// and public properties for each data member.
// In the main method, we will instantiate the class and assign data to properties, then display the data back on console.

using System;

namespace StructAndClassPractice
{
    internal class Student
    {
        private int studentId;
        private string studentFName;
        private string studentLName;
        private char studentGrade;
        public int StudentId 
        { 
            get { return this.studentId; }
            set { this.studentId = value; }
        }
        public string StudentFName
        {
            get { return this.studentFName; }
            set { this.studentFName = value; }
        }
        public string StudentLName
        {
            get { return this.studentLName; }
            set { this.studentLName = value; }
        }
        public char StudentGrade
        {
            get { return this.studentGrade; }
            set { this.studentGrade = value; }
        }
        public Student(int studentId, string studentFName, string studentLName, char studentGrade)
        {
            this.studentId = studentId;
            this.studentFName= studentFName;
            this.studentLName = studentLName;
            this.studentGrade = studentGrade;
        }
        public Student()
        {

        }

        /// <summary>
        /// A method to display all Student field values for the student object that calls this method
        /// </summary>
        public void DisplayStudent()
        {
            Console.WriteLine("\nStudent Details:");    //to display a header before the details are displayed, then the next statement displays all fields
            Console.WriteLine($"StudentID:\t{this.studentId}\nFirst Name:\t{this.studentFName}\nLast Name:\t{this.studentLName}\nGrade:\t\t{this.studentGrade}");
        }
    }
}
