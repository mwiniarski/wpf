using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calendar.View
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
            this.editVM.CloseAction = new Action(() =>
            {
                this.DialogResult = true;
                this.Close();
            });

            this.editVM.RemoveAction = new Action(() =>
            {
                this.DialogResult = true;
                this.editVM.Remove = true;
                this.Close();
            });
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int result;
            int maxVal;
            var tb = ((TextBox)sender);
            string s = tb.Text + e.Text;

            if (tb.Name == "hour")
                maxVal = 23;
            else
                maxVal = 59;

            if (!(int.TryParse(s, out result)) || result < 0 || result > maxVal)
            {
                e.Handled = true;
            }
        }
    }
}
