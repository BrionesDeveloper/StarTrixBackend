using MediatR;
using Microsoft.EntityFrameworkCore;
using NewSystem.Data;
using NewSystem.Domain.Players;
using NewSystem.Domain.Scores;

namespace NewSystem.App.Players
{
    public record UpSertPlayerCommand(string Name, int Points) : IRequest<Result<bool>>;

    internal class UpSertPlayersHandler(NewSystemContext context) : IRequestHandler<UpSertPlayerCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(UpSertPlayerCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
                return new Error<bool>("Invalid", "Player name cannot be empty.");

            var name = command.Name.Trim();

            var player = await context.Players
                .Include(p => p.Scores)
                .FirstOrDefaultAsync(p => p.DisplayName.ToLower() == name.ToLower(), cancellationToken);

            if (player is null)
            {
                // Create player and first score
                player = new Player
                {
                    Id = Guid.NewGuid(),
                    DisplayName = name,
                    CreatedAt = DateTime.UtcNow,
                    Scores = new List<Score>
                    {
                        new Score
                        {
                            Id = Guid.NewGuid(),
                            Value = command.Points,
                            CreatedAt = DateTime.UtcNow
                        }
                    }
                };

                context.Players.Add(player);
            }
            if (player is not null)
            {
                var score = new Score
                {
                    Id = Guid.NewGuid(),
                    PlayerId = player.Id,
                    Value = command.Points,
                    CreatedAt = DateTime.UtcNow
                };

                context.Scores.Add(score);
            }

            await context.SaveChangesAsync(cancellationToken);

            return new Ok<bool>(true);
        }
    }
}
