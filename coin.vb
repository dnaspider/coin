Public Class coin
    Private Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vKey As Int32) As UShort

    ReadOnly g_url = "https://www.coinbase.com/"
    Dim g_i = 0
    ReadOnly g_frequency = 180 '180*ms=run 
    Dim g_zoom As Single
    Dim g_FromLoadWeb = 0
    Dim g_drag As Boolean
    Dim g_drag_x As Integer
    Dim g_drag_y As Integer

    Sub DragFormInit()
        g_drag = True
        g_drag_x = Cursor.Position.X - Me.Left
        g_drag_y = Cursor.Position.Y - Me.Top
    End Sub

    Sub DragForm()
        If g_drag = True Then
            Me.Top = Cursor.Position.Y - g_drag_y
            Me.Left = Cursor.Position.X - g_drag_x
        End If
    End Sub

    Private Sub RichTextBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles RichTextBox1.MouseDoubleClick
        g_zoom = RichTextBox1.ZoomFactor
        LoadWeb()
        RichTextBox1.ZoomFactor = g_zoom
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, RichTextBox1.MouseDown
        If MouseButtons = Windows.Forms.MouseButtons.Left Then DragFormInit()
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp, RichTextBox1.MouseUp
        RichTextBox1.SelectionStart = 0
        RichTextBox1.SelectionLength = 0
        g_drag = False
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove, RichTextBox1.MouseMove
        If MouseButtons = Windows.Forms.MouseButtons.Left Then DragForm()
    End Sub

    Private Sub RichTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBox1.KeyPress
        If GetAsyncKeyState(Keys.Enter) Then LoadWeb()
        If GetAsyncKeyState(Keys.T) Then
            ToggleTimer()
            g_i = 0
        End If
        If GetAsyncKeyState(Keys.O) Then ToggleOptions()
        If GetAsyncKeyState(Keys.A) Then
            If Not TopMost Then TopMost = True Else TopMost = False
        End If
    End Sub

    Sub LoadWeb()
        WebBrowser1.Navigate(g_url)
        AddHandler(WebBrowser1.DocumentCompleted), AddressOf Run
        g_FromLoadWeb = 0
    End Sub

    Sub ToggleTimer()
        If Not Timer1.Enabled Then
            Label1.Left = RichTextBox1.Left + 3
            Timer1.Enabled = True
            Label1.Visible = True
        Else
            Timer1.Enabled = False
            Label1.Visible = False
        End If
    End Sub

    Sub ToggleOptions()
        If Me.FormBorderStyle = FormBorderStyle.None Then
            Me.FormBorderStyle = FormBorderStyle.Sizable
        Else
            Me.FormBorderStyle = FormBorderStyle.None
        End If
    End Sub

    Sub Run()
        If g_FromLoadWeb >= 1 Then
            Return
        Else
            g_FromLoadWeb += 1
        End If

        If WebBrowser1.DocumentText.IndexOf("<title>N") > 0 Or WebBrowser1.DocumentText.IndexOf("ge</title>") > 0 Then
            If Width < 76 Then Width = 76
            RichTextBox1.Text = " Not connected"
            Exit Sub '<title>Navigation Canceled</title> <title>Can&rsquo;t reach this page</title>
        End If

        Dim i = WebBrowser1.DocumentText.IndexOf("$", WebBrowser1.DocumentText.IndexOf("BTC</h4>"))
        Dim p = WebBrowser1.DocumentText.IndexOf("<", i)
        RichTextBox1.Text = " " + WebBrowser1.DocumentText.Substring(i, p - i)
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        If GetAsyncKeyState(Keys.F1) Then
            MsgBox("DOUBLE_CLICK or ENTER:" + vbNewLine + "Get BTC price from " + g_url +
               vbNewLine + vbNewLine + "T:" + vbNewLine + "Toggle one minute timer on/off" +
               vbNewLine + vbNewLine + "CTRL + SCROLL_WHEEL:" + vbNewLine + "Font size" +
               vbNewLine + vbNewLine + "A:" + vbNewLine + "Always on top" +
               vbNewLine + vbNewLine + "O:" + vbNewLine + "Options" +
            vbNewLine + vbNewLine + "ESC:" + vbNewLine + "Exit", vbInformation)
        End If
        If GetAsyncKeyState(Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        WebBrowser1.ScriptErrorsSuppressed = True
        LoadWeb()
        Height = 15
        Width = 61
        Label1.Top = Me.Height - 1
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If g_i = 0 Then LoadWeb()
        g_i += 1
        Label1.Width = g_i / g_frequency * Width
        If g_i > g_frequency Then g_i = 0
    End Sub

    Private Sub RichTextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyUp
        If GetAsyncKeyState(Keys.LControlKey) Then g_zoom = RichTextBox1.ZoomFactor
    End Sub
End Class