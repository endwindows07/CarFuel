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
        internal readonly AppDB db;

        public App(AppDB db)
        {
            memberService = new Lazy<MemberService>(() => new MemberService(this));
            carService = new Lazy<CarService>(()=> new CarService(this));
            this.db = db;
        }

        public MemberService Members => memberService.Value;

        public CarService Cars => carService.Value;

        public int SaveChanged() => db.SaveChanges();
        public Task<int> SaveChangedAsyns() => db.SaveChangesAsync();
    }
}
