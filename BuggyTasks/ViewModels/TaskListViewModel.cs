using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using BuggyTasks.Models;
using BuggyTasks.Services;

namespace BuggyTasks.ViewModels;

public partial class TaskListViewModel : ObservableObject
{
    public ObservableCollection<TaskItem> Tasks => TaskService.Instance.Tasks;

    public TaskListViewModel()
    {
    }
}