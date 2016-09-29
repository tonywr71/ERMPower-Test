using ERMPower_Test.Application;
using ERMPower_Test.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMPower_Test
{
  class ErmController
  {
    private FileProcessor _fileProcessor;
    private IView _view;
    public ErmController(FileProcessor fileProcessor, IView view)
    {
      this._fileProcessor = fileProcessor;
      this._view = view;
    }

    internal void ProcessFiles(string folderName)
    {
      foreach (var fileName in Directory.EnumerateFiles(folderName))
      {
        this._fileProcessor.ProcessFile(fileName, this._view);
      }
    }
  }
}
