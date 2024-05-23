using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    public abstract class Post
    {
        public string Author { get; set; }
        public DateTime Timestamp { get; set; }
        public int Likes { get; private set; }
        public List<string> Comments { get; private set; }

        public Post(string author)
        {
            Author = author;
            Timestamp = DateTime.Now;
            Likes = 0;
            Comments = new List<string>();
        }

        public void Like()
        {
            Likes++;
        }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }

        public abstract void Display();
    }
}
