using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Net_Bootcamp_Asp_Exo.Validations
{
    public class OptionalPasswordRegexAttribute : ValidationAttribute
    {

        private const string _pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!]).{8,25}$";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;


            if (string.IsNullOrWhiteSpace(password))
            {
                return ValidationResult.Success;
            }

            if (!Regex.IsMatch(password, _pattern))
            {
                return new ValidationResult(ErrorMessage ??
                    "Le mot de passe doit contenir au moins 1 Maj, 1 Min, 1 chiffre, 1 char spécial (8 à 25 caractères).");
            }

            return ValidationResult.Success;
        }
    }
}
