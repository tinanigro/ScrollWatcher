using System;

namespace ScrollWatcher
{
    public class ScrollingEventArgs : EventArgs
    {
        public ScrollDirection ScrollDirection { get; set; }

        public ScrollingEventArgs(ScrollDirection eventArgs)
        {
            ScrollDirection = eventArgs;
        }
    }
}
