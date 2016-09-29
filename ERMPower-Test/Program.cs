using Autofac;
using ERMPower_Test.Application;
using ERMPower_Test.Views;
using System;
using System.IO;

namespace ERMPower_Test
{
  class Program
  {
    static void Main(string[] args)
    {
      var listProcessor = new ListProcessor();
      var fileProcessor = new FileProcessor(listProcessor);

      var builder = new ContainerBuilder();
      builder.Register(c => new ErmController(c.Resolve<FileProcessor>(), c.Resolve<IView>()));
      builder.RegisterType<MainView>().As<IView>();
      builder.RegisterInstance(listProcessor).As<ListProcessor>();
      builder.RegisterInstance(fileProcessor).As<FileProcessor>();
      builder.RegisterInstance(Console.Out).As<TextWriter>().ExternallyOwned();

      var folderName = @"..\..\Sample Files";
      using (var container = builder.Build())
      {
        container.Resolve<ErmController>().ProcessFiles(folderName);
      }

      Console.ReadLine();
    }

  }
}
