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
            //Application.Run(new FormDashboard(1001)); // bypass
            Application.Run(new FormLogin());
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

                // Define the job and tie it to the LeaveStatusUpdateJob class
                IJobDetail job = JobBuilder.Create<AutoLeaveStatusUpdate_HelperClass.LeaveStatusUpdateJob>()
                    .WithIdentity("leaveStatusUpdateJob")
                    .Build();

                // Trigger the job to run immediately
                ITrigger immediateTrigger = TriggerBuilder.Create()
                    .WithIdentity("immediateTrigger")
                    .StartNow() // Trigger immediately
                    .Build();

                // Schedule the job using the immediate trigger
                await scheduler.ScheduleJob(job, immediateTrigger);

                // Trigger the job to run daily at 12:00 AM
                ITrigger dailyTrigger = TriggerBuilder.Create()
                    .WithIdentity("leaveStatusUpdateTrigger")
                    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(0, 0)) // Runs daily at 12:00 AM
                    .Build();

                // Schedule the daily job
                await scheduler.ScheduleJob(job, dailyTrigger);

                Console.WriteLine("Jobs scheduled successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting scheduler: {ex.Message}");
            }
            finally
            {
                // Optionally, handle scheduler shutdown gracefully when the application exits
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
