namespace Home_Work_11_2.Models.Clients
{
    public class Passport
    {
        public Guid Id { get; set; }
        public int PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public DateOnly BirthDate { get; set; }

        public Passport(int _passportSeries, string _passportNumber, DateOnly _birthDate)
        {
            Id = Guid.NewGuid();
            PassportSeries = _passportSeries;
            PassportNumber = _passportNumber;
            BirthDate = _birthDate;
        }
    }
}
