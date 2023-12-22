using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practical7
{
    public partial class Validation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected Boolean isValidCard(string cardNumber) 
        {
            Boolean isValid = false;
            if(string.IsNullOrEmpty(cardNumber)==false) 
            {  
                
                if(Regex.IsMatch(cardNumber, "^4\\d{15}") && rblCardType.SelectedIndex == 0 )
                {
                    //Visa card
                    isValid = true;
                }
                else if(Regex.IsMatch(cardNumber, "^5\\d{15}") && rblCardType.SelectedIndex == 1 ) 
                { 
                    isValid = true; 
                }
            }
            else
            {
                lblMessage.Text = "You have entered the following <br>" +
                    "User name :" + txtName.Text + "<br>" +
                    "Password :" + txtPassword.Text + "<br>" +
                    "Date of birth:" + txtDOB.Text + "<br>" +
                    "Credit Card Number:" + txtCardNumber.Text ;

                Response.Write("<script>alert('your message here')</script>");
            }
            return isValid;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtDOB.Text = string.Empty; 
            txtCardNumber.Text = string.Empty;
            rblCardType.SelectedIndex = 0;  
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            revCreditCard.IsValid = false;
            if(isValidCard(txtCardNumber.Text) ==false)
            {
                if(rblCardType.SelectedIndex == 0) 
                {
                    //Visa
                    revCreditCard.ErrorMessage =
                        "Visa card numbers should start with a digit '4'.";
                }
                else
                {
                    //Master
                    revCreditCard.ErrorMessage = 
                        "Master card numbers should start with a digit '5'. ";
                }

            }
        }
    }
}