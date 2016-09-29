using ERMPower_Test.FileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMPower_Test.Application
{
  public class ListProcessor
  {
    public List<ICsvRecord> theList { set; private get; }

    public decimal? GetMedianValue()
    {
      decimal result;

      var lpListCount = this.theList.Count;
      if (lpListCount == 0)
      {
        return null;
      }
      else if (lpListCount == 1)
      {
        if (decimal.TryParse(this.theList[0].CalculationValueString, out result))
          return result;
        return null;
      }
      else
      {
        int middlePoint;
        if (lpListCount % 2 == 0) //even
        {
          middlePoint = lpListCount / 2 - 1; //starting point
          decimal firstValue;
          decimal secondValue;
          if (decimal.TryParse(this.theList[middlePoint].CalculationValueString, out firstValue)
            && decimal.TryParse(this.theList[middlePoint + 1].CalculationValueString, out secondValue))
          {
            result = (firstValue + secondValue) / 2;
            return result;
          }
          else
          {
            return null;
          }
        }
        else // odd
        {
          middlePoint = lpListCount / 2 + 1;
          if (decimal.TryParse(this.theList[middlePoint].CalculationValueString, out result))
          {
            return result;
          }
          return null;
        }
      }
    }

    public List<ICsvRecord> GetValues20PercentAboveMedian()
    {
      var medianValue = this.GetMedianValue();
      if (medianValue != null)
      {
        var over20PercentAbove = medianValue * 1.2M;

        var result = this.theList.Where(l => l.CalculationValue > over20PercentAbove).ToList();
        return result;
      }
      else
        return new List<ICsvRecord>();
    }

    public List<ICsvRecord> GetAbnormalValues()
    {
      var result = this.theList.Where(l => l.CalculationValue == null).ToList();
      return result;
    }



  }
}
