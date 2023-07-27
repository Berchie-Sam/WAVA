Public Class frmHelp
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        'Simple Guide
        If e.Node.Name = "Node0" Then
            TextBox1.Text = "
        WAVA SIMPLE GUIDE
WAVA starts with a splash screen which tells you the name of the application and the developer. 
After the splash screen is fully loaded, the cover page appears to prevent distractions that may arise especially from other applications. You have the option to exit by clicking the exit button or proceed to the web browser.

If the password has been set then you can enter the your password to enable access to the web browser window. Otherwise you have to set a password. 
WAVA starts with the home page ‘www.google.co.uk’. To navigate to a specific webpage, its address must be specified in the address bar. The webpage can be converted to text or read aloud when it is fully loaded and displayed.

• You can press Ctrl+W key combination to search the Internet provided the web address has been entered.
• You can press Ctrl+Shift+F key combination to open your Favourites (Bookmarks) and cursor down to the page you want to open.
 
You can go back to a previous page by pressing the Ctrl+Shift+Left arrow key combination.  
You go back one page each time you press it.
"
        End If

        'Menu Items
        If e.Node.Name = "Node1" Then
            TextBox1.Text = "
                         WAVA MENU ITEMS
  FILE MENU (Alt + F)
Search (Control + W)
This fetches and displays a web page after you have provided its right web address in the address bar.
Home (Control + H)
This takes you to the homepage.
Back (Control + Shift+ Left Arrow)
This returns you to the previous webpage.
Forward (Control+ Shift + Right Arrow)
Go to the next page, if you have gone back to a previous one already.
Refresh (Alt+ Shift + R)
Get and reprocess the web page again. Useful if WAVA has got stuck and you had to stop it.
Favorites/Bookmarks (Control + Shift + F)
Opens the favorites (bookmarks) window.
History (Control + Shift + H)
Opens the History window. It consists of a list of the websites visited.
Read Aloud (Control + R)
Enables the voice synthesizer (reader) to read the content of the fully loaded current webpage.
Pause Reading (Control + Shift + P)
Pauses the reading activity of the reader or the voice synthesizer.
Resume Reading (Control + Shift + R)
Resumes a paused reading activity of the reader.
Stop Reading (Control + End)
Stops the reading activity of the reader.
Exit Application (Escape)
Opens the favorites (bookmarks) window.




  EDIT MENU (Alt + E)
Cut (Control + X)
Copy (Control + C)
Paste (Control + V)

  VIEW MENU (Alt + V)
Status Bar (Alt + Shift + S)
Makes the status bar visible.
Web View (Alt + Shift + W)
Makes the web view of the webpage visible.
Text View (Alt + Shift + T)
Displays the text view of the webpage.



  OPTIONS MENU (Alt + O)
Font ()
Reveals the font dialog. This enables you to change the font, font size and font style of text content in Text View.  
Colour()
Allows you to the change the background as well as the text colour in Text View.


  HELP MENU (Alt + H)
Help (F1)
Reveals the Help window.
About WAVA (F2)
Reveals the ‘About’ window which displays important information about the application.


"
        End If

        'File Menu
        If e.Node.Name = "Node2" Then
            TextBox1.Text = "
       FILE MENU (Alt + F)
  Search (Control + W)
This fetches and displays a web page after you have provided its right web address in the address bar.
  Home (Control + H)
This takes you to the homepage.
  Back (Control + Shift+ Left Arrow)
This returns you to the previous webpage.
  Forward (Control+ Shift + Right Arrow)
Go to the next page, if you have gone back to a previous one already.
  Refresh (Alt+ Shift + R)
Get and reprocess the web page again. Useful if WAVA has got stuck and you had to stop it.
  Favorites/Bookmarks (Control + Shift + F)
Opens the favorites (bookmarks) window.
  History (Control + Shift + H)
Opens the History window. It consists of a list of the websites visited.
  Read Aloud (Control + R)
Enables the voice synthesizer (reader) to read the content of the fully loaded current webpage.
  Pause Reading (Control + Shift + P)
Pauses the reading activity of the reader or the voice synthesizer.
  Resume Reading (Control + Shift + R)
Resumes a paused reading activity of the reader.
  Stop Reading (Control + End)
Stops the reading activity of the reader.
  Exit Application (Escape)
Opens the favorites (bookmarks) window.
"
        End If

        'Edit Menu
        If e.Node.Name = "Node3" Then
            TextBox1.Text = "
        EDIT MENU (Alt + E)
  Cut (Control + X)
Cuts an item and stores it in the clipboard.
  Copy (Control + C)
Copies an items and stores it in the clipboard
  Paste (Control + V)
Transports an item in the clipboard to the position of a cursor or blinking spot.
"
        End If

        'View Menu
        If e.Node.Name = "Node4" Then
            TextBox1.Text = "
        VIEW MENU (Alt + V)
  Status Bar (Alt + Shift + S)
Makes the status bar visible.
  Web View (Alt + Shift + W)
Makes the web view of the webpage visible.
  Text View (Alt + Shift + T)
Displays the text view of the webpage.

"
        End If

        'Options Menu
        If e.Node.Name = "Node5" Then
            TextBox1.Text = "
        OPTIONS MENU (Alt + O)
  Font ()
Reveals the font dialog. This enables you to change the font, font size and font style of text content in Text View.  
  Colour()
Allows you to the change the background as well as the text colour in Text View.
"
        End If

        'Help Menu
        If e.Node.Name = "Node6" Then
            TextBox1.Text = "
        HELP MENU (Alt + H)
  Help (F1)
Reveals the Help window.
  About WAVA (F2)
Reveals the ‘About’ window which displays important information about the application.
"
        End If

        'Shortcut Keys
        If e.Node.Name = "Node7" Then
            TextBox1.Text =
"
        Shortcut Keys in WAVA

Search – Control+ W
Home – Control + H
Back – Control+ Shift + Left
Forward – Control + Shift + Right
Favorites/Bookmarks – Control+ Shift + F
History – Control + Shift + H
Read Aloud – Control + R
Pause Reading – Control + Shift + P
Resume Reading – Control+ Shift + R
Stop Reading – Control + End
Help – F1
About – F2
Refresh – Escape
Text View – Alt + Shift + T
Web View – Alt+ Shift + W
Status Bar – Alt + Shift + S
Font – Shift + F4
Colour – Shift + F5
Cut – Control+ X
Copy – Control + C
Paste – Control + V
File – Alt + F
Edit – Alt + E
View – Alt + V
Options – Alt + O
Help – Alt + H
"
        End If

        'Toolbar
        If e.Node.Name = "Node8" Then
            TextBox1.Text =
"
        The WAVA toolbar
The Back button (double arrow pointing left) takes you back to the last web page you visited.
The Forward button (double arrow pointing right) stops WebbIE trying to get a page.
The Refresh button (circular arrow) makes WAVA go and get the current web page again.
The Address bar (rectangular bar) is where you type in the address of the webpage or website. You can also click on the dropdown button at the end of the address bar to select a URL from a list web addresses of visited websites.
The Search button (magnifying glass icon) fetches the web address you specify in the address bar from the World Wide Web.
The Add button (star icon) adds the current webpage or website to Favorites  
The Home button (house) makes WebbIE go to your Home Page.
The Stop button (square icon) stops the web browser from loading a webpage.
The Read Aloud button (speaker icon) enables the reader or voice synthesizer to read the text content of the current webpage.
The Resume Reading button (play icon) enables the reader to continue reading from where it was paused on the current webpage.
The Pause Reading button (pause icon) enables the reader to halt its reading activity.
The Stop Reading button (muted speaker icon) stops the reading activity of the reader.
The More Options button (three dots) indicates other options available in relation to the reader’s operations. Voice Gender allows the user to select his preferred voice for the reader. Volume enables you to adjust the volume or loudness of the reader. Rate or Speed allows you to adjust the reading speed of the reader.  
"
        End If

        'Help and Support
        If e.Node.Name = "Node9" Then
            TextBox1.Text =
"
WAVA Help and Support
WAVA was developed by three-man team, so support is limited! You can contact the team on email, appwava@gmail.com.
You can also contact the lead engineer, Sam Berchie on
 Email: soberchie@gmail.com
Facebook: Sam Berchie
WhatsApp: 0541310324
Thanks for using our application!
"
        End If
    End Sub
End Class