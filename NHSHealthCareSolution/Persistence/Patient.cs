using System;
using System.ComponentModel.DataAnnotations;

namespace NHSHealthCareSolution.Persistence
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string BmiCategory { get; set; }
    }
}