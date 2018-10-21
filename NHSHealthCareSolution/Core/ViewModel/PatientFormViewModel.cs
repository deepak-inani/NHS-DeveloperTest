using NHSHealthCareSolution.Controllers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace NHSHealthCareSolution.Core.ViewModel
{
    public class PatientFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.##}")]
        public decimal Height { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth
        {
            get; set;
        }


        public string BmiCategory
        {
            get
            {
                decimal bmi = Math.Round(this.Weight / (this.Height * this.Height));
                return bmi.ToCategory();
            }
        }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<PatientsController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<PatientsController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
    }
}