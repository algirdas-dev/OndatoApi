using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Ondato.Helpers.Serializers
{
    public static class ObjectToByteArraySerializer
    {
        public static byte[] SerializeToByteArray(this object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                if (obj.GetType() == typeof(JsonElement)) 
                    formatter.Serialize(stream, obj.ToString());
                else
                    formatter.Serialize(stream, obj);

                return stream.ToArray();
            }
        }

        public class Test {
            public object T { get; set; }
        }
    }
}
