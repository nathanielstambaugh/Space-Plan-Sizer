using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Plan_Sizer__.NET_4._8_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtKW_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDoit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTKW.Text))
            {
                MessageBox.Show("Please enter the KiloWatts listed in the ELE file");
                txtTKW.Focus();
            } else
            {
                decimal tkw = Convert.ToDecimal(txtTKW.Text);
                decimal kw = tkw / 2;
                decimal sqft = kw * 50 / 3;
                txtKW.Text = kw.ToString();
                txtSQFT.Text = Math.Round(sqft,1).ToString();
            }
            
        }

        private void txtTKW_TextChanged(object sender, EventArgs e)
        {
            if (txtTKW.Text.Trim() == "") return;
            for (int i = 0; i < txtTKW.Text.Length; i++)
            {
                if (!char.IsDigit(txtTKW.Text[i]) && txtTKW.Text[i] != '.')
                {
                    MessageBox.Show("Please enter a valid number");
                    txtTKW.Clear();
                }
            }
        }
    }
}
