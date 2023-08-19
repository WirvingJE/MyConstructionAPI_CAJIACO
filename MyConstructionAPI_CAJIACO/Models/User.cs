using System;
using System.Collections.Generic;

namespace MyConstructionAPI_CAJIACO.Models
{
    public partial class User
    {
        public User()
        {
            ConstructionCategories = new HashSet<ConstructionCategory>();
            ConstructionSteps = new HashSet<ConstructionStep>();
            Constructions = new HashSet<Construction>();
        }

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }
        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; } = null!;
        public virtual ICollection<ConstructionCategory> ConstructionCategories { get; set; }
        public virtual ICollection<ConstructionStep> ConstructionSteps { get; set; }
        public virtual ICollection<Construction> Constructions { get; set; }
    }
}
