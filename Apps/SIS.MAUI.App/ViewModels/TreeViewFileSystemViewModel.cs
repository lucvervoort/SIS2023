﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using UraniumUI;

namespace UraniumApp.ViewModels;
public class TreeViewFileSystemViewModel : UraniumBindableObject
{
    public ObservableCollection<NodeItem> Nodes { get; private set; }

    public ICommand LoadChildrenCommand { get; set; }

    public TreeViewFileSystemViewModel()
    {
        InitializeNodes();
        LoadChildrenCommand = new Command<NodeItem>((node) =>
        {
            try
            {
                foreach (var item in GetContent(node.Path))
                {
                    node.Children.Add(item);
                }

                if (node.Children.Count == 0)
                {
                    node.IsLeaf = true;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        });
    }

    void InitializeNodes()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            path = "C:\\";
        }

        Nodes = new ObservableCollection<NodeItem>(
            GetContent(path));
    }

    IEnumerable<NodeItem> GetContent(string dir)
    {
        var directories = Directory.GetDirectories(dir);
        foreach (string d in directories)
        {
            yield return new NodeItem
            {
                Name = d.Split(Path.DirectorySeparatorChar).LastOrDefault(),
                Path = d,
                IsDirectory = true,
                IsLeaf = false,
            };
        }
        var files = Directory.GetFiles(dir);

        foreach (string f in files)
        {
            var node = new NodeItem
            {
                Name = f.Split(Path.DirectorySeparatorChar).LastOrDefault(),
                Path = f,
                IsDirectory = false,
                IsLeaf = true,
            };
            yield return node;
        }
    }

    public class NodeItem : UraniumBindableObject
    {
        private bool isLeaf;

        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsDirectory { get; set; }
        public bool IsLeaf { get => isLeaf; set => SetProperty(ref isLeaf, value); }
        public ObservableCollection<NodeItem> Children { get; } = new();
    }
}
