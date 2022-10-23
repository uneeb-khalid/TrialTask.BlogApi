namespace TrialTask.BlogApi.Schemas
{
    public class BlogPostAddRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string BlogId { get; set; }
        public string userId { get; set; }
    }
    public class BlogPostEditRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
    public class BlogPostResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string BlogId { get; set; }
        public string userId { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
