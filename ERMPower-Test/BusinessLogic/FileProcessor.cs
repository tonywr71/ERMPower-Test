using ERMPower_Test.FieldMapping;
using ERMPower_Test.FileTypes;
using ERMPower_Test.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMPower_Test.Application
{
  class FileProcessor
  {
    private const string CsvFileSuffix = ".csv";
    private const string LPFilePrefix = "LP_";
    private const string TOUFilePrefix = "TOU_";
    private const string OutputMessage = "File:{0} Median:{1}";
    private const string ErrorMessage = "Something went wrong";

    private ListProcessor listProcessor;
    //private IView view;
    public FileProcessor(ListProcessor listProcessor)
    {
      this.listProcessor = listProcessor;
    }

    public void ProcessFile(string fileName, IView view)
    {
      if (fileName.EndsWith(CsvFileSuffix))
      {
        using (var textReader = File.OpenText(fileName))
        {
          dynamic fileTypeToCsvRecordList = null;

          var shortFileName = Path.GetFileName(fileName);
          if (shortFileName.StartsWith(LPFilePrefix))
          {
            fileTypeToCsvRecordList = new FileTypeToCsvRecordList<LPFileType, LPFileMapping>(textReader);
          }
          else if (shortFileName.StartsWith(TOUFilePrefix))
          {
            fileTypeToCsvRecordList = new FileTypeToCsvRecordList<TOUFileType, TOUFileMapping>(textReader);
          }
          if (fileTypeToCsvRecordList != null)
          {
            var lpList = fileTypeToCsvRecordList.GetRecordList();

            this.listProcessor.theList = lpList;
            var medianValue = this.listProcessor.GetMedianValue();
            view.WriteLine(string.Format(OutputMessage, shortFileName, medianValue));
            var above20PercentValues = listProcessor.GetValues20PercentAboveMedian();
            if (above20PercentValues.Count > 0)
            {
              view.WriteLine("20% above median values:");
              foreach (var above20PercentValue in above20PercentValues)
              {
                view.WriteLine(string.Format("{0} {1} {2} {3}", shortFileName, above20PercentValue.DateTime, above20PercentValue.CalculationValueString, medianValue));
              }
            }
            var abnormalValues = listProcessor.GetAbnormalValues();
            if (abnormalValues.Count > 0)
            {
              view.WriteLine("Abnormal values");
              foreach (var value in abnormalValues)
              {
                view.WriteLine(string.Format("{0} {1} {2} {3}", shortFileName, value.DateTime, value.CalculationValueString, medianValue));
              }
            }
            view.WriteLine(string.Empty);
          }
          else
          {
            view.WriteLine(ErrorMessage);
          }

        }
      }

    }

  }
}
