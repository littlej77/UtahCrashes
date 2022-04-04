using System;
using System.Linq;

namespace UtahCrashes.Models
{
    public interface ICrashesRepository
    {
        IQueryable<Crash> Crashes { get; }
        IQueryable<County> Counties { get; }

        public void AddCrash(Crash c);
        public void EditCrash(Crash c);
        public void DeleteCrash(Crash c);
       
    }
}
