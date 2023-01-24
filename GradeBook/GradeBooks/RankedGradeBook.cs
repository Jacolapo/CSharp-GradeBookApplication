using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
            Name = name;
        }
        public override char GetLetterGrade(double averageGrade)
        {

            if(Students.Count < 5)
            {
                
                throw new InvalidOperationException("You need a minimum of 5 student to calculate a rank");
                
            }                 
                   
            else
            {
                var allAverageGrades = new List<double>();
                foreach (var student in Students)
                {
                    allAverageGrades.Add(student.AverageGrade);                    
                }
                allAverageGrades.Sort();      
                //calculate the index size of each 20% range
                var rangeSize = (allAverageGrades.Count()/5);
                
                if (allAverageGrades.IndexOf(averageGrade) < rangeSize)
                {
                    return 'F';
                }
                if (allAverageGrades.IndexOf(averageGrade) < rangeSize*2)
                {
                    return 'D';
                }
                if (allAverageGrades.IndexOf(averageGrade) < rangeSize*3)
                {
                    return 'C';
                }
                if (allAverageGrades.IndexOf(averageGrade) < rangeSize*4)
                {
                    return 'B';
                }
                if (allAverageGrades.IndexOf(averageGrade) < rangeSize*5)
                {
                    return 'A';
                }
                                             
               
            }

            return 'F';


            
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics(); 
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);  
        }

    }
}
