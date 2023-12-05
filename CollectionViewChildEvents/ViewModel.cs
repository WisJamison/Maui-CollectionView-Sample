using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Swordfish.NET.Collections;
using Swordfish.NET.Collections.Auxiliary;

namespace CollectionViewChildEvents;

public partial class ViewModel : ObservableObject
{
    public ConcurrentObservableDictionary<BannerImage, int> ImageList { get; } = new();
    private KeyValuePair<BannerImage, int> _itemBeingDragged;

    public ViewModel()
    {
        GetImageList();
    }

    [RelayCommand]
    public void ItemDragged(KeyValuePair<BannerImage, int> user)
    {
        Debug.WriteLine($"ItemDragged : {user.Key.ImageName}");
        _itemBeingDragged = user;
    }

    [RelayCommand]
    public void ItemDraggedOver(KeyValuePair<BannerImage, int> user)
    {
        Debug.WriteLine($"ItemDraggedOver : {user.Key.ImageName}");
        try
        {
            var itemToMove = _itemBeingDragged;
            var itemToInsertBefore = user;
            if (itemToMove.Key == null || itemToInsertBefore.Key == null || itemToMove.Key.ImageName.Equals(
                    itemToInsertBefore.Key.ImageName))
                return;
            //List<BannerImage> images = ImageList.Keys.ToList();
            int insertAtIndex = ImageList.IndexOf(kv => kv.Equals(itemToInsertBefore));
            if (insertAtIndex >= 0 && insertAtIndex < ImageList.Count)
            {
                ImageList.Remove(itemToMove);
                ImageList.Insert(insertAtIndex, itemToMove);
                Debug.WriteLine($"Moved {itemToMove} to {insertAtIndex}");
            }

            Debug.WriteLine(
                $"ItemDropped: [{itemToMove.Key.ImageName}] => [{itemToInsertBefore.Key.ImageName}], target index = [{insertAtIndex}]");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    public void AddNewItem()
    {
        ImageList.Add(new BannerImage(){ImageName = "New"}, 5);
    }

    [RelayCommand]
    public void RemoveItem()
    {
        ImageList.RemoveAt(0);
    }

    public void GetImageList()
    {
        ImageList.Add(new BannerImage()
        {
            HeaderColor = Color.FromArgb("#F7DC6F"),
            ImageName = "img1",
            ImageUrl = ImageSource.FromFile("img6.jpg")
        }, 1);
        ImageList.Add(new BannerImage()
        {
            HeaderColor = Color.FromArgb("#7DCEA0"),
            ImageName = "img2",
            ImageUrl = ImageSource.FromFile("img7.jpg")
        }, 2);
        ImageList.Add(new BannerImage()
        {
            HeaderColor = Color.FromArgb("#7FB3D5"),
            ImageName = "img3",
            ImageUrl = ImageSource.FromFile("img8.jpeg")
        }, 3);
        ImageList.Add(new BannerImage()
        {
            HeaderColor = Color.FromArgb("#00FF00"),
            ImageName = "img4",
            ImageUrl = ImageSource.FromFile("gif4.gif")
        }, 4);
    }
}