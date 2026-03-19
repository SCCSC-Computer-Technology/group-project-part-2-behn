using System;
using System.Collections.Generic;

namespace SportsApp2.Models;

public partial class Nbagame
{
    public int NbagameId { get; set; }

    public int HomeTeamId { get; set; }

    public int AwayTeamId { get; set; }

    public DateTime GameDate { get; set; }

    public int? HomeScore { get; set; }

    public int? AwayScore { get; set; }

    public virtual Nbateam AwayTeam { get; set; } = null!;

    public virtual Nbateam HomeTeam { get; set; } = null!;
}
