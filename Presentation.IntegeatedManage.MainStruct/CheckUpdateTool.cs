using NAppUpdate.Framework;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Sources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsSampleApp;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct
{
    public class CheckUpdateTool
    {
        private static Timer _resetCheckedState;
        public static void Run()
        {
            // UpdateManager initialization
            UpdateManager updManager = UpdateManager.Instance;
            updManager.UpdateSource = new SimpleWebSource("http://www.kangli.com/Update/SampleUpdateFeed.xml");
            updManager.Config.TempFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Presentation.IntegeatedManage.MainStruct\\Updates");
            // If you don't call this method, the updater.exe will continually attempt to connect the named pipe and get stuck.
            // Therefore you should always implement this method call.
            updManager.ReinstateIfRestarted();

            // Create a timer for reseting the update state
            _resetCheckedState = new Timer
            {
                Interval = 60000
            };
            _resetCheckedState.Tick += (sender, ea) =>
            {
                if (UpdateManager.Instance.State != UpdateManager.UpdateProcessState.Checked) return;
                UpdateManager.Instance.CleanUp();
                //lblStatus.Text = DateTime.Now + " - Update state was reset to NotChecked";
            };
            _resetCheckedState.Start();
            btnCheckForUpdates_Click();
            btnPrepareUpdates_Click();
        }
        private static void btnCheckForUpdates_Click()
        {
            // For the purpose of this demonstration, we are loading the update feed from a local file and passing
            // it to UpdateManager using MemorySource.
            // Without passing this IUpdateSource object to CheckForUpdates, it will attempt to retrieve an
            // update feed from the feed URL specified in SimpleWebSource (which we did not provide)
            //string feedXml = File.ReadAllText("SampleUpdateFeed.xml");
            //IUpdateSource feedSource = new MemorySource(feedXml);
            IUpdateSource feedSource = new SimpleWebSource("http://www.kangli.com/Update/SampleUpdateFeed.xml");
            CheckForUpdates(feedSource);
        }
        private static void btnCheckForUpdatesCustom_Click()
        {
            string feedUrl = InputBox("Please enter a Url for a valid NauXml feed", "Feed Url required", "");

            if (string.IsNullOrEmpty(feedUrl)) return;

            IUpdateSource source = UpdateManager.Instance.UpdateSource;
            if (source is SimpleWebSource)
            {
                // All we need to do is set the feed url and we are all set, no need to create new objects etc
                ((SimpleWebSource)source).FeedUrl = feedUrl;
                CheckForUpdates(source);
            }
            else
            {
                // No idea what we had there, so we create a new feed source and pass it along - note the
                // source for retreiving the actual updates will keep intact, and will be used when preparing
                // the updates
                source = new SimpleWebSource(feedUrl);
                CheckForUpdates(source);
            }
        }

        private static void CheckForUpdates(IUpdateSource source)
        {
            // Get a local pointer to the UpdateManager instance
            UpdateManager updManager = UpdateManager.Instance;

            // Only check for updates if we haven't done so already
            if (updManager.State != UpdateManager.UpdateProcessState.NotChecked)
            {
                MessageBox.Show("Update process has already initialized; current state: " + updManager.State.ToString());
                return;
            }

            try
            {
                // Check for updates - returns true if relevant updates are found (after processing all the tasks and
                // conditions)
                // Throws exceptions in case of bad arguments or unexpected results
                updManager.CheckForUpdates(source);
            }
            catch (Exception ex)
            {
                if (ex is NAppUpdateException)
                {
                    // This indicates a feed or network error; ex will contain all the info necessary
                    // to deal with that
                }
                else MessageBox.Show(ex.ToString());
                return;
            }


            if (updManager.UpdatesAvailable == 0)
            {
                MessageBox.Show("Your software is up to date");
                return;
            }

            DialogResult dr = MessageBox.Show(string.Format("Updates are available to your software ({0} total). Do you want to download and prepare them now? You can always do this at a later time.", updManager.UpdatesAvailable), "Software updates available", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes) updManager.BeginPrepareUpdates(OnPrepareUpdatesCompleted, null);
        }

        private static void btnPrepareUpdates_Click()
        {
            UpdateManager updManager = UpdateManager.Instance;

            if (updManager.State != UpdateManager.UpdateProcessState.Checked)
            {
                MessageBox.Show("Cannot prepare updates at the current state: " + updManager.State.ToString());
                return;
            }

            if (updManager.UpdatesAvailable == 0)
            {
                MessageBox.Show("There are no updates to prepare");
                return;
            }

            updManager.BeginPrepareUpdates(OnPrepareUpdatesCompleted, null);
        }

        private static void btnInstallUpdates_Click()
        {
            UpdateManager updManager = UpdateManager.Instance;

            if (updManager.State != UpdateManager.UpdateProcessState.Prepared)
            {
                MessageBox.Show("Cannot install updates at the current state, they need to be prepared first. Current state is " + updManager.State.ToString());
                return;
            }

            //updManager.ApplyUpdates(chkRelaunch.Checked, chkLogging.Checked, chkShowConsole.Checked);
            updManager.ApplyUpdates(true, true, true);
        }

        private static void OnPrepareUpdatesCompleted(IAsyncResult asyncResult)
        {
            try
            {
                ((UpdateProcessAsyncResult)asyncResult).EndInvoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Updates preperation failed. Check the feed and try again.{0}{1}", Environment.NewLine, ex));
                return;
            }

            // Get a local pointer to the UpdateManager instance
            UpdateManager updManager = UpdateManager.Instance;

            DialogResult dr = MessageBox.Show("Updates are ready to install. Do you wish to install them now?", "Software updates ready", MessageBoxButtons.YesNo);

            if (dr != DialogResult.Yes) return;
            // This is a synchronous method by design, make sure to save all user work before calling
            // it as it might restart your application
            try
            {
                //updManager.ApplyUpdates(chkRelaunch.Checked, chkLogging.Checked, chkShowConsole.Checked);
                updManager.ApplyUpdates(true, true, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error while trying to install software updates{0}{1}", Environment.NewLine, ex));
            }
        }
        private static void btnRollback_Click()
        {
            if (UpdateManager.Instance.State != UpdateManager.UpdateProcessState.RollbackRequired)
            {
                MessageBox.Show("There is no failed update process to rollback; current state: " + UpdateManager.Instance.State.ToString());
                return;
            }

            UpdateManager.Instance.RollbackUpdates();
        }

        /// <summary>
        /// Replacement for VB InputBox, returns user input string.
        /// </summary>
        /// <returns>string</returns>
        private static string InputBox(string prompt, string title, string defaultValue)
        {
            frmInputBoxDialog ib = new frmInputBoxDialog
            {
                FormPrompt = prompt,
                FormCaption = title,
                DefaultValue = defaultValue
            };
            ib.ShowDialog();
            string s = ib.InputResponse;
            ib.Close();
            return s;
        }
    }
}
