using static System.Formats.Asn1.AsnWriter;

namespace NewSystem.Domain.Player
{
    /// <summary>
    ///   Player data entity.
    /// </summary>
    /// <summary>
    /// Player entity.
    /// </summary>
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string DisplayName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<Score> Scores { get; set; } = new();
    


        //public static Player? Create(string Name, int Points)
        //{
        //    return new Player
        //    {
        //        Name = Name,
        //        Points = Points
        //    };
        //}

        //public void Update(int Points)
        //{
        //    this.Points = Points;
        //}
    }
}
