using System;
using System.Collections.Generic;

namespace MCFMAF_01.Database.TRDB2;

public partial class MsStorageLocation
{
    public string LocationId { get; set; } = null!;

    public string LocationName { get; set; } = null!;

    public virtual ICollection<TrBpkb> TrBpkbs { get; } = new List<TrBpkb>();
}
