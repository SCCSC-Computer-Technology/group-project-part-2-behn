using System;
using System.Collections.Generic;

namespace SportsApp2.Models;

public partial class Nflschedule
{
    public int NflscheduleId { get; set; }

    public byte WeekNumber { get; set; }

    public DateOnly GameDate { get; set; }

    public int AwayTeamId { get; set; }

    public int HomeTeamId { get; set; }

    public string? SiteNote { get; set; }

    public string KickoffEt { get; set; } = null!;

    public string KickoffLocal { get; set; } = null!;

    public string Network { get; set; } = null!;

    public virtual Nflteam AwayTeam { get; set; } = null!;

    public virtual Nflteam HomeTeam { get; set; } = null!;
}
