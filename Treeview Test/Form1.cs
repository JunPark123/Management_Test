using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Mangement_TestProgram
{
    public partial class Form1 : Form
    {
        private Dpeco_FinalTest Dpeco_Final;
        private Dpeco_BoardTest Dpeco_Board;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void 최종검사ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;

            Dpeco_Final = new Dpeco_FinalTest();
            panel1.Dock = DockStyle.Fill;
            Dpeco_Final.TopLevel = false;
            panel1.Controls.Add(Dpeco_Final);
            Dpeco_Final.Show();
        }

        private void 디피코ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;

            Dpeco_Board = new Dpeco_BoardTest();
            panel1.Dock = DockStyle.Fill;
            Dpeco_Board.TopLevel = false;
            panel1.Controls.Add(Dpeco_Board);
            Dpeco_Board.Show();
        }
    }
}
