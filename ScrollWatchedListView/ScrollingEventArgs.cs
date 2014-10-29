using System;

namespace ScrollWatchedSelector
{
    public class ScrollingEventArgs : EventArgs
    {
        public ScrollingType ScrollingType { get; set; }

        public ScrollingEventArgs(ScrollingType eventArgs)
        {
            ScrollingType = eventArgs;
        }
    }
}
