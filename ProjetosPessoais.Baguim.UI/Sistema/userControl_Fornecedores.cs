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
    public partial class userControl_Fornecedores : userControl_Container
    {
        public userControl_Fornecedores()
        {
            InitializeComponent();
        }

        public new string NomeCompleto => "Cadastro de Fornecedores";
        public new string NomeReduzido => "Fornecedores";
    }
}
