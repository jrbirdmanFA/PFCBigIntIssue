using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleApp7
{
    class Program
    {
        static void Main()
        {
            //using (var db = new BloggingContext())
            //{
            //    // Create
            //    Console.WriteLine("Inserting a new blog");
            //    db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
            //    db.SaveChanges();


            //    // Read
            //    Console.WriteLine("Querying for a blog");
            //    var blog = db.Blogs
            //        .OrderBy(b => b.BlogId)
            //        .First();

            //    // Update
            //    Console.WriteLine("Updating the blog and adding a post");
            //    //blog.Url = "https://devblogs.microsoft.com/dotnet";
            //    //blog.Posts.Add(
            //    //    new Post
            //    //    {
            //    //        Title = "Hello World",
            //    //        Content = "I wrote an app using EF Core!"
            //    //    });
            //    //db.SaveChanges();

            //    blog.Posts.Add(
            //        new VideoPost
            //        {
            //            Title = "Hello World, The Movie",
            //            Content = "Lareum ipsum, alpha, beta, crapper...",
            //            VideoTitle = "this is the video title",
            //            ReleaseDate = DateTime.Today.AddDays(-300)
            //        });
            //    blog.Posts.Add(
            //        new DumbAsAPost
            //        {
            //            Title = "Hello World, The Movie",
            //            Content = "Lareum ipsum, alpha, beta, crapper...",
            //            Stupid = true
            //        });
            //    db.SaveChanges();

            //    var blogList = db.Blogs.ToList();
            //    foreach (var b in blogList)
            //    {
            //        Console.WriteLine($"Blog Dump: {b.Url}");
            //        foreach(var p in b.Posts)
            //        {
            //            Console.WriteLine($" Post Dump: {p.PostId} {p.Title}");
            //        }
            //    }

            //    //var videoBlogList = db.Blogs.Where(x => (x. as VideoPost).ReleaseDate > DateTime.Today.AddMonths(-12));
            //    //var testList = db.Blogs.Include(x => (x.Posts as IList<VideoPost))).ToList();


            //    // Delete
            //    var blogList2 = db.Blogs.ToList();
            //    foreach (var b in blogList2)
            //    {
            //        Console.WriteLine("Delete a blog");
            //        db.Remove(b);
            //    }
            //    db.SaveChanges();
            //}

            using (var db = new BloggingContext())
            {
                //Console.WriteLine("Testing fix 1...");
                //var testBigInt = new TestBigInt() { MyProperty = $"test - {DateTime.Now.ToShortTimeString()}" };
                //db.Add(testBigInt);
                //db.SaveChanges();

                //var testRecords = db.TestBigInts.ToList();
                //foreach (var tr in testRecords)
                //{
                //    Console.WriteLine($"Id: {tr.TestBigIntId}  MyProperty:{tr.MyProperty}");
                //}

                // Original
                Console.WriteLine("Testing the original...");
                var orgTest = new TestBigIntOrg() { MyProperty = $"test - {DateTime.Now.ToShortTimeString()}" };
                db.Add(orgTest);
                db.SaveChanges();

                var orgRecs = db.TestBigIntsOrg.ToList();
                foreach (var tr in orgRecs)
                {
                    Console.WriteLine($"Id: {tr.Id}  MyProperty:{tr.MyProperty}");
                }

            }
        }
    }
}