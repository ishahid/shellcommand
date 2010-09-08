using System;

namespace ShellCommand
{
    public class CommandEventArgs : EventArgs 
    {
        public string Output 
        {
            get { return output; }
        }
        private string output;
        
        public bool IsError 
        {
            get { return is_error; }
        }
        private bool is_error;
        
        public CommandEventArgs(string output, bool is_error)
        {
            this.output = output;
            this.is_error = is_error;
        }
        
        public CommandEventArgs(string output) : this(output, false) {}
    }
}
