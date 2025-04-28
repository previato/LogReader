using System;

namespace LogReader
{
    public class LogFileChangedEventArgs : EventArgs
    {
        public LogFileChangedEventArgs(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }
    }
}