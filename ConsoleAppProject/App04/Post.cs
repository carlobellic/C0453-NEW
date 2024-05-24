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
// Author is the name of the person entered, the code "DateTime.Now" just pulls the current system time, as well as this the comments are just a string.
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
