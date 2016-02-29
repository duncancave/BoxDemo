using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxDemo.Data.Entities;
using BoxDemo.Service;
using System.Collections.Generic;

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
    }
}
