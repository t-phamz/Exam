//20183732_Tommy_Pham
using System;
using System.Collections.Generic;

namespace _20183732_Tommy_Pham
{
    class Program
    {
        static void Main(string[] args)
        {


            IStregsystem stregsystem = new Stregsystem();
            IStregsystemUI ui = new StregsystemCLI(stregsystem);
            StregsystemCommandParser sc = new StregsystemCommandParser(ui, stregsystem);

            ui.Start();
        }
    }
}
