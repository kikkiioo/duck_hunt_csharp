﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
using System.Text.Json.Serialization;
=======
>>>>>>> 4934e7196b7086046a0e676e5f080319d00ff878
using System.Threading.Tasks;

namespace WpfDuckHunt.Models
{
<<<<<<< HEAD
    [Serializable]
    [JsonConverter(typeof(JsonStringEnumConverter))]
=======
>>>>>>> 4934e7196b7086046a0e676e5f080319d00ff878
    public enum EnumDuckState
    {
        NOTHING,
        RIGHTFLY,
        LEFTFLY,
        DIE,
        FALL
    }
}