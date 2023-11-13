﻿using DotNurse.Injector.Attributes;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using UraniumUI.Material.Controls;
using UraniumUI.Resources;

namespace UraniumApp.ViewModels.InputFields;

[RegisterAs(typeof(PickerFieldViewModel))]
public class PickerFieldViewModel : SingleControlEditingViewModel<PickerField>
{

    //Test props
    private ObservableCollection<TestModel> testModels;
    public ObservableCollection<TestModel> TestModels { get { return testModels; } }

    public PickerFieldViewModel()
    {
        testModels = new ObservableCollection<TestModel>()
        {
            new TestModel() {Value = "option1"},
            new TestModel() {Value = "option2"}
        };
    }
    protected override string InitialXDocumentCode => """<ContentPage xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" xmlns:material="http://schemas.enisn-projects.io/dotnet/maui/uraniumui/material"><material:PickerField /></ContentPage>""";

    protected override PickerField InitializeControl()
    {
        return new PickerField
        {
            Title = "Pick an option",
            ItemsSource = new[]
            {
                "Option 1",
                "Option 2",
                "Option 3",
            }
        };
    }

    protected override void PostGenerateSourceCode(XElement control)
    {
        control.SetAttributeValue("ItemsSource", "{Binding Items}");
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

    //Test for picker field using object as bindable property
    public class TestModel
    {
        public string Value { get; set; }
    }
}
