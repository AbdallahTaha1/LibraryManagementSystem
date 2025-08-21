using AutoMapper;
using LibraryManagementSystem.DTOs.BookDtos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var books = _bookService.GetAllBooks();

            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            return View(bookDtos);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookDto dto)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid) return View(dto);

            // Check if a book with the same Isban already exists
            var isBookExists = await _bookService.IsBookExists(dto.Isbn);
            if (isBookExists)
            {
                ModelState.AddModelError("Isbn", "A book with this ISBN already exists.");
                return View(dto);
            }
            // Map the DTO to the Book model and add it
            var book = _mapper.Map<Book>(dto);

            var result = await _bookService.AddBook(book);
            if (!result)
            {
                ModelState.AddModelError("", "Failed to add book.");
                return View(dto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Edit/{guid}
        public async Task<ActionResult> Edit(Guid id)
        {
            var book = await _bookService.GetBookById(id);

            if (book is null) return NotFound();

            var dto = _mapper.Map<UpdateBookDto>(book);
            return View(dto);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateBookDto updateBookDto)
        {
            if (!ModelState.IsValid) return View(updateBookDto);

            var book = await _bookService.GetBookById(updateBookDto.Id);

            if (book == null) return NotFound();

            _mapper.Map(updateBookDto, book);

            if (updateBookDto.Img != null)
            {
                using var ms = new MemoryStream();
                await updateBookDto.Img.CopyToAsync(ms);
                book.DbImg = ms.ToArray();
            }

            var result = await _bookService.EditBook(book);
            if (!result)
            {
                ModelState.AddModelError("", "Failed to update book.");
                return View(updateBookDto);
            }

            return RedirectToAction(nameof(Index));
        }


        // DELETE: Books/Delete/5
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            // Check if the book exists
            var book = await _bookService.GetBookById(id);

            if (book == null) return BadRequest();

            var isDeleted = await _bookService.DeleteBook(id);
            return isDeleted ? Ok() : BadRequest();

        }
    }
}
