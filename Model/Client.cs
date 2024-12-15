namespace TaskMe.Model
{
    /// <summary>
    /// Представляет клиента в системе TaskMe.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Уникальный идентификатор клиента.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия клиента.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Номер телефона клиента.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Полное имя клиента, составленное из имени и фамилии.
        /// </summary>
        public string ClientName
        {
            get => $"{FirstName} {SecondName}";
        }
    }
}
