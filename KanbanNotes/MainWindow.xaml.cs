﻿using KanbanNotes.ViewModels;

namespace KanbanNotes;

/// <summary> Interaction logic for MainWindow.xaml </summary>
public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel = new();

    public MainWindow()
    {
        InitializeComponent();

        _viewModel.LoadData();
        this.Closing += MainWindow_Closing;

        DataContext = _viewModel;
    }

    private void MainWindow_Closing(object? sender, CancelEventArgs e) => _viewModel.SaveData();

    private void CreateColumn(object sender, RoutedEventArgs e) => _viewModel.CreateColumn();

    private void CreateTask(object sender, RoutedEventArgs e) => _viewModel.CreateTask(0);

    private void TaskColumn_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Middle)
        {
            var taskColumn = (StackPanel)sender;
            var taskColumnContext = (ObservableCollection<Task>)taskColumn.Tag;
            int columnIndex = _viewModel.TaskColumns.IndexOf(taskColumnContext);

            _viewModel.CreateTask(columnIndex);
        }
    }

    private void TaskColumn_Drop(object sender, DragEventArgs e)
    {
        var dropedElement = (Border)e.Data.GetData(typeof(Border));
        var task = (Task)dropedElement.Tag;
        var sourceColumnContext = (ObservableCollection<Task>)FindTaggedParent(dropedElement).Tag;
        var targetColumnContext = (ObservableCollection<Task>)((StackPanel)sender).Tag;

        _viewModel.TransferTask(task, sourceColumnContext, targetColumnContext);
    }

    private void Task_Drag(object sender, MouseButtonEventArgs e)
    {
        var draggedTask = (FrameworkElement)sender;

        DragDrop.DoDragDrop(draggedTask, draggedTask, DragDropEffects.All);
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
