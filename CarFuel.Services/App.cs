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
        internal readonly AppDB Db;

        public App(AppDB db)
        {
            memberService = new Lazy<MemberService>(() => new MemberService(this));
            carService = new Lazy<CarService>(()=> new CarService(this));
            Db = db;
        }

        public MemberService Members => memberService.Value;

        public CarService Cars => carService.Value;

        public int SaveChanged() => Db.SaveChanges();
        public Task<int> SaveChangedAsyns() => Db.SaveChangesAsync();
    }
}
