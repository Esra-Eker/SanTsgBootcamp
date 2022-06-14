using Bootcamp.Application.Interfaces;
using Bootcamp.Application.Models;
using Bootcamp.Data;
using Bootcamp.Data.Repositories.Interfaces;
using Bootcamp.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly BootcampDbContext _context;
        //private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger<UserController> _logger;

        public UserController(BootcampDbContext context, IUserRepository userRepository, IEmailService emailService, ILogger<UserController> logger)
        {
            _context = context;
            //_userRepository = userRepository;
            _emailService = emailService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var kullanicilar = _context.Users.ToList();         
            return View(kullanicilar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            MailRequest mail = new MailRequest
            {
                Body="Kaydınız Başarıyla Oluşturulmuştur",
                Subject="Bootcamp Kayıt Onayı",
                ToEmail=user.EmailAddress
            };
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                await _emailService.SendEmailAsync(mail);
                _logger.LogInformation("Yeni kullanıcı kaydı eklendi");
                return RedirectToAction("Index");
            }
            
            return View(user);
            
        }

        public IActionResult Edit(int? id)
        {
            if (id.GetValueOrDefault() == 0)
                return NotFound();

            var kullanici = _context.Users.FirstOrDefault(x => x.Id == id);

            if (kullanici == null)
                return NotFound();

            return View(kullanici);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            _logger.LogInformation("Kullanıcı düzenlendi");
            return RedirectToAction("Index");       
        }

        public IActionResult Delete(int? id)
        {
            var kullanici = _context.Users.FirstOrDefault(x => x.Id == id);

            if (kullanici == null)
                return NotFound();
            return View(kullanici);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var kullanici = _context.Users.FirstOrDefault(x => x.Id == id);

            if (kullanici == null)
                return NotFound();
            _context.Users.Remove(kullanici);
            _context.SaveChanges();
            _logger.LogInformation("Kullanıcı silindi");
            return RedirectToAction("Index");
        }
     
    }
}
