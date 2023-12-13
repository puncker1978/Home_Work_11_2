namespace Home_Work_11_2.Models.Clients
{
    public class BankAccount
    {
        public Guid Id { get; set; }

        public decimal Sum { get; set; }

        /// <summary>
        /// Конструктор для создания нового банковского счёта
        /// </summary>
        /// <param name="sum">Начальная сумма на счёте</param>
        public BankAccount(decimal sum)
        {
            Id = Guid.NewGuid();
            Sum = sum;
        }
    }
}
