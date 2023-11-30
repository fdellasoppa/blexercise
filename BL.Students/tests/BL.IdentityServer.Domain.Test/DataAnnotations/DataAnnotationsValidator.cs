using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace BL.IdentityServer.Domain.Test.DataAnnotations
{
    internal class DataAnnotationsValidator
    {
        internal static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        internal static ValidationResult? FindError(
            object model,
            string memberName,
            string errorMessagePart)
        {
            var validations = ValidateModel(model);
            return validations.FirstOrDefault(v =>
                v.ErrorMessage is not null
                && v.MemberNames.Contains(memberName)
                && v.ErrorMessage.Contains(errorMessagePart));
        }
    }
}
