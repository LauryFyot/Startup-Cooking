using ProjetNotrePetiteCuisine.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProjetNotrePetiteCuisine.GUI.Windows
{
    /// <summary>
    /// Interaction logic for ProgressBar.xaml
    /// </summary>
    public partial class DatabasePopulateProgressBar : Window
    {

        private BackgroundWorker worker = new BackgroundWorker();
        private Database database;
        private bool populateDatabase;
        private float progress = 0;

        public DatabasePopulateProgressBar(Database database, bool populateDatabase)
        {
            this.database = database;
            this.populateDatabase = populateDatabase;
            InitializeComponent();
            this.DataContext = this;
        }

        public void ChangeStepTitle(string title)
        {
            this.AddProgress();
            Task.Run(() =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.currentTaskTitle.Content = title;
                }), DispatcherPriority.Render);
            });
        }

        private void AddProgress()
        {
            this.progress += 1.86f;
            this.worker.ReportProgress((int) this.progress);
        }

        public void ReportMaxProgress()
        {
            this.worker.ReportProgress(int.MaxValue);
        }

        public void Start()
        {
            this.worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            this.worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DatabasePopulate.Initialize(this.database, this, this.populateDatabase);

            this.Dispatcher.Invoke(() =>
            {
                this.Close();
            });
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbStatus.Value = e.ProgressPercentage;
        }

    }
}
