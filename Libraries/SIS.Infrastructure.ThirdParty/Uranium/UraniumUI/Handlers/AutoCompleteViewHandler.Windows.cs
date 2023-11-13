﻿#if WINDOWS
using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml.Controls;
using UraniumUI.Controls;

namespace UraniumUI.Handlers;
public partial class AutoCompleteViewHandler : ViewHandler<IAutoCompleteView, AutoSuggestBox>
{
    protected override AutoSuggestBox CreatePlatformView()
    {
        var textBox = new AutoSuggestBox();

        textBox.ItemsSource = VirtualView.ItemsSource;
        textBox.Text = VirtualView.Text;

        return textBox;
    }

    protected override void ConnectHandler(AutoSuggestBox platformView)
    {
        PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
        PlatformView.FocusVisualPrimaryThickness = new Microsoft.UI.Xaml.Thickness(0);
        PlatformView.FocusVisualSecondaryThickness = new Microsoft.UI.Xaml.Thickness(0);

        PlatformView.TextBoxStyle = null;

        PlatformView.TextChanged += PlatformView_TextChanged;
        PlatformView.KeyDown += TextBox_KeyDown;
        PlatformView.SuggestionChosen += PlatformView_SuggestionChosen;
    }

    protected override void DisconnectHandler(AutoSuggestBox platformView)
    {
        PlatformView.TextChanged -= PlatformView_TextChanged;
        PlatformView.KeyDown -= TextBox_KeyDown;
        PlatformView.SuggestionChosen -= PlatformView_SuggestionChosen;
    }

    private void PlatformView_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (VirtualView.Text != sender.Text)
        {
            VirtualView.Text = sender.Text;
        }

        if (VirtualView.ItemsSource != null)
        {
            PlatformView.ItemsSource = VirtualView.ItemsSource.Where(x => x.Contains(sender.Text));
        }
    }

    private void TextBox_KeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            VirtualView.Completed();
        }
    }
    
    private void PlatformView_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        if (VirtualView.SelectedText != PlatformView.Text)
        {
            VirtualView.SelectedText = args.SelectedItem?.ToString();
        }
    }

    public static void MapText(AutoCompleteViewHandler handler, AutoCompleteView view)
    {
        if (view.Text != handler.PlatformView.Text)
        {
            handler.PlatformView.Text = view.Text;
        }
    }

    public static void MapItemsSource(AutoCompleteViewHandler handler, AutoCompleteView view)
    {
        handler.PlatformView.ItemsSource = view.ItemsSource;
    }
}
#endif