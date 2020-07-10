//using Application.ApplicationServices;
//using Application.DTO.UserDTO;
//using Domain;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Domain.Entities;

//namespace Application.CommandHandler.UserCommand
//{
//    public class UserRepository : IUser, ICommandHandler
//    {
//        private readonly TestAppContext _context;
//        public UserRepository(TestAppContext context)
//        {
//            _context = context;
//        }
//        public User CheckLogin(LoginDTO login)
//        {
//            return _context.Users.Where(c => c.Email == login.Email).FirstOrDefault(c => c.Password == login.Password);
//        }

//        public void Commit()
//        {
//            _context.SaveChanges();
//        }
//        public User RegisterUser(RegisterDTO register)
//        {
//            if (_context.Users.Any(c => c.Email == register.Email))
//            {
//                return null;
//            }
//            else
//            {
//                User user = new User();
//                user.Email = register.Email;
//                user.UserName = register.UserName;
//                user.Password = register.Passowrd;
//                return user;
//            }
            
//        }
//    }
//}
