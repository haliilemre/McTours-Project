namespace McTours.Passengers
{
    public class SearchPassengerResult
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string GenderName => EnumHelper.GetGenderName(Gender);
    }
}
