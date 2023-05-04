using System;
using Catstagram.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Catstagram.Database
{
	public class DatabaseContext : DbContext
	{

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{

		}

        public DbSet<CatPost> CatPosts { get; set; }
	}
}

