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
using static Assignment2.MainGameWindow;

namespace Assignemnt2
{
    public partial class ColorSelectionDialog : Window
    {
        public CustomColors SelectedColor { get; private set; }
        public ColorSelectionDialog()
        {
            InitializeComponent();
        }
        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            SolidColorBrush? colorBrush = button.Background as SolidColorBrush;
            if (colorBrush != null)
            {
                if (colorBrush.Color == Colors.Purple)
                {
                    SelectedColor = CustomColors.Purple;
                }
                else if (colorBrush.Color == Colors.Blue)
                {
                    SelectedColor = CustomColors.Blue;
                }
                else if (colorBrush.Color == Colors.Red)
                {
                    SelectedColor = CustomColors.Red;
                }
                else if (colorBrush.Color == Colors.Orange)
                {
                    SelectedColor = CustomColors.Orange;
                }
                else if (colorBrush.Color == Colors.Green)
                {
                    SelectedColor = CustomColors.Green;
                }
                else if (colorBrush.Color == Colors.Yellow)
                {
                    SelectedColor = CustomColors.Yellow;
                }
                else if (colorBrush.Color == Colors.White)
                {
                    SelectedColor = CustomColors.White;
                }
                else if (colorBrush.Color == Colors.Brown)
                {
                    SelectedColor = CustomColors.Brown;
                }
            }
            DialogResult = true;
        }
    }
}

