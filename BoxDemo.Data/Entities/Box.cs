namespace BoxDemo.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Box
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Stuff> BunchOfStuff { get; set; }
    }
}
