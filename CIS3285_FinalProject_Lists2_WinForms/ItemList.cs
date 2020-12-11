using System;
using System.Collections.Generic;
using System.Text;

namespace CIS3285_FinalProject
{
    class ItemList
    {
        List<IListItem> itemList;

        public ItemList()
        {
            itemList = new List<IListItem>();
        }

        public ItemList(List<IListItem> newList)
        {
            itemList = newList;
        }

        public void AddItem(IListItem newItem)
        {
            itemList.Add(newItem);
        }

        public void CheckItem(IListItem item)
        {
            item.markChecked();
        }

        public IEnumerable<IListItem> GetUnChecked()
        {
            List<IListItem> unpurchased = new List<IListItem>();
            foreach (IListItem item in itemList)
            {
                if (!item.IsChecked())
                {
                    unpurchased.Add(item);
                }
            }
            return unpurchased;
        }

        public IEnumerable<IListItem> GetAllItems ( )
        {           
            return itemList;
        }

    }
}
