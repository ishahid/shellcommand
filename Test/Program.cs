using System;

namespace ShellCommand
{
    class Program
    {
        public static void Main(string[] args)
        {
            ShellCommand shellcmd = new ShellCommand();
            shellcmd.OutputRecieved += new CommandEventHandler(shellcommand_OutputRecieved);
            
            int res = shellcmd.Execute("ping", "172.21.14.64");
            
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Command finished with exit code " + res);
            Console.ReadKey(true);
        }

        static void shellcommand_OutputRecieved(object sender, CommandEventArgs e)
        {
            if (e.IsError) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Output);
            } else {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(e.Output);
            }
        }
    }
}