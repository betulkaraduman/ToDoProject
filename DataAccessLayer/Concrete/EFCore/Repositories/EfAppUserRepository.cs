using DataAccessLayer.Concrete.EFCore.Contexts;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Concrete.EFCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {

        public List<AppUser> AllMembers()
        {
            using (var context = new TodoContext())
            {
                return context.Users.Join(context.UserRoles, user => user.Id, role => role.UserId, (resultUser, resultRole) => new
                {
                    user = resultUser,
                    userRole = resultRole


                }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTwoTable, resultRole) => new
                {
                    user = resultTwoTable.user,
                    userRole = resultTwoTable.userRole,
                    roles = resultRole
                }).Where(I => I.roles.Name == "Member").Select(I => new AppUser { Id = I.user.Id, Name = I.user.Name, Surname = I.user.Surname, Email = I.user.Email, UserName = I.user.UserName, Picture = I.user.Picture }).ToList();

            }
        }

        public List<AppUser> AllMembers(out int sumPage, string searchWord, int activePage = 1)
        {
            using (var context = new TodoContext())
            {
                var result = context.Users.Join(context.UserRoles, user => user.Id, role => role.UserId, (resultUser, resultRole) => new
                {
                    user = resultUser,
                    userRole = resultRole


                }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTwoTable, resultRole) => new
                {
                    user = resultTwoTable.user,
                    userRole = resultTwoTable.userRole,
                    roles = resultRole
                }).Where(I => I.roles.Name == "Member").Select(I => new AppUser { Id = I.user.Id, Name = I.user.Name, Surname = I.user.Surname, Email = I.user.Email, UserName = I.user.UserName, Picture = I.user.Picture });
                sumPage = (int)Math.Ceiling((double)result.Count() / 3);

                if (!string.IsNullOrWhiteSpace(searchWord))
                {
                    result = result.Where(i => i.Name.ToLower().Contains(searchWord.ToLower()) || i.Surname.ToLower().Contains(searchWord.ToLower()));
                    sumPage = (int)Math.Ceiling((double)result.Count() / 3);
                }
                result = result.Skip((activePage - 1) * 2).Take(2);

                return result.ToList();
            }
        }

        public List<DualHelper> MostWorkFinishedStaff()
        {
            using var context = new TodoContext();
            return context.work.Include(I => I.appUser).Where(I => I.State).GroupBy(I => I.appUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Name = I.Key,
                WorkCount = I.Count()
            }).ToList();
          
        }
        public List<DualHelper> MostWorkNotFinishedStaff()
        {
            using var context = new TodoContext();
            return context.work.Include(I => I.appUser).Where(I => !I.State && I.AppUserId!=null).GroupBy(I => I.appUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Name = I.Key,
                WorkCount = I.Count()
            }).ToList();

        }

    }
}
