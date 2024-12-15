using TaskMe.Model;
using System.Collections.ObjectModel;

namespace TaskMe.ViewModel.Base
{
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

        public string RequestNumber
        {
            get => _requestNumber;
            set
            {
                _requestNumber = value;
                OnPropertyChanged(nameof(RequestNumber));
            }
        }

        public DateTime CreateAt
        {
            get => _createAt;
            set
            {
                _createAt = value;
                OnPropertyChanged(nameof(CreateAt));
            }
        }

        public DateTime UpdateAt
        {
            get => _updateAt;
            set
            {
                _updateAt = value;
                OnPropertyChanged(nameof(UpdateAt));
            }
        }

        public string Equipment
        {
            get => _equipment;
            set
            {
                _equipment = value;
                OnPropertyChanged(nameof(Equipment));
            }
        }

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string ClientFullName
        {
            get => _clientFullName;
            set
            {
                _clientFullName = value;
                OnPropertyChanged(nameof(ClientFullName));
            }
        }

        public string ExecutorFullName
        {
            get => _executorFullName;
            set
            {
                _executorFullName = value;
                OnPropertyChanged(nameof(ExecutorFullName));
            }
        }

        public Status Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

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
