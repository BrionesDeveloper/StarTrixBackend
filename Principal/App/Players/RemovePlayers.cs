using MediatR;
using Microsoft.EntityFrameworkCore;
using NewSystem.Data;

namespace NewSystem.App.Players
{
    public record RemovePlayerCommand(Guid Id) : IRequest<Result<bool>>;
    internal class RemovePlayers(NewSystemContext context) : IRequestHandler<RemovePlayerCommand, Result<bool>>
    {
        /// <summary>Handles a request</summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        public async Task<Result<bool>> Handle(RemovePlayerCommand request, CancellationToken cancellationToken)
        {
            var remove = await context.Players.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);

            if (remove is null)
                return new Error<bool>("NotFound", "The record for deletion was not found");

            context.Remove(remove);

            await context.SaveChangesAsync();

            return new Ok<bool>(true);
        }
    }
}
