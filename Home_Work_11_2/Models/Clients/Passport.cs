namespace Home_Work_11_2.Models.Clients
{
    public class Passport
    {
        public Guid Id { get; set; }
        public int PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public DateOnly BirthDate { get; set; }

        public Passport(int passportSeries, string passportNumber, DateOnly birthDate)
        {
            Id = Guid.NewGuid();
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            BirthDate = birthDate;
        }
    }
}
