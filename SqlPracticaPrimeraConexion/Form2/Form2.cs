﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Form2
{
    public partial class Form2 : Form
    {
        private List<Elemento> listaElemento;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ElementoNegocio conect = new ElementoNegocio();
            listaElemento = conect.listar();
            dgvpoket2.DataSource = listaElemento;
        }
    }
}
