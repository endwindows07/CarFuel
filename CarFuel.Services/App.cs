using System;
using System.Threading.Tasks;
using CarFuel.Services.Data;

namespace CarFuel.Services
{
    public class App
    {
        private Lazy<MemberService> memberService;

        public App(AppDB db)
        {
            memberService = new Lazy<MemberService>(() => new MemberService(db));
            Cars = new CarService(db);
            Db = db;
        }

        public MemberService Members => memberService.Value;

        public CarService Cars { get; set; }
        public AppDB Db { get; }

        public int SaveChanged() => Db.SaveChanges();
        public Task<int> SaveChangedAsyns() => Db.SaveChangesAsync();
    }
}
