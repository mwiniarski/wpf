using Calendar.Model;
using Calendar.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Day d = (Day)((StackPanel)sender).DataContext;
            DayViewModel mainVM = this.dayVM;

            if (e.OriginalSource is StackPanel)
            {
                EditWindow wnd = new EditWindow();
                EditViewModel editVM = wnd.editVM;
                bool? res = wnd.ShowDialog();
                if (res.HasValue && res.Value)
                {
                    mainVM.AddEventToDay(d, new CalendarEvent { Title = editVM.Title });
                }
            }
            else if (e.OriginalSource is TextBlock)
            {
                var t = (TextBlock)e.OriginalSource;
                if(t.Name != "date")
                {
                    CalendarEvent ce = (CalendarEvent)t.DataContext;
                    mainVM.EditEventOnDay(d, ce);
                }
            }
        }        
    }
}
