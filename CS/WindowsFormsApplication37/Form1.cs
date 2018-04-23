using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Win;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Controls;

namespace WindowsFormsApplication37 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            popupControlContainer1.Popup += popupControlContainer1_Popup;
        }

        void popupControlContainer1_Popup(object sender, EventArgs e) {
            PopupControlContainer control = sender as PopupControlContainer;
            PopupContainerBarControl barControl = (control.Parent as PopupContainerBarControl);
            barControl.Paint += Form1_Paint;
        }

        void Form1_Paint(object sender, PaintEventArgs e) {
            PopupContainerBarControl barControl = (sender as PopupContainerBarControl);
            Point offsetLocation = new Point(barControl.CloseButton.Location.X + barControl.CloseButton.Width + 3, barControl.CloseButton.Location.Y);
            e.Graphics.DrawString("Custom string", barControl.Font, Brushes.Green, offsetLocation);
        }
    }
}
