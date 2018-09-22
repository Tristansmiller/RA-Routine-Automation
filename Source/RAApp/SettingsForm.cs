using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA_Application
{
    public partial class SettingsForm : Form
    {
        #region Class Variables
        //string representation of what keys are currently held down when the macro box is focused
        public List<string> keysDown = new List<string>();
        //virtual code int representation of what keys are currently held down when the macro box is focused.
        public List<int> keyCodes = new List<int>();
        //flag for freezing the input, toggles when enter is pressed while macro box is focused
        bool isSet = false;
        //flag to signal main form after OK button is pressed and macro is set.
        public bool hasWrittenNewMacro = false;
        #endregion

        #region Initialization
        public SettingsForm()
        {
            InitializeComponent();
            this.Show();
            this.Hide();
        }
        #endregion

        //moves the form on top of the main form and then reveals it to the user.
        public void showForm(Point location)
        {
            this.Location = location;
            hasWrittenNewMacro = false;
            this.Show();
        }

        //Button 1 is the OK button, this function is called when it's pressed  and it writes the macro to RAConfig.config, hides itself, and signals main form
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "RAConfig.config";
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    for(int i = 0; i < keyCodes.Count; i++)
                    {
                        sw.WriteLine(keyCodes.ElementAt(i));
                    }
                }
            }
            catch { }
            finally { this.Hide(); hasWrittenNewMacro = true; }
        }

        //ensures the macro box content always represents the macro string that the program is holding
        private void MacroBox_TextChanged(object sender, EventArgs e)
        {
            MacroBox.Text = getCurrentMacroString();
        }
        //checks the keys that are pressed and adds them to the key list if appropriate
        private void MacroBox_KeyDown(object sender, KeyEventArgs args)
        {
            //get string representation of the key
            string input = args.KeyCode.ToString();
            //if enter, then need to freeze/unfreeze input
            if(input == "Return")
            {
                if (isSet)
                {
                    //reset macro and exit function
                    isSet = false;
                    keysDown = new List<string>();
                    keyCodes = new List<int>();
                    return;
                }
                else
                {
                    //set the freeze flag and exit
                    isSet = true;
                    return;
                }
            }
            if (!isSet)
            {
                //if the key isnt already in the list of keys, then add it
                if (!keysDown.Contains(input))
                {
                    keysDown.Add(input);
                    keyCodes.Add(args.KeyValue);
                }
                MacroBox.Text = getCurrentMacroString();
            }
        }
        //removes whatever key has come up from the list of keys
        private void MacroBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs args)
        {
            if (!isSet)
            {
                keysDown.Remove(args.KeyCode.ToString());
                keyCodes.Remove(args.KeyValue);
                MacroBox.Text = getCurrentMacroString();
            }
        }
        //formats the list of keys into a nicer string that's more representative of a keystroke - literally just adds + in between elements lol
        private string getCurrentMacroString()
        {
            if (keysDown.Count != 0)
            {
                string text = keysDown.ElementAt(0);
                for (int i = 1; i < keysDown.Count; i++)
                {
                    text += "+" + keysDown.ElementAt(i);
                }
                return text;
            }
            else
            {
                return "";
            }
        }
    }

}
