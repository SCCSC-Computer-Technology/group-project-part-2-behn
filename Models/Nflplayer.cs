using System;
using System.Collections.Generic;

namespace SportsApp2.Models;

public partial class Nflplayer
{
    public int NflplayerId { get; set; }

    public string PlayerName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int NflteamId { get; set; }

    public string? DateOfBirth { get; set; }

    public string? Height { get; set; }

    public string? Weight { get; set; }

    public string? College { get; set; }

    public string? YearsPlayed { get; set; }

    public virtual Nflteam Nflteam { get; set; } = null!;
}
