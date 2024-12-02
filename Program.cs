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
            Application.Run(new FormDashboard(1001)); // bypass
            //Application.Run(new FormLogin()); // bypass

        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]

        private static extern bool SetProcessDPIAware();

        private static async Task StartScheduler()
        {
            try
            {
                // Create a new scheduler
                IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                await scheduler.Start();

                // Define the job and tie it to the LeaveStatusUpdateJob class
                IJobDetail job = JobBuilder.Create<AutoLeaveStatusUpdate_HelperClass.LeaveStatusUpdateJob>()
                    .WithIdentity("leaveStatusUpdateJob")
                    .Build();

                // Trigger the job to run every day at a specific time (e.g., 12:00 AM)
                ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("leaveStatusUpdateTrigger")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(0, 0)) // Runs daily at 12:00 AM
                .Build();

                // Schedule the job using the trigger
                await scheduler.ScheduleJob(job, trigger);
                //Console.WriteLine("Job scheduled successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting scheduler: {ex.Message}");
            }
        }
    }
}
