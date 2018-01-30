using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetosPessoais.Baguim.UI.Modelos;

namespace ProjetosPessoais.Baguim.UI.Sistema
{
    public partial class userControl_Grupo_Produtos : userControl_Container
    {
        public userControl_Grupo_Produtos()
        {
            InitializeComponent();
            //button_Excluir.Visible = false;
            panel_Componentes.AutoScroll = true;
            panel_Componentes.Controls.Add(new Button() { Location = new Point(350, 1100),Text = "XABLAU" });
        }

        public override string NomeCompleto => "Cadastro de Grupos de Produtos";
        public override string NomeReduzido => "Grupos de Produtos";
    }
}
