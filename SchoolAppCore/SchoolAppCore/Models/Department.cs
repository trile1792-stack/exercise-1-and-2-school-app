using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAppCore.Models
{
    public class Department
    {
        [Key]
        [Column("DepartmentID")]
        public int DepartmentID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Budget")]
        public decimal Budget { get; set; }

        [Column("StartDate")]
        public DateTime StartDate { get; set; }

        [Column("InstructorID")]
        public int? InstructorID { get; set; }

        [ForeignKey("InstructorID")]
        public Instructor Administrator { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}