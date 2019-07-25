using System;
using System.Threading.Tasks;
using CarFuel.Services.Data;

namespace CarFuel.Services
{
    public class App
    {
        private Lazy<MemberService> memberService;
        private Lazy<CarService> carService;
        //public AppDB Db { get; }
        public AppDB Db { get; }

        public App(AppDB db)
        {
            memberService = new Lazy<MemberService>(() => new MemberService(db));
            carService = new Lazy<CarService>(()=> new CarService(db));
            Db = db;
        }

        public MemberService Members => memberService.Value;

        public CarService Cars => carService.Value;

        public int SaveChanged() => Db.SaveChanges();
        public Task<int> SaveChangedAsyns() => Db.SaveChangesAsync();
    }
}
