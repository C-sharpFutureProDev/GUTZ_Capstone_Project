﻿using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
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
                    // Log the current date for debugging
                    DateTime currentDate = DateTime.Now.Date;

                    // SQL query to update leave status
                    string sql = @"UPDATE tbl_leave 
                                   SET leave_status = 'Completed' 
                                   WHERE CAST(end_date AS DATE) <= @currentDate AND leave_status = 'Active'";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@currentDate", currentDate }
                    };

                    // Execute the update query asynchronously
                    bool result = await DB_OperationHelperClass.ExecuteCRUDSQLQueryAsync(sql, parameters);

                    if (result)
                    {
                        // cut payroll implementation
                    }
                    else
                    {
                        //  log failed automated payroll cut
                    }
                }
                catch (Exception ex)
                {
                    // Log the error message for debugging
                    Console.WriteLine($"Error in LeaveStatusUpdateJob: {ex.Message}");
                }
            }
        }
    }
}