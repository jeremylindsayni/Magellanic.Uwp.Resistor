using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Magellanic.Uwp.Resistor.Models
{
    public class Resistor
    {
        private ValueBand _firstBand;
        private ValueBand _secondBand;
        private ValueBand _thirdBand;
        private ToleranceBand _toleranceBand;

        public Resistor()
        {
            _firstBand = new ValueBand { BandNumber = 1 };
            _secondBand = new ValueBand { BandNumber = 2 };
            _thirdBand = new ValueBand { BandNumber = 3 };
            _toleranceBand = new ToleranceBand();

            Bands = new List<AbstractBand> { _firstBand, _secondBand, _thirdBand, _toleranceBand };
        }

        public IEnumerable<AbstractBand> Bands { get; set; }

        public ToleranceBand Tolerance
        {
            get
            {
                return (ToleranceBand)Bands?.Single(m => m is ToleranceBand);
            }
            private set
            {
                _toleranceBand = value;
            }
        }

        public ValueBand FirstBand
        {
            get
            {
                return GetBandByNumber(1);
            }
            private set
            {
                _firstBand = value;
            }
        }

        public ValueBand SecondBand
        {
            get
            {
                return GetBandByNumber(2);
            }
            private set
            {
                _secondBand = value;
            }
        }

        public ValueBand ThirdBand
        {
            get
            {
                return GetBandByNumber(3);
            }
            private set
            {
                _thirdBand = value;
            }
        }

        public string Value
        {
            get
            {
                double resistorValue = (10 * FirstBand.BandValue.Value + SecondBand.BandValue.Value) * Math.Pow(10, ThirdBand.BandValue.Value);

                string resistorString;
                if (resistorValue > 1000000)
                {
                    resistorValue = resistorValue / 1000000;
                    resistorString = resistorValue.ToString(CultureInfo.InvariantCulture);
                    if (resistorString.Contains("."))
                    {
                        resistorString = resistorString.Replace(".", "M");
                    }
                    else
                    {
                        resistorString = resistorString + "M";
                    }
                }
                else if (resistorValue > 1000)
                {
                    resistorValue = resistorValue / 1000;
                    resistorString = resistorValue.ToString(CultureInfo.InvariantCulture);
                    if (resistorString.Contains("."))
                    {
                        resistorString = resistorString.Replace(".", "K");
                    }
                    else
                    {
                        resistorString = resistorString + "K";
                    }
                }
                else
                {
                    resistorString = resistorValue + "Ω";
                }

                return resistorString + " (±" + Tolerance.BandValue + "%)";
            }
        }

        public void Reset()
        {
            _firstBand.BandValue = null;
            _secondBand.BandValue = null;
            _thirdBand.BandValue = null;
            _toleranceBand.BandValue = null;
        }

        private ValueBand GetBandByNumber(int bandNumber)
        {
            return (ValueBand)Bands?.Where(m => m is ValueBand).SingleOrDefault(m => ((ValueBand)m).BandNumber == bandNumber);
        }
    }
}