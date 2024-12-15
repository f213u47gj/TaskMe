using TaskMe.Model;
using System.Collections.ObjectModel;

namespace TaskMe.ViewModel.Base
{
    /// <summary>
    /// Базовый класс для ViewModel, который представляет собой сущность, редактируемую в пользовательском интерфейсе.
    /// </summary>
    public class EditBaseViewModel : BaseViewModel
    {
        private string _requestNumber;
        private DateTime _createAt;
        private DateTime _updateAt;
        private string _equipment;
        private string _type;
        private string _description;
        private string _clientFullName;
        private string _executorFullName;
        private Status _status;
        private ObservableCollection<Status> _statuses;

        /// <summary>
        /// Номер запроса.
        /// </summary>
        public string RequestNumber
        {
            get => _requestNumber;
            set
            {
                _requestNumber = value;
                OnPropertyChanged(nameof(RequestNumber));
            }
        }

        /// <summary>
        /// Дата и время создания запроса.
        /// </summary>
        public DateTime CreateAt
        {
            get => _createAt;
            set
            {
                _createAt = value;
                OnPropertyChanged(nameof(CreateAt));
            }
        }

        /// <summary>
        /// Дата и время последнего обновления запроса.
        /// </summary>
        public DateTime UpdateAt
        {
            get => _updateAt;
            set
            {
                _updateAt = value;
                OnPropertyChanged(nameof(UpdateAt));
            }
        }

        /// <summary>
        /// Оборудование, к которому относится запрос.
        /// </summary>
        public string Equipment
        {
            get => _equipment;
            set
            {
                _equipment = value;
                OnPropertyChanged(nameof(Equipment));
            }
        }

        /// <summary>
        /// Тип запроса.
        /// </summary>
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        /// <summary>
        /// Описание запроса.
        /// </summary>
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        /// <summary>
        /// Полное имя клиента, сделавшего запрос.
        /// </summary>
        public string ClientFullName
        {
            get => _clientFullName;
            set
            {
                _clientFullName = value;
                OnPropertyChanged(nameof(ClientFullName));
            }
        }

        /// <summary>
        /// Полное имя исполнителя, ответственного за запрос.
        /// </summary>
        public string ExecutorFullName
        {
            get => _executorFullName;
            set
            {
                _executorFullName = value;
                OnPropertyChanged(nameof(ExecutorFullName));
            }
        }

        /// <summary>
        /// Статус запроса.
        /// </summary>
        public Status Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        /// <summary>
        /// Коллекция всех возможных статусов для запроса.
        /// </summary>
        public ObservableCollection<Status> Statuses
        {
            get => _statuses;
            set
            {
                _statuses = value;
                OnPropertyChanged(nameof(Statuses));
            }
        }
    }
}
