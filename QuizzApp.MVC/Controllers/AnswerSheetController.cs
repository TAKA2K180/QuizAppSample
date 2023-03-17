using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Core.Models;
using QuizzApp.MVC.Data;

namespace QuizzApp.MVC.Controllers
{
    public class AnswerSheetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnswerSheetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnswerSheet
        public async Task<IActionResult> Index()
        {
            var questions = await _context.Questions.ToListAsync();
            
            return View(questions);
        }

        // GET: AnswerSheet/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questions == null)
            {
                return NotFound();
            }

            return View(questions);
        }

        // GET: AnswerSheet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnswerSheet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,QuestionId,Answer,AnswerId")] Questions questions)
        {
            if (ModelState.IsValid)
            {
                questions.Id = Guid.NewGuid();
                _context.Add(questions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questions);
        }

        // GET: AnswerSheet/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions.FindAsync(id);
            if (questions == null)
            {
                return NotFound();
            }
            return View(questions);
        }

        // POST: AnswerSheet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Question,QuestionId,Answer,AnswerId")] Questions questions)
        {
            if (id != questions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionsExists(questions.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(questions);
        }

        // GET: AnswerSheet/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questions == null)
            {
                return NotFound();
            }

            return View(questions);
        }

        // POST: AnswerSheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Questions'  is null.");
            }
            var questions = await _context.Questions.FindAsync(id);
            if (questions != null)
            {
                _context.Questions.Remove(questions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionsExists(Guid id)
        {
          return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
