﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Faculty
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormFaculty());
            Application.Run(new FormCourse());
            Application.Run(new FormEnroll());
        }
    }
}
