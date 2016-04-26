namespace BoxDemo.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using BoxDemo.Data.Entities;
    using BoxDemo.Service.Interfaces;

    public class PipeService : IPipeService
    {
        /// <summary>
        /// Checks to see if the box contains the required stuff to go through the pipe
        /// </summary>
        /// <param name="pipe"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool DoesPipeAcceptBox(Pipe pipe, Box box)
        {
            var result = pipe.AllowedStuff.All(stuff => box.BunchOfStuff.Any(s => s.Type == stuff.Type));

            return result;
        }

        public List<Pipe> GetPipes()
        {
            return new List<Pipe>();
        }
    }
}
