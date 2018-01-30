using ProjetosPessoais.Baguim.UI.Modelos;
using ProjetosPessoais.Baguim.UI.Padroes;
using ProjetosPessoais.Baguim.UI.Sistema;
using ProjetosPessoais.Baguim.UI.WindowsUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetosPessoais.Baguim.UI
{
    public partial class form_Principal : Form
    {
        private CoresPadroes cores = new CoresPadroes();

        public form_Principal()
        {
            InitializeComponent();
            Configurar_Layout();
        }

        private void Configurar_Layout()
        {
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

        private void label_MinimizarSistema_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void panel_BarraSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                NativeUtils.MovimentarForm(Handle);
        }

        private void label_FecharSistema_Click(object sender, EventArgs e) => Environment.Exit(0);

        private void minimizarToolStripMenuItem_Click(object sender, EventArgs e) => label_MinimizarSistema_Click(sender, e);

        private void label_Maximizar_Click(object sender, EventArgs e) =>
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;

        private void AbrirJanela(Type controle)
        {
            var janelaJaEstaAberta = false;

            foreach (var control in panel_Container.Controls)
            {
                if (control.GetType() == controle)
                {
                    janelaJaEstaAberta = true;
                    break;
                }
            }

            if(!janelaJaEstaAberta)
            {
                var novoContainer = (userControl_Container)Activator.CreateInstance(controle);
                panel_Container.Controls.Add(novoContainer);
                AbrirAba(novoContainer);
                novoContainer = null;
            }
            panel_Container.Controls[controle.Name].BringToFront();
        }

        private void AbrirAba(userControl_Container container)
        {
            //Botão da Aba----------------------------------------------
            var button_Aba = new Button();
            button_Aba.Name = container.Name;
            button_Aba.Dock = DockStyle.Left;
            button_Aba.FlatStyle = FlatStyle.Flat;
            button_Aba.AutoSize = true;
            button_Aba.MaximumSize = new Size(150, 40);
            button_Aba.MinimumSize = new Size(100, 25);
            button_Aba.Font = new Font("Segoe WP", 8f, FontStyle.Bold);
            button_Aba.Text = container.NomeReduzido;
            toolTip_Principal.SetToolTip(button_Aba, container.NomeCompleto);
            button_Aba.ForeColor = cores.Botoes[CorDo.OnHoverForeColor];
            button_Aba.OnHover(button_Aba.BackColor, cores.Botoes[CorDo.OnHover], cores.Botoes[CorDo.OnHoverForeColor]);
            button_Aba.Click += (sender, EvenArgs) => SelecionarJanela(container.Name);

            var contextMenuStrip_Aba = new ContextMenuStrip();
            contextMenuStrip_Aba.Items.Add("Fechar");
            contextMenuStrip_Aba.Items[0].Click += (sender, EventArgs) => FecharJanela(container.Name);
            button_Aba.ContextMenuStrip = contextMenuStrip_Aba;
            //----------------------------------------------------------

            //Botão de Fechar a Aba-------------------------------------
            var label_FecharAba = new Label();
            label_FecharAba.Name = container.Name;
            label_FecharAba.Top = button_Aba.Bounds.Top +2;
            label_FecharAba.Width = 11;
            label_FecharAba.Height = 11;
            label_FecharAba.FlatStyle = FlatStyle.Flat;
            label_FecharAba.Font = new Font("Segoe WP", 6f, FontStyle.Bold);
            label_FecharAba.TextAlign = ContentAlignment.TopRight;
            label_FecharAba.Text = "X";
            label_FecharAba.BackColor = button_Aba.BackColor;
            label_FecharAba.ForeColor = button_Aba.ForeColor;
            label_FecharAba.OnHover(label_FecharAba.BackColor, cores.Botoes[CorDo.OnHover], cores.Botoes[CorDo.OnHoverForeColor]);
            toolTip_Principal.SetToolTip(label_FecharAba, $"Fechar - {button_Aba.Text}");
            label_FecharAba.Click += (sender,EvenArgs) => FecharJanela(container.Name);
            button_Aba.Controls.Add(label_FecharAba);
            //----------------------------------------------------------

            panel_BarraDeJanelas.Controls.Add(button_Aba);
            label_FecharAba.Left = button_Aba.Width - 13;
            button_Aba = null;
            label_FecharAba = null;
        }

        private void SelecionarJanela(string container) => panel_Container.Controls[container].BringToFront();

        private void FecharJanela(string container)
        {
            //Validações ...
            //registro em edição,etc ..
            //--------------
            panel_Container.Controls[container].Dispose();
            panel_BarraDeJanelas.Controls[container].Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e) => AbrirJanela(typeof(userControl_Produtos));

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e) => AbrirJanela(typeof(userControl_Fornecedores));

        private void grupoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e) => AbrirJanela(typeof(userControl_Grupo_Produtos));
    }
}
