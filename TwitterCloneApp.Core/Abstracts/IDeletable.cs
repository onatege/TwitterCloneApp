namespace TwitterCloneApp.Core.Abstracts
{
	public interface IDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
