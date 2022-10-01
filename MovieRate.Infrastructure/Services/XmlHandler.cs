using System.Xml;
using System.Xml.Serialization;
using MovieRate.Core.Interfaces;
using MovieRate.Core.Models;
using SuperXML;

namespace MovieRate.Infrastructure.Services;

public class XmlHandler<T> : IXmlHandler<T> where T : BaseModel
{
    public string GenerateXml(T model)
    {
        var compiler = new Compiler().AddKey("model", model);
        var compiled = compiler.CompileXml(@"C:\Users\SlowArrow\Desktop\generatedXml.xml");
        return compiled;
    }

    public void SaveXmlToFile(string xml,string filePath)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xml);
        xmlDocument.Save(filePath);
    }
}