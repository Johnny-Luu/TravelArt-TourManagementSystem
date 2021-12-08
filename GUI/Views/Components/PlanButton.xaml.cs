using System.Windows.Controls;

namespace GUI.Views.Components
{
    public partial class PlanButton : UserControl
    {
        public int index;
        public PlanButton(int i)
        {
            index = i;
            InitializeComponent();
            
        }
    
    }
}