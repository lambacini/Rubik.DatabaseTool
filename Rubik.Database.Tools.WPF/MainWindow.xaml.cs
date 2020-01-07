using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Microsoft.Win32;

namespace Rubik.Database.Tools.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        Storyboard stopAnim;
        Storyboard startAnim;
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            stopAnim = (Storyboard)FindResource("StopAnim");
            startAnim = (Storyboard)FindResource("AnimStart");
        }
        
        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UcExportDb uc = new UcExportDb();
            uc.Margin = new Thickness(0, 0, 0, 0);
            border.Child = uc;
        }

        private void TreeViewItem_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog()
                                    {
                                        Filter =  "Rubik Database Schemas (*.rds)|*.rds"
                                    };
            if (of.ShowDialog().Value)
            {
                Objects.Database db = Utils.DeserializeDatabase(of.FileName);
                UcExportDb uc = new UcExportDb();
                uc.DatabaseSchema = db;
                uc.Margin = new Thickness(0, 0, 0, 0);
                border.Child = uc;
            }
        }

    }
}
