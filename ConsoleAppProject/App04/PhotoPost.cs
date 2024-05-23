using System;
using System.Xml.Linq;

namespace ConsoleAppProject.App04
{
    public class PhotoPost : Post
    {
        public string PhotoFilename { get; set; }
        public string Caption { get; set; }

        public PhotoPost(string author, string photoFilename, string caption) : base(author)
        {
            PhotoFilename = photoFilename;
            Caption = caption;
        }

        public override void Display()
        {
            Console.WriteLine($"Photo Post by {Author}");
            Console.WriteLine($"Timestamp: {Timestamp}");
            Console.WriteLine($"Photo: {PhotoFilename}");
            Console.WriteLine($"Caption: {Caption}");
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

