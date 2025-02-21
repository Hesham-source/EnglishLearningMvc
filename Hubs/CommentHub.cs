using Microsoft.AspNetCore.SignalR;
using EnglishLearning.Data;
using EnglishLearning.Models;
using EnglishLearning.Models.Identity;
using System;

namespace EnglishLearning.Hubs
{
    public class CommentHub:Hub
    {
        ApplicationDbContext applictionDbcontext;

        public CommentHub(ApplicationDbContext applictionDbcontext)
        {
            this.applictionDbcontext = applictionDbcontext;
        }

        public void WriteComment(string UserName, string CommentText, string CourseID)
        {
            Comment comment = new Comment() { 
                Text = CommentText, 
                Date = DateTime.Now,
                UserId = UserName,
                CourseId = int.Parse(CourseID) 
            };
            applictionDbcontext.comments.Add(comment);
            Clients.All.SendAsync("NewComment", UserName, CommentText, CourseID);
            applictionDbcontext.SaveChanges();
        }
    }
}
