namespace Home_Work_11_2.Models.Clients
{
    public delegate void AccountHandler(string message);
    public class BankAccount
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
        /// Номер счёта
        /// </summary>
        internal Guid Id { get => id; set => id = value; }

        /// <summary>
        /// Сумма на счёте
        /// </summary>
        public decimal Sum { get => sum; set => sum = value; }

        /// <summary>
        /// Конструктор для создания нового банковского счёта
        /// </summary>
        /// <param name="sum">Начальная сумма на счёте</param>
        public BankAccount(decimal sum)
        {
            Id = Guid.NewGuid();
            Sum = sum;
        }

        /// <summary>
        /// Конструктор для создания банковского счёта нового клиента
        /// </summary>
        public BankAccount()
        {
            Id = Guid.NewGuid();
            Sum = 0;
        }

        // Создаем переменную делегата
        AccountHandler? taken;

        // Регистрируем делегат
        internal void RegisterHandler(AccountHandler del) => taken = del;

        /// <summary>
        /// Метод для пополения баланса банковского счёта
        /// </summary>
        /// <param name="sum">Сумма пополения счёта</param>
        internal void TopUpAccount(decimal sum) => Sum += sum;

        /// <summary>
        /// Метод снятия с банковского счёта
        /// </summary>
        /// <param name="sum">Сумма снятия со счёта</param>
        internal void TopDownAccount(decimal sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                // вызываем делегат, передавая ему сообщение
                taken?.Invoke($"Со счета списано {sum} у.е.");
            }
            else
            {
                taken?.Invoke($"Недостаточно средств. Баланс: {Sum} у.е.");
            }
        }

        /// <summary>
        /// Метод возвращает баланс на счету
        /// </summary>
        /// <returns>Баланс счёта</returns>
        internal decimal ShowBalance() => Sum;
    }
}
