using McTours.Domain;

namespace McTours.Business.Validators
{
    internal class PassengerValidator
    {
        public ValidationResult Validate(Passenger passenger)
        {
            var validationResult = new ValidationResult();
            if (string.IsNullOrWhiteSpace(passenger.FirstName))
            {
                validationResult.AddError("İsim boş geçilemez");
            }
            if (string.IsNullOrWhiteSpace(passenger.LastName))
            {
                validationResult.AddError("Soyisim boş geçilemez");
            }
            if (string.IsNullOrWhiteSpace(passenger.IdentityNumber))
            {
                validationResult.AddError("ID boş geçilemez");
            }
            else if (passenger.IdentityNumber.Length > 13)
            {
                validationResult.AddError("ID numarasını yanlış girdiniz");
            }
            else if (passenger.IdentityNumber.Length < 8)
            {
                validationResult.AddError("ID numarasını eksik girdiniz");
            }
            if (passenger.BirthDate >= DateTime.Now)
            {
                validationResult.AddError("Doğum tarihi hatalı girdiniz");
            }
            else if (passenger.BirthDate > DateTime.Now.AddYears(-18)) // +18 can buy
            {
                validationResult.AddError("Bilet satışı sadece 18+ bireyler içindir");
            }
            return validationResult;
        }
    }
}
