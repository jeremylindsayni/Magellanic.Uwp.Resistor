using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Magellanic.Uwp.Resistor
{
    public sealed partial class MainPage : Page
    {
        private Models.Resistor _resistor;

        public MainPage()
        {
            InitializeComponent();
            _resistor = new Models.Resistor();
            DisableToleranceButtons();
        }

        private void ColourBand(SolidColorBrush bandBrush, int bandValue)
        {
            if (_resistor.FirstBand.BandValue == null)
            {
                _resistor.FirstBand.BandValue = bandValue;

                // colour first band
                FirstBand.Fill.Opacity = 1;
                SecondBand.Fill.Opacity =
                ThirdBand.Fill.Opacity =
                FourthBand.Fill.Opacity = 0;

                FirstBand.Fill = bandBrush;
            }
            else if (_resistor.SecondBand.BandValue == null)
            {
                _resistor.SecondBand.BandValue = bandValue;

                // colour second band
                SecondBand.Fill.Opacity = 1;
                ThirdBand.Fill.Opacity =
                FourthBand.Fill.Opacity = 0;

                SecondBand.Fill = bandBrush;
            }
            else if (_resistor.ThirdBand.BandValue == null)
            {
                _resistor.ThirdBand.BandValue = bandValue;

                // colour third band
                ThirdBand.Fill.Opacity = 1;
                FourthBand.Fill.Opacity = 0;

                ThirdBand.Fill = bandBrush;

                // disable color buttons
                DisableColouredButtonStatus();

                // enable tolerance buttons
                EnableToleranceButtons();
            }
            else if (_resistor.Tolerance.BandValue == null)
            {
                _resistor.Tolerance.BandValue = bandValue;

                // colour tolerance band
                FourthBand.Fill.Opacity = 1;

                FourthBand.Fill = bandBrush;

                // disable color buttons
                DisableColouredButtonStatus();

                // disable tolerance buttons
                DisableToleranceButtons();

                ResistorValueText.Text = _resistor.Value;
            }
        }

        private void BlackButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.Black), 0);
        }

        private void BrownButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.Brown), 1);
        }

        private void RedButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.Red), 2);
        }

        private void OrangeButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.Orange), 3);
        }

        private void YellowButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.Yellow), 4);
        }

        private void GreenButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.Green), 5);
        }

        private void BlueButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.Blue), 6);
        }

        private void VioletButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.Purple), 7);
        }

        private void GrayButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.Gray), 8);
        }

        private void WhiteButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.White), 9);
        }

        private void GoldButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.Yellow), 5);

            DisableToleranceButtons();
        }

        private void SilverButtonClick(object sender, RoutedEventArgs e)
        {
            ColourBand(new SolidColorBrush(Colors.Silver), 10);

            DisableToleranceButtons();
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            _resistor.Reset();
            FirstBand.Fill.Opacity =
            SecondBand.Fill.Opacity =
            ThirdBand.Fill.Opacity =
            FourthBand.Fill.Opacity = 0;

            ResistorValueText.Text = string.Empty;

            EnableColouredButtonStatus();

            DisableToleranceButtons();
        }

        private void EnableToleranceButtons()
        {
            SetToleranceButtonStatus(true);
        }

        private void DisableToleranceButtons()
        {
            SetToleranceButtonStatus(false);
        }

        private void SetToleranceButtonStatus(bool isEnabled)
        {
            GoldButton.IsEnabled =
            SilverButton.IsEnabled = isEnabled;
        }

        private void EnableColouredButtonStatus()
        {
            SetColouredButtonStatus(true);
        }

        private void DisableColouredButtonStatus()
        {
            SetColouredButtonStatus(false);
        }

        private void SetColouredButtonStatus(bool isEnabled)
        {
            BlackButton.IsEnabled =
            BrownButton.IsEnabled =
            RedButton.IsEnabled =
            OrangeButton.IsEnabled =
            YellowButton.IsEnabled =
            GreenButton.IsEnabled =
            BlueButton.IsEnabled =
            VioletButton.IsEnabled =
            GrayButton.IsEnabled =
            WhiteButton.IsEnabled = isEnabled;
        }
    }
}
