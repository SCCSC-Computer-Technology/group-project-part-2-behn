using System;
using System.Collections.Generic;

namespace SportsApp2.Models;

public partial class Nflteam
{
    public int NflteamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public string Conference { get; set; } = null!;

    public string? Stadium { get; set; }

    public int Wins { get; set; }

    public int Losses { get; set; }

    public int Ties { get; set; }

    public virtual ICollection<Nflgame> NflgameAwayTeams { get; set; } = new List<Nflgame>();

    public virtual ICollection<Nflgame> NflgameHomeTeams { get; set; } = new List<Nflgame>();

    public virtual ICollection<Nflplayer> Nflplayers { get; set; } = new List<Nflplayer>();

    public virtual ICollection<Nflschedule> NflscheduleAwayTeams { get; set; } = new List<Nflschedule>();

    public virtual ICollection<Nflschedule> NflscheduleHomeTeams { get; set; } = new List<Nflschedule>();

    public virtual NflseasonStat NflseasonStat { get; set; }
}
