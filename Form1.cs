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
                MessageBox.Show("Please paste the KiloWatts, Quantity, and Action headers listed in the ELE file","Do the needful!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtInput.Focus();
            }
            else
            {
                if (!txtInput.Text.Contains("Quantity") && txtInput.Text.Contains("KilloWatt") && txtInput.Text.Contains("Action")) // if it only contains KiloWatt and Action header
                {
                    if (txtInput.Text.IndexOf("Action") == 0)
                    {
                        txtInput.Text = txtInput.Text.TrimEnd();
                        int ikw = txtInput.Text.IndexOf("K") + 11;
                        int action = txtInput.Text.IndexOf("A") + 8;
                        string k = txtInput.Text.Substring(ikw, txtInput.Text.Length - ikw);
                        string a = txtInput.Text.Substring(action, txtInput.Text.IndexOf("K") - action - 2);
                        string[] k1 = k.Split('\r');
                        string[] a1 = a.Split('\r');
                        decimal[] dk1 = new decimal[k1.Length];
                        decimal tkw = 0;
                        bool isNumeric = true;
                        bool isCharacter = true;


                        // Trim the whitespace from array elements and convert to decimal
                        for (int i = 0; i < k1.Length; i++)
                        {
                            k1[i] = k1[i].Trim();
                            if (k1[i] != "")
                            {
                                if (decimal.TryParse(k1[i], out decimal _)) // Check for NaN
                                {
                                    dk1[i] = Convert.ToDecimal(k1[i]);
                                }
                                else
                                {
                                    MessageBox.Show("Detected a non-number under the Kilowatt header. Please make sure that all characters are numbers below the kilowatt header.", "Check yourself before you wreck yourself", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    isNumeric = false;
                                    i = k1.Length; // stop loop
                                    txtInput.Focus();
                                }

                            }

                        }

                        // Trim the whitespace from Action array
                        for (int i = 0; i < a1.Length; i++)
                        {
                            a1[i] = a1[i].Trim();
                            if (a1[i] != "")
                            {
                                if (!a1[i].Equals("Remove"))
                                {

                                    if (!a1[i].Equals("Install"))
                                    {
                                        MessageBox.Show("Could not detect Install or Remove under Action header. Please make sure that all characters are correct below the headers.", "Doh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        isCharacter = false;
                                        i = a1.Length; // stop loop
                                    }

                                }


                            }

                        }
                        // Calculate total KW with quantity assumption of 1
                        if (isNumeric && isCharacter)
                        {
                            if (a1.Length == dk1.Length) // Check to make sure both arrays are equal length
                            {
                                for (int i = 0; i < dk1.Length; i++)
                                {
                                    if (a1[i].Equals("Install"))
                                    {
                                        tkw += dk1[i] * 1;
                                    }
                                    else if (a1[i].Equals("Remove"))
                                    {
                                        tkw -= dk1[i] * 1;
                                    }
                                }
                                // Calculate using site formula
                                decimal kw = tkw / 2;
                                decimal sqft = kw * 50 / 3;

                                // Convert negative numbers to positive numbers if needed
                                if (kw < 0 || sqft < 0)
                                {
                                    kw = Math.Abs(kw);
                                    sqft = Math.Abs(sqft);
                                    txtOutput.Text = "*******Net Negative.*******\n\r\n\r\n\rWarning: Quantity is missing. Assuming quantity of 1\r\n\r\nSized at " + Convert.ToString(kw) + " kw and " + Convert.ToString(Math.Round(sqft, 1)) + " sqft.";
                                }
                                else
                                {
                                    txtOutput.Text = "Warning: Quantity is missing. Assuming quantity of 1\r\n\r\nSized at " + Convert.ToString(kw) + " kw and " + Convert.ToString(Math.Round(sqft, 1)) + " sqft.";
                                }
                            }
                            else
                            {
                                MessageBox.Show("It appears that the amount header line items doesn't match. The amount of line items for Quantity, KiloWatts and Action should always match each other.", "Mistakes were made", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtInput.Focus();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("The column headers appear to be out of order. Please make sure Action is first and Quantity is second (Optional) and Kilowatt is third.","It's okay, humans make mistakes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    



                    
                }
                else
                {
                    if (!txtInput.Text.Contains("KilloWatt"))
                    {
                        MessageBox.Show("Kilowatt header is required. Please paste the Kilowatt field from the ELE file into the textbox.","Danger Will Robinson!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int index1 = txtInput.Text.IndexOf("A");
                        int index2 = txtInput.Text.IndexOf("n");
                        int index3 = txtInput.Text.IndexOf("Q");
                        int index4 = txtInput.Text.IndexOf("y");
                        int index5 = txtInput.Text.IndexOf("K");

                        if (!txtInput.Text.Contains("Quantity") && !txtInput.Text.Contains("KiloWatt") && !txtInput.Text.Contains("Action")) // If it doesn't contain any headers
                        {
                            MessageBox.Show("Couldn't find the column headers. Please include at least the KiloWatt header and Action header (Quantity is optional if not listed in ELE)", "Welp!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtInput.Focus();
                        }
                        else
                        {
                            if (txtInput.Text.IndexOf("Action") != 0) // check to make sure Action is first array element in textbox
                            {
                                MessageBox.Show("The column headers appear to be out of order. Please make sure Action is first and Quantity is second (Optional) and Kilowatt is third.", "It's okay, humans make mistakes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtInput.Focus();
                            }
                            else
                            {
                                if (txtInput.Text.Contains("Quantity") && !txtInput.Text.Contains("KilloWatt") && txtInput.Text.Contains("Action"))
                                {
                                    MessageBox.Show("KiloWatt header is required. Please paste the KiloWatt field from the ELE file into the textbox.", "Danger Will Robinson!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    txtInput.Text = txtInput.Text.TrimEnd();
                                    int ikw = index5 + 11;
                                    string q = txtInput.Text.Substring(index4 + 3, index5 - index4 - 5);
                                    string k = txtInput.Text.Substring(ikw, txtInput.Text.Length - ikw);
                                    string a = txtInput.Text.Substring(index2 + 3, index3 - index2 - 5);
                                    string[] q1 = q.Split('\r');
                                    string[] k1 = k.Split('\r');
                                    string[] a1 = a.Split('\r');
                                    int[] iq1 = new int[q1.Length];
                                    decimal[] dk1 = new decimal[k1.Length];
                                    decimal tkw = 0;
                                    bool isNumeric = true;
                                    bool isCharacter = true;

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
                                                MessageBox.Show("Detected a non-number under the Quantity header. Please make sure that all characters are numbers below the quantity header.", "You did a oopsie!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                isNumeric = false;
                                                i = q1.Length; // stop loop
                                                txtInput.Focus();
                                            }
                                        }
                                    }

                                    // Trim the whitespace from array elements and convert to decimal
                                    for (int i = 0; i < k1.Length; i++)
                                    {
                                        k1[i] = k1[i].Trim();
                                        if (k1[i] != "")
                                        {
                                            if (decimal.TryParse(k1[i], out decimal _)) // Check for NaN
                                            {
                                                dk1[i] = Convert.ToDecimal(k1[i]);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Detected a non-number under the KiloWatt header. Please make sure that all characters are numbers below the Kilowatt header.", "Oopsie daisy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                isNumeric = false;
                                                i = k1.Length; // stop loop
                                                txtInput.Focus();
                                            }

                                        }
                                    }

                                    // Trim the whitespace from array Action
                                    for (int i = 0; i < a1.Length; i++)
                                    {
                                        a1[i] = a1[i].Trim();
                                        if (!a1[i].Equals("Remove"))
                                        {

                                            if (!a1[i].Equals("Install"))
                                            {
                                                MessageBox.Show("Could not detect Install or Remove under Action header. Please make sure that all characters are correct below the headers.", "Doh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                isCharacter = false;
                                                i = a1.Length; // stop loop
                                            }

                                        }
                                    }

                                    if (isNumeric && isCharacter)
                                    {
                                        if (iq1.Length == dk1.Length && iq1.Length == a1.Length && dk1.Length == a1.Length) // Make sure all arrays are equal length
                                        {
                                            // Calculate total KW
                                            for (int i = 0; i < iq1.Length; i++)
                                            {
                                                if (a1[i].Equals("Install"))
                                                {
                                                    tkw += iq1[i] * dk1[i];
                                                }
                                                if (a1[i].Equals("Remove"))
                                                {
                                                    tkw -= iq1[i] * dk1[i];
                                                }

                                            }

                                            // Calculate using site formula
                                            decimal kw = tkw / 2;
                                            decimal sqft = kw * 50 / 3;

                                            // Convert negative numbers to positive numbers if needed
                                            if (kw < 0 || sqft < 0)
                                            {
                                                kw = Math.Abs(kw);
                                                sqft = Math.Abs(sqft);
                                                txtOutput.Text = "*******Net Negative.*******\n\r\n\r\n\rSized at " + Convert.ToString(kw) + " kw and " + Convert.ToString(Math.Round(sqft, 1)) + " sqft.";
                                            }
                                            else
                                            {
                                                txtOutput.Text = "Sized at " + Convert.ToString(kw) + " kw and " + Convert.ToString(Math.Round(sqft, 1)) + " sqft.";
                                            }


                                        }
                                        else
                                        {
                                            MessageBox.Show("It appears that the amount header line items doesn't match. The amount of line items for Quantity, KiloWatts and Action should always match each other.", "Mistakes were made", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            txtInput.Focus();
                                        }

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
            }
            else
            {
                btnClear.Enabled = false;
                txtOutput.Text = "";
            }
        }
    }
}
        
    

