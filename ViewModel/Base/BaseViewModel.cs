using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace TaskMe.ViewModel.Base
{
    /// <summary>
    /// Базовый класс для всех ViewModel, реализующий интерфейс INotifyPropertyChanged.
    /// Предоставляет функциональность для уведомлений о изменении свойств и команду для закрытия окна.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Команда для закрытия окна.
        /// </summary>
        public ICommand CloseWindowCommand { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса BaseViewModel.
        /// </summary>
        public BaseViewModel()
        {
            // Инициализирует команду для закрытия окна
            CloseWindowCommand = new RelayCommand(CloseWindow);
        }

        /// <summary>
        /// Закрывает окно, переданное в параметре.
        /// </summary>
        /// <param name="parameter">Параметр, который должен быть экземпляром окна.</param>
        private void CloseWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.Close(); // Закрывает переданное окно
            }
        }

        /// <summary>
        /// Событие, уведомляющее об изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Метод для вызова события изменения свойства.
        /// </summary>
        /// <param name="propertyName">Название свойства, которое было изменено. По умолчанию использует имя вызывающего свойства.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // Вызывает событие изменения свойства
        }
    }
}
