using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagement.Models
{
    public class Employee
    {
        [Key]
        public int Emp_Id { get; set; }

        [Required, StringLength(200)]
        [DisplayName("Name")]
        public string Emp_Name { get; set; }

        [Required,Range(18,65)]
        [DisplayName("Age")]
        public int Emp_Age { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string Emp_Gender { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number must be exactly 10 digits")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid mobile number")]
        [DisplayName("Mobile")]
        public string Emp_Mobile { get; set; } // Change from int to string


        [Required,Range(0,int.MaxValue)]
        [DisplayName("Salary")]
        public int Emp_Salary { get; set; }

        [DisplayName("Status")]
        public bool Emp_Status { get; set; }

        [ForeignKey("Department")]
        [Required(ErrorMessage="Please Select A Department")]
        public int Dep_Id { get; set; }

        public Department? Department { get; set; }
    }
}
