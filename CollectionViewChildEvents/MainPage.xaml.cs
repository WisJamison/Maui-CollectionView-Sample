using System.Diagnostics;

namespace CollectionViewChildEvents;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        BindingContext = new ViewModel();
        
        InitializeComponent();
    }

    private void OnChildAdded(object sender, ElementEventArgs e)
    {
        Debug.WriteLine($"CollectionView ChildAdded: type is {e.Element.GetType()}");
    }
    
    private void OnChildRemoved(object sender, ElementEventArgs e)
    {
        Debug.WriteLine($"CollectionView ChildRemoved: type is {e.Element.GetType()}");
    }

    private void OnCollectionViewSizedChanged(object sender, EventArgs e)
    {
        Debug.WriteLine($"CollectionView SizeChanged.");
    }
}