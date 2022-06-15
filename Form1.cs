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

        private void txtDoit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtInput.Text))
            {
                MessageBox.Show("Please paste the KiloWatts and Quantity listed in the ELE file");
                txtInput.Focus();
            }
            else
            {
                if (!txtInput.Text.Contains("Quantity") && txtInput.Text.Contains("KilloWatt")) // if it only contains KiloWatt header
                {
                    txtInput.Text = txtInput.Text.TrimEnd();
                    int ikw = txtInput.Text.IndexOf("K") + 11;
                    string k = txtInput.Text.Substring(ikw, txtInput.Text.Length - ikw);
                    string[] k1 = k.Split('\r');
                    decimal[] dk1 = new decimal[k1.Length];
                    decimal tkw = 0;
                    bool isNumeric = true;

                    // Trim the whitespace from array elements and convert to decimal
                    for (int i = 0; i < k1.Length; i++)
                    {
                        k1[i] = k1[i].Trim();
                        if (k1[i] != "")
                        {
                            if (decimal.TryParse(k1[i], out decimal _))
                            {
                                dk1[i] = Convert.ToDecimal(k1[i]);
                            }
                            else
                            {
                                MessageBox.Show("Detected a non-number in the textbox. Please make sure that all characters are numbers below the headers.");
                                isNumeric = false;
                                i = k1.Length; // stop loop
                                txtInput.Focus();
                            }

                        }
                            
                    }

                

                    // Calculate total KW with quantity assumption of 1
                    if (isNumeric)
                    {
                        for (int i = 0; i < dk1.Length; i++)
                        {
                            tkw += dk1[i] * 1;
                        }

                        // Calculate using site formula
                        decimal kw = tkw / 2;
                        decimal sqft = kw * 50 / 3;

                        txtOutput.Text = "Warning: Quantity is missing. Assuming quantity of 1\r\n\r\nSized at " + Convert.ToString(kw) + " kw and " + Convert.ToString(Math.Round(sqft, 1)) + " sqft.";
                    }
                }
                else
                {
                    int index1 = txtInput.Text.IndexOf("Q");
                    int index2 = txtInput.Text.IndexOf("y");
                    int index3 = txtInput.Text.IndexOf("K");

                    if (!txtInput.Text.Contains("Quantity") && !txtInput.Text.Contains("KiloWatt")) // If it doesn't contain any headers
                    {
                        MessageBox.Show("Couldn't find the column headers. Please include at least the KiloWatt header (Quantity is optional if not listed in ELE)");
                        txtInput.Focus();
                    }
                    else
                    {
                        if (index1 != 0 && index2 != 9) // check for length of the word 'Quantity'
                        {
                            MessageBox.Show("The column headers appear to be out of order. Please make sure Quantity is first and KiloWatt is second.");
                            txtInput.Focus();
                        }
                        else
                        {
                            if (txtInput.Text.Contains("Quantity") && !txtInput.Text.Contains("KilloWatt"))
                            {
                                MessageBox.Show("KiloWatt header is required. Please paste the KiloWatt field from the ELE file into the textbox.");
                            }
                            else
                            {
                                txtInput.Text = txtInput.Text.TrimEnd();
                                int ikw = index3 + 11;
                                string q = txtInput.Text.Substring(index2 + 3, index3 - index2 - 5);
                                string k = txtInput.Text.Substring(ikw, txtInput.Text.Length - ikw);
                                string[] q1 = q.Split('\r');
                                string[] k1 = k.Split('\r');
                                int[] iq1 = new int[q1.Length];
                                decimal[] dk1 = new decimal[k1.Length];
                                decimal tkw = 0;
                                bool isNumeric = true;

                                // Trim the whitespace from array elements and convert to int32
                                for (int i = 0; i < q1.Length; i++)
                                {
                                    q1[i] = q1[i].Trim();
                                    if (q1[i] != "")
                                    {
                                        if (int.TryParse(q1[i], out int _))
                                        {
                                            iq1[i] = Convert.ToInt32(q1[i]);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Detected a non-number under the Quantity header. Please make sure that all characters are numbers below the headers.");
                                            isNumeric = false;
                                            i = q1.Length; // stop loop
                                            txtInput.Focus();
                                        }
                                    }               // Trim the whitespace from array elements and convert to decimal
                                }

                                for (int i = 0; i < k1.Length; i++)
                                {
                                    k1[i] = k1[i].Trim();
                                    if (k1[i] != "")
                                    {
                                        if (decimal.TryParse(k1[i], out decimal _))
                                        {
                                            dk1[i] = Convert.ToDecimal(k1[i]);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Detected a non-number under the KiloWatt header. Please make sure that all characters are numbers below the headers.");
                                            isNumeric = false;
                                            i = k1.Length; // stop loop
                                            txtInput.Focus();
                                        }

                                    }
                                }

                                if (isNumeric)
                                {
                                    if (iq1.Length == dk1.Length) // Make sure both arrays are equal in size
                                    {
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
                                    else
                                    {
                                        MessageBox.Show("It appears that the amount kilowatt line items doesn't match the amount of quantity items. The amount of line items for Quantity should always match the KiloWatts.");
                                        txtInput.Focus();
                                    }

                                }


                            }
                                    
                                
                            
                            

                           

                            
                            
                           
                        }
                        



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
                txtOutput.Text = "";
            }
            else
            {
                btnClear.Enabled = false;
            }
        }
    }
}
        
    

