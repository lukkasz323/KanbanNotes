namespace KanbanNotes;

/// <summary> Interaction logic for MainWindow.xaml </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TaskColumn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        //var taskBorder = (FrameworkElement)sender;

        //DragDrop.DoDragDrop(taskBorder, taskBorder, DragDropEffects.All);
    }

    private void TaskColumn_Drop(object sender, DragEventArgs e)
    {
        //var draggedTask = (FrameworkElement)e.Data.GetData(typeof(Border));
        //var sourcePanel = (Panel)draggedTask.Parent;
        //var targetPanel = (Panel)sender;

        //sourcePanel.Children.Remove(draggedTask);
        //targetPanel.Children.Add(draggedTask);
    }
}
