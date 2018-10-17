using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Balbet.WEB.Filters
{
    public class BirthDayAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "U must be older than 18";
        private DateTime ValidAge { get; set; }

        public BirthDayAttribute(int validAge)
        {
            ValidAge = new DateTime(DateTime.Now.Year - validAge, DateTime.Now.Month, DateTime.Now.Day);
            ErrorMessage = DefaultErrorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                var isValid = ValidAge >= date;
                if (isValid)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessageString);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "birthday",
                ErrorMessage = ErrorMessageString
            };
            rule.ValidationParameters.Add("validage", ValidAge);
            yield return rule;
        }
    }
}