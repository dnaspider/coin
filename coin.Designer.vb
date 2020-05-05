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
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.URL = New System.Windows.Forms.TextBox()
        Me.ScrapeAfter = New System.Windows.Forms.TextBox()
        Me.ScrapeBegin = New System.Windows.Forms.TextBox()
        Me.ScrapeEnd = New System.Windows.Forms.TextBox()
        Me.Description = New System.Windows.Forms.TextBox()
        Me.Log = New System.Windows.Forms.TextBox()
        Me.ScrapeReplace = New System.Windows.Forms.TextBox()
        Me.ScrapeReplaceW = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.BackColor = System.Drawing.Color.Black
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Red
        Me.RichTextBox1.Location = New System.Drawing.Point(-10, 4)
        Me.RichTextBox1.MaxLength = 0
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.RichTextBox1.Size = New System.Drawing.Size(355, 105)
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
        Me.Label1.Size = New System.Drawing.Size(0, 3)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = " "
        Me.Label1.Visible = False
        '
        'URL
        '
        Me.URL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.URL.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.URL.ForeColor = System.Drawing.Color.Yellow
        Me.URL.Location = New System.Drawing.Point(13, 182)
        Me.URL.Name = "URL"
        Me.URL.Size = New System.Drawing.Size(320, 37)
        Me.URL.TabIndex = 2
        '
        'ScrapeAfter
        '
        Me.ScrapeAfter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScrapeAfter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScrapeAfter.ForeColor = System.Drawing.Color.Yellow
        Me.ScrapeAfter.Location = New System.Drawing.Point(13, 225)
        Me.ScrapeAfter.Multiline = True
        Me.ScrapeAfter.Name = "ScrapeAfter"
        Me.ScrapeAfter.Size = New System.Drawing.Size(320, 37)
        Me.ScrapeAfter.TabIndex = 3
        '
        'ScrapeBegin
        '
        Me.ScrapeBegin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScrapeBegin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScrapeBegin.ForeColor = System.Drawing.Color.Yellow
        Me.ScrapeBegin.Location = New System.Drawing.Point(13, 268)
        Me.ScrapeBegin.Multiline = True
        Me.ScrapeBegin.Name = "ScrapeBegin"
        Me.ScrapeBegin.Size = New System.Drawing.Size(320, 37)
        Me.ScrapeBegin.TabIndex = 4
        '
        'ScrapeEnd
        '
        Me.ScrapeEnd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScrapeEnd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScrapeEnd.ForeColor = System.Drawing.Color.Yellow
        Me.ScrapeEnd.Location = New System.Drawing.Point(13, 310)
        Me.ScrapeEnd.Multiline = True
        Me.ScrapeEnd.Name = "ScrapeEnd"
        Me.ScrapeEnd.Size = New System.Drawing.Size(320, 37)
        Me.ScrapeEnd.TabIndex = 5
        '
        'Description
        '
        Me.Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Description.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Description.ForeColor = System.Drawing.Color.Yellow
        Me.Description.Location = New System.Drawing.Point(13, 439)
        Me.Description.Name = "Description"
        Me.Description.Size = New System.Drawing.Size(320, 37)
        Me.Description.TabIndex = 8
        '
        'Log
        '
        Me.Log.AcceptsReturn = True
        Me.Log.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Log.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Log.ForeColor = System.Drawing.Color.Yellow
        Me.Log.Location = New System.Drawing.Point(13, 482)
        Me.Log.Multiline = True
        Me.Log.Name = "Log"
        Me.Log.Size = New System.Drawing.Size(320, 159)
        Me.Log.TabIndex = 9
        '
        'ScrapeReplace
        '
        Me.ScrapeReplace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScrapeReplace.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScrapeReplace.ForeColor = System.Drawing.Color.Yellow
        Me.ScrapeReplace.Location = New System.Drawing.Point(13, 353)
        Me.ScrapeReplace.Multiline = True
        Me.ScrapeReplace.Name = "ScrapeReplace"
        Me.ScrapeReplace.Size = New System.Drawing.Size(320, 37)
        Me.ScrapeReplace.TabIndex = 6
        '
        'ScrapeReplaceW
        '
        Me.ScrapeReplaceW.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScrapeReplaceW.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScrapeReplaceW.ForeColor = System.Drawing.Color.Yellow
        Me.ScrapeReplaceW.Location = New System.Drawing.Point(13, 396)
        Me.ScrapeReplaceW.Multiline = True
        Me.ScrapeReplaceW.Name = "ScrapeReplaceW"
        Me.ScrapeReplaceW.Size = New System.Drawing.Size(320, 37)
        Me.ScrapeReplaceW.TabIndex = 7
        '
        'coin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(345, 74)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Log)
        Me.Controls.Add(Me.ScrapeReplaceW)
        Me.Controls.Add(Me.ScrapeReplace)
        Me.Controls.Add(Me.Description)
        Me.Controls.Add(Me.ScrapeEnd)
        Me.Controls.Add(Me.ScrapeBegin)
        Me.Controls.Add(Me.ScrapeAfter)
        Me.Controls.Add(Me.URL)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "coin"
        Me.Opacity = 0.75R
        Me.ShowIcon = False
        Me.Text = "coin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents URL As TextBox
    Friend WithEvents ScrapeAfter As TextBox
    Friend WithEvents ScrapeBegin As TextBox
    Friend WithEvents ScrapeEnd As TextBox
    Friend WithEvents Description As TextBox
    Friend WithEvents Log As TextBox
    Friend WithEvents ScrapeReplace As TextBox
    Friend WithEvents ScrapeReplaceW As TextBox
End Class
