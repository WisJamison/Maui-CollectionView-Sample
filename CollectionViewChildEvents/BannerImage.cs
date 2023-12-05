using CommunityToolkit.Mvvm.ComponentModel;

namespace CollectionViewChildEvents;

public partial class BannerImage : ObservableObject
{
    [ObservableProperty] private int _navBarPositon;
    [ObservableProperty] private ImageSource imageUrl;
    [ObservableProperty] private string imageName;

    [ObservableProperty]
    private string imageDesc = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";

    [ObservableProperty] private bool isSquareView;
    [ObservableProperty] private Color headerColor;
}