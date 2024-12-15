using TaskMe.Model;
using TaskMe.IRepository;
using TaskMe.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace TaskMe.ViewModel
{
    public class CreateRequestViewModel : EditBaseViewModel
    {
        private readonly RequestIRepository _requestRepository;
        private readonly ClientIRepository _clientRepository;
        private readonly StatusIRepository _statusRepository;

        public CreateRequestViewModel(RequestIRepository requestRepository, ClientIRepository  clientRepository, StatusIRepository statusRepository)
        {
            _requestRepository = requestRepository;
            _clientRepository = clientRepository;
            _statusRepository = statusRepository;
            LoadStatuses();
            CreateRequestCommand = new RelayCommand(CreateRequest);
            UpdateAt = DateTime.Now;
        }

        public ICommand CreateRequestCommand { get; }

        private async void CreateRequest(object parameter)
        {
            if (parameter is Window window)
            {
                if (string.IsNullOrEmpty(ClientFullName) ||
                    string.IsNullOrEmpty(Equipment) ||
                    string.IsNullOrEmpty(Type) ||
                    string.IsNullOrEmpty(Description))
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля");
                    return;
                }

                var client = await _clientRepository.GetClientByFullName(ClientFullName);

                if (int.TryParse(RequestNumber, out int requestNumber))
                {
                    var request = new Request
                    {
                        RequestNumber = requestNumber,
                        UpdateAt = UpdateAt,
                        Equipment = Equipment,
                        Type = Type,
                        Description = Description,
                        Status = Status,
                        Client = client
                    };
                    await _requestRepository.AddRequest(request);
                    MessageBox.Show("Заявка добавлена");
                    window.Close();
                }
                else
                {
                    MessageBox.Show("Номер заявки должен быть числовым значением");
                }
            }
        }

        private async void LoadStatuses()
        {
            var statuses = await _statusRepository.GetStatuses();
            Statuses = new ObservableCollection<Status>(statuses);
            Status = Statuses.First();
        }
    }
}
