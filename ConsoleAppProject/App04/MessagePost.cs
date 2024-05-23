using System;
using System.Xml.Linq;

namespace ConsoleAppProject.App04
{
    public class MessagePost : Post
    {
        public string Message { get; set; }

        public MessagePost(string author, string message) : base(author)
        {
            Message = message;
        }

        public override void Display()
        {
            Console.WriteLine($"Message Post by {Author}");
            Console.WriteLine($"Timestamp: {Timestamp}");
            Console.WriteLine($"Message: {Message}");
            Console.WriteLine($"Likes: {Likes}");
            Console.WriteLine("Comments:");
            foreach (string comment in Comments)
            {
                Console.WriteLine($" - {comment}");
            }
            Console.WriteLine();
        }
    }
}
