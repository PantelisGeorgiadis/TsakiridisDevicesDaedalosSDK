////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos Desktop Application
//      Author      :	Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   17-10-2016
//
//
//      File description :
//      Name    :       Program.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;

namespace TsakiridisDevicesDaedalos
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
#if !MONO
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#endif
            Application.Run(new MainForm());
        }
    }
}
