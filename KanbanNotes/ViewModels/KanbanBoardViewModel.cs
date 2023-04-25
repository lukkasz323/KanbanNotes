using KanbanNotes.Models;

namespace KanbanNotes.ViewModels;

public class KanbanBoardViewModel
{
    private readonly KanbanBoardModel _model = new();

    public List<List<Task>> TaskColumns { get; }

    public KanbanBoardViewModel()
    {
        TaskColumns = _model.GetColumns();
        TaskColumns.Add(new());
        TaskColumns.Add(new());
        TaskColumns.Add(new());
        TaskColumns[1].Add(new());
    }
}
