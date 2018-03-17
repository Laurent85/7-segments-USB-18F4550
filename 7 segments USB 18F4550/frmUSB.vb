Public Class frmUSB
    ' vendor and product IDs
    Private Const VendorID As Short = &H2    'Replace with your device's
    Private Const ProductID As Short = &H5678      'product and vendor IDs

    ' read and write buffers
    Private Const BufferInSize As Short = 64 'Size of the data buffer coming IN to the PC
    Private Const BufferOutSize As Short = 64    'Size of the data buffer going OUT from the PC
    Dim Lecture_PIC(BufferInSize) As Byte          'Received data will be stored here - the first byte in the array is unused
    Dim Ecriture_PIC(BufferOutSize) As Byte    'Transmitted data is stored here - the first item in the array must be 0

    ' ****************************************************************
    ' when the form loads, connect to the HID controller - pass
    ' the form window handle so that you can receive notification
    ' events...
    '*****************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' do not remove!
        ConnectToHID(Me)
    End Sub

    '*****************************************************************
    ' disconnect from the HID controller...
    '*****************************************************************
    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        DisconnectFromHID()
    End Sub

    '*****************************************************************
    ' a HID device has been plugged in...
    '*****************************************************************
    Public Sub OnPlugged(ByVal pHandle As Integer)
        If hidGetVendorID(pHandle) = VendorID And hidGetProductID(pHandle) = ProductID Then
            ' ** YOUR CODE HERE **
            RadioButton12.Checked = True
            Ampoule.Text = "Ampoule éteinte"
            Label2.Text = "USB connecté"
            Segment1.BackColor = Color.Transparent
            Segment2.BackColor = Color.Transparent
            Segment3.BackColor = Color.Transparent
            Segment4.BackColor = Color.Transparent
            Segment5.BackColor = Color.Transparent
            Segment6.BackColor = Color.Transparent
            Segment7.BackColor = Color.Transparent
            'Ecriture_PIC(2) = 11
            'hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
        End If
    End Sub

    '*****************************************************************
    ' a HID device has been unplugged...
    '*****************************************************************
    Public Sub OnUnplugged(ByVal pHandle As Integer)
        If hidGetVendorID(pHandle) = VendorID And hidGetProductID(pHandle) = ProductID Then
            hidSetReadNotify(hidGetHandle(VendorID, ProductID), False)
            ' ** YOUR CODE HERE **
            RadioButton12.Checked = True
            Segment1.BackColor = Color.Transparent
            Segment2.BackColor = Color.Transparent
            Segment3.BackColor = Color.Transparent
            Segment4.BackColor = Color.Transparent
            Segment5.BackColor = Color.Transparent
            Segment6.BackColor = Color.Transparent
            Segment7.BackColor = Color.Transparent
            Ampoule.Text = "Ampoule éteinte"
            Label2.Text = "USB déconnecté"
            Ecriture_PIC(2) = 11
            hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
        End If
    End Sub

    '*****************************************************************
    ' controller changed notification - called
    ' after ALL HID devices are plugged or unplugged
    '*****************************************************************
    Public Sub OnChanged()
        ' get the handle of the device we are interested in, then set
        ' its read notify flag to true - this ensures you get a read
        ' notification message when there is some data to read...
        Dim pHandle As Integer
        pHandle = hidGetHandle(VendorID, ProductID)
        hidSetReadNotify(hidGetHandle(VendorID, ProductID), True)
    End Sub

    '*****************************************************************
    ' on read event...
    '*****************************************************************
    Public Sub OnRead(ByVal pHandle As Integer)
        ' read the data (don't forget, pass the whole array)...
        If hidRead(pHandle, Lecture_PIC(0)) Then
            ProgressBar1.Value = Lecture_PIC(11)
            Label3.Text = "ADC = " & (Lecture_PIC(11) * 4)
            If Lecture_PIC(6) = 0 Then
                Segment1.BackColor = Color.Green
                Segment2.BackColor = Color.Green
                Segment3.BackColor = Color.Green
                Segment4.BackColor = Color.Green
                Segment5.BackColor = Color.Green
                Segment6.BackColor = Color.Green
                Segment7.BackColor = Color.Transparent
            Else
                If Lecture_PIC(6) = 1 Then
                    Segment1.BackColor = Color.Transparent
                    Segment2.BackColor = Color.Green
                    Segment3.BackColor = Color.Green
                    Segment4.BackColor = Color.Transparent
                    Segment5.BackColor = Color.Transparent
                    Segment6.BackColor = Color.Transparent
                    Segment7.BackColor = Color.Transparent
                Else
                    If Lecture_PIC(6) = 2 Then
                        Segment1.BackColor = Color.Green
                        Segment2.BackColor = Color.Green
                        Segment3.BackColor = Color.Transparent
                        Segment4.BackColor = Color.Green
                        Segment5.BackColor = Color.Green
                        Segment6.BackColor = Color.Transparent
                        Segment7.BackColor = Color.Green
                    Else
                        If Lecture_PIC(6) = 3 Then
                            Segment1.BackColor = Color.Green
                            Segment2.BackColor = Color.Green
                            Segment3.BackColor = Color.Green
                            Segment4.BackColor = Color.Green
                            Segment5.BackColor = Color.Transparent
                            Segment6.BackColor = Color.Transparent
                            Segment7.BackColor = Color.Green
                        Else
                            If Lecture_PIC(6) = 4 Then
                                Segment1.BackColor = Color.Transparent
                                Segment2.BackColor = Color.Green
                                Segment3.BackColor = Color.Green
                                Segment4.BackColor = Color.Transparent
                                Segment5.BackColor = Color.Transparent
                                Segment6.BackColor = Color.Green
                                Segment7.BackColor = Color.Green
                            Else
                                If Lecture_PIC(6) = 5 Then
                                    Segment1.BackColor = Color.Green
                                    Segment2.BackColor = Color.Transparent
                                    Segment3.BackColor = Color.Green
                                    Segment4.BackColor = Color.Green
                                    Segment5.BackColor = Color.Transparent
                                    Segment6.BackColor = Color.Green
                                    Segment7.BackColor = Color.Green
                                Else
                                    If Lecture_PIC(6) = 6 Then
                                        Segment1.BackColor = Color.Green
                                        Segment2.BackColor = Color.Transparent
                                        Segment3.BackColor = Color.Green
                                        Segment4.BackColor = Color.Green
                                        Segment5.BackColor = Color.Green
                                        Segment6.BackColor = Color.Green
                                        Segment7.BackColor = Color.Green
                                    Else
                                        If Lecture_PIC(6) = 7 Then
                                            Segment1.BackColor = Color.Green
                                            Segment2.BackColor = Color.Green
                                            Segment3.BackColor = Color.Green
                                            Segment4.BackColor = Color.Transparent
                                            Segment5.BackColor = Color.Transparent
                                            Segment6.BackColor = Color.Transparent
                                            Segment7.BackColor = Color.Transparent
                                        Else
                                            If Lecture_PIC(6) = 8 Then
                                                Segment1.BackColor = Color.Green
                                                Segment2.BackColor = Color.Green
                                                Segment3.BackColor = Color.Green
                                                Segment4.BackColor = Color.Green
                                                Segment5.BackColor = Color.Green
                                                Segment6.BackColor = Color.Green
                                                Segment7.BackColor = Color.Green
                                            Else
                                                If Lecture_PIC(6) = 9 Then
                                                    Segment1.BackColor = Color.Green
                                                    Segment2.BackColor = Color.Green
                                                    Segment3.BackColor = Color.Green
                                                    Segment4.BackColor = Color.Green
                                                    Segment5.BackColor = Color.Transparent
                                                    Segment6.BackColor = Color.Green
                                                    Segment7.BackColor = Color.Green
                                                Else
                                                    If Lecture_PIC(6) = 10 Then
                                                        Segment1.BackColor = Color.Transparent
                                                        Segment2.BackColor = Color.Transparent
                                                        Segment3.BackColor = Color.Transparent
                                                        Segment4.BackColor = Color.Transparent
                                                        Segment5.BackColor = Color.Transparent
                                                        Segment6.BackColor = Color.Transparent
                                                        Segment7.BackColor = Color.Transparent
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Ecriture_PIC(2) = 0
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Ecriture_PIC(2) = 1
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Ecriture_PIC(2) = 2
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Ecriture_PIC(2) = 3
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Ecriture_PIC(2) = 4
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        Ecriture_PIC(2) = 5
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        Ecriture_PIC(2) = 6
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub RadioButton8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton8.CheckedChanged
        Ecriture_PIC(2) = 7
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub RadioButton9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton9.CheckedChanged
        Ecriture_PIC(2) = 8
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub RadioButton10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton10.CheckedChanged
        Ecriture_PIC(2) = 9
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub RadioButton11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton11.CheckedChanged
debut:
        If RadioButton11.Checked = True Then
            RadioButton11.Checked = True
            RadioButton12.Checked = False
            Ecriture_PIC(2) = 10
            hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
        Else
            Ecriture_PIC(2) = 11
            hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
        End If
    End Sub

    Private Sub RadioButton12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton12.CheckedChanged
        Ecriture_PIC(2) = 11
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Segment1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Segment1.Click

    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub RectangleShape4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RectangleShape4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape4.Click
        If RadioButton11.Checked = True Then
            Ecriture_PIC(2) = 11
            hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
            RadioButton11.Checked = False
            RadioButton12.Checked = True
        End If
        Ampoule.Text = "Ampoule allumée"
        Ecriture_PIC(3) = 1
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub RectangleShape6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape6.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ampoule.Click

    End Sub

    Private Sub RectangleShape5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape5.Click
        If RadioButton11.Checked = True Then
            Ecriture_PIC(2) = 11
            hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
            RadioButton11.Checked = False
            RadioButton12.Checked = True
        End If
        Ampoule.Text = "Ampoule éteinte"
        Ecriture_PIC(3) = 0
        hidWriteEx(VendorID, ProductID, Ecriture_PIC(0))
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub
End Class
