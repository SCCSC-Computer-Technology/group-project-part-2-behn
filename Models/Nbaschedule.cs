using System;
using System.Collections.Generic;

namespace SportsApp2.Models;

public partial class Nbaschedule
{
    public int NbascheduleId { get; set; }

    public DateOnly GameDate { get; set; }

    public int AwayTeamId { get; set; }

    public int HomeTeamId { get; set; }

    public virtual Nbateam AwayTeam { get; set; } = null!;

    public virtual Nbateam HomeTeam { get; set; } = null!;
}
