
namespace Ondato.DB.Models
{
    public class DictionaryValue
    {
        public int DictionaryValueId { get; set; }
        public string Key { get; set; }
        public byte[] Value { get; set; }

        public DictionaryKey DictionaryKey { get; set; }
    }
}
