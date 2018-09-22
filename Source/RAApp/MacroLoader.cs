using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA_Application
{
    class MacroLoader
    {
        public static int[] loadMacro(string filePath)
        {
                List<int> macroKeys = new List<int>();
                StreamReader sr = new StreamReader(filePath);
                string[] macros = sr.ReadLine().Split(',');
                sr.Close();
                for (int i = 0; i < macros.Length; i++)
                {
                    macroKeys.Add(int.Parse(macros[i]));
                }
                return macroKeys.ToArray();

        }
    }
}
