namespace Home_Work_11_2.Models
{
    public delegate void AccountHandler(string message);
    internal class BankAccount
    {
        /// <summary>
        /// Номер счёта
        /// </summary>
        private Guid id;

        /// <summary>
        /// Сумма на счёте
        /// </summary>
        private decimal sum;

        /// <summary>
        /// Сумма на счёте
        /// </summary>
        public Guid Id { get; set; }

        public BankAccount(int sum)
        {
            this.Id = Guid.NewGuid();
            this.sum = sum;
        }

        // Создаем переменную делегата
        AccountHandler? taken;


        // Регистрируем делегат
        public void RegisterHandler(AccountHandler del) => taken = del;

        /// <summary>
        /// Метод для пополения баланса банковского счёта
        /// </summary>
        /// <param name="sum"></param>
        public void TopUpAccount(int sum) => this.sum += sum;

        /// <summary>
        /// Метод снятия с банковского счёта
        /// </summary>
        /// <param name="sum"></param>
        public void TopDownAccount(int sum)
        {
            if (this.sum >= sum)
            {
                this.sum -= sum;
                // вызываем делегат, передавая ему сообщение
                taken?.Invoke($"Со счета списано {sum} у.е.");
            }
            else
            {
                taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} у.е.");
            }
        }
    }
}
