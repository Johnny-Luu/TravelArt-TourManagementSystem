using System;
using System.Windows.Forms;

namespace FunctionLibrary
{
    public static class AddingHotel
            {
                public static bool isAddAble(string name, string price, string address, string phone ,string province)
                    
                {
                    if (name == "" || price == "" || address == "" || phone == "" || province== "")
                    {
                        MessageBox.Show("Please fill all fields");
                        return false;
                    }
                    if (name.Length<1 || name.Length>100)
                    {
                        MessageBox.Show("Please enter Hotel Name from 1 to 100 character ");
                        return false;
                    }

                    if (!long.TryParse(price, out long slotNumber))
                    {
                        MessageBox.Show("Price much be a number ");
                        return false;
                    }
                    if (price.Length<4 || price.Length>9)
                    {
                        MessageBox.Show("Please enter price Minimum 1.000 to  999.999.999");
                        return false;
                    }
                    if (address.Length<5 )
                    {
                        MessageBox.Show("Please enter address more or equal to 5 character");
                        return false;
                    }
                    return true;
                }
            }
    }
