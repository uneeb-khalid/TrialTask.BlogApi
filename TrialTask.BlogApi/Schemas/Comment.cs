namespace TrialTask.BlogApi.Schemas
{
    public class AddCommentRequest
    {
        public string Content { get; set; }
        public string PostId { get; set; }
        public string UserId { get; set; }
    } 
    
    public class EditCommentRequest
    {
        public string Id { get; set; }
        public string Content { get; set; }
    }
}
