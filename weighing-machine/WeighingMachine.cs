using System;
using System.Globalization;
class WeighingMachine
{
    private double _weight = 0;
    public int Precision { get ; private set; }
    public double Weight 
                        {   get{  return _weight; }
                            set{
                                    if(value >0) _weight = value;
                                    else throw new ArgumentOutOfRangeException();
                                } 
                          }
    public double TareAdjustment { get; set; } = 5;
    public WeighingMachine(int precision)
    {

    this.Precision = precision; 
    
    }
    public string DisplayWeight { get 
                                        {
                                            NumberFormatInfo setPrecision = new NumberFormatInfo();
                                            setPrecision.NumberDecimalDigits = Precision;
                                            return $"{(Weight - TareAdjustment).ToString("N", setPrecision)} kg"; 
                                        } 
                                }

}
