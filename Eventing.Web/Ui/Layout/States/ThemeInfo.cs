using MudBlazor.ThemeManager;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Eventing.Web.Ui.Layout.States;

//See: https://github.com/MudBlazor/ThemeManager/issues/1
public class ThemeInfo : INotifyPropertyChanged
{
    private bool _isDarkMode;

    public bool IsDarkMode
    {
        get => this._isDarkMode;
        set => this.SetField(ref this._isDarkMode, value);
    }

    public void ToggleDarkMode()
    {
        this.IsDarkMode = !this.IsDarkMode;
    }

    private bool _isThemeManagerOpen;

    public bool IsThemeManagerOpen
    {
        get => this._isThemeManagerOpen;
        set => this.SetField(ref this._isThemeManagerOpen, value);
    }

    private ThemeManagerTheme _themeManager = new();

    public ThemeManagerTheme ThemeManager
    {
        get => this._themeManager;
        set => this.SetField(ref this._themeManager, value);
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
        this.OnPropertyChanged(propertyName);
        return true;
    }
}