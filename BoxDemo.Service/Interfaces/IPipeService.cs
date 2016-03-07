using BoxDemo.Data.Entities;
using System.Collections.Generic;

namespace BoxDemo.Service.Interfaces
{
    public interface IPipeService
    {
        bool DoesPipeAcceptBox(Pipe pipe, Box box);

        List<Pipe> GetPipes();
    }
}
