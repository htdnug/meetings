namespace ClassLibraryCS
{
    public abstract class FileRepositoryBase
    {
        protected FileRepositoryBase(string path)
        {
            this.Path = path;
        }

        protected string Path { get; set; }
    }
}
