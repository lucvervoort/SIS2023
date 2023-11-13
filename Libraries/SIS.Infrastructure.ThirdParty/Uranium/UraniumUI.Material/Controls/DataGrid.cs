﻿using Microsoft.Maui.Controls;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace UraniumUI.Material.Controls;

public partial class DataGrid : Frame
{
    private Grid _rootGrid;

    public Type CurrentType { get; protected set; }

    public IList<DataGridColumn> Columns { get; protected set; } = new ObservableCollection<DataGridColumn>();

    public DataGrid()
    {
        _rootGrid = new Grid
        {
            HorizontalOptions = LayoutOptions.Fill
        };

        RenderEmptyView();
        InitializeFactoryMethods();
        this.Padding = new Thickness(0, 10);
        (Columns as INotifyCollectionChanged).CollectionChanged += Columns_CollectionChanged;
    }

    private void OnItemSourceSet(IList oldSource, IList newSource)
    {
        var sourceType = newSource.GetType();
        if (sourceType.GenericTypeArguments.Length != 1)
        {
            throw new InvalidOperationException("DataGrid collection must be a generic typed collection like List<T>.");
        }

        CurrentType = sourceType.GenericTypeArguments.First();

        var columnsAreReady = Columns?.Any() ?? false;

        SetAutoColumns();

        if (oldSource is INotifyCollectionChanged oldObservable)
        {
            oldObservable.CollectionChanged -= ItemsSource_CollectionChanged;
        }

        if (newSource is INotifyCollectionChanged newObservable)
        {
            newObservable.CollectionChanged += ItemsSource_CollectionChanged;
        }

        if (columnsAreReady)
        {
            Render();
        }
    }

    private void ItemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (ItemsSource.Count == 0)
        {
            ResetGrid();
            RenderEmptyView();
            return;
        }

        if (ItemsSource.Count == 1)
        {
            Render();
            return;
        }

        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                {
                    SlideRow(e.NewStartingIndex + 1, 2 * e.NewItems.Count);

                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        AddRow(e.NewStartingIndex + 1 + i, e.NewItems[i], e.NewStartingIndex + i == ItemsSource.Count - 1);
                    }
                }
                break;
            case NotifyCollectionChangedAction.Remove:
                {
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        RemoveRow(e.OldStartingIndex + 1 + i);
                    }

                    SlideRow(e.OldStartingIndex + 1, (-2 * e.OldItems.Count));
                }
                break;
            default:
                // TODO: Optimize
                Render();
                break;
        }
    }

    private void Columns_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        Render();
    }

    protected virtual void SetAutoColumns()
    {
        if (UseAutoColumns)
        {
            if (Columns is INotifyCollectionChanged observable)
            {
                observable.CollectionChanged -= Columns_CollectionChanged;
            }

            Columns = CurrentType?.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(s => new DataGridColumn
                {
                    Title = s.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? s.Name,
                    Binding = new Binding(s.Name),
                    PropertyInfo = s,
                }).ToList();

            Render();
        }
    }

    protected virtual void Render()
    {
        if (Columns == null || Columns.Count == 0 || CurrentType == null)
        {
            return; // Not ready yet.
        }

        if (ItemsSource.Count == 0)
        {
            RenderEmptyView();
            return;
        }

        EnsurePropertyInfosAreSet();

        var tableHeaderRows = 1;
        ResetGrid();
        ConfigureGridColumnDefinitions(Columns.Count);
        ConfigureGridRowDefinitions(ItemsSource.Count + tableHeaderRows);

        AddTableHeaders();

        for (int i = 0; i < ItemsSource.Count; i++)
        {
            var row = i + tableHeaderRows; // +1 is table header.

            AddRow(row, ItemsSource[i], i == ItemsSource.Count - 1);
        }

        RegisterSelectionChanges();
    }

    private void ResetGrid()
    {
        _rootGrid.Clear();
        _rootGrid.Children.Clear();

        if (this.Content != _rootGrid)
        {
            this.Content = _rootGrid;
        }
    }

    protected virtual void AddTableHeaders(int row = 0)
    {
        for (int i = 0; i < Columns.Count; i++)
        {
            var titleView = Columns[i].TitleView
                ?? TitleTemplate?.CreateContent() as View
                ?? LabelFactory("Value")
                ?? CreateLabel("Value");

            if (titleView is Label label)
            {
                label.FontAttributes = FontAttributes.Bold;
            }

            // TODO: Use an attribute to localize it.
            titleView.BindingContext = new
            {
                Value = Columns[i].Title
            };

            _rootGrid.Add(titleView, column: i, row);
        }
    }

    protected virtual void AddRow(int row, object item, bool isLastRow)
    {
        var actualRow = row * 2;

        AddSeparator(actualRow - 1);

        for (int columnNumber = 0; columnNumber < Columns.Count; columnNumber++)
        {
            var binding = Columns[columnNumber].Binding as Binding;

            var path = binding?.Path ?? Columns[columnNumber].PropertyName ?? "Value"; // Backward compatibility.

            var created = (View)Columns[columnNumber].CellItemTemplate?.CreateContent()
                ?? (View)CellItemTemplate?.CreateContent()
                ?? LabelFactory(path) ?? CreateLabel(path);

            var view = new ContentView
            {
                Content = created,
                BindingContext = (CellItemTemplate is null) ? item : new
                {
                    Value = Columns[columnNumber].PropertyInfo.GetValue(item)
                }
            };

            SetSelectionVisualStates(view);

            _rootGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
            _rootGrid.Add(view, columnNumber, row: actualRow);
        }
    }

    protected virtual void RemoveRow(int row)
    {
        var actualRow = row * 2;

        for (int i = 0; i < _rootGrid.Children.Count; i++)
        {
            var child = _rootGrid.Children[i] as View;
            if (Grid.GetRow(child) == actualRow)
            {
                _rootGrid.Children.RemoveAt(i);
                i--;
            }

            if (Grid.GetRow(child) == actualRow - 1 && child is BoxView)
            {
                _rootGrid.Children.RemoveAt(i);
                _rootGrid.RowDefinitions.RemoveAt(actualRow);
                i--;
            }
        }

        _rootGrid.RowDefinitions.RemoveAt(actualRow);

        if (_rootGrid.Children.LastOrDefault() is BoxView box)
        {
            _rootGrid.Children.Remove(box);
            _rootGrid.RowDefinitions.RemoveAt(0);
        }
    }

    protected virtual void AddSeparator(int row)
    {
        var line = HorizontalLineFactory() ?? CreateHorizontalLine();
        _rootGrid.AddWithSpan(line, row, 0, columnSpan: Columns.Count);
    }

    private void ConfigureGridColumnDefinitions(int columns)
    {
        _rootGrid.ColumnDefinitions.Clear();
        for (int i = 0; i < Columns.Count; i++)
        {
            _rootGrid.AddColumnDefinition(new ColumnDefinition(Columns[i].Width));
        }
    }

    private void ConfigureGridRowDefinitions(int rows)
    {
        _rootGrid.RowDefinitions.Clear();
        var actualRows = rows * 2 - 1;

        for (int i = 0; i < actualRows; i++)
        {
            _rootGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
        }
    }

    protected virtual void SlideRow(int row, int amount = 1)
    {
        var actualRow = row * 2;

        foreach (View item in _rootGrid.Children.Where(x => x is View view && Grid.GetRow(view) >= actualRow - 1))
        {
            var newRow = Grid.GetRow(item) + amount;
            Grid.SetRow(item, newRow);
        }
    }

    // TODO: Remove later. [Obsolete]
    protected virtual void EnsurePropertyInfosAreSet()
    {
        foreach (var column in Columns.Where(x => x.PropertyInfo == null && x.PropertyName != null))
        {
            column.PropertyInfo = CurrentType.GetProperty(column.PropertyName);
        }
    }

    protected virtual void OnSelectedItemsSet()
    {
        UpdateSelections();

        if (SelectedItems is INotifyCollectionChanged observable)
        {
            observable.CollectionChanged += (s, e) => UpdateSelections();
        }
    }

    protected void UpdateSelections()
    {
        foreach (View child in _rootGrid.Children)
        {
            if (SelectedItems.Contains(child.BindingContext))
            {
                VisualStateManager.GoToState(child, DataGridCellVisualStates.Selected);
            }
            else
            {
                VisualStateManager.GoToState(child, DataGridCellVisualStates.Unselected);
            }
        }
    }

    protected virtual void RenderEmptyView()
    {
        this.Content = EmptyView ??= (View)EmptyViewTemplate?.CreateContent() ?? new BoxView { HorizontalOptions = LayoutOptions.Fill, Margin = 40 };
    }

    protected virtual void OnEmptyViewTemplateSet()
    {
        if (EmptyViewTemplate != null)
        {
            EmptyView = null;
        }
    }

    protected virtual void OnTitleTemplateChanged()
    {
        if (_rootGrid.Children.Any())
        {
            RemoveRow(0);
            AddTableHeaders();
        }
    }

    private void RegisterSelectionChanges()
    {
        foreach (IDataGridSelectionColumn selection in Columns.Where(x => x is IDataGridSelectionColumn))
        {
            selection.SelectionChanged += SelectionChanged;
        }
    }

    private void SelectionChanged(object sender, bool isSelected)
    {
        if (SelectedItems is null)
        {
            SelectedItems = new ObservableCollection<object>();
        }

        if (sender is View cell && cell.BindingContext is not null)
        {
            if (isSelected)
            {
                if (!SelectedItems.Contains(cell.BindingContext))
                {
                    SelectedItems.Add(cell.BindingContext);
                }
            }
            else
            {
                SelectedItems.Remove(cell.BindingContext);
            }

            OnPropertyChanged(nameof(SelectedItems));
        }
    }

    protected void SetSelectionVisualStatesForAll()
    {
        if (_rootGrid is null)
        {
            return;
        }

        foreach (View child in _rootGrid.Children)
        {
            SetSelectionVisualStates(child);
        }
    }

    protected virtual void SetSelectionVisualStates(View view)
    {
        VisualStateManager.SetVisualStateGroups(view, new VisualStateGroupList
        {
            new VisualStateGroup
            {
                Name = "DataGridSelectionStates",
                States =
                {
                    new VisualState
                    {
                        Name = "Selected",
                        Setters =
                        {
                            new Setter
                            {
                                Property = View.BackgroundColorProperty,
                                Value = SelectionColor.MultiplyAlpha(0.2f)
                            }
                        }
                    },
                    new VisualState
                    {
                        Name = "Unselected",
                        Setters =
                        {
                            new Setter
                            {
                                Property = View.BackgroundColorProperty,
                                Value = Colors.Transparent
                            }
                        }
                    }
                }
            }
        });
    }

    public static class DataGridCellVisualStates
    {
        public const string Selected = "Selected";
        public const string Unselected = "Unselected";
    }

    public class GoToStateTriggerAction : TriggerAction<View>
    {
        public GoToStateTriggerAction(string state)
        {
            State = state;
        }

        public string State { get; protected set; }
        protected override void Invoke(View sender)
        {
            VisualStateManager.GoToState(sender, State);
        }
    }
}
