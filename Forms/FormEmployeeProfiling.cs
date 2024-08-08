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
            // Clear the selection after initialization
            this.DGVEmployee.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | 
                BindingFlags.NonPublic).SetValue(DGVEmployee, true, null);
            this.DGVEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);

            // Create a custom button cell 
            Column8.CellTemplate.Style.Font = new Font("Arial", 9f, FontStyle.Bold);
            Column9.CellTemplate.Style.Font = new Font("Arial", 9f, FontStyle.Bold);
        }

        private void FormEmployeeProfiling_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            // Add the required columns to the DataTable
            dataTable.Columns.Add("Image", typeof(Bitmap));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Agent Code", typeof(string));
            dataTable.Columns.Add("Department", typeof(string));
            dataTable.Columns.Add("Job Description", typeof(string));
            dataTable.Columns.Add("Hire Date", typeof(DateTime));

            // Generate some dummy data and add it to the DataTable
            for (int i = 1001; i <= 1012; i++)
            {
                // Load the image from the downloads folder
                Bitmap userImage = new Bitmap("C:\\Users\\User\\Downloads\\264692019_231225682454241_3629721876682858121_n.jpg");

                dataTable.Rows.Add(
                    userImage,
                    $" Orlando Jaso",
                     i,
                    $" GUTZ-Orlando",
                    $" BPO Dept.",
                    $" Call Center Agent",
                     new DateTime(2024, 1, 1)
                );
            }

            // Bind the DataTable to the DataGridView
            DGVEmployee.DataSource = dataTable;
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            FormEmployeeEnrollment formEmployeeEnrollment = new FormEmployeeEnrollment();
            formEmployeeEnrollment.ShowDialog(this);
        }
    }
}
