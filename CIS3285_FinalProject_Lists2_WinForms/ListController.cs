using System;
using System.Collections.Generic;
using System.Text;

namespace CIS3285_FinalProject
{
    /// <summary>
    /// The list controller is used by the UI Form to manage the list. 
    /// This should contain all the busness and control login for managing the list.
    /// It makes use of the ShoppingList to hold the actual list
    /// </summary>
    public class ListController
    {
        public ItemList itemList;
        public IListRepository itemDbRepository;

        public ListController(IListRepository itemDbRepository)
        {
            // Read the initial list from the database repository
            this.itemDbRepository = itemDbRepository;
            
            itemList = new ItemList(itemDbRepository.ReadAll());
        }
        public void AddItem(IListItem newItem)
        {
            itemList.AddItem(newItem);
        }

        public IEnumerable<IListItem> GetListItems()
        {
            return itemList.GetUnChecked();
        }

        public void MarkItemAsChecked(IListItem item)
        {
            itemList.CheckItem(item);
            itemDbRepository.UpdateChecked(item.Id);
        }
    }
}
