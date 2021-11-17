using System;
using System.Windows.Input;

namespace CursorTest;

public class ActionCommand : ICommand
{
    private readonly Func<object?, bool> _canExecuteAction;
    private readonly Action<object?> _executeAction;

    public ActionCommand(Action<object?> executeAction, Func<object?, bool>? canExecuteAction = null)
    {
        _canExecuteAction = canExecuteAction ?? (_ => true);
        _executeAction = executeAction;
    }

    public bool CanExecute(object? parameter) => _canExecuteAction(parameter);

    public void Execute(object? parameter) => _executeAction(parameter);

    public event EventHandler? CanExecuteChanged;
}