using System;

namespace BoxOfficeASP.Models
{
    public class Seance
    {
        public int SeanceId { get; set; }
        public DateTime StartTime { get; set; }
        public string MovieTitle { get; set; }
    }
}