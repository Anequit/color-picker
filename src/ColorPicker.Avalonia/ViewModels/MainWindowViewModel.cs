using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace ColorPicker.Avalonia.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private int _red;
    private int _green;
    private int _blue;
    private string _hex = string.Empty;
    private readonly AsyncRelayCommand _copyHexCommand;
    private readonly RelayCommand _randomizeHex;
    
    public MainWindowViewModel()
    {
        _copyHexCommand = new AsyncRelayCommand(CopyHex);
        _randomizeHex = new RelayCommand(RandomizeHex);

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

    public string Hex
    {
        get => _hex;
        set => SetProperty(ref _hex, value);
    }

    public IAsyncRelayCommand CopyHexCommand => _copyHexCommand;
    
    public IRelayCommand RandomizeHexCommand => _randomizeHex;

    private void UpdateHex() => Hex = $"#{_red:X2}{_green:X2}{_blue:X2}";

    private void RandomizeHex()
    {
        Red = Random.Shared.Next(0, 256);
        Blue = Random.Shared.Next(0, 256);
        Green = Random.Shared.Next(0, 256);
    }

    private async Task CopyHex() => await Application.Current?.Clipboard?.SetTextAsync(Hex)!;
}