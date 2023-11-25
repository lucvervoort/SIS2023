using Microsoft.Maui.Controls.Shapes;
using UraniumUI.Resources;

namespace UraniumApp;

[ContentProperty(nameof(ShowcaseView))]
public class ViewShowcaseView : Border
{
    protected Grid rootGrid = new();
    protected ContentView contentView = new() { HorizontalOptions = LayoutOptions.Start, Padding = 10 };
    protected ContentView sidePanelContentView = new();
    protected ContentView bottomContentView = new();

    public ViewShowcaseView()
    {
        this.SetAppThemeColor(
            BackgroundColorProperty,
            ColorResource.GetColor("Surface", Colors.Gray),
            ColorResource.GetColor("SurfaceDark", Colors.DarkGray));

        sidePanelContentView.SetAppThemeColor(ContentView.BackgroundColorProperty, Color.FromArgb("#25ffffff"), Color.FromArgb("#25000000"));

        StrokeShape = new RoundRectangle
        {
            CornerRadius = 8
        };

        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
        {
            rootGrid.RowDefinitions = (RowDefinitionCollection)new RowDefinitionCollectionTypeConverter().ConvertFrom("Auto,Auto");
            rootGrid.Add(contentView);
            rootGrid.Add(sidePanelContentView, row: 1);
        }
        else
        {
            rootGrid.ColumnDefinitions = (ColumnDefinitionCollection)new ColumnDefinitionCollectionTypeConverter().ConvertFrom("7*,3*");

            rootGrid.Add(contentView);
            rootGrid.Add(sidePanelContentView, column: 1);
        }

        Content = new VerticalStackLayout
        {
            Children =
            {
                rootGrid,
                bottomContentView
            }
        };
    }

    public View ShowcaseView { get => contentView.Content; set => contentView.Content = value; }

    public View SidePanel { get => sidePanelContentView.Content; set => sidePanelContentView.Content = value; }

    public View BottomView { get => bottomContentView.Content; set => bottomContentView.Content = value; }
}
