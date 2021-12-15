using System.Windows.Forms;

namespace FunctionLibrary
{
    public static class AddingDestination
    {
        public static bool isAddAble(string name, string description, string province,string idHotel,bool picture)
        {
            if(name == "" || description == "" || province == "" || idHotel == "")
            {
                MessageBox.Show("Please fill all fields");
                return false;
            }
            if (name.Length<1 || name.Length>100)
            {
                MessageBox.Show("Please enter Hotel Name from 1 to 100 character ");
                return false;
            }
            if (description.Length<10)
            {
                MessageBox.Show("Please enter Description longer or equal to 10 character ");
                return false;
            }
            if (picture == false)
            {
                MessageBox.Show("Please choose a picture");
                return false;
            }

            return true;
        }
    }
}