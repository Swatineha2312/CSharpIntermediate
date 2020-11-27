//===========Still needs Encapsulation===============
/*Exercise 2: Design a StackOverflow Post
*Used my own creativity and got the details from user only
*This is less encapsulated code.
 */

//===========Post.cs===============
using System;

namespace CSharpIntermediate
{
    class Post
    {
        int countUp = 0, countDown = 0, voteCount = 0;

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDateTime { get; set; }
        public int VoteCount { get; set; } = 0;

        public void CreatePost()
        {
            Console.WriteLine("----Welcome to Stackoverflow! Create the post by writing your content below-----");
            Console.WriteLine("Enter the title of the post: ");
            Title = Console.ReadLine();
            Console.WriteLine("Enter the description of the post: ");
            Description = Console.ReadLine();
            PostDateTime = DateTime.Now;
        }
        public void UpVote()
        {
            countUp += 1; voteCount += 1;
            Console.WriteLine("Your upvote is counted. Total votes for the post is: " + voteCount + "\n");
        }
        public void DownVote()
        {
            countDown += 1; voteCount += 1;
            Console.WriteLine("Your downvote is counted. Total votes for the post is: " + voteCount + "\n");
        }
        public void PostShow()
        {
            Console.WriteLine("Title of the post: " + Title);
            Console.WriteLine("Description of the post: " + Description);
            Console.WriteLine("Date/Time post created: " + PostDateTime);
            Console.WriteLine("Upvotes: " + countUp + "  Downvotes: " + countDown + "  Total Votes: " + (countUp + countDown) + "\n");
        }
    }
}

//=====Program.cs========
using System;

namespace CSharpIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            var post = new Post();
            post.CreatePost();
            int selection; Console.WriteLine("\n");
            
            do
            {
                Console.WriteLine("Select the number according to the requirement:\n1.I want to Upvote the post\n2.I want to Downvote the post\n3.Show the post Details\n0.Quit  ");
                selection = Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        post.UpVote();
                        break;
                    case 2:
                        post.DownVote();
                        break;
                    case 3:
                        post.PostShow();
                        break;
                    case 0:
                        break;
                }
            } while (selection != 0);
        }
    }
}

