using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject
{
    class ToDoListController
    {
        private ToDoList toDoList;
        private ToDoItemRepository itemDbRepository;

        public ToDoListController()
        {
            // Read the initial list from the database repository
            itemDbRepository = new ToDoItemRepository();
            toDoList = new ToDoList(itemDbRepository.ReadAll());
        }
        public void CreateToDoItem(string Activity)
        {
            ToDoItem newItem = new ToDoItem(Activity);
            toDoList.AddItem(newItem);
            itemDbRepository.createItem(newItem);
        }

        public IEnumerable<IListItem> GetListItems()
        {
            return toDoList.GetItems();
        }

        public void MarkItemAsChecked(IListItem item)
        {
            toDoList.CheckItem(item);
            ToDoItem i = (ToDoItem)item;
            itemDbRepository.updateChecked(item.Id);
        }
    }
}
