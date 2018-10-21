using System.ComponentModel;

namespace NHSHealthCareSolution.Core.ViewModel
{
    public class BmiReportViewModel
    {
        [DisplayName("BMI Category")]
        public string BmiCategory { get; set; }

        [DisplayName("Patient Count")]
        public int PatientCount { get; set; }
    }
}