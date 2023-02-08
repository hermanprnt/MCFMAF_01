using System;
using System.Collections.Generic;

namespace MCFMAF_01.Database.MasterDB;

public partial class MsUser
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserType { get; set; } = null!;
}
