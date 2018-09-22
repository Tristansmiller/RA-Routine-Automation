using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RA_Application
{
    class RoutineListener
    {

        [DllImport(@"RAInternals.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern void executeAutomatedRoutine([MarshalAs(UnmanagedType.LPStr)]string filePath, float speed, int loops);
        [DllImport(@"RAInternals.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern void interruptInterpreterSequence(int[] macroKeys);
        //Thread that hosts the namedpipeserver
        private static Thread scheduleServer;
        //Pipeserver that RABooter uses to communicate with the main app
        private static NamedPipeServerStream pipeServer;
        //flag to signal interrupt from another thread
        private static bool interruptFlag = false;
        public static void Start(int[] macroKeys)
        {
            int i = 1;
            scheduleServer = new Thread(()=> { ScheduleThread(macroKeys); }) ;
            scheduleServer.Start();
        }
        public static void Stop()
        {
            interruptFlag = true;
            //creates a fake client to force the server thread past the WaitForConnection() function.
            NamedPipeClientStream interruptClient =
                new NamedPipeClientStream(".", "RABootPipe", PipeDirection.Out, PipeOptions.None, System.Security.Principal.TokenImpersonationLevel.Impersonation);
            interruptClient.Connect();
            interruptClient.Close();
            pipeServer.Close();
        }
        //this is the main function used by the thread that communicates with the RABooter.
        //When it receives a message, it will interpret the message as a filepath and attempt to launch the routine.
        private static void ScheduleThread(int[] macroKeys)
        {
            pipeServer =
                new NamedPipeServerStream("RABootPipe", PipeDirection.In, 5);
            int threadId = Thread.CurrentThread.ManagedThreadId;
            while (!interruptFlag)
            {
                //This function will wait forever until a client connects
                pipeServer.WaitForConnection();
                if (interruptFlag)
                {
                    return;
                }
                try
                {
                    //Reads a string in from the pipe
                    StreamString ss = new StreamString(pipeServer);
                    string message = ss.ReadString();
                    Thread interruptThread = new Thread(() => { interruptInterpreterSequence(macroKeys); });
                    interruptThread.Start();
                    //the message from the pipe contains the file path for the routine to be executed.
                    executeAutomatedRoutine(message, 1, 1);
                    try
                    {
                        pipeServer.Disconnect();//this is sometimes crashing it
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.Write(ex);
                    }
                    Thread.Sleep(1000);
                }
                catch (IOException e)
                {
                    Console.WriteLine("ERR: " + e.Message);
                }
            }
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
            //string stream buffer stuff for named pipes
            public string ReadString()
            {
                int length = 0;
                length = ioStream.ReadByte() * 256;
                length += ioStream.ReadByte();
                byte[] inBuffer = new byte[length];
                ioStream.Read(inBuffer, 0, length);
                return streamEncoding.GetString(inBuffer);
            }
        }
    }
}
