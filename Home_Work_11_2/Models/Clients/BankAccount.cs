namespace Home_Work_11_2.Models.Clients
{
    public class BankAccount
    {
        #region Поля
        private Guid id;
        private decimal sum;
        #endregion

        #region Свойства
        public decimal Sum
        {
            get => sum;
            set
            {
                if (sum != value)
                {
                    sum = value;
                }
            }
        }
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
        #endregion

        #region Конструктор
        public BankAccount()
        {

        }
        /// <summary>
        /// Конструктор для создания нового банковского счёта
        /// </summary>
        /// <param name="sum">Начальная сумма на счёте</param>
        public BankAccount(decimal _sum)
        {
            Id = Guid.NewGuid();
            Sum = _sum;
        }
        #endregion
    }
}
