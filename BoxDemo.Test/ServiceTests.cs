using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxDemo.Data.Entities;
using BoxDemo.Service;
using System.Collections.Generic;
using Moq;
using BoxDemo.Service.Interfaces;

namespace BoxDemo.Test
{
    [TestClass]
    public class ServiceTests
    {
        private PipeService pipeService { get; set; }

        [TestInitialize]
        public void Setup()
        {
            pipeService = new PipeService();
        }

        [TestMethod]
        public void PipeAcceptsBox()
        {
            // Arrange
            var box = new Box();
            var stuffForBox = new List<Stuff>();
            stuffForBox.Add(new Stuff { Id = Guid.NewGuid(), Name = "Cheese", Type = Core.Enums.StuffType.Small });
            stuffForBox.Add(new Stuff { Id = Guid.NewGuid(), Name = "Hammer", Type = Core.Enums.StuffType.Large });

            box.BunchOfStuff = stuffForBox;

            var pipe = new Pipe();
            var allowedStuff = new List<Stuff>();
            allowedStuff.Add(new Stuff { Id = Guid.NewGuid(), Name = "Cheese", Type = Core.Enums.StuffType.Small });

            pipe.AllowedStuff = allowedStuff;

            // Act
            var result = pipeService.DoesPipeAcceptBox(pipe, box);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void PipeRejectsBox()
        {
            // Arrange
            var box = new Box();
            var stuffForBox = new List<Stuff>();
            stuffForBox.Add(new Stuff { Id = Guid.NewGuid(), Name = "Hammer", Type = Core.Enums.StuffType.Large });

            box.BunchOfStuff = stuffForBox;

            var pipe = new Pipe();
            var allowedStuff = new List<Stuff>();
            allowedStuff.Add(new Stuff { Id = Guid.NewGuid(), Name = "Cheese", Type = Core.Enums.StuffType.Small });

            pipe.AllowedStuff = allowedStuff;

            // Act
            var result = pipeService.DoesPipeAcceptBox(pipe, box);

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
