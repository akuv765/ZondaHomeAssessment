using System.ComponentModel.DataAnnotations;

namespace AssessmentAmit.Models
{
    public class Salary
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }

        public int TotalDays { get; set; }

        [Required]
        [Range(1,31)]
        public int PresentDays { get; set; }

        public decimal Basic { get; set; }

        public decimal HRA { get; set; }

        public decimal DA { get; set; }

        public decimal TA { get; set; }

        public decimal GrossSalary { get; set; }
    }

}