using FileManager;

namespace UI
{
    class OutToConsoleConfig : IConfiguration
    {
        public int PageSize { get; set; }
        public int DepthLevel { get; set; }
        public string CurrentDirectory { get; set; }
    }
}
