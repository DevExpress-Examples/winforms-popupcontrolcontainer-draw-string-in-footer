Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Controls
Imports DevExpress.XtraEditors
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace T265126

    Friend Class CustomPopupControlContainer
        Inherits PopupControlContainer

        Public Sub New(ByVal container As IContainer)
            MyBase.New(container)
            AddHandler Popup, AddressOf CustomPopupControlContainer_Popup
        End Sub

        Private Sub CustomPopupControlContainer_Popup(ByVal sender As Object, ByVal e As EventArgs)
            CreateButton()
        End Sub

        Private myButton As SimpleButton

        Private closeButton As Control

        Private _SubControl As PopupContainerBarControl

        Private Sub CreateButton()
            myButton = New SimpleButton()
            myButton.Text = "button"
            closeButton = SubControl.Controls(0)
            AddHandler closeButton.LocationChanged, AddressOf CloseButton_LocationChanged
            myButton.Size = New Size(100, SubControl.Controls(0).Size.Height)
            _SubControl = SubControl
            _SubControl.Controls.Add(myButton)
            AddHandler _SubControl.PaintEx, AddressOf SubControl_PaintEx
        End Sub

        Private Sub SubControl_PaintEx(ByVal sender As Object, ByVal e As DevExpress.Utils.XtraPaintEventArgs)
            Dim barControl As PopupContainerBarControl = TryCast(sender, PopupContainerBarControl)
            Dim offsetLocation As Point = New Point(myButton.Location.X + myButton.Width + 3, barControl.CloseButton.Location.Y + 3)
            e.Cache.DrawString("Custom string", barControl.Font, Brushes.Red, offsetLocation)
        End Sub

        Private Sub CloseButton_LocationChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim closeButton As Control = TryCast(sender, Control)
            Dim location As Point = closeButton.Location
            location.Offset(closeButton.Width + 3, 0)
            myButton.Location = location
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            RemoveHandler Popup, AddressOf CustomPopupControlContainer_Popup
            RemoveHandler closeButton.LocationChanged, AddressOf CloseButton_LocationChanged
            RemoveHandler _SubControl.PaintEx, AddressOf SubControl_PaintEx
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
