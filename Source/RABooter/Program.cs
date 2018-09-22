using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.IO.Pipes;

namespace RABooter
{
    class Program
    {
        static bool isMainApplicationOpen()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.Equals("RA.exe"))
                {
                    return true;
                }
            }
            return false;
        }
        static void launchMainApplication(string exePath)
        {
            Process mainApp = new Process();
            mainApp.StartInfo.UseShellExecute = false;
            mainApp.StartInfo.RedirectStandardOutput = false;
            mainApp.StartInfo.FileName = exePath + "/RA.exe";
            mainApp.StartInfo.Arguments = exePath + "/macro.config";
            Console.WriteLine(mainApp.StartInfo.FileName);
            Console.WriteLine(mainApp.Start());
        }
        private static void sendMessage(string message)
        {
            NamedPipeClientStream pipeClient =
                new NamedPipeClientStream(".", "RABootPipe", PipeDirection.Out, PipeOptions.None, System.Security.Principal.TokenImpersonationLevel.Impersonation);
            Console.WriteLine("Attempting to connect to pipe");
            pipeClient.Connect();
            Console.WriteLine("Successfully connected to pipe. Attempting to write " + message);
            StreamString ss = new StreamString(pipeClient);
            ss.WriteString(message);
            Console.WriteLine("Wrote message to pipe.");
        }
        private class StreamString
        {
            private Stream ioStream;
            private UnicodeEncoding streamEncoding;
            public StreamString(Stream ioStream)
            {
                this.ioStream = ioStream;
                streamEncoding = new UnicodeEncoding();
            }

            public int WriteString(string outString)
            {
                byte[] outBuffer = streamEncoding.GetBytes(outString);
                int length = outBuffer.Length;
                if (length > UInt16.MaxValue)
                {
                    length = (int)UInt16.MaxValue;
                }
                ioStream.WriteByte((byte)(length / 256));
                ioStream.WriteByte((byte)(length & 255));
                ioStream.Write(outBuffer, 0, length);
                ioStream.Flush();
                return outBuffer.Length + 2;
            }
        }
        static void Main(string[] args)
        {
            if (!isMainApplicationOpen())
            {
                launchMainApplication(args[1]);
            }
            sendMessage(args[0]);
        }
    }
}
