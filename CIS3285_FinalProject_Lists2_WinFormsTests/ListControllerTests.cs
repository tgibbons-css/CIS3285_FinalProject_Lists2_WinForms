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
    public class ListControllerTests
    {
        [TestMethod()]
        public void ListControllerTest()
        {
            // Arrange 
            MockRepo repo = new MockRepo();
            ListController ctrl = new ListController(repo);
            // Act
            IEnumerable<IListItem> testList = ctrl.GetListItems();
            int size = testList.Count();
            // Assert
            Assert.AreEqual(size, 2);
        }

        [TestMethod()]
        public void AddItemTest()
        {
            // Arrange 
            MockRepo repo = new MockRepo();
            ListController ctrl = new ListController(repo);
            IEnumerable<IListItem> testList1 = ctrl.GetListItems();
            int size1 = testList1.Count();
            // Act
            ctrl.AddItem(new ToDoItem("test 333"));
            IEnumerable<IListItem> testList2 = ctrl.GetListItems();
            int size2 = testList2.Count();
            // Assert
            Assert.AreEqual(size1 + 1, size2);
        }

    }

    internal class MockRepo : IListRepository
    {
        // A mock repo run in memory w/o databaes access
        // creates a repo with two sample items
        List<IListItem> testList;

        public MockRepo()
        {
            testList = new List<IListItem>();
            IListItem testItem1 = new ToDoItem("test 111");
            IListItem testItem2 = new ToDoItem("test 222");
            testList.Add(testItem1);
            testList.Add(testItem2);
        }

        public List<IListItem> ReadAll()
        {
            return testList;
        }

        public void UpdateChecked(Guid id)
        {
            if (testList[0].Id==id)
            {
                testList[0].markChecked();
            }

        }
    }
}