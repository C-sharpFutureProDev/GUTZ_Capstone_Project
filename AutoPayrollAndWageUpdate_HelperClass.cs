using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows;

namespace GUTZ_Capstone_Project
{
    internal class AutoPayrollAndWageUpdate_HelperClass
    {
        public class PayrollStatusUpdateJob : IJob
        {
            public async Task Execute(IJobExecutionContext context)
            {
                try
                {
                    DateTime currentDate = DateTime.Now.Date;

                    // Update payroll status to 'Completed'
                    string updateSql = @"UPDATE tbl_payroll 
                                         SET payroll_status = 'Completed' 
                                         WHERE CAST(pay_end_date AS DATE) <= @currentDate 
                                         AND payroll_status = 'In-Progress'";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@currentDate", currentDate }
                    };

                    bool statusUpdated = await DB_OperationHelperClass.ExecuteCRUDSQLQueryAsync(updateSql, parameters);

                    if (statusUpdated)
                    {
                        // Insert Completed Payroll Data
                        //await InsertCompletedPayrollData(currentDate);

                        // Generate and insert new payroll period
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in PayrollStatusUpdateJob: {ex.Message}");
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}