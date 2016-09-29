using CsvHelper.Configuration;
using ERMPower_Test.FileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMPower_Test.FieldMapping
{
  public class LPFileMapping : CsvClassMap<LPFileType>
  {
    private const string MeterPointCode = "MeterPoint Code";
    private const string SerialNumber = "Serial Number";
    private const string PlantCode = "Plant Code";
    private const string DateTime = "Date/Time";
    private const string DataType = "Data Type";
    private const string DataValue = "Data Value";
    private const string Units = "Units";
    private const string Status = "Status";

    public LPFileMapping()
    {
      Map(m => m.MeterPointCode).Name(MeterPointCode);
      Map(m => m.SerialNumber).Name(SerialNumber);
      Map(m => m.PlantCode).Name(PlantCode);
      Map(m => m.DateTime).Name(DateTime);
      Map(m => m.DataType).Name(DataType);
      Map(m => m.DataValue).Name(DataValue);
      Map(m => m.Units).Name(Units);
      Map(m => m.Status).Name(Status);
    }
  }
}
