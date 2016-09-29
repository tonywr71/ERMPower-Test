using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMPower_Test.FileTypes
{
  public class TOUFileType : ICsvRecord
  {
    public string MeterPointCode { get; set; }
    public string SerialNumber { get; set; }
    public string PlantCode { get; set; }
    public string DateTime { get; set; }
    public string DataType { get; set; }
    public string Energy { get; set; }
    public string MaximumDemand { get; set; }
    public string TimeOfMaxDemand { get; set; }
    public string Units { get; set; }
    public string Status { get; set; }
    public string Period { get; set; }
    public string DLSActive { get; set; }
    public string BillingResetCount { get; set; }
    public string BillingResetDateTime { get; set; }
    public string Rate { get; set; }

    public string CalculationValueString
    {
      get
      {
        return this.Energy;
      }
    }

    public decimal? CalculationValue
    {
      get
      {
        decimal result;
        if (decimal.TryParse(this.Energy, out result))
          return result;
        return result;
      }
    }

  }
}
