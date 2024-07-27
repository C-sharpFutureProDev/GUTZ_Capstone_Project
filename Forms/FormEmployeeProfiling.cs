using Guna.UI2.WinForms;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project.Forms
{
    public partial class FormEmployeeProfiling : Form
    {
        public FormEmployeeProfiling()
        {
            InitializeComponent();
            this.DGVEmployee.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | 
                BindingFlags.NonPublic).SetValue(DGVEmployee, true, null);
            this.DGVEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            //this.DGVEmployee.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;

            // Create a custom button cell 
            Column8.CellTemplate.Style.Font = new Font("Arial", 9f, FontStyle.Bold);
            Column9.CellTemplate.Style.Font = new Font("Arial", 9f, FontStyle.Bold);
        }

        private void FormEmployeeProfiling_Load(object sender, EventArgs e)
        {
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
            DGVEmployee.DataSource = dataTable;
        }
    }
}
