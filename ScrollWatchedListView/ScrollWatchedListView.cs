using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.Extensions;

namespace ScrollWatchedSelector
{
    public class ScrollWatchedListView : ListView, IScrollWatchedSelector
    {
        public ScrollWatchedListView()
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
            scrollViewer = SelectorHelper.RegisterScrollViewer(sender as ListView, this);
        }

        public void InvokeScrollingEvent(ScrollingEventArgs e)
        {
            GoingTopOrBottom(this, e);
        }
    }
}
