using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Memória
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saírToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        List <int> xeirameafotos = new List <int>();
        int ordemdalistaxeirameafotosmatate=0;

        Random rnd = new Random();
        int marcador=1;
        int nomerofotos = 0;

        private async void criadeiradebotoes ()
        {
            marcador = 1;
            int nfotos = int.Parse (comboBox1.Text);
            nomerofotos = nfotos * (nfotos - 1) / 2;

            for (int i=0; i<nfotos; i++)
            {
                for (int k=0; k<nfotos-1; k++)
                {
                    Button butoooes = new Button();
                    butoooes.Size = new Size(110, 90);
                    butoooes.Location = new Point(i*110+35, k*110+30);
                    butoooes.Tag = ordemdalistaxeirameafotosmatate;
                    butoooes.BackgroundImageLayout= ImageLayout.Stretch; 
                    ordemdalistaxeirameafotosmatate++;

                    int x = 0;
                    while (true) 
                    { 
                        x= rnd.Next(1,nomerofotos+1);
                        if (xeirameafotos.Count(n=>n==x)!=2)
                        {
                            xeirameafotos.Add(x);
                            break;
                        }
                    }
                    if (x == 1) butoooes.BackgroundImage = Properties.Resources.india;
                    else if (x == 2) butoooes.BackgroundImage = Properties.Resources.chad_2;
                    else if (x == 3) butoooes.BackgroundImage = Properties.Resources.dhakla;
                    else if (x == 4) butoooes.BackgroundImage = Properties.Resources.nigeria;
                    else if (x == 5) butoooes.BackgroundImage = Properties.Resources.moscovo;
                    else if (x == 6) butoooes.BackgroundImage = Properties.Resources.mexico_2;
                    else if (x == 7) butoooes.BackgroundImage = Properties.Resources.mexico;
                    else if (x == 8) butoooes.BackgroundImage = Properties.Resources._911;
                    else if (x == 9) butoooes.BackgroundImage = Properties.Resources.texas;
                    else if (x == 10) butoooes.BackgroundImage = Properties.Resources.missouri;

                    butoooes.Click += new EventHandler(this.jogo);
                    Controls.Add(butoooes);
                }
            }
            await Task.Delay(2000);
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    control.BackgroundImage = null;
                }
            }

            marcador = 0;
        }

        private void jogarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label1.Visible)
            {
                comboBox1.Hide();
                label1.Hide();
                label2.Hide();
                criadeiradebotoes();
            }
            else
            {
                restart();
            }
         }

        int peter=0, griffin=0, louis=0;
        private async void jogo (object sender, EventArgs e)
        {
            if (marcador == 0)
            {
                marcador=1;
                Button btn = (Button)sender;

                griffin++;

                int x = xeirameafotos[(int)btn.Tag];

                if (x == 1) btn.BackgroundImage = Properties.Resources.india;
                else if (x == 2) btn.BackgroundImage =  Properties.Resources.chad_2;
                else if (x == 3) btn.BackgroundImage =  Properties.Resources.dhakla;
                else if (x == 4) btn.BackgroundImage =  Properties.Resources.nigeria;
                else if (x == 5) btn.BackgroundImage =  Properties.Resources.moscovo;
                else if (x == 6) btn.BackgroundImage =  Properties.Resources.mexico_2;
                else if (x == 7) btn.BackgroundImage =  Properties.Resources.mexico;
                else if (x == 8) btn.BackgroundImage =  Properties.Resources._911;
                else if (x == 9) btn.BackgroundImage =  Properties.Resources.texas;
                else if (x == 10) btn.BackgroundImage = Properties.Resources.missouri;

                if (griffin == 1)
                {
                    peter = (int)btn.Tag;
                }
                else if (griffin == 2)
                {
                    griffin = 0;
                    if (x == xeirameafotos[peter])
                    {
                        btn.Click -= new EventHandler(this.jogo);

                        foreach (Control control in Controls)
                        {
                            if (control.Tag != null && (int)control.Tag == peter)
                            {
                                control.Click -= new EventHandler(this.jogo);
                                break;
                            }
                        }
                        louis++;
                        if (louis == nomerofotos)
                        {
                            MessageBox.Show("Ganhou");
                            await Task.Delay(500);
                            restart();
                        }
                    }
                    else
                    {
                        await Task.Delay(400);
                        btn.BackgroundImage = null;

                        foreach (Control control in Controls)
                        {
                            if (control.Tag != null && (int)control.Tag == peter)
                            {
                                control.BackgroundImage = null;
                                break;
                            }
                        }
                    }
                    peter = 0;
                }
                marcador = 0;
            }
        }
        
        private void restart ()
        {
            List<Control> buttonsToRemove = new List<Control>();

            foreach (Control control in Controls)
            {
                if (control is Button)
                {
                    buttonsToRemove.Add(control);
                }
            }

            foreach (Control button in buttonsToRemove)
            {
                Controls.Remove(button);
            }

            label1.Show();
            label2.Show();
            comboBox1.Show();
            marcador = 1;
            peter = 0;
            griffin = 0;
            nomerofotos = 0;
            ordemdalistaxeirameafotosmatate = 0;
            xeirameafotos.Clear();
        }
    }
}
