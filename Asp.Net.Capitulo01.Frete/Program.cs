﻿using System;
using System.Windows.Forms;

namespace Asp.Net.Capitulo01.Frete
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FreteForm());
        }
    }
}
