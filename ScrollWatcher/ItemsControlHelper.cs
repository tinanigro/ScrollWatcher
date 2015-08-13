using System;
using Windows.UI.Xaml.Controls;

namespace ScrollWatcher
{
    public static class ItemsControlHelper
    {
        private static IScrollWatcher _scrollWatcher;
        public static ScrollViewer RegisterScrollViewer(ItemsControl selector, IScrollWatcher scrollWatcher)
        {
            _scrollWatcher = scrollWatcher;
            ScrollViewer sV = null;
            sV = selector.GetFirstDescendantOfType<ScrollViewer>();
            sV.ViewChanging += ScrollViewerOnViewChanging;
            return sV;
        }

        public static void ScrollViewerOnViewChanging(object sender, ScrollViewerViewChangingEventArgs scrollViewerViewChangingEventArgs)
        {
            var voffset = scrollViewerViewChangingEventArgs.NextView.VerticalOffset;
            if (voffset < 50 || voffset > (_scrollWatcher.ScrollViewer.ScrollableHeight - 50)) return;

            if (voffset > _scrollWatcher.Scroll + 30)
            {
                // Scrolling to bottom
                if (_scrollWatcher.ScrollDirection != ScrollDirection.Bottom)
                {
                    _scrollWatcher.ScrollDirection = ScrollDirection.Bottom;
                    ScrollingEventArgs e = new ScrollingEventArgs(_scrollWatcher.ScrollDirection);
                    _scrollWatcher.InvokeScrollingEvent(e);
                }
                _scrollWatcher.Scroll = voffset;
            }
            else if (voffset < _scrollWatcher.Scroll - 30)
            {
                // Scrolling to top
                if (_scrollWatcher.ScrollDirection != ScrollDirection.Top)
                {
                    _scrollWatcher.ScrollDirection = ScrollDirection.Top;
                    ScrollingEventArgs e = new ScrollingEventArgs(_scrollWatcher.ScrollDirection);
                    _scrollWatcher.InvokeScrollingEvent(e);
                }
                _scrollWatcher.Scroll = voffset;
            }
        }
    }
}
