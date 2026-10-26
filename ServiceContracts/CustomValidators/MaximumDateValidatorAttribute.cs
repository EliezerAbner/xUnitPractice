using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.CustomValidators;

public class MaximumDateValidatorAttribute : ValidationAttribute
{
    public DateTime MaximumDate {get; set;} = new DateTime(2000, 1, 1);
    public string DefaultErrorMessage { get; set; } = "Date should not be older than Jan 1 2000";

    public MaximumDateValidatorAttribute()
    {
    }
    
    public MaximumDateValidatorAttribute(DateTime maximumDate)
    {
        MaximumDate = maximumDate;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            DateTime date = (DateTime)value;

            return date < MaximumDate
                ? new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MaximumDate))
                : ValidationResult.Success;
        }
        
        return null;
    }
}