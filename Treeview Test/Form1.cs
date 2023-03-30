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
            enum_PK316, enum_BK139
        }

        private PanelManager _panelManager;
        private FormManager _formManager;
        

        public Form1()
        {
            InitializeComponent();
            Panel[] panels = new Panel[] { panel1, panel2 };
            _panelManager = new PanelManager(panels);
            _formManager = new FormManager();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Control_Panel(int index)
        {
            try
            {

                _panelManager.ShowPanel(index,_formManager.Select_Form(index));
            }
            catch (Exception)
            {
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
        }

        private void 최종검사ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Control_Panel((int)Test.enum_PK316);
            _formManager.ShowForm2();
        }

        private void 디피코ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control_Panel((int)Test.enum_BK139);
            _formManager.ShowForm3();
        }
    }

    public class PanelManager
    {
        /// <summary>
        /// readonly 키워드를 사용하면 참조가 변경되거나 할당x
        /// panel 갯수가 많아지면 동적 자료 구조로 변경
        /// </summary>
        private readonly Panel[] panels = new Panel[20];
        private readonly Panel panel1;
        private readonly Panel panel2;
        private Dpeco_FinalTest finalTest;
        private Dpeco_BoardTest boardTest;

        public PanelManager(Panel[] panels)
        {
            this.panels = panels;
        }

        public PanelManager(Panel panel1, Panel panel2)
        {
            this.panel1 = panel1;
            this.panel2 = panel2;
            finalTest = new Dpeco_FinalTest();
            boardTest = new Dpeco_BoardTest();
        }

        public PanelManager(Panel[] panels, Panel panel1, Panel panel2)
        {
            this.panels = panels;
            this.panel1 = panel1;
            this.panel2 = panel2;
            finalTest = new Dpeco_FinalTest();
            boardTest = new Dpeco_BoardTest();
        }

        /// <summary>
        /// index 매개변수만 panel을 true하고 나머지는 false 처리
        /// </summary>
        /// <param name="index"></param>
        public void ShowPanel(int index)
        {
            if (index >= panels.Length)
            {
                throw new IndexOutOfRangeException("Panel index out of range.");
            }
            foreach (Panel panel in panels)
            {
                panel.Visible = false;
            }

            panels[index].Visible = true;
            panels[index].Controls.Clear();
        }

        public void ShowPanel(int index,Form form)
        {
            if (index >= panels.Length)
            {
                throw new IndexOutOfRangeException("Panel index out of range.");
            }

            if(form == null)
            {
                throw new IndexOutOfRangeException("Form is null.");
            }
            foreach (Panel panel in panels)
            {
                panel.Visible = false;
            }

            panels[index].Visible = true;
            panels[index].Controls.Clear();
            panels[index].Dock = DockStyle.Fill;
            form.TopLevel = false;
            panels[index].Controls.Add(form);
        }
    }

    public class FormManager
    {
        enum Test
        {
            enum_PK316, enum_BK139
        }

        private Dpeco_FinalTest _PK316Fianl;
        private Dpeco_BoardTest _BK139Board;

        public FormManager()
        {    // Form2 초기화 코드
            _PK316Fianl = new Dpeco_FinalTest();
            _BK139Board = new Dpeco_BoardTest();
        }

        public Form Select_Form(int index)
        {
            try
            {
                if (index >= 20)
                {
                    throw new IndexOutOfRangeException("Forms index out of range.");
                }

                switch (index)
                {
                    case 0:
                        return _PK316Fianl;
                    case 1:
                        return _BK139Board;
                    default:
                        break;
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ShowForm2()
        {
            _PK316Fianl.Show();
        }

        public void ShowForm3()
        {
            _BK139Board.Show();
        }
        // 다른 Form2에 필요한 메서드 등을 추가할 수 있습니다.
    }
}
