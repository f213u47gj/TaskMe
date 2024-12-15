using TaskMe.IRepository;
using TaskMe.ViewModel.Base;
using TaskMe.Model;
using TaskMe.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace TaskMe.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly RequestIRepository _requestrepository;
        private ObservableCollection<Request> _requests;
        private Request _selectedRequest;

        public MainViewModel(RequestIRepository requestRepository)
        {
            _requestrepository = requestRepository;
            LoadRequests();
            OpenCreateRequestWindowCommand = new RelayCommand(OpenCreateRequestWindow);
            OpenEditRequestWindowCommand = new RelayCommand(OpenEditRequestWindow);
            RefrashRequestsCommand = new RelayCommand(LoadRequests);
        }

        public ICommand OpenCreateRequestWindowCommand { get; }
        public ICommand OpenEditRequestWindowCommand { get; }
        public ICommand RefrashRequestsCommand { get; }

        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set
            {
                _requests = value;
                OnPropertyChanged(nameof(Requests));
            }
        }

        public Request SelectedRequest
        {
            get => _selectedRequest;
            set
            {
                _selectedRequest = value;
                OnPropertyChanged(nameof(SelectedRequest));
            }
        }

        private async void LoadRequests(object? parameter = null)
        {
            var requests = await _requestrepository.GetRequests();
            Requests = new ObservableCollection<Request>(requests);
        }

        private void OpenCreateRequestWindow(object parameter)
        {
            var createRequestWindow = new CreateRequestWindow();
            createRequestWindow.ShowDialog();
        }

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
