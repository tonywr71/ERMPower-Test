using CsvHelper;
using CsvHelper.Configuration;
using ERMPower_Test.FieldMapping;
using ERMPower_Test.FileTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMPower_Test.Application
{
  public class FileTypeToCsvRecordList<T1,T2> where T1: ICsvRecord where T2 : CsvClassMap<T1>
  {
    private StreamReader reader;
    public FileTypeToCsvRecordList(StreamReader reader)
    {
      this.reader = reader;
    }

    public List<ICsvRecord> GetRecordList()
    {
      var csvRecordList = new List<ICsvRecord>();

      var fileCsvReader = new CsvReader(this.reader);
      fileCsvReader.Configuration.RegisterClassMap<T2>();
      while (fileCsvReader.Read())
      {
        var currentRecord = fileCsvReader.GetRecord<T1>();
        csvRecordList.Add(currentRecord);
      }

      return csvRecordList;
    }

  }
}
