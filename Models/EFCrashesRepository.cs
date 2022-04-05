using System;
using System.Linq;

namespace UtahCrashes.Models
{
    public class EFCrashesRepository : ICrashesRepository
    {
        private CrashesDbContext context { get; set; }

        public EFCrashesRepository (CrashesDbContext temp)
        {
            context = temp;
        }

        public IQueryable<Crash> Crashes => context.Crashes;
        public IQueryable<County> Counties => context.Counties;

        public void AddCrash(Crash c)
        {
            context.Add(c);
            context.SaveChanges();
        }

        public void EditCrash(Crash c)
        {
            context.Update(c);
            context.SaveChanges();
        }

        public void DeleteCrash(Crash c)
        {
            context.Remove(c);
            context.SaveChanges();
        }

    }
}
