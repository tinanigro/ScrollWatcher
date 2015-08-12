using System;
using Windows.UI.Xaml.Controls;

namespace ScrollWatcher
{
    public static class ItemsControlHelper
    {
        private static IScrollWatcher _ScrollWatcher;
        public static ScrollViewer RegisterScrollViewer(ItemsControl selector, IScrollWatcher ScrollWatcher)
        {
            _ScrollWatcher = ScrollWatcher;
            ScrollViewer sV = null;
            sV = selector.GetFirstDescendantOfType<ScrollViewer>();
            sV.ViewChanging += ScrollViewerOnViewChanging;
            return sV;
        }

        public static void ScrollViewerOnViewChanging(object sender, ScrollViewerViewChangingEventArgs scrollViewerViewChangingEventArgs)
        {
            var voffset = scrollViewerViewChangingEventArgs.NextView.VerticalOffset;
            if (voffset < 50 || voffset > (_ScrollWatcher.ScrollViewer.ScrollableHeight - 50)) return;

            if (voffset > _ScrollWatcher.Scroll + 30)
            {
                // Scrolling to bottom
                if (_ScrollWatcher.ScrollDirection != ScrollDirection.Bottom)
                {
                    _ScrollWatcher.ScrollDirection = ScrollDirection.Bottom;
                    ScrollingEventArgs e = new ScrollingEventArgs(_ScrollWatcher.ScrollDirection);
                    _ScrollWatcher.InvokeScrollingEvent(e);
                }
                _ScrollWatcher.Scroll = voffset;
            }
            else if (voffset < _ScrollWatcher.Scroll - 30)
            {
                // Scrolling to top
                if (_ScrollWatcher.ScrollDirection != ScrollDirection.Top)
                {
                    _ScrollWatcher.ScrollDirection = ScrollDirection.Top;
                    ScrollingEventArgs e = new ScrollingEventArgs(_ScrollWatcher.ScrollDirection);
                    _ScrollWatcher.InvokeScrollingEvent(e);
                }
                _ScrollWatcher.Scroll = voffset;
            }
        }
    }
}
