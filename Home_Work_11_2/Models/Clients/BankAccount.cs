namespace Home_Work_11_2.Models.Clients
{
    public class BankAccount
    {
        private Guid id;
        private decimal sum;

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

        /// <summary>
        /// Конструктор для создания нового банковского счёта
        /// </summary>
        /// <param name="sum">Начальная сумма на счёте</param>
        public BankAccount(decimal _sum)
        {
            Id = Guid.NewGuid();
            Sum = _sum;
        }
    }
}
