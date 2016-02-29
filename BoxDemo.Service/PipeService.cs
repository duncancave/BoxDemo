﻿using BoxDemo.Data.Entities;
using System.Linq;

namespace BoxDemo.Service
{
    public class PipeService
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
    }
}