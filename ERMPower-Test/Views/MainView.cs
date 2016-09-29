using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMPower_Test.Views
{
  class MainView : IView
  {
    readonly TextWriter _writer;
    public MainView(TextWriter writer)
    {
      _writer = writer;
    }

    public void WriteLine(string value)
    {
      _writer.WriteLine(value);
    }
  }
}
