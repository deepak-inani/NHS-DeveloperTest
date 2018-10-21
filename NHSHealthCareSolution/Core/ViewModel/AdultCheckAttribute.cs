using System;

namespace NHSHealthCareSolution.Core.ViewModel
{
    public class AdultCheckAttribute : ValidDateAttribute
    {

        public override bool IsValid(object value)
        {
            var birthDate = Convert.ToDateTime(value);
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now < birthDate.AddYears(age))
                age--;

            return age >= 18 ? true : false;
        }
    }
}