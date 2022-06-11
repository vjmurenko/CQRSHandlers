namespace UseCases.Common.Commands.Create
{
	public class CreateEntityCommand<TDto>
	{
		public TDto Dto { get; set; }
	}
}