using CqrsFramework;

namespace UseCases.Common.Commands.Create
{
	public class CreateEntityCommand<TDto> : IRequest<int>
	{
		public TDto Dto { get; set; }
	}
}