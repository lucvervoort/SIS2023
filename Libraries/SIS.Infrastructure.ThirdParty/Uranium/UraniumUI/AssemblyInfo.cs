﻿using UraniumUI;

[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.NamespacePrefix + nameof(UraniumUI.Controls))]
[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.NamespacePrefix + nameof(UraniumUI.Pages))]
[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.NamespacePrefix + nameof(UraniumUI.Resources))]
[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.NamespacePrefix + nameof(UraniumUI.Theming))]
[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.NamespacePrefix + nameof(UraniumUI.Triggers))]
[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.NamespacePrefix + nameof(UraniumUI.Views))]
[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.NamespacePrefix + nameof(UraniumUI.ViewExtensions))]

[assembly: Microsoft.Maui.Controls.XmlnsPrefix(Constants.XamlNamespace, "uranium")]

namespace UraniumUI;
public static class Constants
{
    public const string XamlNamespace = "http://schemas.enisn-projects.io/dotnet/maui/uraniumui";

    public const string NamespacePrefix = $"{nameof(UraniumUI)}.";
}