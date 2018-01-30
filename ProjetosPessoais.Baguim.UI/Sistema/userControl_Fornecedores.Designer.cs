namespace ProjetosPessoais.Baguim.UI.Sistema
{
    partial class userControl_Fornecedores
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Componentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_NomeTela
            // 
            this.label_NomeTela.Location = new System.Drawing.Point(906, 0);
            this.label_NomeTela.Size = new System.Drawing.Size(61, 13);
            this.label_NomeTela.Text = "Fornecedor";
            // 
            // panel_Componentes
            // 
            this.panel_Componentes.Controls.Add(this.label1);
            this.panel_Componentes.Size = new System.Drawing.Size(967, 724);
            this.panel_Componentes.Controls.SetChildIndex(this.label1, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 668);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SALAFRARIO";
            // 
            // userControl_Fornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "userControl_Fornecedores";
            this.Size = new System.Drawing.Size(967, 777);
            this.panel_Componentes.ResumeLayout(false);
            this.panel_Componentes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}
