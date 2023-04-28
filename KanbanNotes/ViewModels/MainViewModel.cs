namespace KanbanNotes.ViewModels;

public class MainViewModel
{
    public ObservableCollection<ObservableCollection<Task>> TaskColumns { get; set; } = new();

    public MainViewModel()
    {
        TaskColumns.Add(new());
        TaskColumns.Add(new());
        TaskColumns.Add(new());
        TaskColumns[1].Add(new());
    }

    public void CreateColumn() => TaskColumns.Add(new());

    public void RemoveColumn(int index) => TaskColumns.RemoveAt(index);

    public void CreateTask(int columnIndex) => TaskColumns[columnIndex].Add(new());

    public void TransferTask(Task task, ObservableCollection<Task> sourceColumn, ObservableCollection<Task> targetColumn)
    {
        sourceColumn.Remove(task);
        targetColumn.Add(task);
    }
}
