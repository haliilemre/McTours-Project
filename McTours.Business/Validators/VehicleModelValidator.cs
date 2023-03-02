using McTours.Domain;

namespace McTours.Business.Validators
{
    internal class VehicleModelValidator
    {
        public ValidationResult Validate(VehicleModel vehicleModel)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(vehicleModel.Name))
            {
                validationResult.AddError("Araç model adı boş geçilemez");
            }

            if (vehicleModel.VehicleMakeId <= 0) // marka id'si seçilmemişse
            {
                validationResult.AddError("Marka alanı boş geçilemez!");
            }

            return validationResult;
        }
    }
}
