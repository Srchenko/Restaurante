﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programa1
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Users\Seba\Downloads\Cafe.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}