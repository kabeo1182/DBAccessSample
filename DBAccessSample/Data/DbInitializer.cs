using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBAccessSample.Models;

namespace DBAccessSample.Data
{
    public class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Organizations.Any())
            {
                return;   // DB has been seeded
            }

            var orgs = new Organization[]
            {
                new Organization {Name = "営業部"},
                new Organization {Name = "開発部"},
            };
            foreach (var o in orgs)
            {
                context.Organizations.Add(o);
            }
            context.SaveChanges();


            var users = new UserInfo[]
            {
                new UserInfo {Name = "山田太郎", OrganizationId = orgs.First(o => o.Name == "営業部").Id},
                new UserInfo {Name = "田中次郎", OrganizationId = orgs.First(o => o.Name == "開発部").Id},
                new UserInfo {Name = "鈴木三郎", OrganizationId = orgs.First(o => o.Name == "開発部").Id},
            };
            foreach (var u in users)
            {
                context.UserInfoes.Add(u);
            }
            context.SaveChanges();
        }
    }
}
