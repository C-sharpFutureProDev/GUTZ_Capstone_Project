using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project.Forms
{
    public partial class FormEmployeeProfiling : Form
    {
        public FormEmployeeProfiling()
        {
            InitializeComponent();
            System.Data.DataTable dataTable = new System.Data.DataTable();

            // Add the required columns to the DataTable
            dataTable.Columns.Add("Image", typeof(Bitmap));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Agent Code", typeof(string));
            dataTable.Columns.Add("Department", typeof(string));
            dataTable.Columns.Add("Job Description", typeof(string));
            dataTable.Columns.Add("Hire Date", typeof(DateTime));

            // Generate some dummy data and add it to the DataTable
            for (int i = 1; i <= 10; i++)
            {
                // Load the image from the downloads folder
                Bitmap userImage = new Bitmap("C:\\Users\\User\\Downloads\\264692019_231225682454241_3629721876682858121_n.jpg");

                dataTable.Rows.Add(
                    userImage,
                    $"Employee {i}",
                    i,
                    $"AC{i:D3}",
                    $"Department {i % 3 + 1}",
                    $"Job Description {i}",
                    new DateTime(2020, 1, 1).AddDays(i * 30)
                );
            }


            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private void FormEmployeeProfiling_Load(object sender, EventArgs e)
        {
            AjustDataGridViewHeight();
        }

        private void AjustDataGridViewHeight()
        {
            var heigth = dataGridView1.ColumnHeadersHeight;
            foreach(DataGridViewRow dr in dataGridView1.Rows)
            {
                heigth += dr.Height;
            }
            dataGridView1.Height = heigth;
        }
    }
}
