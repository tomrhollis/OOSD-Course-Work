using CustomerData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class FrmAddCust : Form
    {
        public FrmAddCust()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // various validation
            // if OK, pass info back to the parent and close
            // if not ok wait for them to fix the issues
            if (Validator.IsPresent(txtCustName, "Customer Name") 
                && Validator.CSVFriendly(txtCustName, "Customer Name")
                && Validator.IsNonNegativeInt32(txtCustAcct, "Account Number") 
                && Validator.IsSelected(cmbCustType, "Customer Type"))
            {
                Object newCust;
                switch (cmbCustType.SelectedIndex)
                {
                    case 0:
                        newCust = new ResidentialCustomer(txtCustName.Text, Convert.ToInt32(txtCustAcct.Text));
                        break;
                    case 1:
                        newCust = new CommercialCustomer(txtCustName.Text, Convert.ToInt32(txtCustAcct.Text));
                        break;
                    case 2:
                        newCust = new IndustrialCustomer(txtCustName.Text, Convert.ToInt32(txtCustAcct.Text));
                        break;
                    default:
                        newCust = null;
                        break;
                }
                this.Tag = newCust;
                this.Close();
            }          

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Tag = null;
            this.Close();
        }

    }
}
