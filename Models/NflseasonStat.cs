using System;
using System.Collections.Generic;

namespace SportsApp2.Models;

public partial class NflseasonStat
{
    public int NflteamId { get; set; }

    public byte Gp { get; set; }

    public short TotalYards { get; set; }

    public decimal TotalYardsPerGame { get; set; }

    public short PassingYards { get; set; }

    public decimal PassingYardsPerGame { get; set; }

    public short RushingYards { get; set; }

    public decimal RushingYardsPerGame { get; set; }

    public short Points { get; set; }

    public decimal PointsPerGame { get; set; }
}
