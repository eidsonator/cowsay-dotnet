using System;
using System.ComponentModel;
using System.IO;
using CommandDotNet.Attributes;

namespace cowsays
{
    public class CowSays
    {
        private string cowEyes = "oo";
        private string cowTongue = " ";
        private string file = "";

        public CowSays(
            [Option(LongName = "dead", ShortName = "d")] bool dead,
            [Option(LongName = "paranoid", ShortName = "p")] bool paranoid,
            [Option(LongName = "file", ShortName = "f")] string file = ""
        ) {
            if (file != "")
            {
                this.file = file;
            }
            if (dead)
            {
                cowEyes = "xx";
                cowTongue = "U";
            }

            if (paranoid)
            {
                cowEyes = "@@";
            }
        }
        
        [DefaultMethod]
        public void CowSay()
        {
            SpeechBubble("Typical cowsay output");
            
            if (this.file != "")
            {
                string line;
                StreamReader lines = new StreamReader("./cows/" + this.file);
                while ((line = lines.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                DrawCow();    
            }
            
        }

        private void SpeechBubble(string text)
        {
            Console.WriteLine(" ________________________________________");
            string whitespace = "";
            string line = "< " + text + whitespace.PadLeft(40 - text.Length, 'X').Replace("X", " ") + ">";
            Console.WriteLine(line);
            Console.WriteLine(" ----------------------------------------");
        }
        
        private void DrawCow() { 
            Console.WriteLine("        \\   ^__^");
            Console.WriteLine("         \\  ({0})\\_______", this.cowEyes);
            Console.WriteLine("            (__)\\       )\\/\\");
            Console.WriteLine("             {0}  ||----w |", this.cowTongue);
            Console.WriteLine("                ||     ||");
        }

    }
}