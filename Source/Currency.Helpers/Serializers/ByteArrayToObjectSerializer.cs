using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ondato.Helpers.Serializers
{
    public static class ByteArrayToObjectSerializer
    {
        public static object SerializeToObject(this byte[] obj)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(obj);
            var result = formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
