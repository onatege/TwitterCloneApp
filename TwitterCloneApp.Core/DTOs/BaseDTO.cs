using System;
namespace TwitterCloneApp.Core.DTOs
{
	public abstract class BaseDTO
	{
        public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}

