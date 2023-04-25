using KanbanNotes.Models;

namespace KanbanNotes.ViewModels;

public class MainViewModel
{
    private readonly KanbanBoardModel _model = new();

    public List<List<Task>> TaskColumns { get; }

    public MainViewModel()
    {
        TaskColumns = _model.GetColumns();
        TaskColumns.Add(new());
        TaskColumns.Add(new());
        TaskColumns.Add(new());
        TaskColumns[1].Add(new());
    }
}
