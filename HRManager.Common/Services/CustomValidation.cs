using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Common.Services
{
    //https://stackoverflow.com/questions/17321948/is-there-a-rangeattribute-for-datetime
    public class AgeOver14 : RangeAttribute
    {
        public AgeOver14()
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(-200).ToShortDateString(),
                  DateTime.Now.AddYears(-14).ToShortDateString())
        { }
    }

    // https://stackoverflow.com/questions/41900485/custom-validation-attributes-comparing-two-properties-in-the-same-model#41901736
    public class DateLessThan : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateLessThan(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

            if (currentValue > comparisonValue)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
