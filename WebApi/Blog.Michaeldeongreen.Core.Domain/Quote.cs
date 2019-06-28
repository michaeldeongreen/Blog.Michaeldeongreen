using System;

namespace Blog.Michaeldeongreen.Core.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string quote { get; set; }
        public DateTime AddedDate { get; set; }
        public string Url { get; set; }
    }
}
