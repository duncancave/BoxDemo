namespace BoxDemo.Test
{
    using System;
    using System.Collections.Generic;

    using BoxDemo.Data.Entities;
    using BoxDemo.Service;
    using BoxDemo.Service.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class ServiceTests
    {
        private PipeService PipeService { get; set; }

        [TestInitialize]
        public void Setup()
        {
            this.PipeService = new PipeService();
        }

        [TestMethod]
        public void PipeAcceptsBox()
        {
            // Arrange
            var box = new Box();
            var stuffForBox = new List<Stuff>
                                  {
                                      new Stuff { Id = Guid.NewGuid(), Name = "Cheese", Type = Core.Enums.StuffType.Small },
                                      new Stuff { Id = Guid.NewGuid(), Name = "Hammer", Type = Core.Enums.StuffType.Large }
                                  };

            box.BunchOfStuff = stuffForBox;

            var pipe = new Pipe();
            var allowedStuff = new List<Stuff>
                                   {
                                       new Stuff { Id = Guid.NewGuid(), Name = "Cheese", Type = Core.Enums.StuffType.Small }
                                   };

            pipe.AllowedStuff = allowedStuff;

            // Act
            var result = this.PipeService.DoesPipeAcceptBox(pipe, box);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void PipeRejectsBox()
        {
            // Arrange
            var box = new Box();
            var stuffForBox = new List<Stuff>
                                  {
                                      new Stuff { Id = Guid.NewGuid(), Name = "Hammer", Type = Core.Enums.StuffType.Large }
                                  };

            box.BunchOfStuff = stuffForBox;

            var pipe = new Pipe();
            var allowedStuff = new List<Stuff>
                                   {
                                       new Stuff { Id = Guid.NewGuid(), Name = "Cheese", Type = Core.Enums.StuffType.Small }
                                   };

            pipe.AllowedStuff = allowedStuff;

            // Act
            var result = this.PipeService.DoesPipeAcceptBox(pipe, box);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GetLivePipes()
        {
            // Arrange
            var mock = new Mock<IPipeService>();
            mock.Setup(m => m.GetPipes()).Returns(new List<Pipe>
            {
                new Pipe
                {
                    Name = "Pipe 1",
                    AllowedStuff = new List<Stuff>
                    {
                        new Stuff { Id = Guid.NewGuid(), Name = "Cheese", Type = Core.Enums.StuffType.Small }
                    }
                },
                new Pipe
                {
                    Name = "Pipe 2",
                    AllowedStuff = new List<Stuff>
                    {
                        new Stuff { Id = Guid.NewGuid(), Name = "Hammer", Type = Core.Enums.StuffType.Large }
                    }
                }
            });

            // Act
            var result = mock.Object.GetPipes();

            // Assert
            Assert.AreEqual(2, result.Count);
        }
    }
}
