Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Utils.Win
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Controls

Namespace WindowsFormsApplication37
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            AddHandler popupControlContainer1.Popup, AddressOf popupControlContainer1_Popup
        End Sub

        Private Sub popupControlContainer1_Popup(ByVal sender As Object, ByVal e As EventArgs)
            Dim control As PopupControlContainer = TryCast(sender, PopupControlContainer)
            Dim barControl As PopupContainerBarControl = (TryCast(control.Parent, PopupContainerBarControl))
            AddHandler barControl.Paint, AddressOf Form1_Paint
        End Sub

        Private Sub Form1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
            Dim barControl As PopupContainerBarControl = (TryCast(sender, PopupContainerBarControl))
            Dim offsetLocation As New Point(barControl.CloseButton.Location.X + barControl.CloseButton.Width + 3, barControl.CloseButton.Location.Y)
            e.Graphics.DrawString("Custom string", barControl.Font, Brushes.Green, offsetLocation)
        End Sub
    End Class
End Namespace
