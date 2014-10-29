using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ScrollWatchedSelector;

namespace ScrollWatchedSelector
{
    public class ScrollWatchedGridView : GridView, IScrollWatchedSelector
    {
        public ScrollWatchedGridView()
        {
            this.Loaded += OnLoaded;
            scroll = 0;
            scrollingType = ScrollingType.Nope;
        }


        public ScrollViewer scrollViewer { get; set; }
        public double scroll { get; set; }
        public ScrollingType scrollingType { get; set; }
        public event ToTopOrBottom GoingTopOrBottom;
        public void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            scrollViewer = SelectorHelper.RegisterScrollViewer(sender as GridView, this);
        }

        public void InvokeScrollingEvent(ScrollingEventArgs e)
        {
            GoingTopOrBottom(this, e);
        }
    }
}
