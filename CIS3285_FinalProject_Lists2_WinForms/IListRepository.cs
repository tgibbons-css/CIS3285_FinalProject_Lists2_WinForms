using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject
{
    public interface IListRepository
    {

        //void createItem(IListItem item);
        List<IListItem> ReadAll();
        void UpdateChecked(Guid id);

    }
}
