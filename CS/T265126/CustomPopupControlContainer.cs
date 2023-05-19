using DevExpress.XtraBars;
using DevExpress.XtraBars.Controls;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace T265126 {
    internal class CustomPopupControlContainer : PopupControlContainer {
        public CustomPopupControlContainer(IContainer container) : base(container) {
            Popup += CustomPopupControlContainer_Popup;
        }
        private void CustomPopupControlContainer_Popup(object sender, EventArgs e) {
            CreateButton();
        }
        private SimpleButton myButton;
        private Control closeButton;
        private PopupContainerBarControl subControl;
        private void CreateButton() {
            myButton = new SimpleButton();
            myButton.Text = "button";
            closeButton = SubControl.Controls[0];
            closeButton.LocationChanged += CloseButton_LocationChanged;
            myButton.Size = new Size(100, SubControl.Controls[0].Size.Height);
            subControl = SubControl;
            subControl.Controls.Add(myButton);
            subControl.PaintEx += SubControl_PaintEx;
        }
        private void SubControl_PaintEx(object sender, DevExpress.Utils.XtraPaintEventArgs e) {
            PopupContainerBarControl barControl = (sender as PopupContainerBarControl);
            Point offsetLocation = new Point(myButton.Location.X + myButton.Width + 3, barControl.CloseButton.Location.Y + 3);
            e.Cache.DrawString("Custom string", barControl.Font, Brushes.Red, offsetLocation);
        }
        void CloseButton_LocationChanged(object sender, EventArgs e) {
            Control closeButton = sender as Control;
            Point location = closeButton.Location;
            location.Offset(closeButton.Width + 3, 0);
            myButton.Location = location;
        }
        protected override void Dispose(bool disposing) {
            Popup -= CustomPopupControlContainer_Popup;
            closeButton.LocationChanged -= CloseButton_LocationChanged;
            subControl.PaintEx -= SubControl_PaintEx;
            base.Dispose(disposing);     
        }
    }
}
