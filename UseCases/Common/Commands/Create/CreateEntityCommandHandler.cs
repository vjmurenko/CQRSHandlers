using System.Threading.Tasks;
using AutoMapper;
using CqrsFramework;
using Entities;
using Infrastracture.Interfaces;

namespace UseCases.Common.Commands.Create
{
	public abstract class CreateEntityCommandHandler<TEntity, TRequest, TDto> : IRequestHandler<TRequest, int>
		where TEntity : Entity
		where TRequest : CreateEntityCommand<TDto>
	{
		protected readonly IDbContext _dbContext;
		protected readonly IMapper _mapper;

		protected CreateEntityCommandHandler(IDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public virtual async Task<int> HandleAsync(TRequest tRequest)
		{
			var entity = _mapper.Map<TEntity>(tRequest.Dto);
			InitializeEntity(entity);
			_dbContext.Set<TEntity>().Add(entity);
			await _dbContext.SaveChangesAsync();

			return entity.Id;
		}

		protected virtual void InitializeEntity(TEntity entity)
		{
		}
	}
}