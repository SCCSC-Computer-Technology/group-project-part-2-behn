using System;
using System.Collections.Generic;

namespace SportsApp2.Models;

public partial class NbaseasonStat
{
    public int NbateamId { get; set; }

    public int Gp { get; set; }

    public decimal? PointsPerGame { get; set; }

    public decimal? ReboundsPerGame { get; set; }

    public decimal? AssistsPerGame { get; set; }

    public virtual Nbateam Nbateam { get; set; } = null!;
}
