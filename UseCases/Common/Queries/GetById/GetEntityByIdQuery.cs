using CqrsFramework;

namespace UseCases.Common.Queries.GetById
{
	public abstract class GetEntityByIdQuery<TDto> : IRequest<TDto>
	{
		public int Id { get; set; }
	}
}