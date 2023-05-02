using Microsoft.Win32;
using System.IO;
using System.Text.Json;

namespace KanbanNotes.ViewModels;

public class MainViewModel
{
    public ObservableCollection<ObservableCollection<Task>> TaskColumns { get; set; } = new();

    internal string SaveDataPath { get; } = "saveData.json";

    internal void CreateColumn() => TaskColumns.Add(new());

    internal void RemoveColumn(int index) => TaskColumns.RemoveAt(index);

    internal void CreateTask(int columnIndex) => TaskColumns[columnIndex].Add(new());

    internal void TransferTask(Task task, ObservableCollection<Task> sourceColumn, ObservableCollection<Task> targetColumn)
    {
        sourceColumn.Remove(task);
        targetColumn.Add(task);
    }

    internal void SaveData() => 
        File.WriteAllText(SaveDataPath, JsonSerializer.Serialize(TaskColumns));

    internal bool LoadData()
    {
        string jsonSaveData;
        try
        {
           jsonSaveData = File.ReadAllText(SaveDataPath);
        }
        catch (FileNotFoundException)
        {
            return false;
        }
        ObservableCollection<ObservableCollection<Task>>? saveData = 
            JsonSerializer.Deserialize<ObservableCollection<ObservableCollection<Task>>>(jsonSaveData);
        if (saveData != null)
        {
            TaskColumns = saveData;
        }
        return true;
    }
}
