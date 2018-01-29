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
        public static void OnHover<T>(this T self, Color corNomal, Color corOnHover, Color? corForeColorOnHover = null) where T : Control
        {   
            self.MouseEnter += (sender,EventArgs) => Control_MouseEnter(sender,EventArgs,corOnHover,corForeColorOnHover);
            self.MouseLeave += (sender,EventArgs) => Control_MouseLeave(sender,EventArgs,corNomal);
        }

        private static void Control_MouseLeave(object sender, EventArgs e,Color corNomal)
        {
            ((Control)sender).BackColor = corNomal;
        }

        private static void Control_MouseEnter(object sender, EventArgs e,Color corOnHover,Color? corForeColorOnHover = null)
        {
            ((Control)sender).BackColor = corOnHover;
            if(!(corForeColorOnHover==null))
                ((Control)sender).ForeColor = (Color)corForeColorOnHover;
        }

        public static IEnumerable<T> FindAllChildrenByType<T>(this Control control)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls
                .OfType<T>()
                .Concat<T>(controls.SelectMany<Control, T>(ctrl => FindAllChildrenByType<T>(ctrl)));
        }

        public static IEnumerable<Control> GetAll(this Control control, IEnumerable<Type> filteringTypes)
        {
            var ctrls = control.Controls.Cast<Control>();

            return ctrls.SelectMany(ctrl => GetAll(ctrl, filteringTypes))
                        .Concat(ctrls)
                        .Where(ctl => filteringTypes.Any(t => ctl.GetType() == t));
        }
    }


}
