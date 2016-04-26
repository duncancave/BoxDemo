namespace BoxDemo.Service.Interfaces
{
    using System.Collections.Generic;

    using BoxDemo.Data.Entities;

    public interface IPipeService
    {
        bool DoesPipeAcceptBox(Pipe pipe, Box box);

        List<Pipe> GetPipes();
    }
}
