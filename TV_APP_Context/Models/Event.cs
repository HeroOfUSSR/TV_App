﻿using System;
using System.Collections.Generic;

namespace TV_APP_Context.Models
{
    public partial class Event
    {
        public int IdEvent { get; set; }
        public string NameEvent { get; set; } = null!;
        public string DateEvent { get; set; } = null!;
        public byte[]? PictureEvent { get; set; }
    }
}
