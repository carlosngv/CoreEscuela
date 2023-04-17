namespace CoreEscuela.Entities
{
	public interface IPlace
	{
		public string Address { get; set; }

		void CleanPlace();
	}
}

