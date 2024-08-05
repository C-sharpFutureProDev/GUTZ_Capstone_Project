using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project.Forms
{
    public partial class FormAttendanceMonitoring : Form
    {
        public FormAttendanceMonitoring()
        {
            InitializeComponent();
        }

        private void FormAttendanceMonitoring_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            // Add the required columns to the DataTable
            dataTable.Columns.Add("Image", typeof(Bitmap));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Agent Code", typeof(string));
            dataTable.Columns.Add("Current Shift", typeof(string));
            dataTable.Columns.Add("Time-In", typeof(string));
            dataTable.Columns.Add("Status", typeof(string));
            dataTable.Columns.Add("Time-Out", typeof(string));
            dataTable.Columns.Add("Dial Hours", typeof(string));

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
                    $" Evening",
                    $" 07-31-24 at 7:02 pm",
                    $" Present",
                    $" Pending",
                    $" Pending"
                );
            }

            // Bind the DataTable to the DataGridView
            DGVAttendance.DataSource = dataTable;
        }
    }
}
