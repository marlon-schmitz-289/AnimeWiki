using System.Diagnostics;
using System.Windows.Input;

namespace BaseClasses
{
  public class BaseCommand : ICommand
  {
    readonly Action<object> _execute;
    readonly Predicate<object> _canExecute;



    public BaseCommand(Action<object> execute) : this(execute, null) { }
    public BaseCommand(Action<object> execute, Predicate<object> canExecute)
    {
      if (execute is null)
        throw new ArgumentNullException(nameof(execute));

      _execute = execute;
      _canExecute = canExecute;
    }



    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }



    [DebuggerStepThrough]
    public bool CanExecute(object parameter) => _canExecute is null ? true : _canExecute(parameter);
    public void Execute(object? parameter) => _execute?.Invoke(parameter);
  }
}