using TaskMe.Model;
using TaskMe.IRepository;
using TaskMe.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace TaskMe.ViewModel
{
    /// <summary>
    /// ViewModel для создания новой заявки. Реализует логику обработки данных заявки и взаимодействия с репозиториями.
    /// </summary>
    public class CreateRequestViewModel : EditBaseViewModel
    {
        private readonly RequestIRepository _requestRepository; // Репозиторий для работы с заявками
        private readonly ClientIRepository _clientRepository; // Репозиторий для работы с клиентами
        private readonly StatusIRepository _statusRepository; // Репозиторий для работы со статусами

        /// <summary>
        /// Инициализирует новый экземпляр CreateRequestViewModel.
        /// </summary>
        /// <param name="requestRepository">Репозиторий для работы с заявками.</param>
        /// <param name="clientRepository">Репозиторий для работы с клиентами.</param>
        /// <param name="statusRepository">Репозиторий для работы со статусами.</param>
        public CreateRequestViewModel(RequestIRepository requestRepository, ClientIRepository clientRepository, StatusIRepository statusRepository)
        {
            _requestRepository = requestRepository;
            _clientRepository = clientRepository;
            _statusRepository = statusRepository;
            LoadStatuses(); // Загружает доступные статусы для заявки
            CreateRequestCommand = new RelayCommand(CreateRequest); // Инициализирует команду для создания заявки
            UpdateAt = DateTime.Now; // Устанавливает текущую дату и время как дату последнего обновления
        }

        /// <summary>
        /// Команда для создания новой заявки.
        /// </summary>
        public ICommand CreateRequestCommand { get; }

        /// <summary>
        /// Обработчик создания новой заявки. Проверяет данные, создает заявку и сохраняет её в базе данных.
        /// </summary>
        /// <param name="parameter">Параметр, обычно окно, которое нужно закрыть после успешного добавления заявки.</param>
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

        /// <summary>
        /// Загружает список всех статусов для заявки.
        /// </summary>
        private async void LoadStatuses()
        {
            var statuses = await _statusRepository.GetStatuses();
            Statuses = new ObservableCollection<Status>(statuses);
            Status = Statuses.First();
        }
    }
}
