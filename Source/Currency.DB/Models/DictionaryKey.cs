using System;
using System.Collections.Generic;

namespace Ondato.DB.Models
{
    public class DictionaryKey
    {
        public string Key { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<DictionaryValue> DictionaryValues { get; set; }
    }
}
