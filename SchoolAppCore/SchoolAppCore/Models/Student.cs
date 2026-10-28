using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAppCore.Models
{
    public class Student
    {
        [Key]
        [Column("ID")]
        public int StudentID { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("FirstMidName")]
        public string FirstName { get; set; }

        [Column("EnrollmentDate")]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}