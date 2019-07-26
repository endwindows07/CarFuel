using System;
using System.Threading.Tasks;
using CarFuel.Models;
using CarFuel.Services.Data;

namespace CarFuel.Services
{
    public class App
    {
        private Lazy<MemberService> memberService;
        private Lazy<CarService> carService;
        //public AppDB Db { get; }

        public string UserId { get; set; }
        internal readonly AppDB db;

        public Member CurentMember
        {
            get
            {
                if (string.IsNullOrEmpty(UserId)) return null;

                var member = Members.Find(new Guid(UserId));

                //if (member == null)
                //{
                //    member = new Member();
                //    member.Id = new Guid(UserId);
                //    member.Lavel = MemberLavel.Bascis;
                //    Members.Add(member);

                //    SaveChanged();
                //}



                return member;
            }
        }

        public App(AppDB db)
        {
            memberService = new Lazy<MemberService>(() => new MemberService(this));
            carService = new Lazy<CarService>(() => new CarService(this));
            this.db = db;
        }

        public MemberService Members => memberService.Value;

        public CarService Cars => carService.Value;

        public int SaveChanged() => db.SaveChanges();
        public Task<int> SaveChangedAsyns() => db.SaveChangesAsync();
    }
}
