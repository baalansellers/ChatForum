using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatForum.DAL;
using ChatForum.Models.Forum;
using Microsoft.AspNet.SignalR;

namespace ChatForum.Hubs.Forum
{
    public class ThreadHub : Hub
    {
        ForumContext _forumContext;
        public ThreadHub()
        {
            _forumContext = new ForumContext();
        }

        public void Create(string title, string content)
        {
            var thread = _forumContext.InsertThread(title, content);
            var post = _forumContext.InsertPost(thread.ID, content, out thread);
            Clients.All.threadCreated(thread);
        }

        public IEnumerable<Thread> GetAll()
        {
            var all = _forumContext.Threads.ToArray();
            return all;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _forumContext.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}