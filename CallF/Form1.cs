using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallF
{
    public partial class Form1 : Form
    {
        string fileName;
        FileAcs fileAccess = new FileAcs();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            //fileAccess.Write2File(call, fileName);

        }

        private void callBtn_Click(object sender, EventArgs e)
        {
            Call makeCall = new Call();

            makeCall.BenchName = "name";
            makeCall.Comment = "comment";
            makeCall.Problem = "problem";
            makeCall.Resolved = false;
            
            string message = fileAccess.WriteCallToFile(makeCall, fileName);     
            
            if(message == "Success")
            {
                Call currentCall = fileAccess.ReadCallsFromFile(fileName);
            }
        }
    }
}
