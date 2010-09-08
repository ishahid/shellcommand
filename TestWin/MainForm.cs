
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ShellCommand
{
    public partial class MainForm : Form
    {
        Thread thread;
        
        public MainForm()
        {
            InitializeComponent();
        }
        
        void Tb_cmdKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                e.Handled = true;
                thread = new Thread(new ThreadStart(this.ExecuteCommand));
                thread.Start();
            }
        }
        
        void Btn_executeClick(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(this.ExecuteCommand));
        	thread.Start();
        }
        
        void ExecuteCommand()
        {
            SetEnabled(false);
            
            string[] tokens = tb_cmd.Text.Split(' ');
            string cmd = tokens[0];
            string args = tb_cmd.Text.Substring(cmd.Length).Trim();
            
            Reset("> " + cmd + " " + args + Environment.NewLine);
            
            ShellCommand shellcmd = new ShellCommand();
            shellcmd.OutputRecieved += new CommandEventHandler(shellcommand_OutputRecieved);
            
            int res = shellcmd.Execute(cmd, args);
            
            AddText("Command finished with exit code " + res);
            SetEnabled(true);
            SetFocus();
        }

        void shellcommand_OutputRecieved(object sender, CommandEventArgs e)
        {
            AddText(e.Output + Environment.NewLine);
        }
        
        void SetEnabled(bool enabled)
        {
            if (tb_cmd.InvokeRequired || btn_execute.InvokeRequired) {
                BeginInvoke(new MethodInvoker(delegate(){SetEnabled(enabled);}));
            } else {
                tb_cmd.Enabled = btn_execute.Enabled = enabled;
            }
        }
        
        void SetFocus()
        {
            if (tb_cmd.InvokeRequired) {
                BeginInvoke(new MethodInvoker(delegate(){SetFocus();}));
            } else {
                tb_cmd.Focus();
                tb_cmd.SelectAll();
            }
        }
        
        void Reset(string text)
        {
            if (tb_result.InvokeRequired) {
                BeginInvoke(new MethodInvoker(delegate(){Reset(text);}));
            } else {
                tb_result.Text = text;
                tb_result.Select(tb_result.Text.Length, 0);
            }
        }
        
        void AddText(string text)
        {
            if (tb_result.InvokeRequired) {
                BeginInvoke(new MethodInvoker(delegate(){AddText(text);}));
            } else {
                tb_result.Text += text;
                tb_result.Select(tb_result.Text.Length, 0);
            }
        }
    }
}
