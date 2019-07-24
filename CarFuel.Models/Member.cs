using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarFuel.Models
{
    public class Member
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(512)]
        public string PictureUrl { get; set; }

        
        public MemberLavel Lavel { get; set; } = MemberLavel.Bascis;
        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
