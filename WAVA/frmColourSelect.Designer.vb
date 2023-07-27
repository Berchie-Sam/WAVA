<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColourSelect
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.radYellowOnBlack = New System.Windows.Forms.RadioButton()
        Me.radWhiteOnBlack = New System.Windows.Forms.RadioButton()
        Me.radBlackOnWhite = New System.Windows.Forms.RadioButton()
        Me.radWindowsDefault = New System.Windows.Forms.RadioButton()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'radYellowOnBlack
        '
        Me.radYellowOnBlack.AutoSize = True
        Me.radYellowOnBlack.BackColor = System.Drawing.Color.Black
        Me.radYellowOnBlack.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radYellowOnBlack.ForeColor = System.Drawing.Color.Yellow
        Me.radYellowOnBlack.Location = New System.Drawing.Point(18, 177)
        Me.radYellowOnBlack.Margin = New System.Windows.Forms.Padding(4)
        Me.radYellowOnBlack.Name = "radYellowOnBlack"
        Me.radYellowOnBlack.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.radYellowOnBlack.Size = New System.Drawing.Size(189, 29)
        Me.radYellowOnBlack.TabIndex = 11
        Me.radYellowOnBlack.TabStop = True
        Me.radYellowOnBlack.Text = "Yellow on black"
        Me.radYellowOnBlack.UseVisualStyleBackColor = False
        '
        'radWhiteOnBlack
        '
        Me.radWhiteOnBlack.AutoSize = True
        Me.radWhiteOnBlack.BackColor = System.Drawing.Color.Black
        Me.radWhiteOnBlack.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radWhiteOnBlack.ForeColor = System.Drawing.Color.White
        Me.radWhiteOnBlack.Location = New System.Drawing.Point(18, 128)
        Me.radWhiteOnBlack.Margin = New System.Windows.Forms.Padding(4)
        Me.radWhiteOnBlack.Name = "radWhiteOnBlack"
        Me.radWhiteOnBlack.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.radWhiteOnBlack.Size = New System.Drawing.Size(180, 29)
        Me.radWhiteOnBlack.TabIndex = 10
        Me.radWhiteOnBlack.TabStop = True
        Me.radWhiteOnBlack.Text = "White on black"
        Me.radWhiteOnBlack.UseVisualStyleBackColor = False
        '
        'radBlackOnWhite
        '
        Me.radBlackOnWhite.AutoSize = True
        Me.radBlackOnWhite.BackColor = System.Drawing.Color.White
        Me.radBlackOnWhite.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radBlackOnWhite.ForeColor = System.Drawing.Color.Black
        Me.radBlackOnWhite.Location = New System.Drawing.Point(18, 79)
        Me.radBlackOnWhite.Margin = New System.Windows.Forms.Padding(4)
        Me.radBlackOnWhite.Name = "radBlackOnWhite"
        Me.radBlackOnWhite.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.radBlackOnWhite.Size = New System.Drawing.Size(177, 29)
        Me.radBlackOnWhite.TabIndex = 9
        Me.radBlackOnWhite.TabStop = True
        Me.radBlackOnWhite.Text = "Black on white"
        Me.radBlackOnWhite.UseVisualStyleBackColor = False
        '
        'radWindowsDefault
        '
        Me.radWindowsDefault.AutoSize = True
        Me.radWindowsDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radWindowsDefault.Location = New System.Drawing.Point(18, 30)
        Me.radWindowsDefault.Margin = New System.Windows.Forms.Padding(4)
        Me.radWindowsDefault.Name = "radWindowsDefault"
        Me.radWindowsDefault.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.radWindowsDefault.Size = New System.Drawing.Size(240, 29)
        Me.radWindowsDefault.TabIndex = 8
        Me.radWindowsDefault.TabStop = True
        Me.radWindowsDefault.Text = "Use Windows default"
        Me.radWindowsDefault.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(518, 89)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(176, 52)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(518, 30)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(176, 52)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmColourSelect
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(711, 228)
        Me.Controls.Add(Me.radYellowOnBlack)
        Me.Controls.Add(Me.radWhiteOnBlack)
        Me.Controls.Add(Me.radBlackOnWhite)
        Me.Controls.Add(Me.radWindowsDefault)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmColourSelect"
        Me.ShowIcon = False
        Me.Text = "Select Colour..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents radYellowOnBlack As RadioButton
    Friend WithEvents radWhiteOnBlack As RadioButton
    Friend WithEvents radBlackOnWhite As RadioButton
    Friend WithEvents radWindowsDefault As RadioButton
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
End Class
