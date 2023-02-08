using System;
using System.Collections.Generic;

namespace MCFMAF_01.Database.TRDB1;

public partial class TrBpkb
{
    public string AgreementNumber { get; set; } = null!;

    public string BpkbNo { get; set; } = null!;

    public string BranchId { get; set; } = null!;

    public DateTime? BpkbDate { get; set; }

    public string? FakturNo { get; set; }

    public DateTime? FakturDate { get; set; }

    public string? LocationId { get; set; }

    public string PoliceNo { get; set; } = null!;

    public DateTime BpkbDateIn { get; set; }

    public virtual MsStorageLocation? Location { get; set; }
}
