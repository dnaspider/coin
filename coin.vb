Imports System.Net
Imports System.IO

Public Class coin
    Private Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vKey As Int32) As UShort

    Dim g_i = 0
    Dim g_Frequency = 180 '180*333ms=run 
    Dim g_zoom As Single
    Dim g_drag As Boolean
    Dim g_drag_x As Integer
    Dim g_drag_y As Integer

    Sub LoadSettings()
        If My.Settings.Sizeable Then Me.FormBorderStyle = FormBorderStyle.Sizable Else Me.FormBorderStyle = FormBorderStyle.None
        If My.Settings.Icon > "" Then
            Me.Icon = New Icon(My.Settings.Icon)
            Me.ShowIcon = True
            Me.Icon = Me.Icon
        End If
        Text = My.Settings.Title
        If My.Settings.URL > "" Then S_URL.Text = My.Settings.URL 'https://www.coinbase.com/
        If My.Settings.ScrapeAfter > "" Then S_ScrapeAfter.Text = My.Settings.ScrapeAfter 'BTC</h4>
        If My.Settings.ScrapeBegin > "" Then S_ScrapeBegin.Text = My.Settings.ScrapeBegin '$
        If My.Settings.ScrapeEnd > "" Then S_ScrapeEnd.Text = My.Settings.ScrapeEnd '<
        S_Log.Text = My.Settings.Log
        If My.Settings.LogWordWrap Then RichTextBox1.WordWrap = True Else RichTextBox1.WordWrap = False
        If My.Settings.Description > "" Then S_Description.Text = My.Settings.Description 'Get BTC price
        If My.Settings.TimerFrequency > 0 Then Timer1.Interval = My.Settings.TimerFrequency '333
        If My.Settings.Frequency > 0 Then g_Frequency = My.Settings.Frequency '180
        RichTextBox1.ZoomFactor = My.Settings.Zoom : Zoom()
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
        If Timer1.Enabled And My.Settings.ShowBar Then Label1.Visible = True
        CopyColoro()
        If FormBorderStyle = BorderStyle.None Then Label1.Top = Me.Height - 1 : ToggleOptionsV(False) Else Label1.Top = Me.Height - 40
        RichTextBox1.Width = Me.Width - RichTextBox1.Left
        If My.Settings.FirstRun = True Then F1_MessageBox()
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
        If Me.FormBorderStyle = FormBorderStyle.Sizable Then My.Settings.Sizeable = True Else My.Settings.Sizeable = False
        My.Settings.Icon = My.Settings.Icon
        My.Settings.FirstRun = False
        My.Settings.Title = My.Settings.Title
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
        LoadWeb()
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

    Private Sub RichTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBox1.KeyPress ', S_URL.KeyPress, S_ScrapeEnd.KeyPress, S_ScrapeBegin.KeyPress, S_ScrapeAfter.KeyPress, S_Description.KeyPress, S_Log.KeyPress
        If CheckIfFocused_S() Then Exit Sub
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
        Dim src = ""
        Dim wrResponse As WebResponse
        Dim wrRequest As WebRequest = HttpWebRequest.Create(S_URL.Text)

        Try
            wrResponse = wrRequest.GetResponse()
            Using sr As New StreamReader(wrResponse.GetResponseStream())
                src = sr.ReadToEnd()
                sr.Close()
            End Using
        Catch ex As Exception
            RichTextBox1.Text = " Not connected"
            If Width < 76 Then Width = 76
            Logo()
            g_i += 1
            Exit Sub
        End Try

        Dim i = src.IndexOf(S_ScrapeBegin.Text, src.IndexOf(S_ScrapeAfter.Text))
        Dim p = src.IndexOf(S_ScrapeEnd.Text, i)
        RichTextBox1.Text = " " + src.Substring(i, p - i)

        Logo()

        g_i += 1
    End Sub

    Sub ToggleTimer()
        If Not Timer1.Enabled Then
            Timer1.Enabled = True
            If My.Settings.ShowBar Then Label1.Visible = True
        Else
            Timer1.Enabled = False
            Label1.Visible = False
        End If
        Label1.Left = 0
    End Sub

    Sub ToggleOptionsV(b)
        GetAsyncKeyState(Keys.LShiftKey) : If GetAsyncKeyState(Keys.LShiftKey) Then Exit Sub
        If b = True Then b = 1 Else b = 0
        S_URL.Visible = b
        S_Description.Visible = b
        S_ScrapeAfter.Visible = b
        S_ScrapeBegin.Visible = b
        S_ScrapeEnd.Visible = b
        S_Log.Visible = b
    End Sub

    Sub ToggleOptions()
        If Me.FormBorderStyle = FormBorderStyle.None Then
            Me.FormBorderStyle = FormBorderStyle.Sizable
            If My.Settings.Icon > "" Then
                Me.ShowIcon = True
                Me.Icon = Me.Icon
            End If
            ToggleOptionsV(True)
        Else
            Me.FormBorderStyle = FormBorderStyle.None
            ToggleOptionsV(False)
        End If
        RichTextBox1.Width = Me.Width - RichTextBox1.Left
    End Sub

    Sub Logo()
        If S_Log.Text = "" Or S_Log.Text.StartsWith("'") Then Return

        Dim logDesc = ""
        If My.Settings.LogDescription Then logDesc = " " + S_Description.Text
        If S_Description.Text.StartsWith("'") Then logDesc = " " + S_Description.Text.Substring(1)

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

        S_Log.AppendText(d & " " & t & logDesc & RichTextBox1.Text & vbCrLf)
    End Sub

    Sub F1_MessageBox()
        Dim q = 0, s
        If S_Description.Focused Then q = 1
        If S_URL.Focused Then q = 2
        If S_ScrapeAfter.Focused Then q = 3
        If S_ScrapeBegin.Focused Then q = 4
        If S_ScrapeEnd.Focused Then q = 5
        If S_Log.Focused Then q = 6
        Select Case q
            Case 1
                s = "Description" + vbNewLine + vbNewLine +
                "Add to log:" + vbTab + "'Description" + vbNewLine +
                "DOUBLE_CLICK:" + vbTab + "Toggle '"
            Case 2
                s = "Scrape: " + S_URL.Text
            Case 3
                s = "Start scrape after: IndexOf(""" + S_ScrapeAfter.Text + """)"
            Case 4
                s = "Scrape begin: IndexOf(""" + S_ScrapeBegin.Text + """)"
            Case 5
                s = "Scrape end: IndexOf(""" + S_ScrapeEnd.Text + """)"
            Case 6
                s = "Log (" + S_Log.Lines.Count.ToString + ")" + vbNewLine + vbNewLine +
                    "Clear text or 'text:" + vbTab + "Disable" + vbNewLine +
                    "DOUBLE_CLICK:" + vbTab + "Toggle '"
            Case Else
                s = "Scrape:" + vbTab + vbTab + vbTab + S_URL.Text +
                vbNewLine + "Scrape after (IndexOf):" + vbTab + S_ScrapeAfter.Text +
                vbNewLine + "Scrape begin:" + vbTab + vbTab + S_ScrapeBegin.Text +
                vbNewLine + "Scrape end:" + vbTab + vbTab + S_ScrapeEnd.Text +
                vbNewLine + "Description:" + vbTab + vbTab + S_Description.Text +
                vbNewLine + vbNewLine + "DOUBLE_CLICK or ENTER:" + vbTab + "Run" +
                vbNewLine + "T:" + vbTab + vbTab + vbTab + "Toggle timer on/off" + " (" + Timer1.Enabled.ToString + ", " + My.Settings.TimerFrequency.ToString + "ms)" +
                vbNewLine + "UP/DOWN:" + vbTab + vbTab + "+/- Frequency (" + g_Frequency.ToString + ")" +
                vbNewLine + "O (SHIFT):" + vbTab + vbTab + "Toggle options" +
                vbNewLine + "CTRL + SCROLL_WHEEL:" + vbTab + "Font size" +
                vbNewLine + "0-9 (SHIFT or CTRL):" + vbTab + "Color" +
                vbNewLine + "A:" + vbTab + vbTab + vbTab + "Toggle always on top" +
                vbNewLine + "V:" + vbTab + vbTab + vbTab + "Position" +
                vbNewLine + "+/-:" + vbTab + vbTab + vbTab + "Opacity" +
                vbNewLine + "ESC:" + vbTab + vbTab + vbTab + "Exit" +
                vbNewLine + "F1:" + vbTab + vbTab + vbTab + "?" +
                vbNewLine + vbNewLine + "Settings:" + vbTab + vbTab + vbTab + "C:\Users\..\AppData\Local\coin\..\..\user.config" +
                vbNewLine + "Reset:" + vbTab + vbTab + vbTab + "Delete coin folder (C:\Users\..\AppData\Local\coin)"
        End Select
        MsgBox(s, vbInformation, My.Settings.Title)
    End Sub

    Function CheckIfFocused_S() As Boolean
        Return S_Description.Focused Or S_URL.Focused Or S_ScrapeAfter.Focused Or S_ScrapeBegin.Focused Or S_ScrapeEnd.Focused Or S_Log.Focused
    End Function

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown, S_URL.KeyDown, S_ScrapeEnd.KeyDown, S_ScrapeBegin.KeyDown, S_ScrapeAfter.KeyDown, S_Description.KeyDown, S_Log.KeyDown
        If GetAsyncKeyState(Keys.F1) Then F1_MessageBox()
        If CheckIfFocused_S() Then Exit Sub
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
        If GetAsyncKeyState(Keys.Up) Then g_Frequency += 1
        If GetAsyncKeyState(Keys.Down) Then g_Frequency -= 1
        If GetAsyncKeyState(Keys.Escape) Then Me.Close()
        If GetAsyncKeyState(Keys.V) Then
            Top = Cursor.Position.Y - Me.Height
            Left = Cursor.Position.X - Me.Width
        End If
        If GetAsyncKeyState(Keys.LControlKey) Then Zoom()
    End Sub

    Sub Zoom()
        g_zoom = RichTextBox1.ZoomFactor
        Select Case g_zoom
            Case > 4.5
                RichTextBox1.Left = -6
            Case > 2.5
                RichTextBox1.Left = -5
            Case Else
                RichTextBox1.Left = -3
        End Select
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Visible = False
        LoadSettings()
        LoadWeb()
        Visible = True
        AppActivate(My.Settings.Title)
        RichTextBox1.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If g_i = 0 Then LoadWeb()
        g_i += 1
        Label1.Width = g_i / g_Frequency * Me.Width '180*333ms=run 
        If g_i - 1 > g_Frequency Then g_i = 0 : Label1.Width = 0
    End Sub

    Private Sub coin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSettings()
    End Sub

    Sub ToggleHyph(c As Control)
        If c.Text.StartsWith("'") Then c.Text = c.Text.Substring(1) Else c.Text = "'" + c.Text
    End Sub

    Private Sub S_Description_DoubleClick(sender As Object, e As EventArgs) Handles S_Description.DoubleClick
        ToggleHyph(S_Description)
    End Sub

    Private Sub S_Log_DoubleClick(sender As Object, e As EventArgs) Handles S_Log.DoubleClick
        ToggleHyph(S_Log)
    End Sub

    Private Sub S_Log_MouseWheel(sender As Object, e As MouseEventArgs) Handles S_Log.MouseWheel
        S_Log.Focus()
        If e.Delta > 1 Then
            If S_Log.GetFirstCharIndexOfCurrentLine > 1 Then S_Log.SelectionStart = S_Log.GetFirstCharIndexOfCurrentLine - 1
        Else
            S_Log.SelectionStart += S_Log.GetFirstCharIndexOfCurrentLine + 1
        End If
        S_Log.ScrollToCaret()
    End Sub

    Private Sub S_Log_MouseLeave(sender As Object, e As EventArgs) Handles S_Log.MouseLeave
        RichTextBox1.Focus()
    End Sub
End Class