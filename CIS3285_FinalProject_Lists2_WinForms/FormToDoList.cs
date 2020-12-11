using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS3285_FinalProject
{
    public partial class FormToDoList : Form
    {
        ListController listController;
        ToDoItemRepository toDoRepo;
        FormShoppingList parentForm;
        public FormToDoList()
        {
            InitializeComponent();
            toDoRepo = new ToDoItemRepository();
            listController = new ListController(toDoRepo);
            updateListBox();
        }

        private void buttonAddToList_Click(object sender, EventArgs e)
        {
            string name = textBoxActivity.Text.ToString();
            IListItem newItem = toDoRepo.CreateToDoItem(name);
            listController.AddItem(newItem);

            updateListBox();
        }
        private void updateListBox()
        {
            IEnumerable<IListItem> items = listController.GetListItems();

            listBox1.Items.Clear();
            listBox1.DisplayMember = "Description";
            listBox1.ValueMember = "Id";
            foreach (IListItem item in items)
            {
                listBox1.Items.Add(item);
            }

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            IListItem selectedItem = (IListItem)listBox1.SelectedItem;
            listController.MarkItemAsChecked(selectedItem);

            updateListBox();
        }

        public void setParentForm(FormShoppingList parentForm)
        {
            this.parentForm = parentForm;
        }

        private void buttonShopping_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
