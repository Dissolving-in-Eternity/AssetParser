using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AssetParser
{
    public partial class Form1 : Form
    {
        private readonly string BTN_NAME_START = "Get data!";
        private readonly string BTN_NAME_STOP = "MAKE IT STOP";

        // A flag to stop reading network stream
        bool makeItStop = true;
        // Dictionary to store row number of known assets
        Dictionary<string, int> dic = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
            btnGetData.Text = BTN_NAME_START;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            // If we're currently reading the stream => stop
            if (!makeItStop)
            {
                makeItStop = true;
                btnGetData.Text = BTN_NAME_START;
            }
            // Else => reset the flag and start reading the stream
            else
            {
                makeItStop = false;
                backgroundWorker.RunWorkerAsync();
                btnGetData.Text = BTN_NAME_STOP;
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var tcpClient = new TcpClient("79.125.80.209", 4092))
            using (var netStream = tcpClient.GetStream())
            using (var sr = new StreamReader(netStream))
            {
                bool firstLine = true;
                while (!makeItStop)
                {
                    // Read one line from the stream
                    string line = sr.ReadLine();
                    string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // Remove Login, Password and Access granted parts from the first line
                    // That should be first 4 tokens
                    if (firstLine)
                    {
                        tokens = tokens.Skip(4).ToArray();
                        firstLine = false;
                    }

                    // Report new asset received
                    backgroundWorker.ReportProgress(0, tokens);
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string[] tokens = e.UserState as string[];

            // Tokens should contain: Name, Time, Bid and Ask in that order
            if(tokens?.Length == 4)
            {
                // If it's a known asset => get its row number
                if(dic.ContainsKey(tokens[0]))
                {
                    UpdateAsset(index:dic[tokens[0]], time:tokens[1], bid:tokens[2], ask:tokens[3]);
                }
                // Otherwise add new asset and save it to the dictionary
                else
                {
                    int index = AddNewAsset(name: tokens[0], time: tokens[1], bid: tokens[2], ask: tokens[3]);
                    dic.Add(tokens[0], index);
                }
            }
        }

        /// <summary>
        /// Adds new asset to the DataGrid
        /// </summary>
        /// <returns>Index of the created asset in the DataGrid</returns>
        private int AddNewAsset(string name, string time, string bid, string ask) 
            => dataGrid.Rows.Add(name, time, bid, ask);

        /// <summary>
        /// Updates time, bid and ask cells of a specified row
        /// </summary>
        private void UpdateAsset(int index, string time, string bid, string ask)
        {
            if (index < dataGrid.Rows.Count)
            {
                dataGrid.Rows[index].Cells["ColTime"].Value = time;
                dataGrid.Rows[index].Cells["ColBid"].Value = bid;
                dataGrid.Rows[index].Cells["ColAsk"].Value = ask;
            }
        }
    }
}
