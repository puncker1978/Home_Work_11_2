namespace Home_Work_11_2.Models
{
    internal class Passport
    {
        internal Guid Id { get; set; }
        internal int PassportSeries { get; set; }
        internal string PassportNumber { get; set; }
        internal DateOnly BirthDate { get; set; }

        public Passport(int passportSeries, string passportNumber, DateOnly birthDate)
        {
            Id = Guid.NewGuid();
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            BirthDate = birthDate;
        }
    }
}
