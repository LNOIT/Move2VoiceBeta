using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;



namespace Move2VoiceBeta
{
    public partial class FrmMain : Form
    {
        TelnetConnection tc = new TelnetConnection("freechess.org", 5000);
        string prompt = string.Empty;
        public string tmp = string.Empty;
        public int speechrate = 0;
        public bool engine_runnig = false;
        public bool engine_enabled = true;
        public string sentence = string.Empty;
        string squareName = string.Empty;
        private char[,] board = new char[8, 8];
        private Engine engine;
        string sideToMove = string.Empty;
        string whitePlayer = string.Empty;
        string blackPlayer = string.Empty;
        string amIPlaying = string.Empty;
        string whitesRemainingTime = string.Empty;
        string blacksRemainingTime = string.Empty;
        string lastMove = string.Empty;
        string tmpLastResponse = string.Empty;
        private SpeechQueue speechQueue;
        bool amAtBoard = false;
        bool whiteToMove = true;
        string currentMoveNumber = string.Empty;
        string info = string.Empty;
        string depth = string.Empty;
        int depthNumber = 0;
        string selDepth = string.Empty;
        int selDepthNumber = 0;
        string multiPV = string.Empty;
        int multiPvNumber = 0;
        string score = string.Empty;
        string cp = string.Empty;
        int cpEvaluation = 0;
        string nodes = string.Empty;
        int nodesNumberOf = 0;
        string nps = string.Empty;
        int npsNumber = 0;
        string tbhits = string.Empty;
        int tbhitsNumber = 0;
        string time = string.Empty;
        int timeNumber = 0;
        string pv = string.Empty;
        



        public FrmMain()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 50;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            var fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            ChessInterface ci = new ChessInterface();
            var board = ci.FenToBoard(fen);
            DisplayBoard(board);
            this.Load += FrmMain_Load;  // Add a handler for the Load event
            this.tbUser.Enter += new EventHandler(tbUser_Enter);
            // this.richTextBox2.Enter += new EventHandler(richTextBox2_KeyDown);

            engine = new Engine(this); // Pass the instance of FrmMain to the Engine class
            speechQueue = new SpeechQueue(1);
            pnlServer.Width = this.Width - 550;
            rtbMainConsole.Width = this.Width - 560;


        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            tbUser.Focus();  // Now the call to Focus() will work as expected
            tbUser.SelectAll();

        }

        private void Login()
        {

            //Code for saving pwd etc
        }

        private void ReconnectToTelnetServer()
        {
            try
            {
                // Close the existing connection if it's still open
                if (tc.IsConnected)
                    tc.Close();

                // Create a new instance of TelnetConnection
                tc = new TelnetConnection("freechess.org", 5000);

                // Perform any login or initialization steps as needed

                // Continue communication with the telnet server
                // You can start sending commands or performing other operations
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during reconnection
                // You can log the error, display a message to the user, or take appropriate action
            }
        }


        private void Send(string s)
        {

            if (tc.IsConnected && tbPrompt.Text != "exit")
            {
                if (s=="moves") 
                {
                    s = string.Empty;
                }
                speechQueue.EnqueueSpeech(s);
                rtbMainConsole.Text += s;
                rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
                rtbMainConsole.ScrollToCaret();
                // send client input to server
                tc.WriteLine(s);

                tbLastResponse.Text = tc.Read();
            }
            rtbMainConsole.Text += tbLastResponse.Text.Replace("fics%","");; 
            rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            rtbMainConsole.ScrollToCaret();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }
        private void Connect()
        {
            // Check for empty username and password first.
            if (string.IsNullOrEmpty(tbUser.Text) || string.IsNullOrEmpty(tbPassword.Text))
            {
                tbUser.Text = "guest";
            }

            tbLastResponse.Text = tc.Read();
            rtbMainConsole.Text += tbLastResponse.Text.Replace("fics%","");
            rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            rtbMainConsole.ScrollToCaret();
            string s = tc.Login(tbUser.Text, tbPassword.Text, 100);
            string ts = tc.IsConnected ? "CONNECTED" : "NOT CONNECTED";
            rtbMainConsole.Text += ts;
            tbLastResponse.Text = tc.Read();
            rtbMainConsole.Text += tbLastResponse.Text.Replace("fics%", "");
            speechQueue.EnqueueSpeech(ts);
            rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            rtbMainConsole.ScrollToCaret();
            //System.Threading.Thread.Sleep(100);
            tbLastResponse.Text = tc.Read();
            tmrRead.Enabled = true;
            btnRead.BackColor = Color.Green;
            rtbMainConsole.Text += tbLastResponse.Text.Replace("fics%","");;
            rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            rtbMainConsole.ScrollToCaret();
            tbPrompt.Focus();
        }

        private void tbPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            Speech speech = new Speech((int)nudSpeachrate.Value);
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                char keyChar = (char)('0' + (e.KeyCode - Keys.D0));
                speech.SpeakAsync(keyChar.ToString());
            }
            else 
            {
                speech.SpeakAsync(e.KeyCode.ToString());
            }


            // speechQueue.EnqueueSpeech(e.KeyCode.ToString());
            if (e.KeyCode.ToString() == "Return")
            {

                Send(tbPrompt.Text);
                tbPrompt.Text = string.Empty;


                switch (tbPrompt.Text)
                {

                    case "resume":
                        btnStartEngine.Enabled = false;
                        sentence = "Engine disabled";
                        speechQueue.EnqueueSpeech(sentence);
                        break;
                    case "accept":
                        btnStartEngine.Enabled = false;
                        sentence = "Engine disabled";
                        speechQueue.EnqueueSpeech(sentence);
                        break;
                    case "cherry":
                        //
                        break;
                    default:
                        //
                        break;
                }


            }


        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send(tbPrompt.Text);
        }
        public void ExtractFields(string s)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            int startPos = s.LastIndexOf("<12>");
            int row = 0;
            
            string stmp = s.Substring(startPos);
            label1.Text = stmp;
            // Splitting the string into parts using the space character as a delimiter
            var parts = stmp.Split(' ');
            foreach (string part in parts)
            {
                if (row > 0 && row < 9)
                {
                    richTextBox2.Text += part + Environment.NewLine;
                }
                richTextBox1.Text += row.ToString() + " " + part + Environment.NewLine;
                row++;
            }
            // Extracting the fields
            sideToMove = parts[9];
            if (sideToMove == "W") 
            { 
                whiteToMove = false; 
            } 
            else 
            { 
                whiteToMove = true; 
            }
            amIPlaying = parts[10];
            whitePlayer = parts[17];
            blackPlayer = parts[18];
            currentMoveNumber = parts[26];
            if (amIPlaying == "0")
            {
                btnStartEngine.Enabled = false;
                btnStartEngine.BackColor = Color.Red;

            }
            else
            {
                btnStartEngine.Enabled = true;
                btnStartEngine.BackColor = Color.Green;
            }

            whitesRemainingTime = parts[24];
            blacksRemainingTime = parts[25];
            lastMove = parts[27];
            
            Speech speech = new Speech((int)nudSpeachrate.Value);
            sentence = InterpretLastMove(lastMove, whiteToMove);
            if (lastMove == "o-o")
            {
                sentence = "castles Kingside";
            }
            else if (lastMove == "o-o-o")
            {
                sentence = "castles Queenside";
            }
            sentence = ConvertDigitsToWords(sentence);
            if (!whiteToMove) {
                int cm = 0;
                cm = Convert.ToInt32(currentMoveNumber);
                cm--;
                currentMoveNumber = ConvertDigitsToWords(cm.ToString());
            // there is a bug on the serverside that does not add 1 to the 
            //movenumber on whites turn, this bug occurs strangely enough only after move 1,
            // which means further handling but this will do for now, the movenumber is read
            // correctly after move 2. I will check with FICS
            // 
            }
            speechQueue.EnqueueSpeech(currentMoveNumber + " " + sentence);
            
       
            lblsideToMove.Text = sideToMove;
            lblWhitePlayer.Text = whitePlayer;
            lblBlackPlayer.Text = blackPlayer;
            lblAmIPlaying.Text = amIPlaying;
            lblWhitesRemainingTime.Text = whitesRemainingTime;
            lblBlacksRemainingTime.Text = blacksRemainingTime;


        }


        public string GetCurrentPositionPiecePlacement(RichTextBox rtb, string squareName)
        {
            Dictionary<char, string> pieceTranslationDictionary = new Dictionary<char, string>
    {
        {'r', "Black Rook"},
        {'n', "Black Knight"},
        {'b', "Black Bishop"},
        {'q', "Black Queen"},
        {'k', "Black King"},
        {'p', "Black Pawn"},
        {'R', "White Rook"},
        {'N', "White Knight"},
        {'B', "White Bishop"},
        {'Q', "White Queen"},
        {'K', "White King"},
        {'P', "White Pawn"},
        {'-', ""}
    };
            string pieceX = string.Empty;
            string[] lines = rtb.Lines;
            string[,] boardPosition = new string[8, 8];

            for (int i = 0; i < 8; i++)
            {
                string line = lines[i];
                for (int j = 0; j < 8; j++)
                {
                    char pieceChar = line[j];
                    string pieceName = pieceTranslationDictionary[pieceChar];
                    string squareNameTemp = $"{(char)('a' + j)}{8 - i}";
                    boardPosition[j, 8 - i - 1] = pieceName;

                    if (squareNameTemp == squareName)
                    {
                        pieceX = ($"pieceName: {pieceName}");
                        return pieceX;
                    }
                }
            }

            throw new Exception($"Square name {squareName} not found on the board.");
        }


        private object[] ParseAndAssignLinesFromRichTextBox(string line)
        {
            try
            {
                // Split the line into parts
                string[] parts = line.Split(' ');

                // Assign parts to variables
                string info = parts[0];
                string depth = parts[1];
                int depthNumber = int.Parse(parts[2]);
                string selDepth = parts[3];
                int selDepthNumber = int.Parse(parts[4]);
                string multiPV = parts[5];
                int multiPvNumber = int.Parse(parts[6]);
                string score = parts[7];
                string cp = parts[8];
                int cpEvaluation = int.Parse(parts[9]);
                string nodes = parts[10];
                int nodesNumberOf = int.Parse(parts[11]);
                string nps = parts[12];
                int npsNumber = int.Parse(parts[13]);
                string tbhits = parts[14];
                int tbhitsNumber = int.Parse(parts[15]);
                string time = parts[16];
                int timeNumber = int.Parse(parts[17]);
                string pv = parts[18];

                // Get the pv moves (pv1, pv2, pv3, etc)
                List<string> pvMoves = new List<string>();
                for (int i = 19; i < parts.Length; i++)
                {
                    pvMoves.Add(parts[i]);
                }

                string pvMovesString = String.Join(" ", pvMoves);

                // Convert pvMoves List to array


                // Create an array of objects to return
                object[] values = new object[] { info, depth, depthNumber, selDepth, selDepthNumber, multiPV, multiPvNumber, score, cp, cpEvaluation, nodes, nodesNumberOf, nps, npsNumber, tbhits, tbhitsNumber, time, timeNumber, pv, pvMovesString };

                return values;
            }
            catch (Exception ex)
            {
                // Log the error or silently ignore it, depends on your needs
                // Console.WriteLine(ex.ToString());
                return null;
            }
        }




        private string FormatTime(int seconds)
{
    TimeSpan time = TimeSpan.FromSeconds(seconds);
    string timeFormatted = time.ToString(@"hh\:mm\:ss");
    return timeFormatted;
}
        private string InterpretLastMove(string s, bool isWhitesTurn)
        {
            Dictionary<string, string> replacementTextWhite = new Dictionary<string, string>()
        {
        { "K/", "White King moves " },{ "Q/", "White Queen moves " }, { "R/", "White Rook moves " }, { "B/", "White Bishop moves " },{ "N/", "White Night moves " },{ "P/", "White Pawn moves " },
        };
            

            Dictionary<string, string> replacementTextBlack = new Dictionary<string, string>()
        {
        { "K/", "Black King moves " },{ "Q/", "Black Queen moves " }, { "R/", "Black Rook moves " }, { "B/", "Black Bishop moves " },{ "N/", "Black Night moves " },{ "P/", "Black Pawn moves " },
        };

            string key = s.Substring(0, 2); // Get the first two characters of the input string

            if (isWhitesTurn)
            {
                if (replacementTextWhite.TryGetValue(key, out string replacement))
                {
                    s = replacement + " " + s.Substring(2); // Replace the key with the corresponding value
                    label2.Text = s;
                }
                else
                {
                    s = string.Empty; // No match found, set the string to empty
                }
            }
            else
            {
                if (replacementTextBlack.TryGetValue(key, out string replacement))
                {
                    s = replacement + " " + s.Substring(2); // Replace the key with the corresponding value
                    label2.Text = s;
                }
                else
                {
                    s = string.Empty; // No match found, set the string to empty
                }
            }

            return s;
        }


        private string ConvertDigitsToWords(string input)
        {



            string[] digitWords = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tensWords = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] teensWords = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };


            string result = "";
            try
            {
                int[] digits = input.Select(c => int.Parse(c.ToString())).ToArray();
                int numDigits = digits.Length;

                for (int i = 0; i < numDigits; i++)
                {
                    int digit = digits[i];
                    int position = numDigits - i;

                    if (position == 2)
                    {
                        if (digit == 1 && i + 1 < numDigits)
                        {
                            int nextDigit = digits[i + 1];
                            result += teensWords[nextDigit] + " ";
                            i++; // Skip the next digit since it has been handled
                        }
                        else
                        {
                            result += tensWords[digit] + " ";
                        }
                    }
                    else if (position == 1)
                    {
                        result += digitWords[digit] + " ";
                    }
                    else if (position == 3)
                    {
                        result += digitWords[digit] + " hundred ";
                    }
                    else if (position > 3)
                    {
                        result += digitWords[digit] + " thousand ";
                    }
                }

                return result.Trim();
            }
            catch (Exception ex) {
                return input;
                    }
            
        }


        private void ObserveGame()
        {
            ChessInterface ci = new ChessInterface();
            tbGameString.Text = ci.Style12ToFEN(tbLastResponse.Text);
            ExtractFields(tbLastResponse.Text);
            var fen = tbGameString.Text;
            var board = ci.FenToBoard(fen);
            UpdateBoard(board);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            ChessInterface ci = new ChessInterface();
            tbGameString.Text = ci.Style12ToFEN(tbLastResponse.Text);
            Speech speech = new Speech((int)nudSpeachrate.Value);
            speech.SpeakAsync("Converted to fen");
            var fen = tbGameString.Text;
            var board = ci.FenToBoard(fen);
            UpdateBoard(board);

        }
        Color darkBrown = Color.FromArgb(132, 71, 10);
        Color lightBrown = Color.FromArgb(250, 245, 200);
        public void DisplayBoard(char[,] board)
        {
            try
            {
                int squareSize = 60; // or whatever size you prefer
                
                int tabIndex = 0;

                // clear the panel
                pnlBoard.Controls.Clear();

                for (int i = 0; i < 8; i++)
                {

                    for (int j = 0; j < 8; j++)
                    {
                        var pictureBox = new SelectablePictureBox
                        {
                            TabIndex = tabIndex++,
                            Width = squareSize,
                            Height = squareSize,
                            Location = new Point((j * squareSize) + 10, (i * squareSize) + 10),
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = (i + j) % 2 == 0 ? lightBrown : darkBrown,
                            SizeMode = PictureBoxSizeMode.CenterImage,
                            Tag = $"{(char)('a' + j)}{8 - i}",
                            Name = $"{(char)('a' + j)}{8 - i}",
                            AccessibleDescription = $"{(char)('a' + j)}{8 - i}",
                            TabStop = true,

                        };

                        switch (board[i, j])
                        {
                            case 'r':
                                pictureBox.Image = imageList1.Images[0];
                                break;
                            case 'n':
                                pictureBox.Image = imageList1.Images[1];
                                break;
                            case 'b':
                                pictureBox.Image = imageList1.Images[2];
                                break;
                            case 'q':
                                pictureBox.Image = imageList1.Images[3];
                                break;
                            case 'k':
                                pictureBox.Image = imageList1.Images[4];
                                break;
                            case 'p':
                                pictureBox.Image = imageList1.Images[5];
                                break;
                            case 'R':
                                pictureBox.Image = imageList1.Images[6];
                                break;
                            case 'N':
                                pictureBox.Image = imageList1.Images[7];
                                break;
                            case 'B':
                                pictureBox.Image = imageList1.Images[8];
                                break;
                            case 'Q':
                                pictureBox.Image = imageList1.Images[9];
                                break;
                            case 'K':
                                pictureBox.Image = imageList1.Images[10];
                                break;
                            case 'P':
                                pictureBox.Image = imageList1.Images[11];
                                break;

                            case '-':
                                pictureBox.Image = null;
                                break;
                        }

                        // add the PictureBox to the panel
                        pnlBoard.Controls.Add(pictureBox);
                        pictureBox.Click += PictureBox_Click;
                        pictureBox.Enter += PictureBox_Enter;
                    }
                }
            }
            catch
            {
                // If the function encounters an error, handle it accordingly.
            }
        }
        public void UpdateBoard(char[,] board)
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        string pictureBoxName = $"{(char)('a' + j)}{8 - i}";
                        PictureBox pictureBox = (PictureBox)pnlBoard.Controls[pictureBoxName];

                        if (pictureBox != null)
                        {
                            switch (board[i, j])
                            {
                                case 'r':
                                    pictureBox.Image = imageList1.Images[0];
                                    pictureBox.Tag = $"Black Rook {pictureBoxName}";
                                    break;
                                case 'n':
                                    pictureBox.Image = imageList1.Images[1];
                                    pictureBox.Tag = $"Black Knight {pictureBoxName}";
                                    break;
                                case 'b':
                                    pictureBox.Image = imageList1.Images[2];
                                    pictureBox.Tag = $"Black Bishop {pictureBoxName}";
                                    break;
                                case 'q':
                                    pictureBox.Image = imageList1.Images[3];
                                    pictureBox.Tag = $"Black Queen {pictureBoxName}";
                                    break;
                                case 'k':
                                    pictureBox.Image = imageList1.Images[4];
                                    pictureBox.Tag = $"Black King {pictureBoxName}";
                                    break;
                                case 'p':
                                    pictureBox.Image = imageList1.Images[5];
                                    pictureBox.Tag = $"Black Pawn {pictureBoxName}";
                                    break;
                                case 'R':
                                    pictureBox.Image = imageList1.Images[6];
                                    pictureBox.Tag = $"White Rook {pictureBoxName}";
                                    break;
                                case 'N':
                                    pictureBox.Image = imageList1.Images[7];
                                    pictureBox.Tag = $"White Knight {pictureBoxName}";
                                    break;
                                case 'B':
                                    pictureBox.Image = imageList1.Images[8];
                                    pictureBox.Tag = $"White Bishop {pictureBoxName}";
                                    break;
                                case 'Q':
                                    pictureBox.Image = imageList1.Images[9];
                                    pictureBox.Tag = $"White Queen {pictureBoxName}";
                                    break;
                                case 'K':
                                    pictureBox.Image = imageList1.Images[10];
                                    pictureBox.Tag = $"White King {pictureBoxName}";
                                    break;
                                case 'P':
                                    pictureBox.Image = imageList1.Images[11];
                                    pictureBox.Tag = $"White Pawn {pictureBoxName}";
                                    break;
                                case '-':
                                    pictureBox.Image = null;
                                    pictureBox.Tag = pictureBoxName;
                                    break;
                            }
                        }
                    }
                }

                pnlBoard.Refresh();
            }
            catch
            {
                // If the function encounters an error, you might want to handle it accordingly.
            }
        }


        private Dictionary<string, Color> originalColors = new Dictionary<string, Color>();

        private void StoreOriginalColors()
        {
            foreach (Control control in pnlBoard.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    pictureBox.Tag = pictureBox.BackColor;
                }
            }
        }

        private void RestoreSquareColor()
        {
            foreach (Control c in pnlBoard.Controls)
            {
                if (c.BackColor == Color.LightGray)
                {
                    if (c.Tag.ToString() == squareNameTmp)
                    {
                        c.BackColor = oldColor_1;
                    }
                    else
                    {
                       // c.BackColor = oldColor_2;
                    }
                }
            }
        }








        int timesClicked = 0;
        string squareNameTmp = string.Empty;
        Color oldColor_1 = Color.Empty;
       // Color oldColor_2 = Color.Empty;

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (squareName.Length == 0) { StoreOriginalColors(); }
           
            PictureBox pictureBox = (PictureBox)sender;
            timesClicked++;

            if (timesClicked == 3)
            {
                timesClicked = 1;
            }

            if (pictureBox.BackColor != Color.LightGray)
            {
                if (timesClicked == 1)
                {
                    oldColor_1 = pictureBox.BackColor;
                    squareNameTmp = pictureBox.Name;
                }
               
            }

            if (squareName != pictureBox.Name)
            {
                if (timesClicked == 1)
                {
                    squareName = pictureBox.Name;
                    pictureBox.BackColor = Color.LightGray;
                }
                else
                {
                    squareName += pictureBox.Name;

                    if (squareName.Length == 4)
                    {
                        Send(squareName);
                       
                    }
                    squareName = string.Empty;
                }

               
            }
            else
            {
                pictureBox.BackColor = oldColor_1;
                squareName = string.Empty;
            }
            
      
            pnlBoard.Refresh();
        }


        private void PictureBox_Enter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox; // Cast sender to PictureBox
           
            sentence = pictureBox.Tag.ToString();
            if (pictureBox.Tag.ToString().Length > 2)
            {
                speechQueue.EnqueueSpeech(sentence);
            }
            
                
           
        }
        private async void FocusEachPictureBoxSequentially()
        {
            // Get all PictureBox controls in the panel
            var pictureBoxes = pnlBoard.Controls.OfType<PictureBox>().ToList();

            // Sort the PictureBoxes by their TabIndex property
            pictureBoxes.Sort((a, b) => a.TabIndex.CompareTo(b.TabIndex));

            // Loop through each PictureBox
            foreach (var pictureBox in pictureBoxes)
            {
                // Set focus to the current PictureBox
                pictureBox.Focus();

                // Delay for half a second before moving to the next PictureBox
                await Task.Delay(10);
            }
        }

        private char GetPieceFromFEN(string position)
        {
            string fen = tbGameString.Text; // Replace with your actual FEN string
            string[] fenRows = fen.Split('/');
            int rowIndex = 7 - (position[1] - '1'); // Adjust the row index calculation
            int colIndex = position[0] - 'a';

            if (rowIndex < 0 || rowIndex >= fenRows.Length || colIndex < 0 || colIndex >= fenRows[rowIndex].Length)
                return '\0';

            char piece = fenRows[rowIndex][colIndex];

            if (piece == '1')
            { // Empty square
                return '-';


            }
            else { return fenRows[rowIndex][colIndex]; }





        }










        private string GetPieceName(char piece)
        {
            switch (piece)
            {
                case 'r': return "Black Rook";
                case 'n': return "Black Knight";
                case 'b': return "Black Bishop";
                case 'q': return "Black Queen";
                case 'k': return "Black King";
                case 'p': return "Black Pawn";
                case 'R': return "Rook";
                case 'N': return "Knight";
                case 'B': return "Bishop";
                case 'Q': return "Queen";
                case 'K': return "King";
                case 'P': return "Pawn";
                default: return "empty ";
            }
        }


        private void StartStockFish()
        {
            engine = new Engine(this); // Create the Engine instance if not already created
            Task.Run(() => engine.StartSF(tbGameString.Text, false));
        }

        private void StopStockFish()
        {
            if (engine != null)
            {
                Task.Run(() => engine.StartSF(tbGameString.Text, true));
            }
        }

        private void btnStartEngine_Click(object sender, EventArgs e)
        {
            StartStockFish();
            tbPrompt.Focus();
        }

        public async Task sfAsync()
        {
          //  engine = new Engine(this); // Pass current instance of FrmMain
            await engine.StartSF(tbGameString.Text, false);
        }

        public async Task sf_stopAsync()
        {
           // Engine eng = new Engine(this); // Pass current instance of FrmMain
            await engine.StartSF(tbGameString.Text, true);
        }


        private void tmrEngine_Tick(object sender, EventArgs e)
        {
           
        }


        public string GetLastTwoLines(RichTextBox rtbEngineOutput)
        {
            //Not needed anymore
            if (rtbEngineOutput.Lines.Length >= 2)
            {
                string lastLine = rtbEngineOutput.Lines[rtbEngineOutput.Lines.Length - 1];
                string secondLastLine = rtbEngineOutput.Lines[rtbEngineOutput.Lines.Length - 2];

                return lastLine + " " + secondLastLine;
            }
            else if (rtbEngineOutput.Lines.Length == 1)
            {
                // if there is only one line, return that line
                return rtbEngineOutput.Lines[0];
            }
            else
            {
                // if there are no lines, return an empty string
                return string.Empty;
            }
        }
        public string GetPricipalVariation(RichTextBox rtbEngineOutput)
        {
            try
            {
                if (rtbEngineOutput.Lines.Length >= 3)
                {
                    // Return the third last line
                    return rtbEngineOutput.Lines[rtbEngineOutput.Lines.Length - 3];
                }
                else if (rtbEngineOutput.Lines.Length > 0)
                {
                    // If there's less than 3 lines, return the last line
                    return rtbEngineOutput.Lines[rtbEngineOutput.Lines.Length - 1];
                }
                else
                {
                    // If there are no lines, return an empty string
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Log the error
                label1.Text = ex.ToString();

                // If an error occurred, return an empty string
                return string.Empty;
            }
        }


        private void btnStopEngine_Click(object sender, EventArgs e)
        {
            engine.StopEngine();
            tbPrompt.Focus();

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            string tmp_moves = string.Empty;
            Send("forward 900");
            ChessInterface ci = new ChessInterface();
            //tbLastResponse.Text = tc.Read();
            //tmp_moves = ci.ExtractMovelist(rtbMainConsole.Text + tbLastResponse.Text);

            //rtbPgn.Text = ci.ConvertToPGN(tmp_moves);
            tbPrompt.Focus();
        }

        private void btnReadLine_Click(object sender, EventArgs e)
        {
            Speech speech = new Speech((int)nudSpeachrate.Value);
            sentence = GetLastTwoLines(rtbEngineOutPut);
            if (sentence.Any(char.IsDigit))
            {
                speechQueue.EnqueueSpeech(ConvertDigitsToWords(sentence));
            }
            else
            {
                speechQueue.EnqueueSpeech(sentence);
            }
            tbPrompt.Focus();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (tmrRead.Enabled)
            {
                tmrRead.Enabled = false;
                btnRead.BackColor = Color.Red;

            }
            else
            {
                tmrRead.Enabled = true;
                btnRead.BackColor = Color.Green;
            }
            tbPrompt.Focus();
        }
        private void readPush()
        {
            tbLastResponse.Text = tc.Read();
            rtbLog.Text += tbLastResponse.Text;
            if (tbLastResponse.Text.Contains("<12>"))
            {
                tmpLastResponse = tbLastResponse.Text;
                ObserveGame();
                //btnMoves_Click(this, new EventArgs());
                //button2_Click(this, new EventArgs());

            }
            if (tbLastResponse.Text.Length > 2)
            {
                bool isHandled = false;
                
                string[] patterns = { "{", "kibitz", "tells", "Movelist for game " };
                foreach (string pattern in patterns)
                {
                    if (tbLastResponse.Text.Contains(pattern))
                    {
                        switch (pattern)
                        {
                            case "{":
                                rtbGames.Text += tbLastResponse.Text.Replace("fics%","");;
                                isHandled = true;
                                break;
                            case "kibitz":
                            case "tells":
                                Speech speech = new Speech((int)nudSpeachrate.Value);
                                sentence= tbLastResponse.Text.Replace("fics%","");
                                speechQueue.EnqueueSpeech(sentence);
                                rtbTells.Text += tbLastResponse.Text.Replace("fics%", "");
                                break;
                            case "Movelist for game ":
                                isHandled = true;
                                rtbMovesListRaw.Text += tbLastResponse.Text.Replace("fics%", "");
                                break;
                        }
                        if (isHandled)
                            break;
                    }
                }
                if (!isHandled)
                {
                 
                    rtbMainConsole.Text += tbLastResponse.Text.Replace("fics%","");
                  
                }
            }


        }

        private void tmrRead_Tick(object sender, EventArgs e)
        {
            readPush();



        }

        private void btnMoves_Click(object sender, EventArgs e)
        {
            Send("moves");
            ChessInterface ci = new ChessInterface();
            rtbMovesListRaw.Text = tbLastResponse.Text.Replace("fics%","");
            tbPrompt.Focus();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            ChessInterface ci = new ChessInterface();
            FrmMain frmMain = new FrmMain();
            // ...
            CreatePGN();
            tbPrompt.Focus();

        }
        public string CreatePGN()
        {
            string[] lines = rtbMovesListRaw.Lines;
            StringBuilder pgnBuilder = new StringBuilder();

            // Find move section start index
            int moveSectionStartIndex = Array.FindIndex(lines, line => line.StartsWith("----  ----------------   ----------------"));
            if (moveSectionStartIndex == -1)
            {
                return "Move section not found.";
            }

            // Retrieve player names from the line above move section start
            string playerLine = lines[moveSectionStartIndex - 2];
            if (playerLine.Length < 42)
            {
                return "Unable to find player names.";
            }

            string player1 = playerLine.Substring(6, 16).Trim();
            string player2 = playerLine.Substring(25, 16).Trim();

            // Extract result from the line below move section end
            string resultLine = lines[lines.Count() - 1];
            string result = "NOT AVAILABLE YET";

            // Add PGN header
            pgnBuilder.AppendLine("[Event \"Rated standard match\"]");
            pgnBuilder.AppendLine($"[White \"{player1}\"]");
            pgnBuilder.AppendLine($"[Black \"{player2}\"]");
            pgnBuilder.AppendLine($"[Result \"{result}\"]");

            // Extract moves from move section
            pgnBuilder.AppendLine();
            pgnBuilder.AppendLine("[Moves]");

            StringBuilder movesBuilder = new StringBuilder();

            for (int i = moveSectionStartIndex + 2; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrEmpty(line))
                    continue;

                string[] moveParts = line.Split(new string[] { ".", "  " }, StringSplitOptions.RemoveEmptyEntries);
                if (moveParts.Length >= 5)
                {
                    string moveNumber = moveParts[0].Trim();
                    string whiteMove = moveParts[1].Trim();
                    string blackMove = moveParts[3].Trim();

                    movesBuilder.Append($"{moveNumber}. {whiteMove} {blackMove} ");
                }
            }

            pgnBuilder.Append(movesBuilder.ToString().Trim());
            rtbPgn.Text = pgnBuilder.ToString().Trim();
            rtbPgn.Refresh();
            return "OK";
        }
        private void tmrSmoothUpdate_Tick(object sender, EventArgs e)
        {

            //rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            //rtbMainConsole.ScrollToCaret();
        }

        private void rtbMainConsole_TextChanged(object sender, EventArgs e)
        {
            
            rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            rtbMainConsole.ScrollToCaret();
        }
        private string interpetEngineLine(string s)
        {
            try
            {
                string cpKey = "cp    ";
                string nodesKey = " nodes";

                int startIndex = s.IndexOf(cpKey) + cpKey.Length;
                int endIndex = s.IndexOf(nodesKey);
                string centipawn = s.Substring(startIndex, endIndex - startIndex).Trim();


                //string line = "info depth 15 seldepth 26 multipv 1 score cp 363 nodes 461804 nps 1021690 tbhits 0 time 452 pv a1a8 e8f7 a8h8 f7f6 h8e8 g7g1 e1e2 g1g3 e8e3 g3g1 e2d3 g1f1 d3c4 f6g7 d2d5 f1f7 c4b5 g7f8 b5c5";
                string pvKey = " pv ";
                string principalVariation = string.Empty;
                // int startIndex2 = s.IndexOf(pvKey) + pvKey.Length;
                int startIndex2 = s.IndexOf(pvKey);

                //int startIndex2 = s.IndexOf(pvKey);

                if (startIndex2 != -1) // if "pv " is found in the string
                {
                    //MessageBox.Show($"pvKey found at index {startIndex2} in string: {s}");
                    startIndex2 += pvKey.Length;  // Move the start index to the end of "pv "
                    principalVariation = s.Substring(startIndex2).Trim();

                    // principalVariation now holds "a1a8 e8f7 a8h8 f7f6 h8e8 g7g1 e1e2 g1g3 e8e3 g3g1 e2d3 g1f1 d3c4 f6g7 d2d5 f1f7 c4b5 g7f8 b5c5"
                    // MessageBox.Show(principalVariation);
                }
                else
                {
                    //  MessageBox.Show($"pvKey not found in string: {s}");
                }


                string moves = principalVariation;
                string[] movesArray = moves.Split(' ');

                StringBuilder formattedMoves = new StringBuilder();

                for (int i = 0; i < movesArray.Length; i++)
                {
                    string move = movesArray[i];

                    if (move.Length == 4)
                    {
                        formattedMoves.Append($"{move.Substring(0, 2)} to {move.Substring(2, 2)} ");
                    }
                    else
                    {
                        // handle the case when the move isn't 4 characters
                        // you might need to adjust this based on your specific requirements
                        formattedMoves.Append(move + " ");
                    }
                }

                string result = formattedMoves.ToString().Trim(); // final result
                result = "Evaluation in centi pawn " + centipawn + result;
                return result;
            }
            catch (Exception ex)
            {
                // Catch the exception and print it to the Console.
                //Console.WriteLine(ex.ToString());
                return null;

            }
        }

       

        private void WriteLog()
        {
            try
            {
                string fileName = "log.txt";
                string filePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, fileName);
                string richTextBoxText = richTextBox1.Text; // richTextBox1 is your RichTextBox

                // Append the text to the file
                System.IO.File.AppendAllText(filePath, richTextBoxText);
            }
            catch (Exception ex)
            {
                // Handle or display the error
                //Console.WriteLine(ex.Message);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CreatePGN();
            tbPrompt.Focus();
        }

        private void tbLastResponse_TextChanged(object sender, EventArgs e)
        {
            if (tbLastResponse.Text.Contains("<12>"))
            {
                ObserveGame();
                btnMoves_Click(this, new EventArgs());
                button2_Click(this, new EventArgs());
            }
        }

        private void rtbMovesListRaw_TextChanged(object sender, EventArgs e)
        {
            rtbMovesListRaw.SelectionStart = rtbMovesListRaw.Text.Length;
            rtbMovesListRaw.ScrollToCaret();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Send("back");
            tbPrompt.Focus();

        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Speech speech = new Speech((int)nudSpeachrate.Value);
                speech.SpeakAsync("New Key: F1 brings up this menu. oaoao  New Key: F2 starts the engine. In this test version, the engine's execution time is 10 seconds. This can be adjusted by the user. The engine gives as its best move after that time.  New Key: F3 focuses on the prompt. The prompt is focused by default and where you type the commands to the server. New Key: F4: Focus on the board panel New Key: F5: Reads the position on the board  New Key: F6: Reads the line of the engine. Additional remarks: The aim for this program is to be as user friendly as possible and that means as many tasks as possible will be or are automated or configurable."); 
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnStartEngine_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.F3)
            {
                tbPrompt.Focus();
            }
            else if (e.KeyCode == Keys.F4)
            {
                pnlBoard.Focus();
            }

            else if (e.KeyCode == Keys.F6)
            {
                Speech speech = new Speech((int)nudSpeachrate.Value);
                sentence = GetLastTwoLines(rtbEngineOutPut);
                if (sentence.Any(char.IsDigit))
                {
                    speechQueue.EnqueueSpeech(ConvertDigitsToWords(sentence));
                }
                else 
                {
                    speechQueue.EnqueueSpeech(sentence);
                }
                   
                tbPrompt.Focus();
            }

            else if (e.KeyCode == Keys.F5)
            {
                FocusEachPictureBoxSequentially();
            }
               



            // Constants representing the grid dimensions
            const int GridRows = 8;
            const int GridColumns = 8;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Get the currently focused PictureBox
                SelectablePictureBox selectedPictureBox = pnlBoard.Controls.OfType<SelectablePictureBox>().FirstOrDefault(p => p.Focused);

                if (selectedPictureBox != null)
                {
                    int selectedIndex = selectedPictureBox.TabIndex;
                    int row = (selectedIndex - 1) / GridRows;
                    int column = (selectedIndex - 1) % GridColumns;

                    // Calculate the new row and column based on the arrow key pressed
                    switch (e.KeyCode)
                    {
                        case Keys.Left:
                            column = (column - 1 + GridColumns) % GridColumns;
                            if (column == GridColumns - 1) // If we wrapped to the other side
                            {
                                row = (row - 1 + GridRows) % GridRows; // Go to previous row
                            }
                            break;
                        case Keys.Right:
                            column = (column + 1) % GridColumns;
                            if (column == 0) // If we wrapped to the other side
                            {
                                row = (row + 1) % GridRows; // Go to next row
                            }
                            break;
                        case Keys.Up:
                            row = (row - 1 + GridRows) % GridRows;
                            if (row == GridRows - 1) // If we wrapped to the other side
                            {
                                column = (column - 1 + GridColumns) % GridColumns; // Go to previous column
                            }
                            break;
                        case Keys.Down:
                            row = (row + 1) % GridRows;
                            if (row == 0) // If we wrapped to the other side
                            {
                                column = (column + 1) % GridColumns; // Go to next column
                            }
                            break;
                    }

                    // Calculate the new index and focus the corresponding PictureBox
                    int newIndex = row * GridRows + column + 1;
                    SelectablePictureBox newPictureBox = pnlBoard.Controls.OfType<SelectablePictureBox>().FirstOrDefault(p => p.TabIndex == newIndex);
                    newPictureBox?.Focus();

                    // Prevent further processing of the arrow key by the form
                    e.Handled = true;
                }
            }





        }
        private void SelectablePictureBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SelectablePictureBox selectedPictureBox = (SelectablePictureBox)sender;

                int selectedIndex = selectedPictureBox.TabIndex;
                int row = (selectedIndex - 1) / 8;
                int column = (selectedIndex - 1) % 8;

                if (e.KeyCode == Keys.Left)
                {
                    if (column > 0)
                    {
                        SelectablePictureBox previousPictureBox = pnlBoard.Controls.OfType<SelectablePictureBox>().FirstOrDefault(p => p.TabIndex == selectedIndex - 1);
                        previousPictureBox?.Focus();
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (column < 7)
                    {
                        SelectablePictureBox nextPictureBox = pnlBoard.Controls.OfType<SelectablePictureBox>().FirstOrDefault(p => p.TabIndex == selectedIndex + 1);
                        nextPictureBox?.Focus();
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (row > 0)
                    {
                        SelectablePictureBox abovePictureBox = pnlBoard.Controls.OfType<SelectablePictureBox>().FirstOrDefault(p => p.TabIndex == selectedIndex - 8);
                        abovePictureBox?.Focus();
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    if (row < 7)
                    {
                        SelectablePictureBox belowPictureBox = pnlBoard.Controls.OfType<SelectablePictureBox>().FirstOrDefault(p => p.TabIndex == selectedIndex + 8);
                        belowPictureBox?.Focus();
                    }
                }

                // Prevent further processing of the arrow key by the picture box
                e.IsInputKey = true;
            }
        }


        private char GetCharacterAtCursor(RichTextBox richTextBox)
        {
            int cursorPosition = richTextBox.SelectionStart;

            if (cursorPosition >= 0 && cursorPosition < richTextBox.TextLength)
            {
                return richTextBox.Text[cursorPosition];
            }

            return '\0'; // Return null character if cursor position is invalid
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                Connect();
            }
        }

        private void tbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                Speech speech = new Speech((int)nudSpeachrate.Value);
                sentence = "Please type your password and press enter";
                speechQueue.EnqueueSpeech(sentence);
                
                tbPassword.Focus();
            }

        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            tbUser.Focus();  // Now the call to Focus() will work as expected
            tbUser.SelectAll();
            Speech speech = new Speech((int)nudSpeachrate.Value);
            sentence = "Please type your username and press enter";
            speechQueue.EnqueueSpeech(sentence);

        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            int number;
            bool success;

            if (lblsideToMove.Text == "W")
            {
                string numberStr = lblWhitesRemainingTime.Text;

                success = int.TryParse(numberStr, out number);

                if (success)
                {
                    number--;
                    lblWhitesRemainingTime.Text = number.ToString();
                    lblWhitesRemainingTimeFormated.Text = FormatTime(number);
                }
                else
                {
                    // The string could not be converted to an integer
                }
            }
            else
            {
                string numberStr = lblBlacksRemainingTime.Text;

                success = int.TryParse(numberStr, out number);

                if (success)
                {
                    number--;
                    lblBlacksRemainingTime.Text = number.ToString();
                    lblBlacksRemainingTimeFormated.Text = FormatTime(number);
                }
                else
                {
                    // The string could not be converted to an integer
                }
            }
        }


        private void btnMovesDebug_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.Visible)
            {
                richTextBox1.Visible = true;
                richTextBox1.BringToFront();
                richTextBox1.Refresh();


            }
            else
            {
                richTextBox1.Visible = false;
            }
            tbPrompt.Focus();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            Send("Forward");
            tbPrompt.Focus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Send("Back 100");
            tbPrompt.Focus();

        }

        private void pnlBoard_Enter(object sender, EventArgs e)
        {
            amAtBoard = true;

        }

        private void tbUser_Enter(object sender, EventArgs e)
        {

        }

        private void FrmMain_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnGamesConsole_Click(object sender, EventArgs e)
        {
            if (!rtbGames.Visible)
            {
                rtbGames.Visible = true;
                rtbGames.BringToFront();
                rtbGames.Refresh();


            }
            else
            {
                rtbGames.Visible = false;
            }
            tbPrompt.Focus();
        }



        private void rtbGames_TextChanged(object sender, EventArgs e)
        {
            rtbGames.SelectionStart = rtbGames.Text.Length;
            rtbGames.ScrollToCaret();
        }

        private void rtbTells_TextChanged(object sender, EventArgs e)
        {
            rtbTells.SelectionStart = rtbGames.Text.Length;
            rtbTells.ScrollToCaret();
        }





        private void btnTellsConsole_Click(object sender, EventArgs e)
        {
            if (!rtbTells.Visible)
            {
                rtbTells.Visible = true;
                rtbTells.BringToFront();
                rtbTells.Refresh();


            }
            else
            {
                rtbTells.Visible = false;
            }
            tbPrompt.Focus();
        }



        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            RichTextBox richTextBox = sender as RichTextBox; // Cast sender to RichTextBox

            if (richTextBox != null) // Safety check
            {
                GetRowAndPosition(richTextBox2);
            }
        }
        private void richTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            RichTextBox richTextBox = sender as RichTextBox; // Cast sender to RichTextBox

            if (richTextBox != null) // Safety check
            {
                GetRowAndPosition(richTextBox2);
            }
        }
        private void GetRowAndPosition(RichTextBox richTextBox)
        {
            Point cursorLocation = richTextBox.PointToClient(Cursor.Position);
            int cursorIndex = richTextBox.GetCharIndexFromPosition(cursorLocation);
            int row = richTextBox.GetLineFromCharIndex(cursorIndex);
            int position = cursorIndex - richTextBox.GetFirstCharIndexFromLine(row);
            char character = richTextBox.Text[cursorIndex];

            // Use the extracted values as needed
            label1.Text = $"Row: {row}, Position: {position}, Character: {character}";
        }









        private void richTextBox2_SelectionChanged(object sender, EventArgs e, string cursorPosition)
        {
            RichTextBox richTextBox = sender as RichTextBox; // Cast sender to RichTextBox

            if (richTextBox != null) // Safety check
            {
               // MessageBox.Show(GetCharacterAtCursor(richTextBox).ToString() + " at position " + cursorPosition);
            }
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e, string cursorPosition)
        {
            if (richTextBox2 != null) // Safety check
            {
               // MessageBox.Show(GetCharacterAtCursor(richTextBox2).ToString() + " at position " + cursorPosition);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string fileName = "log.txt";
                string filePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, fileName);
                string richTextBoxText = richTextBox1.Text; // richTextBox1 is your RichTextBox

                // Append the text to the file
                System.IO.File.AppendAllText(filePath, richTextBoxText);
            }
            catch (Exception ex)
            {
                // Handle or display the error
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDebugPieces_Click(object sender, EventArgs e)
        {
            string input = tbDebug.Text;
            string squareName = input.Substring(0, 2);
            label2.Text = GetCurrentPositionPiecePlacement(richTextBox2, squareName);
        }
        private bool dataGridViewVisible = true;
        private void btnParseEngineLine_Click(object sender, EventArgs e)
        {
            // Initialize a new DataGridView
            dataGridView1 = new DataGridView();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            // Set its properties
            //dataGridView1.Dock = DockStyle.Right; // to dock it to the right
           // dataGridView1.Width = (int)(this.Width * 2.0 / 3.0); // to make it cover 2/3 of the form's width
           
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Consolas", 12, FontStyle.Regular);



            // Define the columns
            dataGridView1.Columns.Add("Info", "Info");
            dataGridView1.Columns.Add("Depth", "Depth");
            dataGridView1.Columns.Add("DepthNumber", "Depth Number");
            dataGridView1.Columns.Add("SelDepth", "SelDepth");
            dataGridView1.Columns.Add("SelDepthNumber", "SelDepth Number");
            dataGridView1.Columns.Add("MultiPV", "MultiPV");
            dataGridView1.Columns.Add("MultiPVNumber", "MultiPV Number");
            dataGridView1.Columns.Add("Score", "Score");
            dataGridView1.Columns.Add("Cp", "Cp");
            dataGridView1.Columns.Add("CpEvaluation", "Cp Evaluation");
            dataGridView1.Columns.Add("Nodes", "Nodes");
            dataGridView1.Columns.Add("NodesNumber", "Nodes Number");
            dataGridView1.Columns.Add("Nps", "Nps");
            dataGridView1.Columns.Add("NpsNumber", "Nps Number");
            dataGridView1.Columns.Add("TbHits", "TbHits");
            dataGridView1.Columns.Add("TbHitsNumber", "TbHits Number");
            dataGridView1.Columns.Add("Time", "Time");
            dataGridView1.Columns.Add("TimeNumber", "Time Number");
            dataGridView1.Columns.Add("Pv", "Pv");
            dataGridView1.Columns.Add("PvMoves", "Pv Moves");
            dataGridView1.Rows.Add();
            // ... add the rest of your columns in the same way ...

            // Populate the DataGridView with data
            try
            {
                foreach (string line in rtbEngineOutPut.Lines)
                {
                    if (line.Contains("info depth"))
                    {
                        var values = ParseAndAssignLinesFromRichTextBox(line);

                        // Add a new row in the DataGridView using the array of values
                        dataGridView1.Rows.Add(values);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or do nothing
            }


            // Add the DataGridView to the form's controls
            this.Controls.Add(dataGridView1);
           
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Refresh();
            dataGridView1.BringToFront();
            Button closeButton = new Button();
            closeButton.Text = "Close Grid";
            closeButton.Dock = DockStyle.Bottom; // Adjust this to fit your layout
            closeButton.Click += new EventHandler(closeButton_Click);
            this.Controls.Add(closeButton);

        }
        

        private DataGridView dataGridView1;
        // Then, define the event handler method
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Perform actions here...
            //var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //MessageBox.Show($"You clicked on cell {e.RowIndex}, {e.ColumnIndex} which contains {cellValue}");
        }
        void closeButton_Click(object sender, EventArgs e)
        {
            // Check if DataGridView is currently displayed
            if (this.Controls.Contains(dataGridView1))
            {
                this.Controls.Remove(dataGridView1);
                

            }
           
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        /*
         * We must scan after available voices if we want to use other tan default
         * so this will not be impllemented

            // Create an instance of SpeechSynthesizer
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();

            // Get the available voices
            IEnumerable<InstalledVoice> voices = synthesizer.GetInstalledVoices();

            // Switch to a specific voice
            if (voices.Any(v => v.VoiceInfo.Name == "Microsoft David Desktop"))
            {
                synthesizer.SelectVoice("Microsoft David Desktop");
            }

            // Speak a sentence using the selected voice
            synthesizer.Speak("This is the voice of Microsoft David Desktop");

            // Switch to another voice
            if (voices.Any(v => v.VoiceInfo.Name == "Microsoft Zira Desktop"))
            {
                synthesizer.SelectVoice("Microsoft Zira Desktop");
            }

            // Speak another sentence using the new voice
            synthesizer.Speak("This is the voice of Microsoft Zira Desktop"); */

        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            pnlServer.Width = this.Width - 550;
            rtbMainConsole.Width = this.Width - 560;
            rtbEngineOutPut.Width = rtbMainConsole.Width;
        }

        private void btnShowDebugPanel_Click(object sender, EventArgs e)
        {
            if (pnlDebug.Visible) 
            {
                pnlDebug.Visible = false;       
            }
            else
            {
                pnlDebug.Visible = true;
            }
        }

        private void btnTellsAndMoves_Click(object sender, EventArgs e)
        {
            if (pnlTellsAndMoves.Visible)
            {
                pnlTellsAndMoves.Visible = false;
            }
            else
            {
                pnlTellsAndMoves.Visible = true;
            }
            
        }
    }
}

