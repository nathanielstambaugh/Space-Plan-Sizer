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
            if (String.IsNullOrEmpty(txtInput.Text))
            {
                MessageBox.Show("Please paste the KiloWatts and Quantity listed in the ELE file");
                txtInput.Focus();
            }
            else
            {
                if (!txtInput.Text.Contains("Quantity") && !txtInput.Text.Contains("KiloWatt"))
                {
                    MessageBox.Show("Column headers are missing. Please paste the Quantity and KiloWatts field, including the headers, into the textbox");
                    txtInput.Focus();
                }
                else
                {
                    int index1 = txtInput.Text.IndexOf("Q");
                    int index2 = txtInput.Text.IndexOf("y");
                    int index3 = txtInput.Text.IndexOf("K");

                    if (index1 != 0 && index2 != 9)
                    {
                        MessageBox.Show("Please make sure that the column headers are in the right order: Quantity first and then KiloWatt second");
                        txtInput.Focus();
                    }
                    else
                    {
                        txtInput.Text = txtInput.Text.TrimEnd();
                        int ikw = index3 + 10;
                        string q = txtInput.Text.Substring(index2 + 3, index3 - index2 - 5);
                        string k = txtInput.Text.Substring(ikw, txtInput.Text.Length - ikw);
                        string[] q1 = q.Split('\r');
                        string[] k1 = k.Split('\r');
                        int[] iq1 = new int[q1.Length];
                        decimal[] dk1 = new decimal[k1.Length];
                        decimal tkw = 0;

                        // Trim the whitespace from array elements and convert to int32
                        for (int i = 0; i < q1.Length; i++)
                        {
                            q1[i] = q1[i].Trim();
                            if (q1[i] != "")
                            {
                                iq1[i] = Convert.ToInt32(q1[i]);
                            }
                        }

                        // Trim the whitespace from array elements and convert to decimal
                        for (int i = 0; i < k1.Length; i++)
                        {
                            k1[i] = k1[i].Trim();
                            if (k1[i] != "")
                            {
                                dk1[i] = Convert.ToDecimal(k1[i]);
                            }
                        }

                        // Calculate total KW
                        for (int i = 0; i < iq1.Length; i++)
                        {
                            tkw += iq1[i] * dk1[i];
                        }

                        // Calculate using site formula
                        decimal kw = tkw / 2;
                        decimal sqft = kw * 50 / 3;

                        txtOutput.Text = "Sized at " + Convert.ToString(kw) + " kw and " + Convert.ToString(Math.Round(sqft, 1)) + " sqft.";




                    }
                }



               


            }

        
                    }

        private void button1_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "";
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (txtInput.Text != "")
            {
                btnClear.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
            }
        }
    }
}
        
    

