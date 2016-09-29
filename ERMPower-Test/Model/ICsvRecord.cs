namespace ERMPower_Test.FileTypes
{
  public interface ICsvRecord
  {
    string CalculationValueString { get; }
    string DateTime { get; set; }

    decimal? CalculationValue { get; }
  }
}