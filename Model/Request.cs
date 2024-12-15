using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMe.Model
{
    /// <summary>
    /// Представляет запрос в системе TaskMe.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Уникальный идентификатор запроса.
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        /// Номер запроса.
        /// </summary>
        public int RequestNumber { get; set; }

        /// <summary>
        /// Оборудование, указанное в запросе.
        /// </summary>
        public string Equipment { get; set; }

        /// <summary>
        /// Тип запроса.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Описание запроса.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата и время создания запроса.
        /// </summary>
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// Дата и время последнего обновления запроса.
        /// </summary>
        public DateTime UpdateAt { get; set; }

        /// <summary>
        /// Дата и время завершения запроса (если завершён).
        /// </summary>
        public DateTime? FinishAt { get; set; }

        /// <summary>
        /// Идентификатор статуса запроса.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Объект статуса, связанный с запросом.
        /// </summary>
        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        /// <summary>
        /// Идентификатор клиента, связанного с запросом.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Объект клиента, связанный с запросом.
        /// </summary>
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        /// <summary>
        /// Идентификатор исполнителя, связанного с запросом (если назначен).
        /// </summary>
        public int? ExecutorId { get; set; }

        /// <summary>
        /// Объект исполнителя, связанный с запросом (если назначен).
        /// </summary>
        [ForeignKey("ExecutorId")]
        public Executor Executor { get; set; }
    }
}
