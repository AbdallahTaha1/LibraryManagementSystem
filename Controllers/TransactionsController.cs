using AutoMapper;
using LibraryManagementSystem.Consts;
using LibraryManagementSystem.DTOs.TransactionDtos;
using LibraryManagementSystem.Repositories.UnitOfWork;
using LibraryManagementSystem.Services.TransactionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionsController(ITransactionService transactionService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _transactionService = transactionService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();

            var trasactionDtos = _mapper.Map<IEnumerable<TransactionDto>>(transactions);
            return View(trasactionDtos);
        }

        public IActionResult Create()
        {
            ViewBag.Users = new SelectList(_unitOfWork.Users.GetAll(), "Id", "Name");
            ViewBag.Books = new SelectList(_unitOfWork.Books.GetAll(), "Id", "Title");
            return View();
        }

        // POST: api/transactions
        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Users = new SelectList(_unitOfWork.Users.GetAll(), "Id", "Name");
                ViewBag.Books = new SelectList(_unitOfWork.Books.GetAll(), "Id", "Title");
                return View(dto);
            }

            bool success = false;

            if (dto.Type == TransactionType.Borrow)
                success = await _transactionService.BorrowBook(dto);

            else if (dto.Type == TransactionType.Return)
                success = await _transactionService.ReturnBook(dto);

            if (!success)
            {
                ModelState.AddModelError("", "Transaction failed. Please check book availability.");
                ViewBag.Users = new SelectList(_unitOfWork.Users.GetAll(), "Id", "Name");
                ViewBag.Books = new SelectList(_unitOfWork.Books.GetAll(), "Id", "Title");
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
