using McTours.Domain;

namespace McTours.Business.Validators
{
    internal class BusTripValidator
    {
        public ValidationResult Validate(BusTrip busTrip)
        {
            var validationResult = new ValidationResult();
            if (busTrip.Date < DateTime.Now.AddMinutes(60)) //Min. 60 mins. later can create a new trip.
            {
                validationResult.AddError("En erken 1 saat sonra Yeni sefer oluşturulabilir");
            }
            if (busTrip.EstimatedTravelTime <= 0)
            {
                validationResult.AddError("Tahmini sefer süresi 0 veya 0'dan küçük bir sayı olamaz");
            }
            if (busTrip.TicketPrice < 0)
            {
                validationResult.AddError("Bilet fiyatı negatif bir sayı olamaz");
            }
            if (busTrip.BreakTimeDuration < 0)
            {
                validationResult.AddError("Mola süresi 0'dan küçük olamaz");
            }
            return validationResult;
        }
    }
}
