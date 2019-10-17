using System;
using CarFuel.Models;
using CarFuel.Services.Core;
using CarFuel.Services.Data;

namespace CarFuel.Services
{
    public class MemberService : ServiceBase<Member>
    {
        public MemberService(App db) : base(db)
        {
        }

        public override Member Add(Member item)
        {
            try
            {
                var user = app.Members.Find(item.Id);
                if (user != null) return null;
                return base.Add(item);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override Member Find(params object[] keys)
        {
            var member = base.Find(keys);
            if (member == null) return null;
            return member;
        }
    }
}
