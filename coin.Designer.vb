<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class coin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(51, 159)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(19, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(250, 250)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.Visible = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.BackColor = System.Drawing.Color.Black
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RichTextBox1.DetectUrls = False
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Red
        Me.RichTextBox1.Location = New System.Drawing.Point(-10, 0)
        Me.RichTextBox1.MaxLength = 15
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.RichTextBox1.Size = New System.Drawing.Size(345, 74)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = " F1:  About"
        '
        'Timer1
        '
        Me.Timer1.Interval = 333
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Lime
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(-3, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1, 2)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = " "
        Me.Label1.Visible = False
        '
        'coin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(345, 74)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "coin"
        Me.Opacity = 0.75R
        Me.ShowIcon = False
        Me.Text = "Coin"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
End Class
