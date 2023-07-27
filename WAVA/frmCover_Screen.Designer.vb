<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCover_Screen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCover_Screen))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnWebBrowser = New ns1.BunifuThinButton2()
        Me.btnExit = New ns1.BunifuThinButton2()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.btnWebBrowser)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Location = New System.Drawing.Point(111, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 218)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnWebBrowser
        '
        Me.btnWebBrowser.ActiveBorderThickness = 1
        Me.btnWebBrowser.ActiveCornerRadius = 20
        Me.btnWebBrowser.ActiveFillColor = System.Drawing.SystemColors.ControlDark
        Me.btnWebBrowser.ActiveForecolor = System.Drawing.Color.Black
        Me.btnWebBrowser.ActiveLineColor = System.Drawing.SystemColors.ControlDark
        Me.btnWebBrowser.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnWebBrowser.BackgroundImage = CType(resources.GetObject("btnWebBrowser.BackgroundImage"), System.Drawing.Image)
        Me.btnWebBrowser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnWebBrowser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.btnWebBrowser.ButtonText = "Proceed To Web Browser"
        Me.btnWebBrowser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWebBrowser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWebBrowser.ForeColor = System.Drawing.Color.White
        Me.btnWebBrowser.IdleBorderThickness = 1
        Me.btnWebBrowser.IdleCornerRadius = 5
        Me.btnWebBrowser.IdleFillColor = System.Drawing.SystemColors.ControlDark
        Me.btnWebBrowser.IdleForecolor = System.Drawing.Color.Transparent
        Me.btnWebBrowser.IdleLineColor = System.Drawing.SystemColors.ControlDark
        Me.btnWebBrowser.Location = New System.Drawing.Point(33, 38)
        Me.btnWebBrowser.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnWebBrowser.Name = "btnWebBrowser"
        Me.btnWebBrowser.Size = New System.Drawing.Size(255, 60)
        Me.btnWebBrowser.TabIndex = 4
        Me.btnWebBrowser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExit
        '
        Me.btnExit.ActiveBorderThickness = 1
        Me.btnExit.ActiveCornerRadius = 20
        Me.btnExit.ActiveFillColor = System.Drawing.SystemColors.ControlDark
        Me.btnExit.ActiveForecolor = System.Drawing.Color.Black
        Me.btnExit.ActiveLineColor = System.Drawing.Color.Transparent
        Me.btnExit.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.btnExit.ButtonText = "EXIT"
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.IdleBorderThickness = 1
        Me.btnExit.IdleCornerRadius = 5
        Me.btnExit.IdleFillColor = System.Drawing.SystemColors.ControlDark
        Me.btnExit.IdleForecolor = System.Drawing.Color.Transparent
        Me.btnExit.IdleLineColor = System.Drawing.Color.Transparent
        Me.btnExit.Location = New System.Drawing.Point(194, 144)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(105, 37)
        Me.btnExit.TabIndex = 3
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCover_Screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(554, 385)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCover_Screen"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCover_Screen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnWebBrowser As ns1.BunifuThinButton2
    Friend WithEvents btnExit As ns1.BunifuThinButton2
End Class
