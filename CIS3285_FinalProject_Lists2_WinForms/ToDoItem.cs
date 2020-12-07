using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject
{
    class ToDoItem : IListItem
    {
        Guid id;
        string activity;
        bool completedYN;

        public ToDoItem(string activity)
        {
            Id = Guid.NewGuid();
            this.Activity = activity;
            CompletedYN = false;
        }

        public ToDoItem(Guid id, string activity, bool completedYN)
        {
            this.id = id;
            this.activity = activity;
            this.completedYN = completedYN;
        }

        public Guid Id { get => id; set => id = value; }
        public string Activity { get => activity; set => activity = value; }
        public bool CompletedYN { get => completedYN; set => completedYN = value; }

        public bool IsChecked()
        {
            return CompletedYN;
        }

        public void markChecked()
        {
            CompletedYN = true;
        }

        public string Description { get => Activity; }

        public override string ToString()
        {
            return Activity;
        }

    }
}
