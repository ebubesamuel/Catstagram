using System;
using System.Diagnostics;
using Catstagram.Database;
using Catstagram.Logic;
using Catstagram.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Controllers
{
	public class CatPostController : Controller
	{
		private readonly PostRepository _postRepository;

		public CatPostController(DatabaseContext context)
		{
			_postRepository = new PostRepository(context);
		}

		public IActionResult Index(string name)
		{
			var posts = string.IsNullOrWhiteSpace(name) ? _postRepository.GetAll() : _postRepository.FilterByName(name);

			return View(posts);
		}

		public IActionResult Details(int id)
		{
			var post = _postRepository.Get(id);

			if (post == null)	
			{
				return NotFound();
			}
			return View(post);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(CatPost post)
		{

			if (ModelState.IsValid)	
			{
				_postRepository.Add(post);
				return RedirectToAction(nameof(Index));
			}
			return View(post);
		}

		public IActionResult Edit(int id)
		{
			var post = _postRepository.Get(id);
			if (post == null)
			{
				return NotFound();
			}
			return View(post);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, CatPost post)
		{
			if (id != post.Id)	
			{
				return NotFound();
			}

			if (ModelState.IsValid)	
			{
				_postRepository.Edit(post);
				return RedirectToAction(nameof(Index));
			}
			return View(post);
		}

		public IActionResult Delete(int id)
		{
			var post = _postRepository.Get(id);
			if (post == null)
			{
				return NotFound();
			}
			return View(post);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			_postRepository.Delete(id);

			return RedirectToAction(nameof(Index));

		}


		public IActionResult Privacy()
		{
			return View();
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

