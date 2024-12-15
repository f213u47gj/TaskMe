using TaskMe.Model;
using TaskMe.Repository;
using TaskMe.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Requests.Repository;

namespace TaskMe.ViewModel
{
    /// <summary>
    /// ViewModel для редактирования существующей заявки. Реализует логику загрузки, обновления и сохранения заявки.
    /// </summary>
    public class EditRequestViewModel : EditBaseViewModel
    {
        private readonly RequestRepository _requestRepository;
        private readonly ClientRepository _clientRepository;
        private readonly StatusRepository _statusRepository;
        private readonly ExecutorRepository _executorRepository;
        private readonly Request _request;

        /// <summary>
        /// Инициализирует новый экземпляр EditRequestViewModel для редактирования существующей заявки.
        /// </summary>
        /// <param name="request">Заявка, которую необходимо отредактировать.</param>
        /// <param name="requestRepository">Репозиторий для работы с заявками.</param>
        /// <param name="clientRepository">Репозиторий для работы с клиентами.</param>
        /// <param name="statusRepository">Репозиторий для работы со статусами.</param>
        /// <param name="executorRepository">Репозиторий для работы с исполнителями.</param>
        public EditRequestViewModel(Request request, RequestRepository requestRepository, ClientRepository clientRepository, StatusRepository statusRepository, ExecutorRepository executorRepository)
        {
            _clientRepository = clientRepository;
            _requestRepository = requestRepository;
            _statusRepository = statusRepository;
            _executorRepository = executorRepository;
            LoadStatuses();
            EditRequestCommand = new RelayCommand(EditRequest);

            if (request != null)
            {
                _request = request;
                RequestNumber = request.RequestNumber.ToString();
                UpdateAt = DateTime.Now;
                Equipment = request.Equipment;
                Type = request.Type;
                Description = request.Description;
                ClientFullName = request.Client.ClientName;
                ExecutorFullName = request.Executor?.ExecutorName ?? string.Empty;
            }
        }

        /// <summary>
        /// Команда для редактирования заявки.
        /// </summary>
        public ICommand EditRequestCommand { get; }

        /// <summary>
        /// Обработчик редактирования заявки. Проверяет данные, обновляет заявку в базе данных.
        /// </summary>
        /// <param name="parameter">Параметр, обычно окно, которое нужно закрыть после успешного обновления заявки.</param>
        private async void EditRequest(object parameter)
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

                if (int.TryParse(RequestNumber, out int parsedRequestNumber))
                {
                    var request = new Request
                    {
                        RequestId = _request.RequestId,
                        CreateAt = _request.CreateAt,
                        RequestNumber = parsedRequestNumber,
                        UpdateAt = UpdateAt,
                        Equipment = Equipment,
                        Type = Type,
                        Description = Description,
                        Status = Status,
                        Client = client,
                    };

                    if (!string.IsNullOrEmpty(ExecutorFullName))
                    {
                        var executor = await _executorRepository.GetExecutorByFullName(ExecutorFullName);

                        if (executor != null)
                        {
                            request.Executor = executor;
                        }
                        else
                        {
                            MessageBox.Show("Исполнитель с такими инициалами не найден");
                            return;
                        }
                    }

                    if (Status == Statuses.Last())
                    {
                        request.FinishAt = UpdateAt;
                    }
                    else
                    {
                        request.FinishAt = null;
                    }

                    await _requestRepository.UpdateRequest(request);
                    MessageBox.Show("Заявка обновлена");
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
            Status = await _statusRepository.GetStatusById(_request.Status.StatusId);
        }
    }
}
