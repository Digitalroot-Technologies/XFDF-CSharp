using System;
using System.Text;

namespace Xfdf
{
  /// <summary>
  /// XFDF Class.
  /// This class definition is used to create PDF files using the XFDF format.
  /// </summary>
  public class Xfdf : IXfdf
  {
    /// <summary>
    /// This is the Content-Length Header that tells the browser how big the file is. IE will not open the file without this.
    /// </summary>
    private const string HeaderContentLength = "Content-Length: ";

    /// <summary>
    /// This is the Content-type Header that tells the browser what type of file this is.
    /// </summary>
    private readonly string _headerContentType = "Content-type: application/vnd.adobe.xfdf" + Environment.NewLine;

    /// <summary>
    /// This is the path to the PDF file that adobe will load.
    /// </summary>
    private string _pathToPdf;

    /// <summary>
    /// This holds the XML that the user passes with addValue.
    /// </summary>
    private string _xmlBody;

    /// <summary>
    /// This holds the XML that ends/closes the XFDF file.
    /// </summary>
    private string _xmlFooter;

    /// <summary>
    /// This holds the XML that starts the XFDF file.
    /// </summary>
    private string _xmlHeader;

    /// <summary>
    /// The Constructor
    /// </summary>
    /// <param name="pathToPdf">The path to the PDF file.</param>
    public Xfdf(string pathToPdf)
    {
      PathToPdf = pathToPdf;
      SetXmlFooter();
    }

    /// <summary>
    /// This is the path to the PDF file that adobe will load.
    /// </summary>
    public string PathToPdf
    {
      get { return _pathToPdf; }
      set
      {
        _pathToPdf = value;
        SetXmlHeader();
      }
    }

    /// <summary>
    /// This builds the XML Footer.
    /// </summary>
    private void SetXmlFooter()
    {
      _xmlFooter = new StringBuilder()
        .AppendLine("</fields>")
        .AppendLine("</xfdf>")
        .ToString();
    }

    /// <summary>
    /// This builds the XML header.
    /// </summary>
    private void SetXmlHeader()
    {
      _xmlHeader = new StringBuilder()
        .AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>")
        .AppendLine("<xfdf xmlns=\"http://ns.adobe.com/xfdf/\" xml:space=\"preserve\">")
        .Append("<f href=\"").Append(PathToPdf).AppendLine("\"/>")
        .AppendLine("<ids original=\"7A0631678ED475F0898815F0A818CFA1\" modified=\"BEF7724317B311718E8675B677EF9B4E\"/>")
        .AppendLine("<fields>")
        .ToString();
    }

    /// <summary>
    /// This adds a field and value to the PDF. This is used to auto populate fields.
    /// </summary>
    /// <param name="field"></param>
    /// <param name="value"></param>
    public void AddValue(string field, string value)
    {
      _xmlBody += new StringBuilder("<field name=\"")
        .Append(field)
        .AppendLine("\">")
        .Append("<value>")
        .Append(value)
        .AppendLine("</value>")
        .AppendLine("</field>")
        .ToString();
    }

    /// <summary>
    /// Returns the content of the XFDF file with out headers. This can be used to store the data in a database.
    /// </summary>
    /// <returns></returns>
    public string GetXml()
    {
      return _xmlHeader
             + _xmlBody
             + _xmlFooter;
    }

    /// <summary>
    /// Returns the content of the XFDF file with headers. This can be used to display to the browser.
    /// </summary>
    /// <returns></returns>
    public string PrintToScreen()
    {
      return _headerContentType
             + HeaderContentLength
             + GetXml().Length
             + Environment.NewLine
             + Environment.NewLine
             + GetXml();
    }
  }
}
