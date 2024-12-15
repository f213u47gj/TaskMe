using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace TaskMe.ViewModel.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ICommand CloseWindowCommand { get; }

        public BaseViewModel()
        {
            CloseWindowCommand = new RelayCommand(CloseWindow);
        }

        private void CloseWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
