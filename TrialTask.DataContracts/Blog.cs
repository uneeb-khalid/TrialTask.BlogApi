﻿namespace TrialTask.DataContracts
{
    public class Blog
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}