using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAppCore.Models
{
    public class Instructor
    {
        [Key]
        [Column("ID")] // Map thuộc tính InstructorID vào cột "ID" thực tế trong SQL Server
        public int InstructorID { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("FirstMidName")] // Map thuộc tính FirstName vào cột "FirstMidName" thực tế trong SQL Server
        public string FirstName { get; set; }

        [Column("HireDate")]
        public DateTime HireDate { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}