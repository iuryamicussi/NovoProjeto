using ProjetosPessoais.Baguim.UI.Padroes;
using ProjetosPessoais.Baguim.UI.Sistema;
using ProjetosPessoais.Baguim.UI.WindowsUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetosPessoais.Baguim.UI
{
    public partial class form_Principal : Form
    {
        private int numeroDeJanelas = 0;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public form_Principal()
        {
            InitializeComponent();
            Configurar_Layout();
        }

        private void Configurar_Layout()
        {
            var cores = new CoresPadroes();

            foreach (var control in panel_MenuLateral.Controls)
            {
                if(control is Button)
                {
                    var button = ((Button)control);
                    button.OnHover(button.BackColor, cores.Botoes[CorDo.OnHover],cores.Botoes[CorDo.OnHoverForeColor]);
                }
            }

            foreach (var control in panel_BarraSuperior.GetAll(new List<Type> {typeof(Label),typeof(PictureBox)}))
            {
                if (control is Label)
                {
                    var label = ((Label)control);
                    label.OnHover(cores.Labels[CorDo.Background], cores.Labels[CorDo.OnHover]);
                }
                else if(control is PictureBox)
                {
                    var pictureBox = ((PictureBox)control);
                    pictureBox.OnHover(pictureBox.BackColor, cores.Labels[CorDo.OnHover]);
                }
            }
        }

        private void label_MinimizarSistema_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel_BarraSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label_FecharSistema_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void minimizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label_MinimizarSistema_Click(sender, e);
        }

        private void label_Maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanela(typeof(userControl_Produtos));
        }

        private void AbrirJanela(Type controle)
        {
            
            var janelaJaEstaAberta = false;

            //Implementar Validações --
            foreach (var control in panel_Container.Controls)
            {
                if (control.GetType() == controle)
                {
                    janelaJaEstaAberta = true;
                    break;
                }
            }
            //-------------------------


            //Implementar Construção/Alteração na Guia de Tabs --
            if(!(janelaJaEstaAberta))
            {
                var novaAba = new Button();
                novaAba.Name = "aba_" + numeroDeJanelas++ ;
                novaAba.Dock = DockStyle.Left;
                //var lala = controle.GetProperty("NomeReduzido");
                novaAba.Text = controle.GetProperty("NomeReduzido").ToString();
                panel_BarraDeJanelas.Controls.Add(novaAba);
            }
            //-------------------------


            //Abrir Janela ------------
            if(!janelaJaEstaAberta)
                panel_Container.Controls.Add((Control)Activator.CreateInstance(controle));
            panel_Container.Controls[controle.Name].BringToFront();
            //-------------------------
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanela(typeof(userControl_Fornecedores));
        }
    }
}
