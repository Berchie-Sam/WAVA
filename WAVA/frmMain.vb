
Imports System.Speech.Synthesis
Imports System.Speech
Imports System.Text.RegularExpressions
Imports System.Text
Imports mshtml
Imports System.IO



Public Class frmMain
    'Declaration of Class variables
    Private doc As String
    Public Shared msg, tooltipMessage As String
    Public Shared voice As New SpeechSynthesizer
    Public WithEvents Recognit As New Recognition.SpeechRecognitionEngine
    Private InitialZoom As Integer = 100
    Private state As Boolean


    'Definition of subroutines or functions
    Public Sub Mouse_Hover()
        'This block of code reads a message when the mouse hovers over a control 
        Try
            voice.SpeakAsync(tooltipMessage)
        Catch ex As Exception
            msg = ex.Message
        End Try
    End Sub

    Private Sub VocalEnhancements()
        'This block of code enables the selection of the type of voice
        Select Case (cbVoice_Gender.SelectedItem.ToString())
            Case "Neutral"
                voice.SelectVoiceByHints(VoiceGender.Neutral)
            Case "Female"
                voice.SelectVoiceByHints(VoiceGender.Female)
            Case "Male"
                voice.SelectVoiceByHints(VoiceGender.Male)
        End Select
        'This part specifies the volume and speed of the speech synthesizer
        voice.Volume = VolumeTrackbar.Value
        voice.Rate = SpeedTrackBar.Value

        If IsNothing(WebBrowser1.Document.Body.InnerHtml) = False Then
            RemoveHTMLTags(doc)
            RemoveScriptsandStylesheets(doc)
        End If
        voice.SpeakAsync(doc)
    End Sub

    'Remove HTML 
    Public Sub RemoveHTMLTags(ByVal HTMLCode As String)

        Dim sHTML As New StringBuilder(HTMLCode)

        Try
            Dim OldWords() As String = {"&nbps;", "&amp;", "&quot;", "&lt;", "&gt", "&req;", "&copy;", "&bull;", "&trade;"}

            Dim NewWord As String = " "

            For i As Integer = 0 To 9 And i <= OldWords.Length
                sHTML.Replace(OldWords(i), NewWord)
            Next i

            Regex.Replace(HTMLCode, "<!(.|\s)*?>", "") 'Returns the result after DOCTYPE is removed
            Regex.Replace(HTMLCode, "</?[a-z][a-z0-9]*[^<>]*>", "") 'Returns the result after HTML tags are removed
            Regex.Replace(HTMLCode, "<!--(.|\s)*?-->", "") 'Returns the result after HTML comments are removed
            Regex.Replace(HTMLCode, "<script.*?</script>", "") 'Returns the result after script tags are removed
        Catch ex As Exception
            msg = ex.Message
        End Try
    End Sub

    Public Function RemoveScriptsandStylesheets(ByVal HTMLCode As String) As String
        'This line of code returns the result  after stylesheets are removed
        Return Regex.Replace(HTMLCode, "<style.*?</style>", "", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
        Return Regex.Replace(HTMLCode, "<script.*?</script>", "", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
        Return Regex.Replace(HTMLCode, "<iframe.*?</iframe>", "", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
        Return Regex.Replace(HTMLCode, "<div.*?</div>", "", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
        Return Regex.Replace(HTMLCode, "<p.*?</p>", "", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
        Return Regex.Replace(HTMLCode, ".glabel{.*?}", "", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
    End Function

    Private Sub WebpageAsString()
        Try
            doc = WebBrowser1.Document.Body.InnerText 'Converts the webpage to string
            RemoveHTMLTags(doc)
            RemoveScriptsandStylesheets(doc)
            txtTextView.Text = doc.ToString 'Assigns and displays the content of doc in the Textpage textbox
        Catch ex As Exception
            msg = ex.Message
        End Try
    End Sub
    Public Sub RemoveHtmlBreaks(ByVal HTMLCode As String)
        Dim sHTML As New StringBuilder(HTMLCode)
        Try
            RemoveHTMLTags(HTMLCode)
            RemoveScriptsandStylesheets(HTMLCode)

            'Checks if there are line breaks (<br>) and paragraphs (<p>) 
            sHTML.Replace("<br>", "\n<br>")
            sHTML.Replace("<br", "\n<br")
            sHTML.Replace("<p", "\n<p")
        Catch ex As Exception
            msg = ex.Message
        End Try
    End Sub
    Public Sub ShowAbout()
        'This block of code shows the version of the application,name and information about the application
        On Error Resume Next
        frmAbout.Show()
    End Sub

    Private Function StatusAndZoom() As Boolean

        If state = True Then
            StatusStrip1.Visible = True
            StatusLabel.Visible = True 'This line displays the status of the web browser as it loads
            btnZoomIn.Visible = True 'Displays the Zoom In button
            btnZoomOut.Visible = True 'Displays the Zoom Out Button
        Else
            StatusStrip1.Visible = False
            StatusLabel.Visible = False 'This line hides the status of the web browser as it loads
            btnZoomIn.Visible = False 'Hides the Zoom In button
            btnZoomOut.Visible = False 'Hides the Zoom Out Button
        End If

        Return state
    End Function
    Private Sub DoWebpageRead()
        'This part gets the inner parts of the html document
        If doc <> Nothing Then
            VocalEnhancements()
        End If
    End Sub
    Private Sub LoadRecognition()
        Try
            Recognit.SetInputToDefaultAudioDevice()

            'Declaration of variables and arrays for speech recognition
            Dim gram As New Recognition.SrgsGrammar.SrgsDocument
            Dim commandRule As New Recognition.SrgsGrammar.SrgsRule("command")
            Dim commandsList As New Recognition.SrgsGrammar.SrgsOneOf("Back", "Forward", "GO", "Search", "Navigate", "Refresh", "Reload", "Home", "Stop", "Read Aloud", "Cancel Speech", "Stop Speech", "Resume Speech", "Play", "Pause Speech", "Pause")

            commandRule.Add(commandsList) 'Adds list of words(commands) to the grammar rule
            gram.Rules.Add(commandRule)
            gram.Root = commandRule

            'Loads the specified words or 'grammar' into the speech recognition engine
            Recognit.LoadGrammar(New Recognition.Grammar(gram))
            'This linne of code enables the speech recogntion engine to recognize words that are available in its dictionary or rule asynchronously
            Recognit.RecognizeAsync()
        Catch ex As Exception
        End Try
    End Sub

    'The following block of code sets an enumeration (a set of constants) to enable zooming feature of the web browser coontrol
    Public Enum Exec
        OLECMDID_OPTICAL_ZOOM = 63
    End Enum
    Private Enum execOpt
        OLECMDEXECOPT_DODEFAULT = 0
        OLECMDEXECOPT_PROMPTUSER = 1
        OLECMDEXECOPT_DONTPROMPTUSER = 2
        OLECMDEXECOPT_SHOWHELP = 3
    End Enum

    'This block of code enables zooming of web browser control
    Public Sub PerformZoom(ByVal Value As Integer)
        Try
            Dim Res As Object = Nothing
            Dim MyWeb As Object
            MyWeb = Me.WebBrowser1.ActiveXInstance 'Calls the ActiveX instance of the web browser control
            MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, execOpt.OLECMDEXECOPT_PROMPTUSER,
                         CObj(Value), CObj(IntPtr.Zero))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'This block of code navigates the web 
    'By fetching the url entered in the address bar
    Private Sub DoWebSearch()
        If txtAddressBar.Text.Contains("http:") Then
            'Outputs a message to the user when the url does not contain the 'https' 
            msg = MessageBox.Show("The specified webpage may be insecure. Do you wish to continue to the webpage?", "Security Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If (msg = DialogResult.Yes) Then
                WebBrowser1.Navigate(txtAddressBar.Text)
            End If
        Else
            WebBrowser1.Navigate(txtAddressBar.Text)
        End If
    End Sub

    'End of Subroutine and Function definition
    Private Sub tspbtnBack_Click(sender As Object, e As EventArgs) Handles tspbtnBack.Click, BackToolStripMenuItem.Click
        'The GoBack method  sends the web browser control to the previous webpage
        'This method, as defined below for the web browser control, is performed when 
        'the "Back" button is clicked
        WebBrowser1.GoBack()
    End Sub
    Private Sub tspbtnForward_Click(sender As Object, e As EventArgs) Handles tspbtnForward.Click, ForwardToolStripMenuItem.Click
        'This line of code enables the web browser control to move forward 
        'to the next webpage that had been accessed  
        WebBrowser1.GoForward()
    End Sub

    Private Sub tspbtnRefresh_Click(sender As Object, e As EventArgs) Handles tspbtnRefresh.Click
        'This line enables the web browser control to refresh or reload its current webpage
        WebBrowser1.Refresh()
    End Sub

    Private Sub tspbtnSearch_Click(sender As Object, e As EventArgs) Handles tspbtnSearch.Click, SearchToolStripMenuItem.Click
        'This block of code enables the web browser control to navigate the web in search of the url specified in the address bar
        DoWebSearch()
        tspbtnRefresh.Enabled = True
    End Sub

    Private Sub tspbtnHome_Click(sender As Object, e As EventArgs) Handles tspbtnHome.Click, HomeToolStripMenuItem.Click
        'This block of code returns the web browser control the Homepage 
        'and deactivates the Back button 
        WebBrowser1.Navigate("https://www.google.co.uk/")
        tspbtnBack.Enabled = False
    End Sub

    Private Sub tspbtnStop_Click(sender As Object, e As EventArgs) Handles tspbtnStop.Click
        'This line of code stops the web browser control from loading a webpage
        WebBrowser1.Stop()
    End Sub

    Private Sub tspbtnReadAloud_Click(sender As Object, e As EventArgs) Handles tspbtnReadAloud.Click, ReadAloudToolStripMenuItem.Click
        Try
            Call DoWebpageRead()
        Catch ex As Exception
            msg = MessageBox.Show(ex.Message)
            voice.SpeakAsync(msg)
        End Try

    End Sub

    Private Sub tspbtnResumeReading_Click(sender As Object, e As EventArgs) Handles ResumeReadingToolStripMenuItem.Click, tspbtnResumeReading.Click
        voice.Resume() 'This line resumes reading activity of the speech synthesizer
    End Sub

    Private Sub tspbtnPauseReading_Click(sender As Object, e As EventArgs) Handles PauseToolStripMenuItem.Click, tspbtnPauseReading.Click
        voice.Pause() 'This line pauses reading activity of the speech synthesizer
    End Sub

    Private Sub txtAddressBar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddressBar.KeyDown
        'This block of code enables the web browser control to navigate the web 
        'in search of the url specified in the address bar when the user
        'presses the 'Enter' key
        Try
            If e.KeyCode = Keys.Enter And txtAddressBar.Text <> Nothing Then
                DoWebSearch()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs)
        'This line of code displays the url of a specific webpage in the address bar
        txtAddressBar.Text = WebBrowser1.Url.ToString()
    End Sub

    'The following subprocedures or subroutines enable the speech synthesizer to read 
    'the name of a command button when the cursor is hovered over it.
    Private Sub tspbtnBack_MouseHover(sender As Object, e As EventArgs) Handles tspbtnBack.MouseHover, BackToolStripMenuItem.MouseHover
        tooltipMessage = "Back"
        Mouse_Hover()
    End Sub
    Private Sub tspbtnForward_MouseHover(sender As Object, e As EventArgs) Handles tspbtnForward.MouseHover, ForwardToolStripMenuItem.MouseHover
        tooltipMessage = "Forward"
        Mouse_Hover()
    End Sub

    Private Sub tspbtnSearch_MouseHover(sender As Object, e As EventArgs) Handles tspbtnSearch.MouseHover, SearchToolStripMenuItem.MouseHover
        tooltipMessage = "Search"
        Mouse_Hover()
    End Sub

    Private Sub tspbtnRefresh_MouseHover(sender As Object, e As EventArgs) Handles tspbtnRefresh.MouseHover
        tooltipMessage = "Refresh"
        Mouse_Hover()
    End Sub

    Private Sub tspbtnHome_MouseHover(sender As Object, e As EventArgs) Handles tspbtnHome.MouseHover, HomeToolStripMenuItem.MouseHover
        tooltipMessage = "Home"
        Mouse_Hover()
    End Sub

    Private Sub tspbtnStopReading_MouseHover(sender As Object, e As EventArgs) Handles StopReadingToolStripMenuItem.MouseHover, tspbtnStopReading.MouseHover
        tooltipMessage = "Stop Reading"
        Mouse_Hover()
    End Sub

    Private Sub tspbtnReadAloud_MouseHover(sender As Object, e As EventArgs) Handles tspbtnReadAloud.MouseHover, ReadAloudToolStripMenuItem.MouseHover
        tooltipMessage = "Read Aloud"
        Mouse_Hover()
    End Sub

    Private Sub tspbtnPauseReading_MouseHover(sender As Object, e As EventArgs) Handles PauseToolStripMenuItem.MouseHover, tspbtnPauseReading.MouseHover
        tooltipMessage = "Pause Reading"
        Mouse_Hover()
    End Sub
    Private Sub tspbtnStop_MouseHover(sender As Object, e As EventArgs) Handles tspbtnStop.MouseHover
        tooltipMessage = "Stop navigation"
        Mouse_Hover()
    End Sub

    Private Sub tspbtnBookmark_MouseHover(sender As Object, e As EventArgs) Handles tspbtnBookmark.MouseHover
        tooltipMessage = "Add Favorite"
        Mouse_Hover()
    End Sub

    Private Sub txtAddressBar_MouseHover(sender As Object, e As EventArgs) Handles txtAddressBar.MouseHover
        tooltipMessage = "Address Bar"
        Mouse_Hover()
    End Sub

    Private Sub ToolStripDropDownButton1_MouseHover(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.MouseHover
        tooltipMessage = "More Options"
        Mouse_Hover()
    End Sub

    Private Sub FileToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.MouseHover
        tooltipMessage = "File"
        Mouse_Hover()
    End Sub

    Private Sub EditToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.MouseHover
        tooltipMessage = "Edit"
        Mouse_Hover()
    End Sub

    Private Sub VIewToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles VIewToolStripMenuItem.MouseHover
        tooltipMessage = "View"
        Mouse_Hover()
    End Sub

    Private Sub HelpToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.MouseHover
        tooltipMessage = "Help"
        Mouse_Hover()
    End Sub

    Private Sub OptionsToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.MouseHover
        tooltipMessage = "Options"
        Mouse_Hover()
    End Sub

    Private Sub FontToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.MouseHover
        tooltipMessage = "Font"
        Mouse_Hover()
    End Sub

    Private Sub ColourToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles ColourToolStripMenuItem.MouseHover
        tooltipMessage = "Colour"
        Mouse_Hover()
    End Sub

    Private Sub FavoritesBookmarksToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles FavoritesBookmarksToolStripMenuItem.MouseHover
        tooltipMessage = "Favorites or Bookmarks"
        Mouse_Hover()
    End Sub

    Private Sub HistoryToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles HistoryToolStripMenuItem.MouseHover
        tooltipMessage = "History"
        Mouse_Hover()
    End Sub

    Private Sub ResumeReadingToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles ResumeReadingToolStripMenuItem.MouseHover, tspbtnResumeReading.MouseHover
        tooltipMessage = "Resume Reading"
        Mouse_Hover()
    End Sub

    Private Sub HelpToolStripMenuItem1_MouseHover(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.MouseHover
        tooltipMessage = "Help"
        Mouse_Hover()
    End Sub

    Private Sub AboutWAVAToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles AboutWAVAToolStripMenuItem.MouseHover
        tooltipMessage = "About WAVA"
        Mouse_Hover()
    End Sub

    Private Sub TextpageToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles TextpageToolStripMenuItem.MouseHover
        tooltipMessage = "Text View"
        Mouse_Hover()
    End Sub

    Private Sub ExitApplicationToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles ExitApplicationToolStripMenuItem.MouseHover
        tooltipMessage = "Exit Application"
        Mouse_Hover()
    End Sub

    Private Sub StatusBarToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles StatusBarToolStripMenuItem.MouseHover
        tooltipMessage = "Status Bar"
        Mouse_Hover()
    End Sub

    Private Sub CutToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.MouseHover
        tooltipMessage = "Cut"
        Mouse_Hover()
    End Sub

    Private Sub CopyToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.MouseHover
        tooltipMessage = "Copy"
        Mouse_Hover()
    End Sub

    Private Sub PasteToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.MouseHover
        tooltipMessage = "Paste"
        Mouse_Hover()
    End Sub

    Private Sub FindToolStripMenuItem_MouseHover(sender As Object, e As EventArgs)
        tooltipMessage = "Find"
        Mouse_Hover()
    End Sub

    Private Sub VoiceGenderToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles VoiceGenderToolStripMenuItem.MouseHover
        tooltipMessage = "Voice Gender"
        Mouse_Hover()
    End Sub

    Private Sub VolumeToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles VolumeToolStripMenuItem.MouseHover
        tooltipMessage = "Volume of voice"
        Mouse_Hover()
    End Sub

    Private Sub RateSpeedToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles RateSpeedToolStripMenuItem.MouseHover
        tooltipMessage = "Speed of voice"
        Mouse_Hover()
    End Sub

    Private Sub WebViewToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles WebViewToolStripMenuItem.MouseHover
        tooltipMessage = "Web View"
        Mouse_Hover()
    End Sub

    'End of Mouse Hover events 


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        state = False

        txtTextView.Visible = False

        StatusAndZoom()

        LoadRecognition() 'This calls the subroutine LoadRecognition

        cbVoice_Gender.Text = "Neutral" 'This line of code sets the default voice to Neutral

        'This block of code disables the buttons for resume reading, pause reading and stop or cancel reading

        txtAddressBar.Text = "https://www.google.co.uk/" 'This displays the web address http://www.google.co.uk in the address bar when the form loads 

        'This block of code adds items in the address bar to the Favorites list
        For Each Item In My.Settings.Favorites
            txtAddressBar.Items.Add(Item)
        Next

        If WebBrowser1.Visible = True Then
            WebViewToolStripMenuItem.Visible = False
            'This If block checks whether the status bar is visible and 
            'adjusts the size of the Web browser control based on result of condition 
            If StatusStrip1.Visible = True Then
                WebBrowser1.Size = New Size(964, 422) 'Decreases the height of the web browser control
            End If
        End If
    End Sub


    Private Sub HistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoryToolStripMenuItem.Click
        'Reveals the History Window 
        frmHistory.Visible = True
    End Sub
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        'This line of code displays the url of a completely loaded webpage in the address bar
        txtAddressBar.Text = WebBrowser1.Url.ToString

        'This line of code ensures that a scroll bar appears on a webpage when necessary
        WebBrowser1.Document.Body.Style = "overflow:auto"

        'Adds the web address of a fully loaded webpage to the History List 
        My.Settings.History.Add(WebBrowser1.Url.ToString)
        frmHistory.ListBox1.Items.Add(WebBrowser1.Url.ToString)

        'Dim domDocument As IHTMLDocument2 = DirectCast(WebBrowser1.Document.DomDocument, IHTMLDocument2)
        'Dim selection As IHTMLSelectionObject = domDocument.selection

        'If selection IsNot Nothing Then
        'Dim read As String
        'Dim range As IHTMLTxtRange = DirectCast(selection.createRange, IHTMLTxtRange)
        ' If range IsNot Nothing Then
        'read = range.text.ToString
        'End If
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        'MsgBox(read)
#Enable Warning BC42104 ' Variable is used before it has been assigned a value

        'End If

        'WebBrowser1.ActiveXInstance.ExecCommand("Copy", False, Nothing)
        'If Clipboard.ContainsText Then
        '  Dim read As String = Clipboard.SetText()
        '   voice.SpeakAsync(read)
        'End If
    End Sub


    Private Sub tspbtnBookmark_Click(sender As Object, e As EventArgs) Handles tspbtnBookmark.Click
        'This block of code adds the url of a specific webpage to the Favorites list
        My.Settings.Favorites.Add(WebBrowser1.Url.ToString)
        txtAddressBar.Items.Add(WebBrowser1.Url.ToString)
        frmFavorites.ListBox1.Items.Add(WebBrowser1.Url.ToString)
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        state = True
        Call StatusAndZoom() 'Calls StatusAndZoom subprocedure
    End Sub

    Private Sub WebBrowser1_ProgressChanged(sender As Object, e As WebBrowserProgressChangedEventArgs) Handles WebBrowser1.ProgressChanged
        'This line displays the state or status of the web browser control
        'as it loads a webpage
        StatusLabel.Text = WebBrowser1.StatusText.ToString
        'This line of code determines the progression of the 
        'progress bar as the web browser loads the webpage
        Try
            ProgressBar1.Value = e.CurrentProgress
        Catch ex As Exception
        End Try
    End Sub

    Private Sub VolumeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolumeToolStripMenuItem.Click
        'Reveals the volume trackbar
        VolumeTrackbar.Visible = True
    End Sub

    Private Sub RateSpeedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RateSpeedToolStripMenuItem.Click
        'Reveals the rate trackbar
        SpeedTrackBar.Visible = True
    End Sub


    Private Sub FavoritesBookmarksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FavoritesBookmarksToolStripMenuItem.Click
        'This line displays the Favorites Window
        frmFavorites.Visible = True
    End Sub

    Private Sub Recognit_ReognizeCompleted(sender As Object, e As Recognition.RecognizeCompletedEventArgs) Handles Recognit.RecognizeCompleted
        Try
            'This block of code allows program to recognize human voice or speech entered 
            Recognit.RecognizeAsync()
        Catch ex As Exception
            msg = ex.Message
        End Try
    End Sub

    Private Sub Recognit_SpeechRecognized(sender As Object, e As Recognition.RecognitionEventArgs) Handles Recognit.SpeechRecognized
        Try
            'the Select Case block performs an action based on the command entered by the user 
            Select Case e.Result.Text
                Case "Back"
                    tspbtnBack_Click(sender, e)
                Case "Forward"
                    tspbtnForward_Click(sender, e)
                Case "Search" Or "Navigate" Or "GO"
                    tspbtnSearch_Click(sender, e)
                Case "Refresh" Or "Reload"
                    tspbtnRefresh_Click(sender, e)
                Case "Home"
                    tspbtnHome_Click(sender, e)
                Case "Stop"
                    tspbtnStop_Click(sender, e)
                Case "Read Aloud"
                    tspbtnReadAloud_Click(sender, e)
                Case "Cancel Speech" Or "Stop Speech"
                    tspbtnStopReading_Click_1(sender, e)
                Case "Resume Speech" Or "Play"
                    tspbtnResumeReading_Click(sender, e)
                Case "Pause Speech" Or "Pause"
                    tspbtnPauseReading_Click(sender, e)
            End Select
        Catch ex As Exception
            msg = MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SpeedTrackBar_MouseLeave_1(sender As Object, e As EventArgs) Handles SpeedTrackBar.MouseLeave
        'Makes a trackbar disappear when the mouse cursor is moved away from it
        SpeedTrackBar.Visible = False
    End Sub



    Private Sub VolumeTrackbar_MouseLeave(sender As Object, e As EventArgs) Handles VolumeTrackbar.MouseLeave
        'Makes a trackbar disappear when the mouse cursor is moved away from it
        VolumeTrackbar.Visible = False
    End Sub

    Private Sub btnZoomOut_Click(sender As Object, e As EventArgs) Handles btnZoomOut.Click
        InitialZoom -= 10 'Zooms out by 10
        Call PerformZoom(InitialZoom) 'Calls the PerformZoom function
    End Sub
    Private Sub btnZoomIn_Click_1(sender As Object, e As EventArgs) Handles btnZoomIn.Click
        InitialZoom += 10 'Zooms in by 10
        PerformZoom(InitialZoom) 'Calls the PerformZoom function
    End Sub

    Private Sub TextpageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextpageToolStripMenuItem.Click
        Try
            state = True
            WebBrowser1.Visible = False
            txtTextView.Visible = True
            StatusAndZoom()

            If WebBrowser1.Document <> Nothing Then
                RemoveHtmlBreaks(doc)
                WebpageAsString()
            Else
                MessageBox.Show("The webpage may not be fully loaded", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            TextpageToolStripMenuItem.Visible = False
            WebViewToolStripMenuItem.Visible = True

        Catch ex As Exception
            msg = ex.Message
        End Try
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        frmHelp.Show() 'Reveals the help window
    End Sub

    Private Sub AboutWAVAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutWAVAToolStripMenuItem.Click
        Call ShowAbout() 'Calls the ShowAbout procedure
    End Sub


    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        'Enables the user to cut an item on the web browser control
        WebBrowser1.Document.ExecCommand("Cut", False, vbNull)
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        'Enables the user to copy an item on the web browser control
        WebBrowser1.Document.ExecCommand("Copy", False, vbNull)
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Enables the user to paste a copied or cut item from the web browser control
        WebBrowser1.Document.ExecCommand("Paste", False, vbNull)
    End Sub

    Private Sub tspbtnStopReading_Click_1(sender As Object, e As EventArgs) Handles tspbtnStopReading.Click
        Try
            'This line stops reading or speech generated by the speech synthesizer voice
            voice.SpeakAsyncCancelAll()
        Catch ex As Exception
            msg = MessageBox.Show(ex.Message) 'Exception is displayed in a MessageBox 
        End Try
    End Sub


    Private Sub WebViewToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles WebViewToolStripMenuItem.Click
        If txtTextView.Visible = True Then
            WebBrowser1.Visible = True
        Else
            WebBrowser1.Visible = False
        End If

        WebViewToolStripMenuItem.Visible = False
        TextpageToolStripMenuItem.Visible = True


    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialog = DialogResult.Yes Then
            'Causes application to close
            Application.ExitThread()
        Else
            e.Cancel = True 'Cancels the Application.ExitThread() event
        End If


    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'Keyboard shortcut for Help
        If e.KeyCode = Keys.F1 Then
            frmHelp.Show()
        End If

        'Keyboard shortcut for About
        If e.KeyCode = Keys.F2 Then
            frmAbout.Show()
        End If

        'Keyboard shortcut for exit
        If e.KeyCode = Keys.Escape Then
            ExitApplicationToolStripMenuItem.PerformClick()
        End If

        'Enables the Text View of a webpage to be displayed when the keys 'Alt', 'Shift+' and 'T' are pressed together
        If (e.KeyCode = Keys.Alt) And (e.KeyCode = Keys.ShiftKey) And (e.KeyCode = Keys.T) Then
            TextpageToolStripMenuItem_Click(sender, e)
        End If

        'Enables the Web View of a webpage to be displayed when the keys 'Alt', 'Shift+' and 'W' are pressed together
        If (e.KeyCode = Keys.Alt) And (e.KeyCode = Keys.ShiftKey) And (e.KeyCode = Keys.W) Then
            WebViewToolStripMenuItem_Click_1(sender, e)
        End If

        'Makes the status bar visible when the keys 'Alt', 'Shift' and 'S' are pressed together
        If (e.KeyCode = Keys.Alt) And (e.KeyCode = Keys.ShiftKey) And (e.KeyCode = Keys.S) Then
            StatusBarToolStripMenuItem_Click(sender, e)
        End If

    End Sub

    Private Sub ExitApplicationToolStripMenuItem_Click(sender As Object, ex As EventArgs) Handles ExitApplicationToolStripMenuItem.Click

        Dim e As FormClosingEventArgs
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        frmMain_FormClosing(sender, e)
#Enable Warning BC42104 ' Variable is used before it has been assigned a value

    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        'user asks to change the font - show appropriate dialog
        On Error GoTo errorHandler
        Me.fdMain.ShowApply = False
        Me.fdMain.AllowSimulations = False
        Me.fdMain.AllowVerticalFonts = False
        Me.fdMain.ShowEffects = False
        Me.fdMain.ShowHelp = False
        Me.fdMain.Font = CType(Me.txtTextView.Font.Clone(), System.Drawing.Font)
        If Me.fdMain.ShowDialog(Me) = DialogResult.OK Then
            Me.txtTextView.Font = fdMain.Font
        End If
        Exit Sub
errorHandler:
        Exit Sub
    End Sub

    Private Sub ColourToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColourToolStripMenuItem.Click
        Dim fcs As frmColourSelect = New frmColourSelect
        Call fcs.SetCurrentSelection(My.Settings.ColourScheme)
        If fcs.ShowDialog(Me) = DialogResult.OK Then
            ' Update global colours
            My.Settings.ColourScheme = fcs.SelectedColourScheme
            Call frmColourSelect.SetColourScheme(Me, CType(My.Settings.ColourScheme, ColourScheme))
        End If
    End Sub

    Private Sub txtTextView_Click(sender As Object, e As EventArgs) Handles txtTextView.Click

        'Get the current line
        Dim current_line As Integer = txtTextView.GetLineFromCharIndex(txtTextView.SelectionStart)
        'Get the number of lines
        Dim lines_number As Integer = txtTextView.Lines.Count

        Select Case (lines_number)
            Case 1
                'Get the length of the line
                Dim line_length As Integer = txtTextView.Lines(current_line).Length

                'Start the selection at the beginning of the line we clicked
                txtTextView.SelectionStart = txtTextView.GetFirstCharIndexOfCurrentLine

                'Select that line's length
                txtTextView.SelectionLength = line_length
            Case (lines_number >= 2)
                'Selects the lines of text if the selected lines are two or more 
                txtTextView.Select(txtTextView.GetFirstCharIndexFromLine(current_line), txtTextView.Lines(lines_number).Length)
                txtTextView.Select()
        End Select
        'Convert the selected text to string
        Dim Text_to_read As String = txtTextView.SelectedText.ToString
        'Cancels all speech synthesis activities
        voice.SpeakAsyncCancelAll()
        'Makes speech synthesizer read aloud the selected text
        voice.SpeakAsync(Text_to_read)
    End Sub
End Class