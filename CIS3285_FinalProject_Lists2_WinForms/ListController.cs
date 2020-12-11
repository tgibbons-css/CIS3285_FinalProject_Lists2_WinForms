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
    class ListController
    {
        private ItemList itemList;
        private IListRepository itemDbRepository;

        public ListController(IListRepository itemDbRepository)
        {
            // Read the initial list from the database repository
            this.itemDbRepository = itemDbRepository;
            
            itemList = new ItemList(itemDbRepository.ReadAll());
        }
        public void AddItem(IListItem newItem)
        {
            itemList.AddItem(newItem);
            //itemDbRepository.createItem(newItem);
        }

        public IEnumerable<IListItem> GetListItems()
        {
            return itemList.GetAllItems();
        }

        public void MarkItemAsChecked(IListItem item)
        {
            itemList.CheckItem(item);
            ShoppingItem i = (ShoppingItem)item;
            itemDbRepository.updateChecked(item.Id);
        }
    }
}
