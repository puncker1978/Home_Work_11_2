namespace Home_Work_11_2.Models.Clients
{
    public class Passport
    {
        #region Поля
        private Guid id;
        private DateOnly birthDate;
        private int passportSeries;
        private string passportNumber;
        #endregion

        #region Свойства
        public Guid Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                }
            }
        }
        public DateOnly BirthDate
        {
            get => birthDate;
            set
            {
                if (birthDate != value)
                {
                    birthDate = value;
                }
            }
        }
        public int PassportSeries
        {
            get => passportSeries;
            set
            {
                if (passportSeries != value)
                {
                    passportSeries = value;
                }
            }
        }
        public string PassportNumber
        {
            get => passportNumber;
            set
            {
                if (passportNumber != value)
                {
                    passportNumber = value;
                }
            }
        }
        #endregion

        #region Конструкторы
        public Passport()
        {
        }

        public Passport(int _passportSeries, string _passportNumber, DateOnly _birthDate)
        {
            Id = Guid.NewGuid();
            PassportSeries = _passportSeries;
            PassportNumber = _passportNumber;
            BirthDate = _birthDate;
        }
        #endregion
    }
}
