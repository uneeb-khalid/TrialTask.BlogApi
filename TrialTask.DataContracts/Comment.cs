namespace TrialTask.DataContracts
{
    public class Comment
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string PostId { get; set; }
        public string UserId { get; set; }
        public DateTime LastModify { get; set; }
    }
}