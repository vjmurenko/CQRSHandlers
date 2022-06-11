namespace UseCases.Common.Commands.Update
{
	public class UpdateEntityCommand<TDto>
	{
		public int Id { get; set; }
		public TDto Dto { get; set; }
	}
}