using System;
using CarFuel.Models;
using CarFuel.Services.Core;
using CarFuel.Services.Data;

namespace CarFuel.Services
{
    public class MemberService : ServiceBase<Member>
    {
        public MemberService(AppDB db) : base(db)
        {

        }
    }
}
