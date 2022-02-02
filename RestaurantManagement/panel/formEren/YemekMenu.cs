﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace panel
{
    public partial class YemekMenu : Form
    {
        public YemekMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YemekMenuTatlilarcs tatlilar = new YemekMenuTatlilarcs();
            tatlilar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FoodShow foodShow = new FoodShow();
            foodShow.ShowDialog();
        }
    }
}
