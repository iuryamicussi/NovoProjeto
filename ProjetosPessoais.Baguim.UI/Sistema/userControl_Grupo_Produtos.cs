﻿using System;
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
        }

        public override string NomeCompleto => "Cadastro de Grupos de Produtos";
        public override string NomeReduzido => "Grupos de Produtos";
    }
}