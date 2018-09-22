using System.IO;
using System.Runtime.InteropServices;

namespace RAInterface
{
    public class RAController
    {
        public RAController()
        {
            string dir = Directory.GetCurrentDirectory();
            ImportedFunctions.AddDllDirectory(dir);
        }
        public double calculateRuntime(string filePath)
        {
            return ImportedFunctions.calculateRuntime(filePath);
        }
        public void watchForStartSequence(int[] macroKeys)
        {
            ImportedFunctions.watchForStartSequence(macroKeys);
        }
        public void interruptInterpreterSequence(int[] macroKeys)
        {
            ImportedFunctions.interruptInterpreterSequence(macroKeys);
        }
        public void recordActivity(string filepath)
        {
            ImportedFunctions.recordActivity(filepath);
        }
        public void executeAutomatedRoutine(string filepath, float speed, int loops)
        {
            ImportedFunctions.executeAutomatedRoutine(filepath, speed, loops);
        }
        private static class ImportedFunctions
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool AddDllDirectory(string path);

            [DllImport(@"RAInternals.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            public static extern void watchForStartSequence(int[] macroKeys);

            [DllImport(@"RAInternals.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            public static extern double calculateRuntime([MarshalAs(UnmanagedType.LPStr)]string filePath);

            [DllImport(@"RAInternals.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            public static extern void interruptInterpreterSequence(int[] macroKeys);

            [DllImport(@"RAInternals.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            public static extern void recordActivity([MarshalAs(UnmanagedType.LPStr)]string filePath);

            [DllImport(@"RAInternals.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            public static extern void executeAutomatedRoutine([MarshalAs(UnmanagedType.LPStr)]string filePath, float speed, int loops);
        }
    }
}
