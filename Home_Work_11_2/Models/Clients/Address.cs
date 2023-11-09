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
        public Guid Id { get => id; set => id = value; }
        public string Town { get => town; set => town = value; }
        public string Street { get => street; set => street = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string FlatNumber { get => flatNumber; set => flatNumber = value; }
        #endregion

        #region Конструкторы
        public Address(string town, string street, string houseNumber, string flatNumber)
        {
            Id = Guid.NewGuid();
            Town = town;
            Street = street;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
        }

        public Address()
        {
        }
        #endregion
    }
}
