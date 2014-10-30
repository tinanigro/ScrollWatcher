using System;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.Extensions;

namespace ScrollWatchedSelector
{
    public static class SelectorHelper
    {
        private static IScrollWatchedSelector _scrollWatchedSelector;
        public static ScrollViewer RegisterScrollViewer(ItemsControl selector, IScrollWatchedSelector scrollWatchedSelector)
        {
            _scrollWatchedSelector = scrollWatchedSelector;
            ScrollViewer sV = null;
            sV = selector.GetFirstDescendantOfType<ScrollViewer>();
            sV.ViewChanging += ScrollViewerOnViewChanging;
            return sV;
        }

        public static void ScrollViewerOnViewChanging(object sender, ScrollViewerViewChangingEventArgs scrollViewerViewChangingEventArgs)
        {
            var voffset = scrollViewerViewChangingEventArgs.NextView.VerticalOffset;
            if (voffset < 50 || voffset > (_scrollWatchedSelector.scrollViewer.ScrollableHeight - 50)) return;

            if (voffset > _scrollWatchedSelector.scroll + 30)
            {
                // Scrolling to bottom
                if (_scrollWatchedSelector.scrollingType != ScrollingType.ToBottom)
                {
                    _scrollWatchedSelector.scrollingType = ScrollingType.ToBottom;
                    ScrollingEventArgs e = new ScrollingEventArgs(_scrollWatchedSelector.scrollingType);
                    _scrollWatchedSelector.InvokeScrollingEvent(e);
                }
                _scrollWatchedSelector.scroll = voffset;
            }
            else if (voffset < _scrollWatchedSelector.scroll - 30)
            {
                // Scrolling to top
                if (_scrollWatchedSelector.scrollingType != ScrollingType.ToTop)
                {
                    _scrollWatchedSelector.scrollingType = ScrollingType.ToTop;
                    ScrollingEventArgs e = new ScrollingEventArgs(_scrollWatchedSelector.scrollingType);
                    _scrollWatchedSelector.InvokeScrollingEvent(e);
                }
                _scrollWatchedSelector.scroll = voffset;
            }
        }
    }
}
