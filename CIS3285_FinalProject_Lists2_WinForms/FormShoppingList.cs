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
    public partial class FormShoppingList : Form
    {
        ListController listController;
        FormToDoList formToDo;

        public FormShoppingList()
        {
            InitializeComponent();
            formToDo = new FormToDoList();
            formToDo.setParentForm(this);
            listController = new ListController();
            updateListBox();
        }

        private void buttonAddToList_Click(object sender, EventArgs e)
        {
            string name = textBoxItemName.Text.ToString();
            int amount = Int32.Parse(textBoxItemAmount.Text);
            listController.CreateshoppingItem(name, amount);

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

        private void buttonToDoForm_Click(object sender, EventArgs e)
        {
            formToDo.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
