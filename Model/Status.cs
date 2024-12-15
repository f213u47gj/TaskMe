namespace TaskMe.Model
{
    /// <summary>
    /// Представляет статус задачи или сущности.
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Получает или задает уникальный идентификатор статуса.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Получает или задает название или описание статуса.
        /// </summary>
        public string Title { get; set; }
    }
}
