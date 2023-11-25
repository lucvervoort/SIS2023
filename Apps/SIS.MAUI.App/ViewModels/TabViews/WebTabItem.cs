using UraniumUI;

namespace UraniumApp.ViewModels.TabViews;

public class WebTabItem : UraniumBindableObject
{
    private string url;
    private string title;

    public WebTabItem(string url = null)
    {
        this.Url = url;
    }

    public string Url
    {
        get => url; set => SetProperty(ref url, value, doAfter: (_url) =>
        {
            if (Uri.TryCreate(_url, UriKind.RelativeOrAbsolute, out Uri uri))
            {
                Title = uri.Host;
            }
        });
    }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public override string ToString()
    {
        return Title;
    }
}