////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos Desktop Application
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   22-04-2017
//
//
//      File description :
//      Name    :       VoltageNumericUpDown.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System.Windows.Forms;

namespace TsakiridisDevicesDaedalos
{
    public class VoltageNumericUpDown : NumericUpDown
    {
        protected override void UpdateEditText()
        {
            Text = Value + " V";
        }
    }
}
