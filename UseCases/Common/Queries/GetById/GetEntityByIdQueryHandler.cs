using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CqrsFramework;
using Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UseCases.Common.Queries.GetById
{
	public abstract class GetEntityByIdQueryHandler<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
		where TEntity : Entity
		where TRequest : GetEntityByIdQuery
	{
		protected readonly IReadOnlyDbContext _readOnlyDbContext;
		protected readonly IMapper _mapper;

		protected GetEntityByIdQueryHandler(IReadOnlyDbContext readOnlyDbContext, IMapper mapper)
		{
			_readOnlyDbContext = readOnlyDbContext;
			_mapper = mapper;
		}

		public virtual async Task<TResponse> HandleAsync(TRequest request)
		{
			return await _readOnlyDbContext.Set<TEntity>()
				.Where(e => e.Id == request.Id)
				.ProjectTo<TResponse>(_mapper.ConfigurationProvider)
				.SingleAsync();
		}
	}
}