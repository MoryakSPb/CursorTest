using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CursorTest;

public class CursorViewModel : INotifyPropertyChanged
{
    private MyCursor _selectedCursor;

    public CursorViewModel()
    {
        SelectCursorCommand = new ActionCommand(x => SelectedCursor = (MyCursor)(x ?? MyCursor.Arrow));
    }

    public ICommand SelectCursorCommand { get; }

    public MyCursor SelectedCursor
    {
        get => _selectedCursor;
        set
        {
            _selectedCursor = value;
            OnPropertyChanged(nameof(SelectedCursor));
            OnPropertyChanged(nameof(CursorContent));
        }
    }

    public Cursor CursorContent => SelectedCursor switch
    {
        MyCursor.Arrow => Cursors.Arrow,
        MyCursor.Pen => Cursors.Pen,
        MyCursor.Help => Cursors.Help,
        MyCursor.UpArrow => Cursors.UpArrow,
        MyCursor.Green => CustomCursors.GreenCursor,
        MyCursor.GreenWithDpiScale => CustomCursors.GreenCursorWithDpiScale,
        MyCursor.Yellow => CustomCursors.YellowCursor,
        MyCursor.YellowWithDpiScale => CustomCursors.YellowCursorWithDpiScale,
        _ => throw new ArgumentOutOfRangeException(),
    };

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new(propertyName));
}