namespace KanbanNotes;

/// <summary> Interaction logic for MainWindow.xaml </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TaskBorder_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var taskBorder = (FrameworkElement)sender;

        DragDrop.DoDragDrop(taskBorder, taskBorder, DragDropEffects.All);
    }

    private void TaskStack_Drop(object sender, DragEventArgs e)
    {
        var draggedTask = (FrameworkElement)e.Data.GetData(typeof(Border));
        var fromPanel = (Panel)draggedTask.Parent;
        var intoPanel = (Panel)sender;

        fromPanel.Children.Remove(draggedTask);
        intoPanel.Children.Add(draggedTask);
    }

    
}
