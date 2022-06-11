using System.Threading.Tasks;
using AutoMapper;
using CqrsFramework;
using Entities;
using Infrastracture.Interfaces;

namespace UseCases.Common.Commands.Update
{
	public class UpdateEntityCommandHandler<TEntity, TRequest, TDto> : RequestHandler<TRequest>
		where TEntity : Entity
		where TRequest : UpdateEntityCommand<TDto>
	{
		protected readonly IDbContext _dbContext;
		protected readonly IMapper _mapper;

		public UpdateEntityCommandHandler(IDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		protected override async Task HandleAsync(TRequest request)
		{
			var entityFromDb = await GettrackedEntityAsync(request);
			_mapper.Map(request.Dto, entityFromDb);
			await _dbContext.SaveChangesAsync();
		}

		protected virtual async Task<TEntity> GettrackedEntityAsync(TRequest request)
		{
			return await _dbContext.Set<TEntity>().FindAsync(request.Id);
		}
	}
}