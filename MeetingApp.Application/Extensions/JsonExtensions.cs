using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;

namespace MeetingApp.Application.Extensions
{
    public static class JsonExtensions
    {
        public static string ObjectToXML(this object o, bool isCDataValue = false)
        {
            StringWriter sw = new StringWriter();

            string returnValue = "";

            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
                returnValue = sw.ToString();

                returnValue = isCDataValue ? $"<![CDATA[{returnValue.Replace("&amp;", " ")}]]>" : returnValue.Replace("&amp;", " ");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }

        public static string ToJSON<T>(this T value, bool apostropheCheck = false)
        {
            if (value == null) return string.Empty;

            string json = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                            MaxDepth = Int32.MaxValue,
                            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
                        });

            json = apostropheCheck ? json.Replace("'", "\\'").Replace("\"", "\\\"") : json;
            json = json.RemoveRepeatedWhiteSpace();
            json = json.Replace(Environment.NewLine, string.Empty);
            return json;
        }

        public static string ToXML<T>(this T value, bool isCDataValue = false)
        {
            if (value == null) return string.Empty;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
                {
                    xmlSerializer.Serialize(xmlWriter, value);
                    return isCDataValue ? $"<![CDATA[{stringWriter.ToString().Replace("&amp;", " ")}]]>" : stringWriter.ToString().Replace("&amp;", " ");
                }
            }
        }
    }
}
