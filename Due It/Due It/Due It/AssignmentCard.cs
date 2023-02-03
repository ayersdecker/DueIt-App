using System;
using System.Collections.Generic;
using System.Text;

namespace Due_It
{
    public class AssignmentCard
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public AssignmentCard()
        {
            Name = "Failure ot Load";
            Description = "Failure to Load";
        }
        public AssignmentCard(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
