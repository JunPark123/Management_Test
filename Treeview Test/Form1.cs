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
        enum Test
        {
            none, enum_PK316, enum_BK139
        }


        private Test _test = Test.none;
        private static Dpeco_FinalTest Dpeco_Final;
        private static Dpeco_BoardTest Dpeco_Board;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }


        /// <summary>
        /// 요약 : 
        /// 화면에 출력시킬 Form 을 선택하는 메서드
        /// 버튼 클릭 이벤트시 Form 선택함
        /// </summary>
        /// <param name="form"><param name="panel"></param>
        /// <returns></returns>
        private void Select_Test(Form form,Panel panel)
        {
            try
            {            
                form = new Form();                
                form.TopLevel = false;
                panel.Dock = DockStyle.Fill;
                panel.Controls.Add(form);               
            }
            catch (Exception)
            {
                MessageBox.Show("Form을 선택하는데 실패하였습니다.");
                throw;
            }
        }
        /// <summary>
        /// panel 어케 줄지 생각해봐야함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;

            Select_Test(Dpeco_Board , panel1);
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
