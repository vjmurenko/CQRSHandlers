using CqrsFramework;

namespace UseCases.Common.Commands.Update
{
	public class UpdateEntityCommand<TDto> : IRequest
	{
		public int Id { get; set; }
		public TDto Dto { get; set; }
	}
}