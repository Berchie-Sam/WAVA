<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplash_Screen
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash_Screen))
        Me.lblWAVA = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.trWAVA = New System.Windows.Forms.Timer(Me.components)
        Me.pgbWava = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'lblWAVA
        '
        Me.lblWAVA.BackColor = System.Drawing.Color.Transparent
        Me.lblWAVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWAVA.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lblWAVA.Location = New System.Drawing.Point(6, 3)
        Me.lblWAVA.Name = "lblWAVA"
        Me.lblWAVA.Size = New System.Drawing.Size(518, 77)
        Me.lblWAVA.TabIndex = 2
        Me.lblWAVA.Text = "WEB ACCESS FOR VISUALLY IMPAIRED APPLICATION (WAVA)"
        Me.lblWAVA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label2.Location = New System.Drawing.Point(8, 319)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 32)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Developer: Sam Berchie" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'trWAVA
        '
        Me.trWAVA.Enabled = True
        Me.trWAVA.Interval = 10
        '
        'pgbWava
        '
        Me.pgbWava.BackColor = System.Drawing.Color.White
        Me.pgbWava.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.pgbWava.Location = New System.Drawing.Point(0, 355)
        Me.pgbWava.Name = "pgbWava"
        Me.pgbWava.Size = New System.Drawing.Size(536, 10)
        Me.pgbWava.TabIndex = 8
        Me.pgbWava.Visible = False
        '
        'frmSplash_Screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(536, 366)
        Me.Controls.Add(Me.pgbWava)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblWAVA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSplash_Screen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblWAVA As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents trWAVA As Timer
    Friend WithEvents pgbWava As ProgressBar
End Class
