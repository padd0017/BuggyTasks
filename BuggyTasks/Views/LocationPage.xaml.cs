using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel;

namespace BuggyTasks.Views;

public partial class LocationPage : ContentPage
{
    public LocationPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await GetLastKnownLocationAsync();
    }

    private async void OnGetLastKnownLocation(object sender, EventArgs e)
    {
        await GetLastKnownLocationAsync();
    }

    private async void OnGetCurrentLocation(object sender, EventArgs e)
    {
        await GetCurrentLocationAsync();
    }

    async Task GetLastKnownLocationAsync()
    {
        try
        {
            StatusLabel.Text = "Getting last known location...";
            DisableButtons();

            var location = await Geolocation.GetLastKnownLocationAsync();
            DisplayLocation(location, "Last Known Location");
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Error getting last known location: {ex.Message}";
            ClearLocationInfo();
        }
        finally
        {
            EnableButtons();
        }
    }

    async Task GetCurrentLocationAsync()
    {
        try
        {
            StatusLabel.Text = "Getting current location...";
            DisableButtons();

            var request = new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Medium,
                Timeout = TimeSpan.FromSeconds(10)
            };

            var location = await Geolocation.GetLocationAsync(request);
            DisplayLocation(location, "Current Location");
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Error getting current location: {ex.Message}";
            ClearLocationInfo();
        }
        finally
        {
            EnableButtons();
        }
    }

    private void DisplayLocation(Location location, string locationType)
    {
        
        if (location != null)
        {
            StatusLabel.Text = $"{locationType} Retrieved Successfully";
            LatitudeLabel.Text = $"Latitude: {location.Latitude:F6}";
            LongitudeLabel.Text = $"Longitude: {location.Longitude:F6}";
            AccuracyLabel.Text = $"Accuracy: {location.Accuracy?.ToString("F1") ?? "Unknown"} meters";
            AltitudeLabel.Text = $"Altitude: {location.Altitude?.ToString("F1") ?? "Unknown"} meters";
            TimestampLabel.Text = $"Timestamp: {location.Timestamp:yyyy-MM-dd HH:mm:ss}";
        }
        else
        {
            StatusLabel.Text = $"No {locationType.ToLower()} available";
            ClearLocationInfo();
        }
    }
    private void ClearLocationInfo()
    {
        LatitudeLabel.Text = "Latitude: Not available";
        LongitudeLabel.Text = "Longitude: Not available";
        AccuracyLabel.Text = "Accuracy: Not available";
        AltitudeLabel.Text = "Altitude: Not available";
        TimestampLabel.Text = "Timestamp: Not available";
    }

    private void DisableButtons()
    {
        GetLastKnownButton.IsEnabled = false;
        GetCurrentButton.IsEnabled = false;
    }

    private void EnableButtons()
    {
        GetLastKnownButton.IsEnabled = true;
        GetCurrentButton.IsEnabled = true;
    }
}