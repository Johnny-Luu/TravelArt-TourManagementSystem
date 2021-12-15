using System;
using System.Windows.Forms;

namespace FunctionLibrary
{
    public static class AddingTour
    {
        public static bool isAddAble(string name, string price,string profit,string shortDescription,string deslist,bool img)
        { if(name == "" || price == "" || profit == "" || shortDescription == "")
            {
                MessageBox.Show("Please fill all fields");
                return false;
            }
            if (name.Length<1 || name.Length>100)
            {
                MessageBox.Show("Please enter Tour Name from 1 to 100 character ");
                return false;
            }

            long priceInt;
            long profitInt;
            if(!long.TryParse(price, out  priceInt) || !long.TryParse(profit, out  profitInt))
            {
                MessageBox.Show("Price and Profit must be number");
                return false;
            }
            
      
            if (price.Length<4 || price.Length>9)
            {
                MessageBox.Show("Please enter profit Minimum 1.000 to 999.999.999");
                return false;
            }
            if (profit.Length<4 || profit.Length>9)
            {
                MessageBox.Show("Please enter profit Minimum 1.000 to 999.999.999");
                return false;
            }
            if(priceInt<=profitInt)
            {
                MessageBox.Show("Price much be more than Profit");
                return false;
            }
            if (shortDescription.Length<10)
            {
                MessageBox.Show("Please enter Short Description Minimum 10 character");
                return false;
            }
            
            // check tour img has chosen or not
            if (img == false)
            {
                MessageBox.Show("Please choose a picture");
                return false;
            }
            // check destination chosen list has item or not
            if(deslist.Length == 0)
            {
                MessageBox.Show("Please choose destination");
                return false;
            }
            
            return true;
        }
    }
}