using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUTZ_Capstone_Project
{
    internal class AutoLeaveStatusUpdate_HelperClass
    {
        public class LeaveStatusUpdateJob : IJob
        {
            public async Task Execute(IJobExecutionContext context)
            {
                try
                {
                    // SQL query to update leave status
                    string sql = @"UPDATE tbl_leave 
                           SET leave_status = 'completed' 
                           WHERE end_date < @currentDate AND leave_status = 'active'";

                    var parameters = new Dictionary<string, object>
            {
                { "@currentDate", DateTime.Now.Date }
            };

                    // Execute the update query asynchronously
                    bool result = await DB_OperationHelperClass.ExecuteCRUDSQLQueryAsync(sql, parameters);

                    if (result)
                    {
                        MessageBox.Show("Leave statuses updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update leave statuses.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in LeaveStatusUpdateJob: {ex.Message}");
                }
            }
        }
    }
}
