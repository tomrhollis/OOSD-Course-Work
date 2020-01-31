using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // for MessageBox

// originally by Jolanta W. Gruca during instruction at SAIT

namespace Lab1
{
    // repository of validation methods
    public static class Validator
    {
        public static bool IsPresent(TextBox tb, string name)
        {
            bool valid = true; // "innocent until proven guilty"
            if (tb.Text == "") // "bad dog"
            {
                valid = false;
                MessageBox.Show(name + " is required", "Input Error");
                tb.Focus();
            }             
            return valid;
        }

        public static bool IsInt32(TextBox tb, string name)
        {
            bool valid = true;
            int val;
            if(!Int32.TryParse(tb.Text, out val)) // not an int
            {
                valid = false;
                MessageBox.Show(name + " must be a whole number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        public static bool IsNonNegativeInt32(TextBox tb, string name)
        {
            bool valid = true;
            int val;
            if (!Int32.TryParse(tb.Text, out val)) // not an int
            {
                valid = false;
                MessageBox.Show(name + " must be a whole number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            else if(val < 0) // negetive
            {
                valid = false;
                MessageBox.Show(name + " must be positive or zero");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        public static bool IsDouble(TextBox tb, string name)
        {
            bool valid = true;
            double val;
            if (!Double.TryParse(tb.Text, out val)) // not a double value
            {
                valid = false;
                MessageBox.Show(name + " must be a number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        public static bool IsNonNegativeDouble(TextBox tb, string name)
        {
            bool valid = true;
            double val;
            if (!Double.TryParse(tb.Text, out val)) // not a double value
            {
                valid = false;
                MessageBox.Show(name + " must be a number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            else if (val < 0) // negetive
            {
                valid = false;
                MessageBox.Show(name + " must be positive or zero");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }


        public static bool IsDecimal(TextBox tb, string name)
        {
            bool valid = true;
            decimal val;
            if (!Decimal.TryParse(tb.Text, out val)) // not a double value
            {
                valid = false;
                MessageBox.Show(name + " must be a number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        public static bool IsNonNegativeDecimal(TextBox tb, string name)
        {
            bool valid = true;
            decimal val;
            if (!Decimal.TryParse(tb.Text, out val)) // not a double value
            {
                valid = false;
                MessageBox.Show(name + " must be a number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            else if (val < 0) // negetive
            {
                valid = false;
                MessageBox.Show(name + " must be positive or zero");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        public static bool IsSelected(ComboBox cb, string name)
        {
            bool valid = true;
            int status = cb.SelectedIndex;
            if (status == -1)
            {
                valid = false;
                MessageBox.Show(name + " must be selected");
                cb.Focus();
            }
            return valid;
        }

        public static bool IsSelected(ListBox lb, string name)
        {
            bool valid = true;
            int status = lb.SelectedIndex;
            if (status == -1)
            {
                valid = false;
                MessageBox.Show(name + " must have a member selected");
                lb.Focus();
            }
            return valid;
        }

        /// <summary>
        /// Test if there are any bad characters for CSV in a string.  Better to handle in other ways, but in this case out of time to learn those ways.
        /// This should eventually be replaced with better knowledge
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CSVFriendly(TextBox tb, string name)
        {
            bool valid = true;
            string input = tb.Text;

            if (input.Contains("\"") || input.Contains(","))
            {
                valid = false;
                MessageBox.Show(name + " cannot contain double quotes or commas");
                tb.Focus();
            }
            return valid;
        }
   
    } // end class
} // end namespace
