using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject
{
    interface IListRepository
    {

        //void createItem(IListItem item);
        List<IListItem> ReadAll();
        void updateChecked(Guid id);

    }
}
