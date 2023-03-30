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
using System.IO;


namespace Mangement_TestProgram
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 파일 경로는 바뀌면 안되므로 상수로 선언함
        /// 추후에는 파일 경로 불러오기 후 실행으로 변경하기
        /// </summary>
        public static class FilePaths
        {
            public const string BootFilePath = "D:\\TS60s\\Project\\Treeview Test\\Treeview Test\\Treeview Test\\bin\\DLTool\\STM\\ST_DL_v1.02\\DL_Stm32_Can_v1.02_20200916.exe";
            public const string FWFilePath = "D:\\TS60s\\Project\\Treeview Test\\Treeview Test\\Treeview Test\\bin\\DLTool\\UDS\\v1.07\\UDS_DL_v107_20220627.exe";
            public const string TjconFilePath = "D:\\TS60s\\Project\\Treeview Test\\Treeview Test\\Treeview Test\\bin\\DLTool\\UDS\\v1.07\\UDS_DL_v107_20220627.exe";
        }

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
        /// Home Button
        /// Panel 모두 해제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _panelManager.ClosePanel();
            }
            catch (Exception)
            {

                throw;
            } 
        }

        /// <summary>
        /// 디피코_PK316 최종검사
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
                       
        private void 최종검사ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Control_Panel((int)Test.enum_PK316);
                _formManager.ShowForm2();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 디피코_BK139 BoardTest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 디피코ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Control_Panel((int)Test.enum_BK139);
                _formManager.ShowForm3();
            }
            catch (Exception)
            {

                throw;
            }          
        }


        /// <summary>
        ///Boot d/l 실행 
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(FilePaths.BootFilePath))
                {
                    throw new FileNotFoundException("파일을 찾을 수 없습니다.", FilePaths.BootFilePath);
                }

                Process.Start(FilePaths.BootFilePath);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                // 파일을 찾을 수 없는 경우 처리할 코드
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // 기타 예외 처리
            }
        }

        private void fWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(FilePaths.FWFilePath))
                {
                    throw new FileNotFoundException("파일을 찾을 수 없습니다.", FilePaths.FWFilePath);
                }

                Process.Start(FilePaths.FWFilePath);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                // 파일을 찾을 수 없는 경우 처리할 코드
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // 기타 예외 처리
            }
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

        public PanelManager(Panel[] panels)
        {
            this.panels = panels;
        }

        public PanelManager(Panel panel1, Panel panel2)
        {
            this.panel1 = panel1;
            this.panel2 = panel2;
        }

        public PanelManager(Panel[] panels, Panel panel1, Panel panel2)
        {
            this.panels = panels;
            this.panel1 = panel1;
            this.panel2 = panel2;
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

        public void ClosePanel()
        {
            try
            {
                foreach (Panel panel in panels)
                {
                    panel.Visible = false;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
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
