namespace BoxDemo.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Pipe
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Stuff> AllowedStuff { get; set; }
    }
}
