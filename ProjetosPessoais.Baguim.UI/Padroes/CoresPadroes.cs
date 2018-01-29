using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosPessoais.Baguim.UI.Padroes
{
    public enum CorDo
    {
        Background, ForeColor, OnHover, OnHoverForeColor
    }
    public class CoresPadroes
    {
        private Dictionary<CorDo, Color> botoes = new Dictionary<CorDo, Color>();
        private Dictionary<CorDo, Color> labels = new Dictionary<CorDo, Color>();

        public Dictionary<CorDo, Color> Botoes => botoes;
        public Dictionary<CorDo, Color> Labels => labels;

        public CoresPadroes()
        {
            //Botões --------
           // botoes.Add(CorDo.Background, ColorTranslator.FromHtml("#CB6B1A"));
            botoes.Add(CorDo.ForeColor, Color.LightGray);
            botoes.Add(CorDo.OnHover, Color.Gainsboro);
            botoes.Add(CorDo.OnHoverForeColor, ColorTranslator.FromHtml("#CB6B1A"));
            // ---------------

            //labels --------
            labels.Add(CorDo.Background, Color.DarkGray);
            labels.Add(CorDo.ForeColor, Color.Black);
            labels.Add(CorDo.OnHover, Color.Wheat);
            //----------------
        }
    }
}
