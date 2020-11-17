using System.ComponentModel.DataAnnotations;

namespace demo.Tools
{
    public class CustomValidationMethods
    {
        public static ValidationResult ValidateCountry(string country, ValidationContext context)
        {
            if (!string.IsNullOrWhiteSpace(country))
            {
                if (country != "Polska" && country != "Niemcy")
                {
                    return new ValidationResult("Invalid country", new[]
                    {
                        context.MemberName
                    });
                }
            }
            return ValidationResult.Success;
        }
    }
}