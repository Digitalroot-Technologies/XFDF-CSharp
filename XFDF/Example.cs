public class Example
{
  public void Main()
  {
    var pdf = new Xfdf.Xfdf("http://www.example.com/myfile.pdf");
    
    // Get data from somewhere. Maybe a database.
    pdf.AddValue("Name", "Andy Smith");
    pdf.AddValue("Phone", "555-555-5555");
    pdf.AddValue("isMarried", "true");

    DisplayPdf(pdf.PrintToScreen());

    var data = pdf.GetXml();
    SaveToDatabase(data);
  }

  private void DisplayPdf(string printToScreen)
  {
    // send data to browser. 
  }

  private void SaveToDatabase(string data)
  {
    // DataSaved
  }
}
