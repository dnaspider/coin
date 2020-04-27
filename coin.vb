Public Class coin
    Private Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vKey As Int32) As UShort

    Dim g_i = 0
    Dim g_Frequency = 180 '180*333ms=run 
    Dim g_zoom As Single
    Dim g_FromLoadWeb = 0
    Dim g_drag As Boolean
    Dim g_drag_x As Integer
    Dim g_drag_y As Integer

    Sub LoadSettings()
        If My.Settings.URL > "" Then S_URL.Text = My.Settings.URL
        If My.Settings.ScrapeAfter > "" Then S_ScrapeAfter.Text = My.Settings.ScrapeAfter
        If My.Settings.ScrapeBegin > "" Then S_ScrapeBegin.Text = My.Settings.ScrapeBegin
        If My.Settings.ScrapeEnd > "" Then S_ScrapeEnd.Text = My.Settings.ScrapeEnd
        S_Log.Text = My.Settings.Log
        If My.Settings.Description > "" Then S_Description.Text = My.Settings.Description
        If My.Settings.TimerFrequency > 0 Then Timer1.Interval = My.Settings.TimerFrequency
        If My.Settings.Frequency > 0 Then g_Frequency = My.Settings.Frequency
        RichTextBox1.ZoomFactor = My.Settings.Zoom
        RichTextBox1.ForeColor = My.Settings.TextColor
        RichTextBox1.BackColor = My.Settings.BackgroundColor
        RichTextBox1.Left = My.Settings.MiscZoomLeft
        Label1.BackColor = My.Settings.BarColor
        Opacity = My.Settings.Opacity
        TopMost = My.Settings.TopMost
        Top = My.Settings.Top
        Left = My.Settings.Left
        Height = My.Settings.Height
        Width = My.Settings.Width
        Timer1.Enabled = My.Settings.TimerEnabled
        If Timer1.Enabled Then Label1.Visible = True
        CopyColoro()
    End Sub

    Sub CopyColoro()
        S_URL.BackColor = RichTextBox1.BackColor
        S_Description.BackColor = RichTextBox1.BackColor
        S_ScrapeAfter.BackColor = RichTextBox1.BackColor
        S_ScrapeBegin.BackColor = RichTextBox1.BackColor
        S_ScrapeEnd.BackColor = RichTextBox1.BackColor
        S_Log.BackColor = RichTextBox1.BackColor
        S_URL.ForeColor = RichTextBox1.ForeColor
        S_Description.ForeColor = RichTextBox1.ForeColor
        S_ScrapeAfter.ForeColor = RichTextBox1.ForeColor
        S_ScrapeBegin.ForeColor = RichTextBox1.ForeColor
        S_ScrapeEnd.ForeColor = RichTextBox1.ForeColor
        S_Log.ForeColor = RichTextBox1.ForeColor
    End Sub

    Sub SaveSettings()
        My.Settings.URL = S_URL.Text
        My.Settings.ScrapeAfter = S_ScrapeAfter.Text
        My.Settings.ScrapeBegin = S_ScrapeBegin.Text
        My.Settings.ScrapeEnd = S_ScrapeEnd.Text
        My.Settings.Description = S_Description.Text
        My.Settings.Log = S_Log.Text
        If g_Frequency > 0 Then My.Settings.Frequency = g_Frequency
        If Timer1.Interval > 0 Then My.Settings.TimerFrequency = Timer1.Interval
        My.Settings.TimerEnabled = Timer1.Enabled
        My.Settings.Zoom = RichTextBox1.ZoomFactor
        My.Settings.TextColor = RichTextBox1.ForeColor
        My.Settings.BackgroundColor = RichTextBox1.BackColor
        My.Settings.MiscZoomLeft = RichTextBox1.Left
        My.Settings.BarColor = Label1.BackColor
        My.Settings.Opacity = Opacity
        My.Settings.TopMost = TopMost
        My.Settings.Top = Top
        My.Settings.Left = Left
        My.Settings.Height = Height
        My.Settings.Width = Width
    End Sub

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

    Sub Coloro(c)
        Dim q = 0
        If GetAsyncKeyState(Keys.LShiftKey) Then q = 1
        If GetAsyncKeyState(Keys.LControlKey) Then q = 2
        Select Case q
            Case 1
                RichTextBox1.BackColor = c
            Case 2
                Label1.BackColor = c
            Case Else
                RichTextBox1.ForeColor = c
        End Select
        CopyColoro()
    End Sub

    Private Sub RichTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBox1.KeyPress, S_URL.KeyPress, S_ScrapeEnd.KeyPress, S_ScrapeBegin.KeyPress, S_ScrapeAfter.KeyPress, S_Description.KeyPress, S_Log.KeyPress
        If GetAsyncKeyState(Keys.Enter) Then LoadWeb()
        If GetAsyncKeyState(Keys.T) Then
            ToggleTimer()
            g_i = 0
        End If
        If GetAsyncKeyState(Keys.O) Then ToggleOptions()
        If GetAsyncKeyState(Keys.A) Then
            If Not TopMost Then TopMost = True Else TopMost = False
        End If
        If GetAsyncKeyState(Keys.Oemplus) Then Opacity += 0.1
        If GetAsyncKeyState(Keys.OemMinus) Then Opacity -= 0.1
    End Sub

    Sub LoadWeb()
        WebBrowser1.Navigate(S_URL.Text)
        AddHandler(WebBrowser1.DocumentCompleted), AddressOf Run
        g_FromLoadWeb = 0
    End Sub

    Sub ToggleTimer()
        If Not Timer1.Enabled Then
            Timer1.Enabled = True
            Label1.Visible = True
        Else
            Timer1.Enabled = False
            Label1.Visible = False
        End If
        Label1.Left = 0
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
        Dim i = WebBrowser1.DocumentText.IndexOf(S_ScrapeBegin.Text, WebBrowser1.DocumentText.IndexOf(S_ScrapeAfter.Text))
        Dim p = WebBrowser1.DocumentText.IndexOf(S_ScrapeEnd.Text, i)
        RichTextBox1.Text = " " + WebBrowser1.DocumentText.Substring(i, p - i)
        Logo()
        g_i += 1
    End Sub

    Sub Logo()
        If S_Log.Text = "" Or S_Log.Text.StartsWith("'") Then Return
        Dim h = Date.Now.Hour.ToString
        Dim hh = CInt(h)
        Dim m = "AM"
        If CInt(h) = 0 Then hh += 12 Else If CInt(h) > 12 Then m = "PM" : hh -= 12
        Dim mi = Date.Now.Minute.ToString
        If mi.Length = 1 Then mi = "0" & mi
        Dim s = Date.Now.Second.ToString
        If s.Length = 1 Then s = "0" & s
        Dim t = hh & ":" & mi & ":" & s & ":" & m
        Dim d = Date.Now.Month.ToString & "/" & Date.Now.Day.ToString & "/" & Date.Now.Year.ToString
        S_Log.Text += d & " " & t & " " & RichTextBox1.Text & vbCrLf
        S_Log.SelectionStart = S_Log.TextLength
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown, S_URL.KeyDown, S_ScrapeEnd.KeyDown, S_ScrapeBegin.KeyDown, S_ScrapeAfter.KeyDown, S_Description.KeyDown, S_Log.KeyDown
        GetAsyncKeyState(Keys.LShiftKey)
        GetAsyncKeyState(Keys.LControlKey)
        If GetAsyncKeyState(Keys.D0) Then Coloro(Color.Lime)
        If GetAsyncKeyState(Keys.D1) Then Coloro(Color.Red)
        If GetAsyncKeyState(Keys.D2) Then Coloro(Color.White)
        If GetAsyncKeyState(Keys.D3) Then Coloro(Color.Blue)
        If GetAsyncKeyState(Keys.D4) Then Coloro(Color.Black)
        If GetAsyncKeyState(Keys.D5) Then Coloro(Color.Cyan)
        If GetAsyncKeyState(Keys.D6) Then Coloro(Color.DarkCyan)
        If GetAsyncKeyState(Keys.D7) Then Coloro(Color.HotPink)
        If GetAsyncKeyState(Keys.D8) Then Coloro(Color.DarkOrange)
        If GetAsyncKeyState(Keys.D9) Then Coloro(Color.Purple)
        If GetAsyncKeyState(Keys.F1) Then
            Dim q = 0, s
            If S_Description.Focused Then q = 1
            If S_URL.Focused Then q = 2
            If S_ScrapeAfter.Focused Then q = 3
            If S_ScrapeBegin.Focused Then q = 4
            If S_ScrapeEnd.Focused Then q = 5
            If S_Log.Focused Then q = 6
            Select Case q
                Case 1
                    s = "Description"
                Case 2
                    s = "Scrape: " + S_URL.Text
                Case 3
                    s = "Start scrape after: IndexOf(""" + S_ScrapeAfter.Text + """)"
                Case 4
                    s = "Scrape begin: IndexOf(""" + S_ScrapeBegin.Text + """)"
                Case 5
                    s = "Scrape end: IndexOf(""" + S_ScrapeEnd.Text + """)"
                Case 6
                    s = "Log" + vbNewLine + vbNewLine + "Clear text or 'text:  Disable"
                Case Else
                    s = "DOUBLE_CLICK or ENTER:" + vbNewLine + S_Description.Text + S_URL.Text +
                    vbNewLine + vbNewLine + "T:" + vbNewLine + "Toggle one minute timer on/off" +
                    vbNewLine + vbNewLine + "CTRL + SCROLL_WHEEL:" + vbNewLine + "Font size" +
                    vbNewLine + vbNewLine + "0-9 (SHIFT or CTRL):" + vbNewLine + "Color" +
                    vbNewLine + vbNewLine + "A:" + vbNewLine + "Always on top" +
                    vbNewLine + vbNewLine + "Up/Down:" + vbNewLine + "Frequency" +
                    vbNewLine + vbNewLine + "V:" + vbNewLine + "Position" +
                    vbNewLine + vbNewLine + "O:" + vbNewLine + "Options" +
                    vbNewLine + vbNewLine + "+/-:" + vbNewLine + "Opacity" +
                    vbNewLine + vbNewLine + "ESC:" + vbNewLine + "Exit" +
                    vbNewLine + vbNewLine + "F1:" + vbNewLine + "?"
            End Select
            MsgBox(s, vbInformation, "coin.exe")
        End If
        If GetAsyncKeyState(Keys.Up) Then g_Frequency += 1
        If GetAsyncKeyState(Keys.Down) Then g_Frequency -= 1
        If GetAsyncKeyState(Keys.Escape) Then Me.Close()
        If GetAsyncKeyState(Keys.V) Then
            Top = Cursor.Position.Y - Me.Height
            Left = Cursor.Position.X - Me.Width
        End If
        If GetAsyncKeyState(Keys.LControlKey) Then
            g_zoom = RichTextBox1.ZoomFactor
            Select Case g_zoom
                Case > 4.5
                    RichTextBox1.Left = -6
                Case > 2.5
                    RichTextBox1.Left = -5
                Case Else
                    RichTextBox1.Left = -3
            End Select
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        S_URL.Text = "https://www.coinbase.com/"
        S_ScrapeBegin.Text = "$"
        S_ScrapeAfter.Text = "BTC</h4>"
        S_ScrapeEnd.Text = "<"
        S_Description.Text = "Get BTC price from "
        LoadSettings()
        WebBrowser1.ScriptErrorsSuppressed = True
        LoadWeb()
        Label1.Top = Me.Height - 1
        RichTextBox1.Width += 10
        RichTextBox1.Height += 10
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If g_i = 0 Then LoadWeb()
        g_i += 1
        Label1.Width = g_i / g_Frequency * Me.Width '180*333ms=run 
        If g_i > g_Frequency Then g_i = 0
    End Sub

    Private Sub coin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSettings()
    End Sub
End Class