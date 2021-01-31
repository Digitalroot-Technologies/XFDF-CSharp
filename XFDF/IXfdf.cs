namespace Xfdf
{
  public interface IXfdf
  {
    /// <summary>
    /// This is the path to the PDF file that adobe will load.
    /// </summary>
    string PathToPdf { get; set; }

    /// <summary>
    /// This adds a field and value to the PDF. This is used to auto populate fields.
    /// </summary>
    /// <param name="field"></param>
    /// <param name="value"></param>
    void AddValue(string field, string value);

    /// <summary>
    /// Returns the content of the XFDF file with out headers. This can be used to store the data in a database.
    /// </summary>
    /// <returns></returns>
    string GetXml();

    /// <summary>
    /// Returns the content of the XFDF file with headers. This can be used to display to the browser.
    /// </summary>
    /// <returns></returns>
    string PrintToScreen();
  }
}
