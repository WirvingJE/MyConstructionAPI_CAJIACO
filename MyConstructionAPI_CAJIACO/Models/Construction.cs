using System;
using System.Collections.Generic;

namespace MyConstructionAPI_CAJIACO.Models
{
    public partial class Construction
    {
        public Construction()
        {
            ConstructionStepConstructionSteps = new HashSet<ConstructionStep>();
        }

        public int ProtocolId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? Active { get; set; }
        public int UserId { get; set; }
        public int ConstructionCategory { get; set; }

        public virtual ConstructionCategory? ConstructionCategoryNavigation { get; set; } = null!;
        public virtual User? User { get; set; } = null!;

        public virtual ICollection<ConstructionStep>? ConstructionStepConstructionSteps { get; set; }
    }
}
