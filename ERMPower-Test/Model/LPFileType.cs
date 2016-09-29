using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMPower_Test.FileTypes
{
  public class LPFileType : ICsvRecord
  {
    public string MeterPointCode { get; set; }
    public string SerialNumber { get; set; }
    public string PlantCode { get; set; }
    public string DateTime { get; set; }
    public string DataType { get; set; }
    public string DataValue { get; set; }
    public string Units { get; set; }
    public string Status { get; set; }

    public string CalculationValueString
    {
      get
      {
        return this.DataValue;
      }
    }

    public decimal? CalculationValue
    {
      get
      {
        decimal result;
        if (decimal.TryParse(this.DataValue, out result))
          return result;
        return result;
      }
    }
  }
}
