using Microsoft.VisualStudio.TestTools.UnitTesting;
using CIS3285_FinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject.Tests
{
    [TestClass()]
    public class ToDoItemTests
    {
        [TestMethod()]
        public void ToDoConstrutorSetsCheckedFalse()
        {
            // Arrange 
            bool isFalse = false;
            ToDoItem testItem = new ToDoItem("test activity");
            // Act
            bool result = testItem.IsChecked();
            // Assert
            Assert.AreEqual(result, isFalse);
        }

        [TestMethod()]
        public void ToDoConstrutorCreatesNewGuid()
        {
            // Arrange 
            ToDoItem testItem = new ToDoItem("test activity");
            // Act
            Guid resultId = testItem.Id;
            // Assert
            Assert.IsNotNull(resultId);
        }

        [TestMethod()]
        public void IsCheckedTrue()
        {
            // Arrange 
            bool isTrue = true;
            ToDoItem testItem = new ToDoItem(Guid.NewGuid(), "test activity", isTrue);
            // Act
            bool result = testItem.IsChecked();
            // Assert
            Assert.AreEqual(result, isTrue);
        }

        [TestMethod()]
        public void IsCheckedFalse()
        {
            // Arrange 
            bool isFalse = false;
            ToDoItem testItem = new ToDoItem(Guid.NewGuid(), "test activity", isFalse);
            // Act
            bool result = testItem.IsChecked();
            // Assert
            Assert.AreEqual(result, isFalse);
        }

        [TestMethod()]
        public void ToDoMarkChecked()
        {
            // Arrange 
            ToDoItem testItem = new ToDoItem("test activity");
            // Act
            testItem.markChecked();
            bool result = testItem.IsChecked();
            // Assert
            Assert.IsTrue(result);
        }

    }
}