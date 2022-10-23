namespace TrialTask.BlogApi.Schemas
{
    public class BlogRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

    }
    public class BlogResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
