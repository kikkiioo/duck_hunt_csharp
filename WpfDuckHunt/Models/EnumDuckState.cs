using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WpfDuckHunt.Models
{
    [Serializable]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumDuckState
    {
        NOTHING,
        RIGHTFLY,
        LEFTFLY,
        DIE,
        FALL
    }
}
