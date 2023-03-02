using McTours.Domain;

namespace McTours.Business.Validators
{
    internal class TicketValidator
    {
        public ValidationResult Validate(Ticket ticket)
        {
            var validationResult = new ValidationResult();
            if (ticket.SeatNumber <= 0)
            {
                validationResult.AddError("Koltuk seçimi yanlıştır");
            }
            if (ticket.Price == 0)
            {
                validationResult.AddError("Bilet ücreti \"0\" olamaz");
            }
            else if (ticket.Price < 0)
            {
                validationResult.AddError("Bilet ücreti negatif olamaz");
            }
            return validationResult;
        }
    }
}
