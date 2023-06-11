using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;





namespace Move2VoiceBeta
{

     public class Engine
    {
        public string rawNotation = "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2";
        public string outSF = "";
        public bool sfReadyTowrite = false;
        

        private FrmMain mainForm;
        public Engine(FrmMain form1)
        {
            this.mainForm = form1;
          
        }

        public async Task StartSF(string fen, bool stop)
        {
            string command = "go movetime 10000";

            var startSF_new = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "stockfish_20090216_x64_modern.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true
                }
            };

            startSF_new.Start();

            startSF_new.StandardInput.WriteLine("ucinewgame");
            startSF_new.StandardInput.WriteLine("setoption name UCI_AnalyseMode value true");
            startSF_new.StandardInput.WriteLine("position fen " + fen);
            startSF_new.StandardInput.WriteLine(command);
            await Task.Delay(10);

            string line;
            while ((line = startSF_new.StandardOutput.ReadLine()) != null)
            {
                outSF += Environment.NewLine + line;

                if (line.StartsWith("bestmove") || stop)
                {
                    // Accessing UI elements from a separate thread:
                    mainForm.Invoke((MethodInvoker)delegate
                    {
                        // Set the Text property in a thread-safe way:
                        mainForm.rtbEngineOutPut.Text = outSF;
                    });

                    mainForm.engine_runnig = false;
                    startSF_new.StandardInput.WriteLine("stop");
                    await Task.Delay(10);  // give the engine some time to process the 'stop' command
                    break;
                }

            }

            outSF = string.Empty;  // Clear outSF after the loop
        }




    }


}


