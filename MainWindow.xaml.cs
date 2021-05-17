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

namespace Assignment4
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

        private bool ValidatePostalCode(string str)
        {
            // Postal code can be #####, #####-####, or A#B#C#
            // Test case for #####
            if (str.Length == 5)
            {
                bool success = Int32.TryParse(str, out var val);
                return success && val > 0;
            };

            // Test case for A#B#C#

            if (str.Length == 6)
            {
                for (var i = 0; i < 6; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (!Char.IsLetter(str[i]))
                        {
                            return false;
                        }
                    }
                    
                    else
                    {
                        if (!Char.IsNumber(str[i]))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            // Test case for #####-####

            if (str.Length == 10)
            {
                var code = str.Split('-');
                if (code.Length == 2)
                {
                    var first = Int32.TryParse(code[0], out var firstVal);
                    var second = Int32.TryParse(code[1], out var secondVal);
                    return first && second && firstVal > 0 && secondVal > 0;
                }

                return false;
            }

            return false;
        }
        private void uiTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var input = uiTextBox.Text.ToUpper();

            if (ValidatePostalCode(input))
            {
                uiSubmitBtn.IsEnabled = true;
            }

            else
            {
                uiSubmitBtn.IsEnabled = false;
            }
           
            uiTextBox.Text = input;
            uiTextBox.CaretIndex = input.Length;
        }
    }
}
