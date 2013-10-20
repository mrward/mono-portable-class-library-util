namespace NuGet
{
    public enum FileConflictResolution
    {
        Overwrite,
        Ignore,
        OverwriteAll,
        IgnoreAll
    }
	
    public interface IFileConflictResolver
    {
        FileConflictResolution ResolveFileConflict(string message);
    }
}