using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string KeyWordSearchString { get; set; }

        public SelectList Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BookSection { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from s in _context.Scripture
                                              orderby s.Book
                                           select s.Book;

            var scriptures = from s in _context.Scripture
                             select s;

            if (!string.IsNullOrEmpty(KeyWordSearchString))
            {
                scriptures = scriptures.Where(s => s.Impression.Contains(KeyWordSearchString));
            }

            if (!string.IsNullOrEmpty(BookSection))
            {
                scriptures = scriptures.Where(s => s.Book == BookSection);
            }

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
        }
    }
}
