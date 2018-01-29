using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetosPessoais.Baguim.UI.WindowsUtil
{
    public static class ExtensionUtils
    {
        public static void OnHover(this object self, Color corNomal, Color corOnHover)
        {   
            if (self is Label)
            {
                ((Label)self).MouseEnter += (sender,EventArgs) => Label_MouseEnter(sender,EventArgs,corOnHover);
                ((Label)self).MouseLeave += (sender,EventArgs) => Label_MouseLeave(sender,EventArgs,corNomal);
            }
        }

        private static void Label_MouseLeave(object sender, EventArgs e,Color corNomal)
        {
            ((Label)sender).BackColor = corNomal;
        }

        private static void Label_MouseEnter(object sender, EventArgs e,Color corOnHover)
        {
            ((Label)sender).BackColor = corOnHover;
        }
    }


}
