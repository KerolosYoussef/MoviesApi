using System.Xml.Serialization;
using MovieRate.Core.Models;

namespace MovieRate.Core.Interfaces;

public interface IXmlHandler<T> where T : BaseModel
{
    string GenerateXml(T model);
    void SaveXmlToFile(string xml, string filePath);
}