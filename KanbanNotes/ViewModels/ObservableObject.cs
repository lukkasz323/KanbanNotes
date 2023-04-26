using System.Runtime.CompilerServices;

namespace KanbanNotes.ViewModels;

public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = nameof(CallerMemberNameAttribute)) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}