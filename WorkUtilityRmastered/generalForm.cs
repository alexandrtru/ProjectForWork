using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WorkUtiliteRmastered
{
    public partial class generalForm : Form
    {
        public static SQLiteConnection sqlConnect = new SQLiteConnection("Data Source = " + Properties.Settings.Default.dbPath + "; version = 3"); //строка подключения к БД

        public generalForm()
        {
            createDataSource();
            setAdapters();
            getDataFromDatabase();
            createViewDevicesTable();
            createViewOrdersTable();

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = (60000 - (System.DateTime.Now.Millisecond + System.DateTime.Now.Second * 1000));
            timer.Start();

            InitializeComponent();
        }

        //открытие окна настроек
        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm s = new settingsForm();
            s.ShowDialog();
        }

        private void generalForm_Load(object sender, EventArgs e)
        {
            refreshDevicesView();
            createTasksView();
            createOrdersView();
            devicesFilter.SelectedIndex = 0;
            tasksFilter.SelectedIndex = 0;
            filterOrder.SelectedIndex = 0;
        }

        //фильтрация таблицы устройств
        private void devicesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (devicesDataView.DataSource != null)
            {
                BindingSource bs = devicesDataView.DataSource as BindingSource;

                switch (devicesFilter.SelectedIndex)
                {
                    case 0: bs.Filter = "issue = 0";
                        break;
                    case 1: bs.Filter = "issue = 1";
                        break;
                    case 2: bs.Filter = "";
                        break;
                    default: bs.Filter = "issue = 0";
                        break;
                }
            }
        }

        private void addDevBtn_Click(object sender, EventArgs e)
        {
            EditDevice ed = new EditDevice(null);
            if (ed.ShowDialog() == DialogResult.OK)
            {
                clientsDataAdapter.Update(data.Tables["clients"]);
                devicesDataAdapter.Update(data.Tables["devices"]);
                refreshDevicesView();
                (devicesDataView.DataSource as BindingSource).Filter = "issue = 0";
                devicesDataView.CurrentCell = devicesDataView[0, devicesDataView.RowCount - 1];
                if (MessageBox.Show("Распечатать квитанцию?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    printPreviewDialog.ShowDialog();
                }
            }
        }

        private void devicesDataView_SelectionChanged(object sender, EventArgs e)
        {
            if (devicesDataView.CurrentRow == null)
            {
                editDevBtn.Enabled = false;
                complDevBtn.Enabled = false;
                printDevBtn.Enabled = false;
            }
            else {
                editDevBtn.Enabled = true;
                complDevBtn.Enabled = true;
                printDevBtn.Enabled = true;
            }
        }

        private void editDevBtn_Click(object sender, EventArgs e)
        {
            edDev();
        }

        private void devicesDataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            edDev();
        }

        private void complDevBtn_Click(object sender, EventArgs e)
        {
            issueDev();
        }

        private void printDevBtn_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void printPreviewDialog_Load(object sender, EventArgs e)
        {
            ((Form)printPreviewDialog).WindowState = FormWindowState.Maximized;
        }

        private void devicesDataView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            devicesDataView.CurrentCell = devicesDataView[e.ColumnIndex, e.RowIndex];
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edDev();
        }

        private void выдатьВернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            issueDev();
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void searchDevBtn_Click(object sender, EventArgs e)
        {
            searchForm sc = new searchForm(devicesDataView.DataSource as BindingSource);
            sc.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (tasksDataView.CurrentRow != null)
            {
                editTaskBtn.Enabled = true;
                completeTaskBtn.Enabled = true;

                using (DataGridViewRow r = tasksDataView.CurrentRow)
                {
                    numberLabel.Text = r.Cells[0].Value.ToString();
                    dateLabel.Text = r.Cells["date"].Value.ToString();
                    taskNameLabel.Text = r.Cells["task"].Value.ToString();

                    switch (int.Parse(r.Cells["priory"].Value.ToString()))
                    {
                        case 0: prioryLabel.Text = "Срочное";
                            break;
                        case 1: prioryLabel.Text = "Не срочное";
                            break;
                        case 2: prioryLabel.Text = "Перманентное";
                            break;
                    }

                    completeToLabel.Text = r.Cells["complete_to"].Value.ToString();
                    if (bool.Parse(r.Cells["complete"].Value.ToString()))
                    {
                        statusLabel.Text = "Выполнено";
                    }
                    else
                    {
                        statusLabel.Text = "Не выполнено";
                    }
                    commentLabel.Text = r.Cells["comment"].Value.ToString();
                }
                taskInfo.Visible = true;
            }
            else
            {
                editTaskBtn.Enabled = false;
                completeTaskBtn.Enabled = false;
                taskInfo.Visible = false;
            }
        }

        private void sortTasksCmbBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tasksDataView.DataSource != null)
            {
                BindingSource bs = tasksDataView.DataSource as BindingSource;

                switch (tasksFilter.SelectedIndex)
                {
                    case 0: bs.Filter = "complete = 0";
                        break;
                    case 1: bs.Filter = "complete = 1";
                        break;
                    case 2: bs.Filter = "";
                        break;
                    default: bs.Filter = "complete = 0";
                        break;
                }
            }
        }

        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            addTask at = new addTask(null);
            if (at.ShowDialog() == DialogResult.OK)
            {
                tasksDataAdapter.Update(data.Tables["tasks"]);
            }
        }

        private void editTaskBtn_Click(object sender, EventArgs e)
        {
            editTask();
        }

        private void completeTaskBtn_Click(object sender, EventArgs e)
        {
            completeTask();
        }

        private void tasksDataView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            tasksDataView.CurrentCell = tasksDataView[e.ColumnIndex, e.RowIndex];
        }

        private void tasksDataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editTask();
        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editTask();
        }

        private void выполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            completeTask();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            orderForm o = new orderForm(null);
            if (o.ShowDialog() == DialogResult.OK)
            {
                clientsDataAdapter.Update(data.Tables["clients"]);
                ordersDataAdapter.Update(data.Tables["orders"]);
                createOrdersView();
            }
        }

        private void filterOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ordersDataView.DataSource != null) {
                BindingSource bs = ordersDataView.DataSource as BindingSource;

                switch (filterOrder.SelectedIndex)
                {
                    default: bs.Filter = "complete = 0";
                        break;
                    case 0: bs.Filter = "complete = 0";
                        break;
                    case 1: bs.Filter = "complete = 1";
                        break;
                    case 2: bs.Filter = "";
                        break;
                }
            }
        }

        private void ordersDataView_SelectionChanged(object sender, EventArgs e)
        {
            if (ordersDataView.CurrentRow != null)
            {
                editOrderBtn.Enabled = true;
                completeOrderBtn.Enabled = true;

                using (DataGridViewRow r = ordersDataView.CurrentRow)
                {
                    orderNumberLabel.Text = r.Cells["id"].Value.ToString();
                    orderDate.Text = r.Cells["date"].Value.ToString();
                    orderLabel.Text = r.Cells["order"].Value.ToString();
                    countOrderLabel.Text = r.Cells["count"].Value.ToString()+ " шт.";
                    clientOrder.Text = r.Cells["client"].Value.ToString() + " тел: " + r.Cells["tel"].Value.ToString();
                    if (bool.Parse(r.Cells["complete"].Value.ToString()))
                    {
                        statusOrder.Text = "Выполнен";
                    }
                    else
                    {
                        statusOrder.Text = "Не выполнен";
                    }
                    commentOrder.Text = r.Cells["comment"].Value.ToString(); 
 
                }
                orderInfo.Visible = true;
            }
            else
            {
                editOrderBtn.Enabled = false;
                completeOrderBtn.Enabled = false;
            }
        }

        private void editOrderBtn_Click(object sender, EventArgs e)
        {
            editOrder();
        }

        private void ordersDataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editOrder();
        }

        private void completeOrderBtn_Click(object sender, EventArgs e)
        {
            completeOrder();
        }

        private void редактироватьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            editOrder();
        }

        private void выполнитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            completeOrder();
        }

        private void ordersDataView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            ordersDataView.CurrentCell = ordersDataView[e.ColumnIndex, e.RowIndex];
        }

        private void editTaskBtn1_Click(object sender, EventArgs e)
        {
            edDev();
        }

        private void completeTaskBtn1_Click(object sender, EventArgs e)
        {
            completeTask();
        }

        private void editOrderBtn1_Click(object sender, EventArgs e)
        {
            editOrder();
        }

        private void completeOrderBtn1_Click(object sender, EventArgs e)
        {
            completeOrder();
        }

    }
}
