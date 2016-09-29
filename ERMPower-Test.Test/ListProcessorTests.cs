using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERMPower_Test.Application;
using ERMPower_Test.FileTypes;

namespace ERMPower_Test.Test
{
  [TestClass]
  public class ListProcessorTests
  {
    [TestMethod]
    public void WhenAFileOnlyHasOneRecordThenTheCalculatedValueIsTheMedian()
    {
      //arrange
      var theList = new System.Collections.Generic.List<ICsvRecord>();
      theList.Add(new TOUFileType() { DateTime = "11/09/2015 00:41:02", Energy = "409646.700000" });
      var listProcessor = new ListProcessor();
      listProcessor.theList = theList;

      //act
      var actual = listProcessor.GetMedianValue();

      //assert
      Assert.AreEqual(409646.700000M, actual);

    }
  }
}
