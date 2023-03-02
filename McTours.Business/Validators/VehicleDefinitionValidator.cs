using McTours.Domain;

namespace McTours.Business.Validators
{
    internal class VehicleDefinitionValidator
    {
        public ValidationResult Validate(VehicleDefinition vehDefinition)
        {
            var validationResult = new ValidationResult();

            if (vehDefinition.Year > 9999)
            {
                validationResult.AddError("Yıl dört basamaklı olmalıdır!!!");
            }

            if (vehDefinition.LineCount < 10 ||
                vehDefinition.LineCount > 12) // marka id'si seçilmemişse
            {
                validationResult.AddError("Koltuk sırası için 10-11-12 değerleri geçerlidir!!!");
            }

            return validationResult;
        }
    }
}
