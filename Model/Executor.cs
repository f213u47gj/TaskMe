namespace TaskMe.Model
{
    /// <summary>
    /// Представляет исполнителя в системе TaskMe.
    /// </summary>
    public class Executor
    {
        /// <summary>
        /// Уникальный идентификатор исполнителя.
        /// </summary>
        public int ExecutorId { get; set; }

        /// <summary>
        /// Имя исполнителя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия исполнителя.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Номер телефона исполнителя.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Полное имя исполнителя, составленное из имени и фамилии.
        /// </summary>
        public string ExecutorName
        {
            get => $"{FirstName} {SecondName}";
        }
    }
}