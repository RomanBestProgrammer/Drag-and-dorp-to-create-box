using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class MainForm : Form
    {
        TextBox txtBx = null;
        public int A1 { set; get; }
        public int B1 { set; get; }
        public int A2 { set; get; }
        public int B2 { set; get; }
        public int Count { set; get; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"{e.X}, {e.Y}";
            //void remoteText(int X, int Y) { this.Text = $"X:{X}, Y:{Y}, S={(A2 - A1) * (B2 - B1)}"; }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            txtBx = new TextBox();
            txtBx.Multiline = true;
            A1 = e.X;
            B1 = e.Y;
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                A2 = e.X;
                B2 = e.Y;
                if (B2 - B1 < 10 && A2 - A1 < 10) //надо брать результат в модуль для обратного направления
                {
                    MessageBox.Show("Неправильный размер");
                }
                else
                {
                    txtBx.Text = $"{++Count}";
                    txtBx.Location = new Point(A1, B1);
                    txtBx.Size = new Size(A2 - A1, B2 - B1);
                    this.Controls.Add(txtBx);
                    txtBx.MouseDoubleClick += TxtBx_MouseDoubleClick;
                    txtBx.MouseClick += TxtBx_MouseClick;
                }
            }
            else
            {
                MessageBox.Show("Можно использовать только левую кнопку мыши");
                B1 = 0; A1 = 0; A2 = 0; B2 = 0;
            }
        }

        private void TxtBx_MouseClick(object sender, MouseEventArgs e)
        {
            //MainForm obj = new MainForm();
            if (MouseButtons.Right == e.Button)
            {
                Point point;
                point = this.txtBx.Location;
                //remoteText(point.X, point.Y);
            }
            //else
            //    MessageBox.Show("Для вывода информации о статике использовать правую кнопку мыши");
        }

        private void TxtBx_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.txtBx.Hide();
        }


    }
}
