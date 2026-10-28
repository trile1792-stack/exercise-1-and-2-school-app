using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAppCore.Models
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] // Không tự tăng vì nhập thủ công bằng tay
        [Column("CourseID")]
        public int CourseID { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Credits")]
        public int Credits { get; set; }

        [Column("DepartmentID")]
        public int DepartmentID { get; set; }

        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}