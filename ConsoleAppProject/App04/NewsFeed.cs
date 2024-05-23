using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    public class NewsFeed
    {
        private List<Post> posts;

        public NewsFeed()
        {
            posts = new List<Post>();
        }

        public void AddPost(Post post)
        {
            posts.Add(post);
        }

        public void Display()
        {
            foreach (Post post in posts)
            {
                post.Display();
            }
        }
    }
}


