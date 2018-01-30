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
using ProjetosPessoais.Baguim.UI.WindowsUtil;

namespace ProjetosPessoais.Baguim.UI.Modelos
{
    public partial class userControl_Container : UserControl, INomeAba
    {
        private IEnumerable<Button> listaDeBotoes;
        public userControl_Container()
        {
            InitializeComponent();
            listaDeBotoes = panel_Botoes.FindAllChildrenByType<Button>();
            Configura_Posicao_Botoes_Atividade();
        }

        private void Configura_Posicao_Botoes_Atividade()
        {
            Aplicar_Espacamento_Panel_Botoes();
            foreach (var botao in listaDeBotoes)
                botao.VisibleChanged += (sender, EventArgs) => Aplicar_Espacamento_Panel_Botoes();

            panel_Principal.SizeChanged += (sender, EventArgs) => Aplicar_Espacamento_Panel_Botoes();
        }

        private void Aplicar_Espacamento_Panel_Botoes() =>
            panel_Botoes_Espacamento_Esquerda.Width = panel_Botoes_Espacamento_Direita.Width = (panel_Botoes_Principal.Width - listaDeBotoes.Where(botoes => botoes.Visible == true).Sum(botoes => botoes.Width)) / 2;

        public virtual string NomeCompleto => "Default";
        public virtual string NomeReduzido => "Default";
    }
}
