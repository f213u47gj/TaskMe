using System.Windows.Input;

namespace TaskMe.ViewModel.Base
{
    /// <summary>
    /// Реализация интерфейса ICommand, представляющая команду с логикой выполнения и проверки возможности выполнения.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute; // Действие для выполнения команды
        private readonly Func<object, bool> _canExecute; // Логика проверки возможности выполнения команды

        /// <summary>
        /// Инициализирует новый экземпляр команды с заданным действием и логикой проверки возможности выполнения.
        /// </summary>
        /// <param name="execute">Действие, которое выполняется при вызове команды.</param>
        /// <param name="canExecute">Функция, проверяющая возможность выполнения команды (необязательно).</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Событие, которое уведомляет об изменении способности выполнения команды.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Определяет, может ли команда быть выполнена.
        /// </summary>
        /// <param name="parameter">Параметры команды.</param>
        /// <returns>Возвращает true, если команда может быть выполнена, иначе false.</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Выполняет команду с переданным параметром.
        /// </summary>
        /// <param name="parameter">Параметры для выполнения команды.</param>
        public void Execute(object? parameter)
        {
            _execute(parameter); // Выполняет действие
        }
    }
}
