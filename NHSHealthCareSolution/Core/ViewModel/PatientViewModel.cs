using System;
using System.ComponentModel;

namespace NHSHealthCareSolution.Core.ViewModel
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Height")]
        public decimal Height { get; set; }

        [DisplayName("Weight")]
        public decimal Weight { get; set; }


        public DateTime DateOfBirth { get; set; }

        [DisplayName("Birth Date")]
        public string BirthDate
        {
            get
            {
                return this.DateOfBirth.ToString("dd - MMM - yyyy");
            }
        }

        [DisplayName("Age")]
        public int Age
        {
            get
            {
                return this.DateOfBirth.GetCurrentAge();
            }
        }

        [DisplayName("Body Mass Index Category")]
        public string BmiCategory
        {
            get; set;
        }
    }
}