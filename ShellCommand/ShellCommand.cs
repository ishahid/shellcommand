using System;
using System.Diagnostics;

namespace ShellCommand
{
    public delegate void CommandEventHandler(object sender, CommandEventArgs e);
    
    public class ShellCommand
    {
        public event CommandEventHandler OutputRecieved;
        private bool last_res_null;
        private bool last_err_null;
        
        protected virtual void OnOutputReceived(CommandEventArgs e) 
        {
            if (OutputRecieved != null) 
            {
                OutputRecieved(this, e); 
            }
        }
        
        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data)) {
                OnOutputReceived(new CommandEventArgs(e.Data));
                last_res_null = false;
            } else {
                if (last_res_null) 
                {
                    OnOutputReceived(new CommandEventArgs(e.Data));
                    last_res_null = false;
                } else {
                    last_res_null = true;
                }
            }
        }

        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data)) {
                OnOutputReceived(new CommandEventArgs(e.Data, true));
                last_err_null = false;
            } else {
                if (last_err_null) 
                {
                    OnOutputReceived(new CommandEventArgs(e.Data, true));
                    last_err_null = false;
                } else {
                    last_err_null = true;
                }
            }
        }

        public int Execute(string command, string arguments, string working_dir)
        {
            Process p = new Process();
            if (working_dir != null && working_dir != "")
            {
                p.StartInfo.WorkingDirectory = working_dir;
            }
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = command;
            p.StartInfo.Arguments = arguments;
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            
            int exit_code = 1;
            try
            {
                p.Start();
    
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
    
                p.WaitForExit();
                exit_code = p.ExitCode;
                p.Close();
                return exit_code;
            }
            catch(Exception ex)
            {
                OnOutputReceived(new CommandEventArgs(ex.Message, true));
                return exit_code;
            }
        }
        
        public int Execute(string command, string arguments)
        {
            return Execute(command, arguments, null);
        }
    }
}
