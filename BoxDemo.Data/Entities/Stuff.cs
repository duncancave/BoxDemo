namespace BoxDemo.Data.Entities
{
    using System;

    using BoxDemo.Core.Enums;

    public class Stuff
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public StuffType Type { get; set; }
    }
}
