using Assignemnt2;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Assignment2
{
    public partial class MainGameWindow : Window
    {
        private int numberOfChances;
        private Dictionary<string, int> buttonColors;
        private Random random = new Random();
        private StackPanel redButtonsContainer;
        private StackPanel rowPanel;
        private Dictionary<string, int> selectedColors = new Dictionary<string, int>();
        public enum CustomColors
        {
            Purple = 1,
            Blue = 2,
            Red = 3,
            Green = 4,
            Brown = 5,
            Yellow = 6,
            White = 7,
            Orange = 8,
            Black=9
        }

        public MainGameWindow(int number)
        {
            InitializeComponent();
            numberOfChances = number;
            buttonColors = new Dictionary<string, int>();
            GenerateRedButtons(numberOfChances);
            GenerateColors();
        }

        private void GenerateColors()
        {
            for (int row = 0; row < numberOfChances; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    string buttonName = $"btn_{row}_{col}";
                    int colorValue = GetRandomColorValue();
                    buttonColors[buttonName] = colorValue;
                }
            }
        }

        private int GetRandomColorValue()
        {
            Array colors = Enum.GetValues(typeof(CustomColors));
            CustomColors randomColor = (CustomColors)colors.GetValue(random.Next(colors.Length));
            return (int)randomColor;
        }

        private SolidColorBrush GetColorBrushFromValue(int colorValue)
        {
            SolidColorBrush colorBrush;
            switch (colorValue)
            {
                case 1:
                    colorBrush = Brushes.Purple;
                    break;
                case 2:
                    colorBrush = Brushes.Blue;
                    break;
                case 3:
                    colorBrush = Brushes.Red;
                    break;
                case 4:
                    colorBrush = Brushes.Green;
                    break;
                case 5:
                    colorBrush = Brushes.Brown;
                    break;
                case 6:
                    colorBrush = Brushes.Yellow;
                    break;
                case 7:
                    colorBrush = Brushes.White;
                    break;
                case 8:
                    colorBrush = Brushes.Orange;
                    break;
                default:
                    colorBrush = Brushes.Black; 
                    break;
            }
            return colorBrush;
        }

        private void GenerateRedButtons(int numberOfChances)
        {
            
            redButtonsContainer = new StackPanel();
            redButtonsContainer.HorizontalAlignment = HorizontalAlignment.Left;
            redButtonsContainer.Margin = new Thickness(0, 10, 0, 0); 
            for (int row = 0; row < numberOfChances; row++)
            {
                rowPanel = new StackPanel();
                rowPanel.Orientation = Orientation.Horizontal;
                rowPanel.Margin = new Thickness(0, 0, 0, 5); 
                for (int col = 0; col < 9; col++)
                {
                    int currentRow = row;
                    Button redButton = new Button
                    {
                        Width = 50,
                        Height = 50,
                        Name = $"btn_{row}_{col}",
                        Content = col == 4 ? "⇉" : "", 
                        Background = System.Windows.Media.Brushes.Gray, 
                        Margin = new Thickness(5, 0, 0, 0), 
                    };
                    if (col == 4)
                    {
                        redButton.Click += (sender, e) =>
                        {
                            ShowColorsForCurrentRow(currentRow); 
                        };
                    }
                    else if (col >= 0 && col <= 3) 
                    {
                        redButton.Click += (sender, e) =>
                        {
                            ColorSelectionDialog colorDialog = new ColorSelectionDialog();
                            bool? dialogResult = colorDialog.ShowDialog();

                            CustomColors selectedColor = colorDialog.SelectedColor;
                            redButton.Background = GetColorBrushFromEnum(selectedColor);
                            selectedColors[redButton.Name] = (int)selectedColor;
                        };
                    }

                    rowPanel.Children.Add(redButton);
                }

                redButtonsContainer.Children.Add(rowPanel);
            }
            redButtonsContainer.Margin = new Thickness(0, 10, 0, 0); 
            Grid.SetRow(redButtonsContainer, 1);
            Grid.SetColumn(redButtonsContainer, 1);
            gameGrid.Children.Add(redButtonsContainer); 
        }
        private SolidColorBrush GetColorBrushFromEnum(CustomColors color)
        {
            SolidColorBrush colorBrush = Brushes.Black; 

            switch (color)
            {
                case CustomColors.Purple:
                    colorBrush = Brushes.Purple;
                    break;
                case CustomColors.Blue:
                    colorBrush = Brushes.Blue;
                    break;
                case CustomColors.Red:
                    colorBrush = Brushes.Red;
                    break;
                case CustomColors.Green:
                    colorBrush = Brushes.Green;
                    break;
                case CustomColors.Brown:
                    colorBrush = Brushes.Brown;
                    break;
                case CustomColors.Yellow:
                    colorBrush = Brushes.Yellow;
                    break;
                case CustomColors.White:
                    colorBrush = Brushes.White;
                    break;
                case CustomColors.Orange:
                    colorBrush = Brushes.Orange;
                    break;
                default:
                    colorBrush = Brushes.Black;
                    break;
            }

            return colorBrush;
        }

        private void ShowColorsForCurrentRow(int row)
        {
            if (row >= 0 && row < buttonColors.Count)
            {
                for (int col = 0; col < 4; col++)
                {
                    string buttonName = $"btn_{row}_{col}";
                    Button button = FindButtonInContainer(buttonName, redButtonsContainer);

                    if (button != null)
                    {
                        if (buttonColors.ContainsKey(buttonName))
                        {
                            int colorValue1 = buttonColors[buttonName];
                            if(selectedColors.ContainsKey(buttonName))
                            {
                                int colorValue2= selectedColors[buttonName];
                                if (colorValue1 == colorValue2)
                                {
                                    string changed_button = $"btn_{row}_{col+5}";
                                    Button button2 = FindButtonInContainer(changed_button,                               redButtonsContainer);
                                    if(button2 != null)
                                    {
                                        SolidColorBrush colorBrush1 = GetColorBrushFromValue(colorValue2);
                                        button2.Background = GetColorBrushFromValue(7);
                                    }
                                }
                                else
                                {
                                    int changed_col = col + 5;
                                    string changed_button = $"btn_{row}_{changed_col}";
                                    Button button2 = FindButtonInContainer(changed_button, redButtonsContainer);
                                    if (button2 != null)
                                    {
                                        button2.Background = GetColorBrushFromValue(9);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private Button? FindButtonInContainer(string buttonName, StackPanel container)
        {
            foreach (var child in container.Children)
            {
                if (child is StackPanel rowPanel)
                {
                    foreach (var rowChild in rowPanel.Children)
                    {
                        if (rowChild is Button button && button.Name == buttonName)
                        {
                            return button;
                        }
                    }
                }
            }

            return null; 
        }


        private SolidColorBrush GetColorFromValue(int colorValue)
        {
            SolidColorBrush colorBrush = Brushes.Black; 

            switch ((CustomColors)colorValue)
            {
                case CustomColors.Purple:
                    colorBrush = Brushes.Purple;
                    break;
                case CustomColors.Blue:
                    colorBrush = Brushes.Blue;
                    break;
                case CustomColors.Red:
                    colorBrush = Brushes.Red;
                    break;
                case CustomColors.Green:
                    colorBrush = Brushes.Green;
                    break;
                case CustomColors.Brown:
                    colorBrush = Brushes.Brown;
                    break;
                case CustomColors.Yellow:
                    colorBrush = Brushes.Yellow;
                    break;
                case CustomColors.White:
                    colorBrush = Brushes.White;
                    break;
                case CustomColors.Orange:
                    colorBrush = Brushes.Orange;
                    break;
                case CustomColors.Black:
                    colorBrush = Brushes.Black;
                    break;
                default:
                    colorBrush = Brushes.Black; 
                    break;
            }

            return colorBrush;
        }

    }
}
