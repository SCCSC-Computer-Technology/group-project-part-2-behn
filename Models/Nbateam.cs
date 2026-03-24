using System;
using System.Collections.Generic;

namespace SportsApp2.Models;

public partial class Nbateam
{
    public int NbateamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public string? Conference { get; set; }

    public string? Division { get; set; }

    public int? Wins { get; set; }

    public int? Losses { get; set; }

    public virtual ICollection<Nbagame> NbagameAwayTeams { get; set; } = new List<Nbagame>();

    public virtual ICollection<Nbagame> NbagameHomeTeams { get; set; } = new List<Nbagame>();

    public virtual ICollection<Nbaplayer> Nbaplayers { get; set; } = new List<Nbaplayer>();

    public virtual ICollection<Nbaschedule> NbascheduleAwayTeams { get; set; } = new List<Nbaschedule>();

    public virtual ICollection<Nbaschedule> NbascheduleHomeTeams { get; set; } = new List<Nbaschedule>();
    public virtual NbaseasonStat NbaseasonStat { get; set; }
}