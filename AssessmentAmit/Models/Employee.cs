using System;
using System.ComponentModel.DataAnnotations;

namespace AssessmentAmit.Models
{
    [Serializable]
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public decimal Basic { get; set; }

        public decimal HRA { get; set; }

        public decimal DA { get; set; }

        public decimal TA { get; set; } = 800;
    }

}