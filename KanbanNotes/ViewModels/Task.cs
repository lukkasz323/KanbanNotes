using System.Threading;

namespace KanbanNotes.ViewModels;

public class Task : ObservableObject
{
    private string _text = "New Task";

    public string Text
    { 
        get => _text; 
        set 
        {
            _text = value;
            OnPropertyChanged();
        } 
    }
}