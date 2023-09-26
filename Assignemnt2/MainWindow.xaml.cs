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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment2
{
    public partial class MainWindow : Window
    {
        private int numberOfChances = 4; 

        public MainWindow()
        {
            InitializeComponent();
            txtChances.PreviewKeyDown += txtChances_PreviewKeyDown;
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfChances >= 4)
            {
                MainGameWindow gameWindow = new MainGameWindow(numberOfChances);
                gameWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The number of chances cannot be less than 4.");
            }
        }



        private void txtChances_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (numberOfChances < 10)
                {
                    numberOfChances++;
                }
                else
                {
                    numberOfChances = 4; 
                }
                txtChances.Text = numberOfChances.ToString();
            }
            else if (e.Key == Key.Down)
            {
                if (numberOfChances > 4)
                {
                    numberOfChances--;
                    txtChances.Text = numberOfChances.ToString();
                }
            }
        }
    }

}
