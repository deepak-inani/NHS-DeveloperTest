namespace NHSHealthCareSolution
{
    public static class BmiExtension
    {
        public static string ToCategory(this decimal Bmi)
        {
            string bmiDescription = string.Empty;
            if (Bmi < 18.5M)
            {
                bmiDescription = "Underweight";
            }
            else if (Bmi >= 18.5M && Bmi < 25.0M)
            {
                bmiDescription = "Normal weight";
            }
            else if (Bmi >= 25.0M && Bmi < 30.0M)
            {
                bmiDescription = "Pre-obesity";
            }
            else if (Bmi >= 30.0M && Bmi < 35M)
            {
                bmiDescription = "Obesity class I";
            }
            else
            {
                bmiDescription = "Obesity class II";
            }

            return bmiDescription;
        }


    }
}