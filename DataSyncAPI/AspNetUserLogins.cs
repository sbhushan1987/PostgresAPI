﻿using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class AspNetUserLogins
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }

        public AspNetUsers User { get; set; }
    }
}
