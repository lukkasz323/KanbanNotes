namespace KanbanNotes.Models;

internal class KanbanBoardModel
{
    private readonly List<List<Task>> _columns = new();

    internal List<List<Task>> GetColumns() => new(_columns);

    internal void CreateColumn() => _columns.Add(new());

    internal void RemoveColumn(int index) => _columns.RemoveAt(index);

    internal void CreateTask(int columnIndex) => _columns[columnIndex].Add(new());

    internal void TransferTask(int sourceTaskIndex, int sourceColumnIndex, int targetColumnIndex) 
    {
        List<Task> sourceColumn = _columns[sourceColumnIndex];
        List<Task> targetColumn = _columns[targetColumnIndex];

        Task task = sourceColumn[sourceTaskIndex];
        sourceColumn.RemoveAt(sourceTaskIndex);
        targetColumn.Add(task);
    }
}