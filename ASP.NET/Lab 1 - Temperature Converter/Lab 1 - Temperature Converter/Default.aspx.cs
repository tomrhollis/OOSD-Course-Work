using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_1___Temperature_Converter
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Clear the fields and reset drop downs to default
        /// </summary>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblAnswer.Text = "";
            txtInput.Text = "";
            ddlFrom.SelectedValue = "C";
            ddlTo.SelectedValue = "F";
        }

        /// <summary>
        /// Decide what calculation we need to use, and display the result
        /// </summary>
        protected void btnCalc_Click(object sender, EventArgs e)
        {
            double input = Convert.ToDouble(txtInput.Text);   // the input temperature (relying on ASP.NET validation tags)
            double output = 0;                    // the result of the calculation
            string from = ddlFrom.SelectedValue;  // the character value of the first dropdown selection
            string to = ddlTo.SelectedValue;      // the character value of the second dropdown selection


            switch (from)
            {
                case "C":
                    switch (to)
                    {
                        case "F":
                            output = CtoF(input);
                            break;
                        case "K":
                            output = CtoK(input);
                            break;
                        case "C":   
                            output = input;
                            break;
                    }
                    break;
                case "F":
                    switch (to)
                    {
                        case "C":
                            output = FtoC(input);
                            break;
                        case "K":
                            output = FtoK(input);
                            break;
                        case "F":    
                            output = input;
                            break;
                    }
                    break;
                case "K":
                    switch (to)
                    {
                        case "F":
                            output = KtoF(input);
                            break;
                        case "C":
                            output = KtoC(input);
                            break;
                        case "K":  
                            output = input;
                            break;
                    }
                    break;

            }

            lblAnswer.Text = output.ToString("F");
            
        }



        /// <summary>
        /// convert celsius to kelvin
        /// </summary>
        /// <param name="temp">The temperature to convert, in Celsius</param>
        /// <returns>the temperature in kelvin</returns>
        private double CtoK(double temp)
        {
            return (temp + 273.15);
        }

        /// <summary>
        /// convert fahrenheit to kelvin
        /// </summary>
        /// <param name="temp">The temperature to convert, in fahrenheit</param>
        /// <returns>the temperature in kelvin</returns>
        private double FtoK(double temp)
        {
            //just use celsius as a middleman
            return CtoK(FtoC(temp));
        }

        /// <summary>
        /// convert kelvin to celsius
        /// </summary>
        /// <param name="temp">The temperature to convert, in kelvin</param>
        /// <returns>the temperature in celsius</returns>
        private double KtoC(double temp)
        {
            return (temp - 273.15);
        }

        /// <summary>
        /// convert kelvin to fahrenheit
        /// </summary>
        /// <param name="temp">The temperature to convert, in kelvin</param>
        /// <returns>the temperature in Fahrenheit</returns>
        private double KtoF(double temp)
        {
            //just use celsius as a middleman
            return CtoF(KtoC(temp));
        }

        /// <summary>
        /// convert celsius to fahrenheit
        /// </summary>
        /// <param name="temp">The temperature to convert, in Celsius</param>
        /// <returns>the temperature in Fahrenheit</returns>
        private double CtoF(double temp)
        {
            return ((temp * 9 / 5) + 32);
        }

        /// <summary>
        /// convert fahrenheit to celsius
        /// </summary>
        /// <param name="temp">The temperature to convert, in Fahrenheit</param>
        /// <returns>the temperature in Celsius</returns>
        private double FtoC(double temp)
        {
            return ((temp - 32) * 5 / 9);
        }
    }
}