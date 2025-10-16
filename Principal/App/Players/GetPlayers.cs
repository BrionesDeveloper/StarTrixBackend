using MediatR;
using Microsoft.EntityFrameworkCore;
using NewSystem.Data;

namespace NewSystem.App.Players
{
    public record GetPlayersQuery() : IRequest<Result<List<GetPlayersList>>>;

    internal class GetPlayersHandler(NewSystemContext context) : IRequestHandler<GetPlayersQuery, Result<List<GetPlayersList>>>
    {
        public async Task<Result<List<GetPlayersList>>> Handle(GetPlayersQuery query, CancellationToken cancellationToken)
        {
            var data = await context.Players
                .Include(p => p.Scores)
                .AsNoTracking()
                .Select(p => new
                {
                    p.Id,
                    p.DisplayName,
                    LatestScore = p.Scores
                        .OrderByDescending(s => s.CreatedAt)
                        .Select(s => s.Value)
                        .FirstOrDefault()
                })
                .OrderByDescending(p => p.LatestScore)
                .Take(10)
                .ToListAsync(cancellationToken);

            if (!data.Any())
                return new Error<List<GetPlayersList>>("NotFound", "No players found");

            var result = data.Select(x => new GetPlayersList(x.Id, x.DisplayName, x.LatestScore)).ToList();

            return new Ok<List<GetPlayersList>>(result);
        }
    }

    /// <summary>
    /// DTO for leaderboard entry.
    /// </summary>
    public record GetPlayersList(Guid Id, string Name, int Score);
}
