using AutoMapper;
using LibraryManagementSystem.DTOs.UserDtos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: Users
        public ActionResult Index()
        {
            var users = _userService.GetAllUsers();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return View(userDtos);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            // check if phone number already exists
            var isUserExists = await _userService.IsUserExists(dto.PhoneNumber);
            if (isUserExists)
            {
                ModelState.AddModelError("PhoneNumber", "A user with this phone number already exists.");
                return View(dto);
            }

            var user = _mapper.Map<User>(dto);
            var result = await _userService.AddUser(user);

            if (!result)
            {
                ModelState.AddModelError("", "Failed to add user.");
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Edit/{id}
        public async Task<ActionResult> Edit(Guid id)
        {
            var user = await _userService.GetUserById(id);

            if (user is null) return NotFound();

            var dto = _mapper.Map<UpdateUserDto>(user);
            return View(dto);
        }

        // POST: Users/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateUserDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var user = await _userService.GetUserById(dto.Id);

            if (user is null) return NotFound();

            _mapper.Map(dto, user);

            var result = await _userService.EditUser(user);
            if (!result)
            {
                ModelState.AddModelError("", "Failed to update user.");
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        // DELETE: Users/Delete/{id}
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user is null) return BadRequest();

            var isDeleted = await _userService.DeleteUser(id);
            return isDeleted ? Ok() : BadRequest();
        }

    }
}
