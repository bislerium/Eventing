using System.ComponentModel;
using System.Runtime.CompilerServices;
using MudBlazor.ThemeManager;

namespace Eventing.Web.States;

//See: https://github.com/MudBlazor/ThemeManager/issues/1
public class ThemeInfo : INotifyPropertyChanged
{
    private bool _isDarkMode;

    public bool IsDarkMode
    {
        get => _isDarkMode;
        set => SetField(ref _isDarkMode, value);
    }

    public void ToggleDarkMode()
    {
        this.IsDarkMode = !this.IsDarkMode;
    }

    private bool _isThemeManagerOpen;

    public bool IsThemeManagerOpen
    {
        get => _isThemeManagerOpen;
        set => SetField(ref _isThemeManagerOpen, value);
    }

    private ThemeManagerTheme _themeManager = new();

    public ThemeManagerTheme ThemeManager
    {
        get => _themeManager;
        set => SetField(ref _themeManager, value);
    }

    public void UpdateTheme(ThemeManagerTheme value)
    {
        this.ThemeManager = value;
    }

    public void ToggleThemeManager(bool value)
    {
        this.IsThemeManagerOpen = value;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}