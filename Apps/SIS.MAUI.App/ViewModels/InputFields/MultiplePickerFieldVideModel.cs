﻿using DotNurse.Injector.Attributes;
using System.Collections;
using System.Xml.Linq;
using UraniumUI.Material.Controls;
using UraniumUI.Resources;

namespace UraniumApp.ViewModels.InputFields;

[RegisterAs(typeof(MultiplePickerFieldVideModel))]
public class MultiplePickerFieldVideModel : SingleControlEditingViewModel<MultiplePickerField>
{
    protected override MultiplePickerField InitializeControl()
    {
        return new MultiplePickerField
        {
            Title = "Pick options",
            ItemsSource = new[]
            {
                "Option 1",
                "Option 2",
                "Option 3",
                "Option 4",
            }
        };
    }
    protected override void PostGenerateSourceCode(XElement control)
    {
        control.SetAttributeValue("ItemsSource", "{Binding Items}");
        control.SetAttributeValue("SelectedItems", "{Binding SelectedItems}");
    }

    protected override void InitializeDefaultValues(Dictionary<string, object> values)
    {
        values.Add(nameof(TextField.TextColor), ColorResource.GetColor("OnBackground", "OnBackgroundDark"));
        values.Add(nameof(TextField.AccentColor), ColorResource.GetColor("Primary", "PrimaryDark"));
        values.Add(nameof(TextField.BorderColor), ColorResource.GetColor("OnBackground", "OnBackgroundDark"));
        values.Add(nameof(TextField.TitleColor), ColorResource.GetColor("OnBackground", "OnBackgroundDark"));
    }

    protected override string FormatValue(object value)
    {
        if (value is IList)
        {
            return null;
        }

        return base.FormatValue(value);
    }
}
