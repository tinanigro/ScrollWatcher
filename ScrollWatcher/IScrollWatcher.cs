using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ScrollWatcher
{
    public delegate void Scrolled(IScrollWatcher lv, EventArgs e);
    public interface IScrollWatcher
    {
        ScrollViewer ScrollViewer { get; set; }
        double Scroll { get; set; }
        ScrollDirection ScrollDirection { get; set; }

        event Scrolled ScrollDetected;

        void OnLoaded(object sender, RoutedEventArgs routedEventArgs);
        void InvokeScrollingEvent(ScrollingEventArgs e);
    }
}
