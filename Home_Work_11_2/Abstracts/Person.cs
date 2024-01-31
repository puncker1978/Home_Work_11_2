namespace Home_Work_11_2.Abstracts
{
    public abstract class Person
    {
        #region Поля
        private Guid id;
        private string secondName;
        private string firstName;
        private string thirdName;
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
        public string SecondName
        {
            get => secondName;
            set
            {
                if (secondName != value)
                {
                    secondName = value;
                }
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                }
            }
        }
        public string ThirdName
        {
            get => thirdName;
            set
            {
                if (thirdName != value)
                {
                    thirdName = value;
                }
            }
        }
        #endregion

        #region Конструкторы
        protected Person()
        {
        }
        protected Person(string _firstName, string _secondName, string _thirdName)
        {
            Id = Guid.NewGuid();
            FirstName = _firstName;
            SecondName = _secondName;
            ThirdName = _thirdName;
        }
        #endregion
    }
}
