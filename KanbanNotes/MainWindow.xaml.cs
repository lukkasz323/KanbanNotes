using KanbanNotes.ViewModels;

namespace KanbanNotes;

/// <summary> Interaction logic for MainWindow.xaml </summary>
public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel = new();

    public MainWindow()
    {
        InitializeComponent();

        DataContext = _viewModel;
    }

    private void Task_Drag(object sender, MouseButtonEventArgs e)
    {
        var draggedTask = (FrameworkElement)sender;

        DragDrop.DoDragDrop(draggedTask, draggedTask, DragDropEffects.All);
    }

    private void TaskColumn_Drop(object sender, DragEventArgs e)
    {
        var dropedElement = (Border)e.Data.GetData(typeof(Border));

        var task = (Task)dropedElement.Tag;
        var sourceColumn = (ObservableCollection<Task>)FindTaggedParent(dropedElement).Tag;
        var targetColumn = (ObservableCollection<Task>)((StackPanel)sender).Tag;

        _viewModel.TransferTask(task, sourceColumn, targetColumn);
    }

    /// <summary> Throws <see cref="NullReferenceException"/> on failure. </summary>
    private FrameworkElement FindTaggedParent(FrameworkElement element)
    {
        var parent = (FrameworkElement)VisualTreeHelper.GetParent(element);

        if (parent.Tag != null)
        {
            return parent;
        }
        return FindTaggedParent(parent);
    }
}
