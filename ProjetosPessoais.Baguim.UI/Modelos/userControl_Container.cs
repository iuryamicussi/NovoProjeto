using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetosPessoais.Baguim.UI.Padroes;

namespace ProjetosPessoais.Baguim.UI.Modelos
{
    public partial class userControl_Container : UserControl, INomeAba
    {
        public userControl_Container()
        {
            InitializeComponent();
        }

        public virtual string NomeCompleto => "Default";
        public virtual string NomeReduzido => "Default";
    }
}
