using System;
using System.Collections.Generic;

namespace MyConstructionAPI_CAJIACO.Models
{
    public partial class ConstructionStep
    {
        public ConstructionStep()
        {
            ConstructionProtocols = new HashSet<Construction>();
        }

        public int ConstructionStepsId { get; set; }
        public string Step { get; set; } = null!;
        public string? Description { get; set; }
        public int UserId { get; set; }

        public virtual User? User { get; set; } = null!;

        public virtual ICollection<Construction>? ConstructionProtocols { get; set; }
    }
}
