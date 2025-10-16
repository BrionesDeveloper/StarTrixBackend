using NewSystem.Domain.Scores;
using static System.Formats.Asn1.AsnWriter;

namespace NewSystem.Domain.Players
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

        public static Player? Create(string Name, int Points)
        {
            return new Player
            {
                DisplayName = Name,
                Scores = Points > 0 ? new List<Score> { new Score { Value = Points } } : new List<Score>()
            };
        }

        public void Update(int Points)
        {
            if (Points > 0)
            {
                this.Scores.Add(new Score { Value = Points });
            }
        }
    }
}
