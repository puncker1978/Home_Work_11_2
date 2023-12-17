namespace Home_Work_11_2.Models.Clients
{
    public class Address
    {
        #region Поля
        private Guid id;

        private string town;

        private string street;

        private string houseNumber;

        private string flatNumber;
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
        public string Town
        {
            get => town;
            set
            {
                if (town != value)
                {
                    town = value;
                }
            }
        }
        public string Street
        {
            get => street;
            set
            {
                if (street != value)
                {
                    street = value;
                }
            }
        }
        public string HouseNumber
        {
            get => houseNumber;
            set
            {
                if (houseNumber != value)
                {
                    houseNumber = value;
                }
            }
        }
        public string FlatNumber
        {
            get => flatNumber;
            set
            {
                if (flatNumber != value)
                {
                    flatNumber = value;
                }
            }
        }
        #endregion

        #region Конструкторы
        public Address(string _town, string _street, string _houseNumber, string _flatNumber)
        {
            Id = Guid.NewGuid();
            Town = _town;
            Street = _street;
            HouseNumber = _houseNumber;
            FlatNumber = _flatNumber;
        }
        #endregion
    }
}
