using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl;
using static GUTZ_Capstone_Project.DB_OperationHelperClass;

namespace GUTZ_Capstone_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start the Quartz scheduler
            StartScheduler().GetAwaiter().GetResult();

            // Run the application
            Application.Run(new FormDashboard("1026")); // bypass
           //Application.Run(new FormLogin());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private static async Task StartScheduler()
        {
            IScheduler scheduler = null;
            try
            {
                // Create a new scheduler
                scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                await scheduler.Start();

                // Schedule LeaveStatusUpdateJob
                IJobDetail leaveJob = JobBuilder.Create<AutoLeaveStatusUpdate_HelperClass.LeaveStatusUpdateJob>()
                    .WithIdentity("leaveStatusUpdateJob")
                    .Build();

                ITrigger leaveTrigger = TriggerBuilder.Create()
                    .WithIdentity("leaveStatusUpdateTrigger")
                    .StartNow() // Trigger immediately
                    .Build();

                await scheduler.ScheduleJob(leaveJob, leaveTrigger);

                // Schedule PayrollStatusUpdateJob
                /*IJobDetail payrollJob = JobBuilder.Create<AutoPayrollAndWageUpdate_HelperClass.PayrollStatusUpdateJob>()
                    .WithIdentity("payrollStatusUpdateJob")
                    .Build();

                ITrigger payrollTrigger = TriggerBuilder.Create()
                    .WithIdentity("payrollStatusUpdateTrigger")
                    .StartNow() // Trigger immediately
                    .Build();

                await scheduler.ScheduleJob(payrollJob, payrollTrigger);
                */

                Console.WriteLine("Jobs scheduled successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting scheduler: {ex.Message}");
            }
            finally
            {
                Application.ApplicationExit += async (s, e) =>
                {
                    if (scheduler != null)
                    {
                        await scheduler.Shutdown();
                    }
                };
            }
        }
    }
}