using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject
{
    class ToDoList
    {
        List<ToDoItem> toDoList;

        public ToDoList()
        {
            toDoList = new List<ToDoItem>();
        }

        public ToDoList(List<ToDoItem> newList)
        {
            toDoList = newList;
        }

        public void AddItem(ToDoItem newItem)
        {
            toDoList.Add(newItem);
        }

        public void CheckItem(IListItem item)
        {
            item.markChecked();
        }

        public IEnumerable<IListItem> GetUnPurchased()
        {
            List<ToDoItem> unpurchased = new List<ToDoItem>();
            foreach (ToDoItem item in toDoList)
            {
                if (!item.CompletedYN)
                {
                    unpurchased.Add(item);
                }
            }
            return unpurchased;
        }

        public IEnumerable<IListItem> GetItems()
        {
            List<ToDoItem> uncheckList = new List<ToDoItem>();

            foreach (ToDoItem item in toDoList)
            {
                if (!item.CompletedYN)
                {
                    uncheckList.Add(item);
                }
            }

            return uncheckList;
        }


    }
}
