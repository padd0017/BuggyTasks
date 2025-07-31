using Microsoft.Maui.Controls;

namespace BuggyTasks.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    async void OnGoToTaskList(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("TaskListPage");  
    }

    async void OnAddTask(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("NewTaskPage");
    }
    
    async void OnGetLocation(Object sender, EventArgs e)
    {
        await DisplayAlert("Location", "Location feature not implemented yet.", "OK");
    }

    async void OnDeviceInfo(object sender, EventArgs e)
    {
        await DisplayAlert("Device Info", "Device Info feature not implemented yet.", "OK");
    }

    
}