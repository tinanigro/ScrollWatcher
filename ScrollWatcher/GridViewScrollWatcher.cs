using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ScrollWatcher;

namespace ScrollWatcher
{
    public class GridViewScrollWatcher : GridView, IScrollWatcher
    {
        public GridViewScrollWatcher()
        {
            this.Loaded += OnLoaded;
            Scroll = 0;
            ScrollDirection = ScrollDirection.None;
        }
        
        public ScrollViewer ScrollViewer { get; set; }
        public double Scroll { get; set; }
        public ScrollDirection ScrollDirection { get; set; }
        public event Scrolled ScrollDetected;

        public void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            ScrollViewer = ItemsControlHelper.RegisterScrollViewer(sender as GridView, this);
        }

        public void InvokeScrollingEvent(ScrollingEventArgs e)
        {
            if (ScrollDetected != null)
                ScrollDetected(this, e);
        }
    }
}
