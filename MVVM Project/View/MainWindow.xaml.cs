using Calendar.Model;
using Calendar.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.FontSize = e.NewSize.Height * 0.035;
        }

        private void StackPanel_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Day d;
            if (e.OriginalSource is StackPanel)
            {
                var a = (StackPanel)e.OriginalSource;
                d = (Day)a.DataContext;
                Console.WriteLine(d.Date);
            }
            else
                return;

            DayViewModel o1 = this.dayVM;
            EditWindow wnd = new EditWindow();
            EditViewModel s = wnd.editVM;
            bool? res = wnd.ShowDialog();
            
            if (res.HasValue && res.Value)
            {
                Console.WriteLine("Tutaj");
                o1.AddEventToDay(d, new CalendarEvent { Title = s.Title });
            }
        }        

        private void ItemsControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
