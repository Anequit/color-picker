using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;
using System.ComponentModel;

namespace ColorPicker.Avalonia;

public class ViewLocator : IDataTemplate
{
    public IControl Build(object? viewmodel)
    {
        string name = viewmodel!.GetType().FullName!.Replace("ViewModel", "View");
        Type? type = Type.GetType(name);

        if(type != null)
            return (Control)Activator.CreateInstance(type)!;

        return new TextBlock
        {
            Text = "Not Found: " + name
        };
    }

    public bool Match(object? data) => data is INotifyPropertyChanged;
}