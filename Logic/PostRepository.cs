using System;
using Catstagram.Database;
using Catstagram.Models;

namespace Catstagram.Logic
{

    public class PostRepository
    {

        private readonly DatabaseContext _context;

		public PostRepository(DatabaseContext context)
		{
			_context = context;
		}

		public IEnumerable<CatPost> GetAll()
		{
			return _context.CatPosts;
		}

		public CatPost Get(int id)
		{
			return _context.CatPosts.FirstOrDefault(p => p.Id == id);
		}

		public void Add (CatPost post)
		{
			_context.CatPosts.Add(post);
			_context.SaveChanges();
		}

		public void Edit(CatPost post)
		{
			var oldPost = Get(post.Id);
			if (oldPost != null)		
			{
				oldPost.Image = post.Image;
				oldPost.AuthorName = post.AuthorName;
				oldPost.Comment = post.Comment;
				oldPost.Email = post.Email;

                _context.SaveChanges();
            }
			
		}

		public void Delete (int id)
		{
			var post = Get(id);
			if (post != null)	
			{
				_context.CatPosts.Remove(post);
				_context.SaveChanges();
			}
		}

		public IEnumerable<CatPost> FilterByName(string nameToFind)
		{
			return _context.CatPosts.Where(p => p.AuthorName.Contains(nameToFind, StringComparison.OrdinalIgnoreCase));
		}

	}
}

