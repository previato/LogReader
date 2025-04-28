using System;

namespace LogReader
{
    public class LogChangedEventArgs : EventArgs 
    {
        public LogChangedEventArgs(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}