using TaskMe.IRepository;
using TaskMe.ViewModel.Base;
using TaskMe.Model;
using TaskMe.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace TaskMe.ViewModel
{
    /// <summary>
    /// Главный ViewModel для отображения и управления заявками.
    /// Реализует логику загрузки заявок, открытия окон для создания и редактирования заявок.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private readonly RequestIRepository _requestrepository;
        private ObservableCollection<Request> _requests;
        private Request _selectedRequest;

        /// <summary>
        /// Инициализирует новый экземпляр MainViewModel и загружает заявки.
        /// </summary>
        /// <param name="requestRepository">Репозиторий для работы с заявками.</param>
        public MainViewModel(RequestIRepository requestRepository)
        {
            _requestrepository = requestRepository;
            LoadRequests();
            OpenCreateRequestWindowCommand = new RelayCommand(OpenCreateRequestWindow);
            OpenEditRequestWindowCommand = new RelayCommand(OpenEditRequestWindow);
            RefrashRequestsCommand = new RelayCommand(LoadRequests);
        }

        /// <summary>
        /// Команда для открытия окна создания новой заявки.
        /// </summary>
        public ICommand OpenCreateRequestWindowCommand { get; }

        /// <summary>
        /// Команда для открытия окна редактирования выбранной заявки.
        /// </summary>
        public ICommand OpenEditRequestWindowCommand { get; }

        /// <summary>
        /// Команда для обновления списка заявок.
        /// </summary>
        public ICommand RefrashRequestsCommand { get; }

        /// <summary>
        /// Список заявок, который будет отображаться в UI.
        /// </summary>
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set
            {
                _requests = value;
                OnPropertyChanged(nameof(Requests));
            }
        }

        /// <summary>
        /// Выбранная заявка.
        /// </summary>
        public Request SelectedRequest
        {
            get => _selectedRequest;
            set
            {
                _selectedRequest = value;
                OnPropertyChanged(nameof(SelectedRequest));
            }
        }

        /// <summary>
        /// Загружает все заявки из репозитория и обновляет список.
        /// </summary>
        /// <param name="parameter">Дополнительный параметр (не используется в этом случае).</param>
        private async void LoadRequests(object? parameter = null)
        {
            var requests = await _requestrepository.GetRequests();
            Requests = new ObservableCollection<Request>(requests);
        }

        /// <summary>
        /// Открывает окно для создания новой заявки.
        /// </summary>
        /// <param name="parameter">Параметр, который может быть передан в команду (не используется в этом случае).</param>
        private void OpenCreateRequestWindow(object parameter)
        {
            var createRequestWindow = new CreateRequestWindow();
            createRequestWindow.ShowDialog();
        }

        /// <summary>
        /// Открывает окно для редактирования выбранной заявки.
        /// </summary>
        /// <param name="parameter">Параметр, содержащий выбранную заявку для редактирования.</param>
        private void OpenEditRequestWindow(object parameter)
        {
            if (parameter is not Request selectedRequest)
            {
                MessageBox.Show("Выберите заявку для редактирования.");
                return;
            }

            var editRequestWindow = new EditRequestWindow(_selectedRequest);
            editRequestWindow.ShowDialog();
        }
    }
}
