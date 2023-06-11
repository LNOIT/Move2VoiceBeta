namespace Move2VoiceBeta
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.lblsideToMove = new System.Windows.Forms.Label();
            this.lblLastMove = new System.Windows.Forms.Label();
            this.lblAmIPlaying = new System.Windows.Forms.Label();
            this.tbGameString = new System.Windows.Forms.TextBox();
            this.pnlGameControls = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnMoves = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlServer = new System.Windows.Forms.Panel();
            this.lblLastBuildDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tbLastResponse = new System.Windows.Forms.TextBox();
            this.tbPrompt = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.rtbMainConsole = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rtbGames = new System.Windows.Forms.RichTextBox();
            this.rtbTells = new System.Windows.Forms.RichTextBox();
            this.pnlEngine = new System.Windows.Forms.Panel();
            this.btnParseEngineLine = new System.Windows.Forms.Button();
            this.tbDebug = new System.Windows.Forms.TextBox();
            this.btnDebugPieces = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btnMovesDebug = new System.Windows.Forms.Button();
            this.nudSpeachrate = new System.Windows.Forms.NumericUpDown();
            this.btnTellsConsole = new System.Windows.Forms.Button();
            this.btnGamesConsole = new System.Windows.Forms.Button();
            this.btnStartEngine = new System.Windows.Forms.Button();
            this.btnStopEngine = new System.Windows.Forms.Button();
            this.btnReadLine = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbEngineOutPut = new System.Windows.Forms.RichTextBox();
            this.tmrEngine = new System.Windows.Forms.Timer(this.components);
            this.rtbPgn = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tmrRead = new System.Windows.Forms.Timer(this.components);
            this.rtbMovesListRaw = new System.Windows.Forms.RichTextBox();
            this.tmrSmoothUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblWhitePlayer = new System.Windows.Forms.Label();
            this.lblBlackPlayer = new System.Windows.Forms.Label();
            this.lblWhitesRemainingTime = new System.Windows.Forms.Label();
            this.lblBlacksRemainingTime = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lblWhitesRemainingTimeFormated = new System.Windows.Forms.Label();
            this.lblBlacksRemainingTimeFormated = new System.Windows.Forms.Label();
            this.pnlBoard.SuspendLayout();
            this.pnlGameControls.SuspendLayout();
            this.pnlServer.SuspendLayout();
            this.pnlEngine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeachrate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.AccessibleDescription = "";
            this.pnlBoard.AccessibleName = "The board";
            this.pnlBoard.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.pnlBoard.BackColor = System.Drawing.Color.DarkRed;
            this.pnlBoard.Controls.Add(this.lblsideToMove);
            this.pnlBoard.Controls.Add(this.lblLastMove);
            this.pnlBoard.Controls.Add(this.lblAmIPlaying);
            this.pnlBoard.Location = new System.Drawing.Point(12, 12);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(500, 500);
            this.pnlBoard.TabIndex = 1;
            this.pnlBoard.TabStop = true;
            this.pnlBoard.Tag = "The chessboard";
            this.pnlBoard.Enter += new System.EventHandler(this.pnlBoard_Enter);
            // 
            // lblsideToMove
            // 
            this.lblsideToMove.AutoSize = true;
            this.lblsideToMove.Location = new System.Drawing.Point(7, 484);
            this.lblsideToMove.Name = "lblsideToMove";
            this.lblsideToMove.Size = new System.Drawing.Size(76, 13);
            this.lblsideToMove.TabIndex = 6;
            this.lblsideToMove.Text = "lblsideToMove";
            // 
            // lblLastMove
            // 
            this.lblLastMove.AutoSize = true;
            this.lblLastMove.Location = new System.Drawing.Point(85, 484);
            this.lblLastMove.Name = "lblLastMove";
            this.lblLastMove.Size = new System.Drawing.Size(57, 13);
            this.lblLastMove.TabIndex = 17;
            this.lblLastMove.Text = "Last Move";
            // 
            // lblAmIPlaying
            // 
            this.lblAmIPlaying.AutoSize = true;
            this.lblAmIPlaying.Location = new System.Drawing.Point(148, 484);
            this.lblAmIPlaying.Name = "lblAmIPlaying";
            this.lblAmIPlaying.Size = new System.Drawing.Size(69, 13);
            this.lblAmIPlaying.TabIndex = 9;
            this.lblAmIPlaying.Text = "lblAmIPlaying";
            // 
            // tbGameString
            // 
            this.tbGameString.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGameString.Location = new System.Drawing.Point(14, 527);
            this.tbGameString.Name = "tbGameString";
            this.tbGameString.Size = new System.Drawing.Size(281, 23);
            this.tbGameString.TabIndex = 1;
            this.tbGameString.TabStop = false;
            this.tbGameString.Text = "4k2r/6r1/8/8/8/8/3R4/R3K3 w Qk - 0 1";
            // 
            // pnlGameControls
            // 
            this.pnlGameControls.Controls.Add(this.button2);
            this.pnlGameControls.Controls.Add(this.btnMoves);
            this.pnlGameControls.Controls.Add(this.btnEnd);
            this.pnlGameControls.Controls.Add(this.btnStart);
            this.pnlGameControls.Controls.Add(this.btnForward);
            this.pnlGameControls.Controls.Add(this.btnBack);
            this.pnlGameControls.Location = new System.Drawing.Point(23, 54);
            this.pnlGameControls.Name = "pnlGameControls";
            this.pnlGameControls.Size = new System.Drawing.Size(431, 37);
            this.pnlGameControls.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(362, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 13;
            this.button2.TabStop = false;
            this.button2.Text = "CreatePgn";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnMoves
            // 
            this.btnMoves.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMoves.Location = new System.Drawing.Point(395, 3);
            this.btnMoves.Name = "btnMoves";
            this.btnMoves.Size = new System.Drawing.Size(33, 23);
            this.btnMoves.TabIndex = 12;
            this.btnMoves.TabStop = false;
            this.btnMoves.Text = "Moves";
            this.btnMoves.UseVisualStyleBackColor = true;
            this.btnMoves.Click += new System.EventHandler(this.btnMoves_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEnd.Location = new System.Drawing.Point(281, 3);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 11;
            this.btnEnd.TabStop = false;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStart
            // 
            this.btnStart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStart.Location = new System.Drawing.Point(184, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnForward
            // 
            this.btnForward.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnForward.Location = new System.Drawing.Point(93, 3);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 23);
            this.btnForward.TabIndex = 9;
            this.btnForward.TabStop = false;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlServer
            // 
            this.pnlServer.Controls.Add(this.lblLastBuildDate);
            this.pnlServer.Controls.Add(this.dateTimePicker1);
            this.pnlServer.Controls.Add(this.tbLastResponse);
            this.pnlServer.Controls.Add(this.tbPrompt);
            this.pnlServer.Controls.Add(this.tbPassword);
            this.pnlServer.Controls.Add(this.tbUser);
            this.pnlServer.Controls.Add(this.btnRead);
            this.pnlServer.Controls.Add(this.btnSend);
            this.pnlServer.Controls.Add(this.btnConnect);
            this.pnlServer.Controls.Add(this.tbGameString);
            this.pnlServer.Controls.Add(this.pnlGameControls);
            this.pnlServer.Controls.Add(this.rtbMainConsole);
            this.pnlServer.Location = new System.Drawing.Point(755, 12);
            this.pnlServer.Name = "pnlServer";
            this.pnlServer.Size = new System.Drawing.Size(689, 550);
            this.pnlServer.TabIndex = 2;
            // 
            // lblLastBuildDate
            // 
            this.lblLastBuildDate.AutoSize = true;
            this.lblLastBuildDate.Location = new System.Drawing.Point(145, 451);
            this.lblLastBuildDate.Name = "lblLastBuildDate";
            this.lblLastBuildDate.Size = new System.Drawing.Size(130, 13);
            this.lblLastBuildDate.TabIndex = 19;
            this.lblLastBuildDate.Text = "Last Build version: x Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.Coral;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.WindowFrame;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.AliceBlue;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(281, 448);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.TabStop = false;
            // 
            // tbLastResponse
            // 
            this.tbLastResponse.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastResponse.Location = new System.Drawing.Point(14, 501);
            this.tbLastResponse.Name = "tbLastResponse";
            this.tbLastResponse.Size = new System.Drawing.Size(242, 23);
            this.tbLastResponse.TabIndex = 17;
            this.tbLastResponse.TabStop = false;
            this.tbLastResponse.TextChanged += new System.EventHandler(this.tbLastResponse_TextChanged);
            // 
            // tbPrompt
            // 
            this.tbPrompt.AcceptsReturn = true;
            this.tbPrompt.AccessibleDescription = "Server commands";
            this.tbPrompt.AccessibleName = "Server commands";
            this.tbPrompt.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrompt.Location = new System.Drawing.Point(14, 475);
            this.tbPrompt.Name = "tbPrompt";
            this.tbPrompt.Size = new System.Drawing.Size(221, 23);
            this.tbPrompt.TabIndex = 0;
            this.tbPrompt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPrompt_KeyDown);
            // 
            // tbPassword
            // 
            this.tbPassword.AccessibleDescription = "Password";
            this.tbPassword.AccessibleName = "Password prompt";
            this.tbPassword.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tbPassword.Location = new System.Drawing.Point(189, 12);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(169, 20);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.TabStop = false;
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
            // 
            // tbUser
            // 
            this.tbUser.AccessibleDescription = "Login prompt";
            this.tbUser.AccessibleName = "Login prompt";
            this.tbUser.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tbUser.Location = new System.Drawing.Point(14, 12);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(169, 20);
            this.tbUser.TabIndex = 3;
            this.tbUser.TabStop = false;
            this.tbUser.Enter += new System.EventHandler(this.tbUser_Enter);
            this.tbUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUser_KeyDown);
            // 
            // btnRead
            // 
            this.btnRead.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRead.Location = new System.Drawing.Point(14, 446);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(125, 23);
            this.btnRead.TabIndex = 13;
            this.btnRead.TabStop = false;
            this.btnRead.Text = "Listening to server";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnSend
            // 
            this.btnSend.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSend.Location = new System.Drawing.Point(241, 474);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 12;
            this.btnSend.TabStop = false;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.AccessibleDescription = "Connect Button";
            this.btnConnect.AccessibleName = "Connect Button";
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConnect.Location = new System.Drawing.Point(364, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.TabStop = false;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // rtbMainConsole
            // 
            this.rtbMainConsole.AccessibleDescription = "Server responses";
            this.rtbMainConsole.AccessibleName = "Main Console";
            this.rtbMainConsole.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.rtbMainConsole.BackColor = System.Drawing.SystemColors.InfoText;
            this.rtbMainConsole.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMainConsole.ForeColor = System.Drawing.Color.Lime;
            this.rtbMainConsole.Location = new System.Drawing.Point(14, 41);
            this.rtbMainConsole.Name = "rtbMainConsole";
            this.rtbMainConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbMainConsole.Size = new System.Drawing.Size(661, 399);
            this.rtbMainConsole.TabIndex = 2;
            this.rtbMainConsole.Text = "";
            this.rtbMainConsole.WordWrap = false;
            this.rtbMainConsole.TextChanged += new System.EventHandler(this.rtbMainConsole_TextChanged);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(9, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 18;
            this.button1.TabStop = false;
            this.button1.Text = "Convert to FEN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbGames
            // 
            this.rtbGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbGames.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbGames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rtbGames.Location = new System.Drawing.Point(518, 469);
            this.rtbGames.Name = "rtbGames";
            this.rtbGames.Size = new System.Drawing.Size(231, 121);
            this.rtbGames.TabIndex = 3;
            this.rtbGames.TabStop = false;
            this.rtbGames.Text = "";
            this.rtbGames.TextChanged += new System.EventHandler(this.rtbGames_TextChanged);
            // 
            // rtbTells
            // 
            this.rtbTells.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbTells.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTells.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rtbTells.Location = new System.Drawing.Point(518, 342);
            this.rtbTells.Name = "rtbTells";
            this.rtbTells.Size = new System.Drawing.Size(231, 121);
            this.rtbTells.TabIndex = 4;
            this.rtbTells.TabStop = false;
            this.rtbTells.Text = "";
            this.rtbTells.TextChanged += new System.EventHandler(this.rtbTells_TextChanged);
            // 
            // pnlEngine
            // 
            this.pnlEngine.Controls.Add(this.btnParseEngineLine);
            this.pnlEngine.Controls.Add(this.tbDebug);
            this.pnlEngine.Controls.Add(this.btnDebugPieces);
            this.pnlEngine.Controls.Add(this.rtbLog);
            this.pnlEngine.Controls.Add(this.richTextBox2);
            this.pnlEngine.Controls.Add(this.button1);
            this.pnlEngine.Controls.Add(this.btnMovesDebug);
            this.pnlEngine.Controls.Add(this.nudSpeachrate);
            this.pnlEngine.Location = new System.Drawing.Point(828, 568);
            this.pnlEngine.Name = "pnlEngine";
            this.pnlEngine.Size = new System.Drawing.Size(452, 209);
            this.pnlEngine.TabIndex = 3;
            // 
            // btnParseEngineLine
            // 
            this.btnParseEngineLine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnParseEngineLine.Location = new System.Drawing.Point(9, 151);
            this.btnParseEngineLine.Name = "btnParseEngineLine";
            this.btnParseEngineLine.Size = new System.Drawing.Size(128, 26);
            this.btnParseEngineLine.TabIndex = 25;
            this.btnParseEngineLine.TabStop = false;
            this.btnParseEngineLine.Text = "Parse Engine";
            this.btnParseEngineLine.UseVisualStyleBackColor = true;
            this.btnParseEngineLine.Click += new System.EventHandler(this.btnParseEngineLine_Click);
            // 
            // tbDebug
            // 
            this.tbDebug.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDebug.Location = new System.Drawing.Point(9, 128);
            this.tbDebug.Name = "tbDebug";
            this.tbDebug.Size = new System.Drawing.Size(127, 23);
            this.tbDebug.TabIndex = 24;
            this.tbDebug.TabStop = false;
            // 
            // btnDebugPieces
            // 
            this.btnDebugPieces.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDebugPieces.Location = new System.Drawing.Point(9, 96);
            this.btnDebugPieces.Name = "btnDebugPieces";
            this.btnDebugPieces.Size = new System.Drawing.Size(128, 26);
            this.btnDebugPieces.TabIndex = 23;
            this.btnDebugPieces.TabStop = false;
            this.btnDebugPieces.Text = "Debug pieces";
            this.btnDebugPieces.UseVisualStyleBackColor = true;
            this.btnDebugPieces.Click += new System.EventHandler(this.btnDebugPieces_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.Location = new System.Drawing.Point(295, 9);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(139, 197);
            this.rtbLog.TabIndex = 22;
            this.rtbLog.TabStop = false;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(143, 9);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(139, 197);
            this.richTextBox2.TabIndex = 21;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.Text = "rnbqkbnr\npppppppp\n--------\n--------\n--------\n--------\nPPPPPPPP\nRNBQKBNR";
            // 
            // btnMovesDebug
            // 
            this.btnMovesDebug.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMovesDebug.Location = new System.Drawing.Point(9, 64);
            this.btnMovesDebug.Name = "btnMovesDebug";
            this.btnMovesDebug.Size = new System.Drawing.Size(128, 26);
            this.btnMovesDebug.TabIndex = 18;
            this.btnMovesDebug.TabStop = false;
            this.btnMovesDebug.Text = "Debug moves";
            this.btnMovesDebug.UseVisualStyleBackColor = true;
            this.btnMovesDebug.Click += new System.EventHandler(this.btnMovesDebug_Click);
            // 
            // nudSpeachrate
            // 
            this.nudSpeachrate.AccessibleName = "Speechrate";
            this.nudSpeachrate.AccessibleRole = System.Windows.Forms.AccessibleRole.SpinButton;
            this.nudSpeachrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSpeachrate.Location = new System.Drawing.Point(17, 9);
            this.nudSpeachrate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSpeachrate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudSpeachrate.Name = "nudSpeachrate";
            this.nudSpeachrate.Size = new System.Drawing.Size(120, 49);
            this.nudSpeachrate.TabIndex = 7;
            this.nudSpeachrate.TabStop = false;
            this.nudSpeachrate.Value = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            // 
            // btnTellsConsole
            // 
            this.btnTellsConsole.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTellsConsole.Location = new System.Drawing.Point(755, 342);
            this.btnTellsConsole.Name = "btnTellsConsole";
            this.btnTellsConsole.Size = new System.Drawing.Size(30, 23);
            this.btnTellsConsole.TabIndex = 20;
            this.btnTellsConsole.TabStop = false;
            this.btnTellsConsole.Text = "Tells Console";
            this.btnTellsConsole.UseVisualStyleBackColor = true;
            this.btnTellsConsole.Click += new System.EventHandler(this.btnTellsConsole_Click);
            // 
            // btnGamesConsole
            // 
            this.btnGamesConsole.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGamesConsole.Location = new System.Drawing.Point(755, 469);
            this.btnGamesConsole.Name = "btnGamesConsole";
            this.btnGamesConsole.Size = new System.Drawing.Size(30, 23);
            this.btnGamesConsole.TabIndex = 19;
            this.btnGamesConsole.TabStop = false;
            this.btnGamesConsole.Text = "Games Console";
            this.btnGamesConsole.UseVisualStyleBackColor = true;
            this.btnGamesConsole.Click += new System.EventHandler(this.btnGamesConsole_Click);
            // 
            // btnStartEngine
            // 
            this.btnStartEngine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStartEngine.Location = new System.Drawing.Point(19, 598);
            this.btnStartEngine.Name = "btnStartEngine";
            this.btnStartEngine.Size = new System.Drawing.Size(75, 23);
            this.btnStartEngine.TabIndex = 8;
            this.btnStartEngine.TabStop = false;
            this.btnStartEngine.Text = "Start Engine";
            this.btnStartEngine.UseVisualStyleBackColor = true;
            this.btnStartEngine.Click += new System.EventHandler(this.btnStartEngine_Click);
            // 
            // btnStopEngine
            // 
            this.btnStopEngine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStopEngine.Location = new System.Drawing.Point(100, 598);
            this.btnStopEngine.Name = "btnStopEngine";
            this.btnStopEngine.Size = new System.Drawing.Size(75, 23);
            this.btnStopEngine.TabIndex = 1;
            this.btnStopEngine.TabStop = false;
            this.btnStopEngine.Text = "Stop Engine";
            this.btnStopEngine.UseVisualStyleBackColor = true;
            this.btnStopEngine.Click += new System.EventHandler(this.btnStopEngine_Click);
            // 
            // btnReadLine
            // 
            this.btnReadLine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReadLine.Location = new System.Drawing.Point(181, 598);
            this.btnReadLine.Name = "btnReadLine";
            this.btnReadLine.Size = new System.Drawing.Size(75, 23);
            this.btnReadLine.TabIndex = 10;
            this.btnReadLine.TabStop = false;
            this.btnReadLine.Text = "Read line";
            this.btnReadLine.UseVisualStyleBackColor = true;
            this.btnReadLine.Click += new System.EventHandler(this.btnReadLine_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 814);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // rtbEngineOutPut
            // 
            this.rtbEngineOutPut.AccessibleDescription = "Where the computer line is shown";
            this.rtbEngineOutPut.AccessibleName = "Engine Console";
            this.rtbEngineOutPut.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.rtbEngineOutPut.AutoWordSelection = true;
            this.rtbEngineOutPut.BackColor = System.Drawing.Color.MidnightBlue;
            this.rtbEngineOutPut.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbEngineOutPut.ForeColor = System.Drawing.SystemColors.Info;
            this.rtbEngineOutPut.Location = new System.Drawing.Point(12, 627);
            this.rtbEngineOutPut.Name = "rtbEngineOutPut";
            this.rtbEngineOutPut.Size = new System.Drawing.Size(773, 184);
            this.rtbEngineOutPut.TabIndex = 4;
            this.rtbEngineOutPut.TabStop = false;
            this.rtbEngineOutPut.Text = resources.GetString("rtbEngineOutPut.Text");
            this.rtbEngineOutPut.WordWrap = false;
            this.rtbEngineOutPut.TextChanged += new System.EventHandler(this.rtbEngineOutPut_TextChanged);
            // 
            // tmrEngine
            // 
            this.tmrEngine.Tick += new System.EventHandler(this.tmrEngine_Tick);
            // 
            // rtbPgn
            // 
            this.rtbPgn.BackColor = System.Drawing.Color.DarkGreen;
            this.rtbPgn.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPgn.ForeColor = System.Drawing.Color.White;
            this.rtbPgn.Location = new System.Drawing.Point(518, 179);
            this.rtbPgn.Name = "rtbPgn";
            this.rtbPgn.Size = new System.Drawing.Size(231, 157);
            this.rtbPgn.TabIndex = 6;
            this.rtbPgn.TabStop = false;
            this.rtbPgn.Text = "";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "br.png");
            this.imageList1.Images.SetKeyName(1, "bn.png");
            this.imageList1.Images.SetKeyName(2, "bb.png");
            this.imageList1.Images.SetKeyName(3, "bq.png");
            this.imageList1.Images.SetKeyName(4, "bk.png");
            this.imageList1.Images.SetKeyName(5, "bp.png");
            this.imageList1.Images.SetKeyName(6, "wr.png");
            this.imageList1.Images.SetKeyName(7, "wn.png");
            this.imageList1.Images.SetKeyName(8, "wb.png");
            this.imageList1.Images.SetKeyName(9, "wq.png");
            this.imageList1.Images.SetKeyName(10, "wk.png");
            this.imageList1.Images.SetKeyName(11, "wp.png");
            this.imageList1.Images.SetKeyName(12, "clear.png");
            // 
            // tmrRead
            // 
            this.tmrRead.Interval = 200;
            this.tmrRead.Tick += new System.EventHandler(this.tmrRead_Tick);
            // 
            // rtbMovesListRaw
            // 
            this.rtbMovesListRaw.BackColor = System.Drawing.Color.Indigo;
            this.rtbMovesListRaw.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMovesListRaw.ForeColor = System.Drawing.SystemColors.Info;
            this.rtbMovesListRaw.Location = new System.Drawing.Point(518, 15);
            this.rtbMovesListRaw.Name = "rtbMovesListRaw";
            this.rtbMovesListRaw.Size = new System.Drawing.Size(231, 158);
            this.rtbMovesListRaw.TabIndex = 5;
            this.rtbMovesListRaw.TabStop = false;
            this.rtbMovesListRaw.Text = "";
            this.rtbMovesListRaw.TextChanged += new System.EventHandler(this.rtbMovesListRaw_TextChanged);
            // 
            // tmrSmoothUpdate
            // 
            this.tmrSmoothUpdate.Interval = 1000;
            this.tmrSmoothUpdate.Tick += new System.EventHandler(this.tmrSmoothUpdate_Tick);
            // 
            // lblWhitePlayer
            // 
            this.lblWhitePlayer.AutoSize = true;
            this.lblWhitePlayer.Location = new System.Drawing.Point(160, 517);
            this.lblWhitePlayer.Name = "lblWhitePlayer";
            this.lblWhitePlayer.Size = new System.Drawing.Size(74, 13);
            this.lblWhitePlayer.TabIndex = 7;
            this.lblWhitePlayer.Text = "lblWhitePlayer";
            // 
            // lblBlackPlayer
            // 
            this.lblBlackPlayer.AutoSize = true;
            this.lblBlackPlayer.Location = new System.Drawing.Point(314, 523);
            this.lblBlackPlayer.Name = "lblBlackPlayer";
            this.lblBlackPlayer.Size = new System.Drawing.Size(34, 13);
            this.lblBlackPlayer.TabIndex = 8;
            this.lblBlackPlayer.Text = "Black";
            // 
            // lblWhitesRemainingTime
            // 
            this.lblWhitesRemainingTime.AutoSize = true;
            this.lblWhitesRemainingTime.BackColor = System.Drawing.Color.White;
            this.lblWhitesRemainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhitesRemainingTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWhitesRemainingTime.Location = new System.Drawing.Point(15, 515);
            this.lblWhitesRemainingTime.Name = "lblWhitesRemainingTime";
            this.lblWhitesRemainingTime.Size = new System.Drawing.Size(40, 24);
            this.lblWhitesRemainingTime.TabIndex = 10;
            this.lblWhitesRemainingTime.Text = "900";
            // 
            // lblBlacksRemainingTime
            // 
            this.lblBlacksRemainingTime.AutoSize = true;
            this.lblBlacksRemainingTime.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBlacksRemainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlacksRemainingTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBlacksRemainingTime.Location = new System.Drawing.Point(394, 517);
            this.lblBlacksRemainingTime.Name = "lblBlacksRemainingTime";
            this.lblBlacksRemainingTime.Size = new System.Drawing.Size(40, 24);
            this.lblBlacksRemainingTime.TabIndex = 11;
            this.lblBlacksRemainingTime.Text = "900";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(563, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(284, 597);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(825, 804);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "label2";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.ForeColor = System.Drawing.Color.Yellow;
            this.button3.Location = new System.Drawing.Point(1116, 794);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 22;
            this.button3.TabStop = false;
            this.button3.Text = "TEST";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblWhitesRemainingTimeFormated
            // 
            this.lblWhitesRemainingTimeFormated.AutoSize = true;
            this.lblWhitesRemainingTimeFormated.BackColor = System.Drawing.Color.White;
            this.lblWhitesRemainingTimeFormated.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhitesRemainingTimeFormated.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWhitesRemainingTimeFormated.Location = new System.Drawing.Point(15, 555);
            this.lblWhitesRemainingTimeFormated.Name = "lblWhitesRemainingTimeFormated";
            this.lblWhitesRemainingTimeFormated.Size = new System.Drawing.Size(40, 24);
            this.lblWhitesRemainingTimeFormated.TabIndex = 23;
            this.lblWhitesRemainingTimeFormated.Text = "900";
            // 
            // lblBlacksRemainingTimeFormated
            // 
            this.lblBlacksRemainingTimeFormated.AutoSize = true;
            this.lblBlacksRemainingTimeFormated.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBlacksRemainingTimeFormated.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlacksRemainingTimeFormated.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBlacksRemainingTimeFormated.Location = new System.Drawing.Point(394, 555);
            this.lblBlacksRemainingTimeFormated.Name = "lblBlacksRemainingTimeFormated";
            this.lblBlacksRemainingTimeFormated.Size = new System.Drawing.Size(40, 24);
            this.lblBlacksRemainingTimeFormated.TabIndex = 24;
            this.lblBlacksRemainingTimeFormated.Text = "900";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1456, 836);
            this.Controls.Add(this.lblBlacksRemainingTimeFormated);
            this.Controls.Add(this.lblWhitesRemainingTimeFormated);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlServer);
            this.Controls.Add(this.rtbMovesListRaw);
            this.Controls.Add(this.btnGamesConsole);
            this.Controls.Add(this.btnTellsConsole);
            this.Controls.Add(this.rtbPgn);
            this.Controls.Add(this.rtbTells);
            this.Controls.Add(this.rtbGames);
            this.Controls.Add(this.rtbEngineOutPut);
            this.Controls.Add(this.lblBlacksRemainingTime);
            this.Controls.Add(this.btnStartEngine);
            this.Controls.Add(this.btnStopEngine);
            this.Controls.Add(this.lblWhitesRemainingTime);
            this.Controls.Add(this.lblBlackPlayer);
            this.Controls.Add(this.btnReadLine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblWhitePlayer);
            this.Controls.Add(this.pnlEngine);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.richTextBox1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "FrmMain";
            this.Text = "Move to voice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.MouseEnter += new System.EventHandler(this.FrmMain_MouseEnter);
            this.pnlBoard.ResumeLayout(false);
            this.pnlBoard.PerformLayout();
            this.pnlGameControls.ResumeLayout(false);
            this.pnlServer.ResumeLayout(false);
            this.pnlServer.PerformLayout();
            this.pnlEngine.ResumeLayout(false);
            this.pnlEngine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeachrate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.TextBox tbGameString;
        private System.Windows.Forms.Panel pnlGameControls;
        private System.Windows.Forms.Panel pnlServer;
        private System.Windows.Forms.RichTextBox rtbMainConsole;
        private System.Windows.Forms.Panel pnlEngine;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        public System.Windows.Forms.RichTextBox rtbEngineOutPut;
        private System.Windows.Forms.Button btnStartEngine;
        private System.Windows.Forms.Button btnStopEngine;
        private System.Windows.Forms.Button btnReadLine;
        private System.Windows.Forms.TextBox tbPrompt;
        private System.Windows.Forms.TextBox tbLastResponse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer tmrEngine;
        private System.Windows.Forms.RichTextBox rtbPgn;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer tmrRead;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnMoves;
        public System.Windows.Forms.RichTextBox rtbMovesListRaw;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer tmrSmoothUpdate;
        public System.Windows.Forms.Label lblsideToMove;
        public System.Windows.Forms.Label lblWhitePlayer;
        public System.Windows.Forms.Label lblBlackPlayer;
        public System.Windows.Forms.Label lblAmIPlaying;
        public System.Windows.Forms.Label lblWhitesRemainingTime;
        public System.Windows.Forms.Label lblBlacksRemainingTime;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox rtbTells;
        private System.Windows.Forms.RichTextBox rtbGames;
        public System.Windows.Forms.NumericUpDown nudSpeachrate;
        public System.Windows.Forms.TextBox tbPassword;
        public System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Timer tmrClock;
        public System.Windows.Forms.Label lblLastMove;
        private System.Windows.Forms.Button btnMovesDebug;
        private System.Windows.Forms.Button btnGamesConsole;
        private System.Windows.Forms.Button btnTellsConsole;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox rtbLog;
        public System.Windows.Forms.Label lblLastBuildDate;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDebugPieces;
        private System.Windows.Forms.TextBox tbDebug;
        private System.Windows.Forms.Button btnParseEngineLine;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label lblWhitesRemainingTimeFormated;
        public System.Windows.Forms.Label lblBlacksRemainingTimeFormated;
    }
}

