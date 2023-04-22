using KanbanNotes.Models;

namespace Tests;

public class KanbanBoardModelTests
{
    private readonly KanbanBoardModel _kanbanBoard;

    public KanbanBoardModelTests() 
    {
        _kanbanBoard = new();

        _kanbanBoard.CreateColumn(); // [a]
        _kanbanBoard.CreateColumn(); // [a] [b]
        _kanbanBoard.CreateColumn(); // [a] [b] [c]
        _kanbanBoard.CreateTask(1); // [a] [b1] [c]
        _kanbanBoard.CreateTask(1); // [a] [b12] [c]
        _kanbanBoard.CreateTask(1); // [a] [b123] [c]
        _kanbanBoard.TransferTask(1, 1, 0); // [a2] [b13] [c]
        _kanbanBoard.RemoveColumn(0); // [b13] [c]
    }

    [Fact]
    public void TestClass()
    {
        List<List<Task>>columns = _kanbanBoard.GetColumns();

        Assert.Collection(columns,
            c => Assert.Collection(c,
                task => Assert.NotNull(task),
                task => Assert.NotNull(task)
            ),
            Assert.Empty
        );
    }
}