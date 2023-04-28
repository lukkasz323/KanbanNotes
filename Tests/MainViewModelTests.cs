using KanbanNotes.ViewModels;

namespace Tests;

public class MainViewModelTests
{
    private readonly MainViewModel _mainViewModel;

    public MainViewModelTests() 
    {
        _mainViewModel = new();

        _mainViewModel.CreateColumn(); // [a]
        _mainViewModel.CreateColumn(); // [a] [b]
        _mainViewModel.CreateColumn(); // [a] [b] [c]
        _mainViewModel.CreateTask(1); // [a] [b1] [c]
        _mainViewModel.CreateTask(1); // [a] [b12] [c]
        _mainViewModel.CreateTask(1); // [a] [b123] [c]
        _mainViewModel.TransferTask(
            task: _mainViewModel.TaskColumns[1][1], 
            sourceColumn: _mainViewModel.TaskColumns[1], 
            targetColumn: _mainViewModel.TaskColumns[0]); // [a2] [b13] [c]
        _mainViewModel.RemoveColumn(0); // [b13] [c]
    }

    [Fact]
    public void TestClass() => Assert.Collection(_mainViewModel.TaskColumns,
            c => Assert.Collection(c,
                task => Assert.NotNull(task),
                task => Assert.NotNull(task)
            ),
            Assert.Empty
        );
}