using CsvHelper.Configuration;
using ERMPower_Test.FileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMPower_Test.FieldMapping
{
  public class TOUFileMapping : CsvClassMap<TOUFileType>
  {
    private const string MeterPointCode = "MeterPoint Code";
    private const string SerialNumber = "Serial Number";
    private const string PlantCode = "Plant Code";
    private const string DateTime = "Date/Time";
    private const string DataType = "Data Type";
    private const string Energy = "Energy";
    private const string MaximumDemand = "Maximum Demand";
    private const string TimeOfMaxDemand = "Time of Max Demand";
    private const string Units = "Units";
    private const string Status = "Status";
    private const string Period = "Period";
    private const string DLSActive = "DLS Active";
    private const string BillingResetCount = "Billing Reset Count";
    private const string BillingResetDateTime = "Billing Reset Date/Time";
    private const string Rate = "Rate";

    public TOUFileMapping()
    {
      Map(m => m.MeterPointCode).Name(MeterPointCode);
      Map(m => m.SerialNumber).Name(SerialNumber);
      Map(m => m.PlantCode).Name(PlantCode);
      Map(m => m.DateTime).Name(DateTime);
      Map(m => m.DataType).Name(DataType);
      Map(m => m.Energy).Name(Energy);
      Map(m => m.MaximumDemand).Name(MaximumDemand);
      Map(m => m.TimeOfMaxDemand).Name(TimeOfMaxDemand);
      Map(m => m.Units).Name(Units);
      Map(m => m.Status).Name(Status);
      Map(m => m.Period).Name(Period);
      Map(m => m.DLSActive).Name(DLSActive);
      Map(m => m.BillingResetCount).Name(BillingResetCount);
      Map(m => m.BillingResetDateTime).Name(BillingResetDateTime);
      Map(m => m.Rate).Name(Rate);
    }
  }
}
