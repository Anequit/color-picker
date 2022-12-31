using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace ColorPicker.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _hex = string.Empty;
    
    private int _red;
    private int _blue;
    private int _green;

    public MainWindowViewModel()
    {
        RandomizeHex();
        UpdateHex();
    }

    public int Red
    {
        get => _red;
        set
        {
            SetProperty(ref _red, value);
            UpdateHex();
        }
    }

    public int Green
    {
        get => _green;
        set
        {
            SetProperty(ref _green, value);
            UpdateHex();
        }
    }

    public int Blue
    {
        get => _blue;
        set
        {
            SetProperty(ref _blue, value);
            UpdateHex();
        }
    }

    private void UpdateHex() => Hex = $"#{_red:X2}{_green:X2}{_blue:X2}";

    [RelayCommand]
    private void RandomizeHex()
    {
        Red = Random.Shared.Next(0, 256);
        Blue = Random.Shared.Next(0, 256);
        Green = Random.Shared.Next(0, 256);
    }

    [RelayCommand]
    private async Task CopyHex() => await Application.Current?.Clipboard?.SetTextAsync(Hex)!;
}