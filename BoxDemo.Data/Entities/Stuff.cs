using BoxDemo.Core.Enums;
using System;

namespace BoxDemo.Data.Entities
{
    public class Stuff
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public StuffType Type { get; set; }
    }
}
