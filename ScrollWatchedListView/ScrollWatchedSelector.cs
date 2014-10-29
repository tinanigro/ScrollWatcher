using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ScrollWatchedSelector
{
    public delegate void ToTopOrBottom(IScrollWatchedSelector lv, EventArgs e);
    public interface IScrollWatchedSelector
    {
        ScrollViewer scrollViewer { get; set; }
        double scroll { get; set; }
        ScrollingType scrollingType { get; set; }

        event ToTopOrBottom GoingTopOrBottom;

        void OnLoaded(object sender, RoutedEventArgs routedEventArgs);
        void InvokeScrollingEvent(ScrollingEventArgs e);
    }
}
