using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ScrollWatcher
{
    public class ListViewScrollWatcher : ListView, IScrollWatcher
    {
        public ListViewScrollWatcher()
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
            ScrollViewer = ItemsControlHelper.RegisterScrollViewer(sender as ListView, this);
        }

        public void InvokeScrollingEvent(ScrollingEventArgs e)
        {
            if (ScrollDetected != null)
                ScrollDetected(this, e);
        }
    }
}
