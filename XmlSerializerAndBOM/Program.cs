using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XmlSerializerAndBOM
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunSerialize();
            RunDeSerialize();
            Console.ReadLine();
        }

        static void RunSerialize()
        {
            #region serialize
            var ser = new SerializerRunner();

            Console.WriteLine("====================> XmlWriter");

            string xmlWriter_UTF8BOM = ser.Serialize_XmlWriter(Encoding.UTF8);
            string xmlWriter_UTF8 = ser.Serialize_XmlWriter(new UTF8Encoding());

            Console.WriteLine(xmlWriter_UTF8BOM);
            Console.WriteLine(xmlWriter_UTF8);
            Console.WriteLine(xmlWriter_UTF8BOM == xmlWriter_UTF8);

            Console.WriteLine("====================> TextWriter.StreamWriter");

            string textWriter_StreamWriter_UTF8BOM = ser.Serialize_TextWriter_StreamWriter(Encoding.UTF8);
            string textWriter_StreamWriter_UTF8 = ser.Serialize_TextWriter_StreamWriter(new UTF8Encoding());

            Console.WriteLine(textWriter_StreamWriter_UTF8BOM);
            Console.WriteLine(textWriter_StreamWriter_UTF8);
            Console.WriteLine(textWriter_StreamWriter_UTF8BOM == textWriter_StreamWriter_UTF8);

            Console.WriteLine("====================> Stream");

            string stream_UTF8BOM = ser.Serialize_Stream(Encoding.UTF8);
            string stream_UTF8 = ser.Serialize_Stream(new UTF8Encoding());

            Console.WriteLine(stream_UTF8BOM);
            Console.WriteLine(stream_UTF8);
            Console.WriteLine(stream_UTF8BOM == stream_UTF8);

            Console.WriteLine("====================> TextWriter.StringBuilder (no encoding potion)");

            string textWriter_StringBuilder = ser.Serialize_TextWriter_StringWriter();

            Console.WriteLine(textWriter_StringBuilder);

            #endregion
        }

        static void RunDeSerialize()
        {
            #region deserialize
            var ser = new SerializerRunner();
            var deser = new DeSerializerRunner();
            var xml = ser.Serialize_XmlWriter(new UTF8Encoding());
            var xmlBOM = ser.Serialize_XmlWriter(Encoding.UTF8);

            Console.WriteLine("====================> XmlReader_FromStream");
            try
            {
                var xmlReader_FromStream = deser.DeSerialize_XmlReader_FromStream<MyModel>(xml, Encoding.UTF8);
                Console.WriteLine(xmlReader_FromStream);

                var xmlReader_FromStreamBOM = deser.DeSerialize_XmlReader_FromStream<MyModel>(xmlBOM, Encoding.UTF8);
                Console.WriteLine(xmlReader_FromStreamBOM);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("====================> XmlReader_FromStringReader");
            try
            {
                var xmlReader_FromTextReader = deser.DeSerialize_XmlReader_FromStringReader<MyModel>(xml);
                Console.WriteLine(xmlReader_FromTextReader);

                var xmlReader_FromTextReaderBOM = deser.DeSerialize_XmlReader_FromStringReader<MyModel>(xmlBOM);
                Console.WriteLine(xmlReader_FromTextReaderBOM);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("====================> StreamReader");
            try
            {
                var streamReader = deser.DeSerialize_StreamReader<MyModel>(xml, Encoding.UTF8);
                Console.WriteLine(streamReader);

                var TextReader_StreamReader_BOM = deser.DeSerialize_StreamReader<MyModel>(xmlBOM, Encoding.UTF8);
                Console.WriteLine(TextReader_StreamReader_BOM);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("====================> Stream");
            var deSerialize_Stream = deser.DeSerialize_Stream<MyModel>(xml, Encoding.UTF8);
            var deSerialize_StreamBOM = deser.DeSerialize_Stream<MyModel>(xmlBOM, Encoding.UTF8);
            Console.WriteLine(deSerialize_Stream);
            Console.WriteLine(deSerialize_StreamBOM);

            Console.WriteLine("====================> StringReader");
            try
            {
                var stringReader = deser.DeSerialize_StringReader<MyModel>(xml);
                Console.WriteLine(stringReader);

                var TextReader_StringReaderBOM = deser.DeSerialize_StringReader<MyModel>(xmlBOM);
                Console.WriteLine(TextReader_StringReaderBOM);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            #endregion
        }
    }

    public class SerializerRunner
    {
        public string Serialize_XmlWriter(Encoding encoding)
        {
            var serializer = new XmlSerializer(typeof(MyModel));

            var ws = new XmlWriterSettings()
            {
                Encoding = encoding
            };

            var ns = new XmlSerializerNamespaces(new XmlQualifiedName[] { XmlQualifiedName.Empty });

            using (var ms = new MemoryStream())
            using (var xw = XmlWriter.Create(ms, ws))
            {
                serializer.Serialize(xw, new MyModel(), ns);
                return ws.Encoding.GetString(ms.ToArray());
            }
        }

        public string Serialize_TextWriter_StreamWriter(Encoding encoding)
        {
            var serializer = new XmlSerializer(typeof(MyModel));

            var ns = new XmlSerializerNamespaces(new XmlQualifiedName[] { XmlQualifiedName.Empty });

            using (var ms = new MemoryStream())
            using (var sw = new StreamWriter(ms, encoding)) // 2nd arg default to utf-8 no BOM
            {
                serializer.Serialize(sw, new MyModel(), ns);
                return encoding.GetString(ms.ToArray());
            }
        }

        public string Serialize_Stream(Encoding encoding)
        {
            var serializer = new XmlSerializer(typeof(MyModel));

            var ns = new XmlSerializerNamespaces(new XmlQualifiedName[] { XmlQualifiedName.Empty });

            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, new MyModel(), ns);
                return encoding.GetString(ms.ToArray());
            }
        }

        public string Serialize_TextWriter_StringWriter()
        {
            var serializer = new XmlSerializer(typeof(MyModel));

            var ns = new XmlSerializerNamespaces(new XmlQualifiedName[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, new MyModel(), ns);
                return sb.ToString();
            }
        }
    }

    public class DeSerializerRunner
    {
        public T DeSerialize_XmlReader_FromStream<T>(string xml, Encoding encoding)
        {
            var serializer = new XmlSerializer(typeof(T));

            var xmlBytes = encoding.GetBytes(xml);
            using (var ms = new MemoryStream(xmlBytes))
            using (var xr = XmlReader.Create(ms))
            {
                xr.Read();
                var result = serializer.Deserialize(xr);
                if (result != null)
                {
                    return (T)result;
                }
                return default(T);
            }
        }

        public T DeSerialize_XmlReader_FromStringReader<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(xml))
            using (var xr = XmlReader.Create(sr))
            {
                xr.Read();
                var result = serializer.Deserialize(xr);
                if (result != null)
                {
                    return (T)result;
                }
                return default(T);
            }
        }

        public T DeSerialize_StreamReader<T>(string xml, Encoding encoding)
        {
            var serializer = new XmlSerializer(typeof(T));

            var xmlBytes = encoding.GetBytes(xml);
            using (var ms = new MemoryStream(xmlBytes))
            using (var tr = new StreamReader(ms, encoding))
            {
                var result = serializer.Deserialize(tr);
                if (result != null)
                {
                    return (T)result;
                }
                return default(T);
            }
        }

        public T DeSerialize_Stream<T>(string xml, Encoding encoding)
        {
            var serializer = new XmlSerializer(typeof(T));

            var xmlBytes = encoding.GetBytes(xml);
            using (var ms = new MemoryStream(xmlBytes))
            {
                var result = serializer.Deserialize(ms);
                if (result != null)
                {
                    return (T)result;
                }
                return default(T);
            }
        }

        public T DeSerialize_StringReader<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(xml))
            {
                var result = serializer.Deserialize(sr);
                if (result != null)
                {
                    return (T)result;
                }
                return default(T);
            }
        }

    }

    public class MyModel
    {
    }
}