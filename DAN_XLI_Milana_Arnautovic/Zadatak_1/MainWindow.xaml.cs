using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadatak_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static BackgroundWorker worker = new BackgroundWorker();

        string number { get; set; }
        string print { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
            Percentage.Content = e.ProgressPercentage.ToString() + "%";
        }


        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            bool isValid = int.TryParse(number, out int numOfCopies);


            int percentage;
            int sum = 0;


            for (int i = 1; i <= numOfCopies; i++)
            {
                Thread.Sleep(1000);
                percentage = 100 / numOfCopies;
                sum = sum + percentage;
                worker.ReportProgress(sum);

                if (worker.CancellationPending)
                {
                    e.Cancel = true;

                    worker.ReportProgress(0);
                    return;
                }


                string path = "../../" + i + "." + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + ".txt";


                File.WriteAllText(path, print);
            }

            e.Result = sum;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Message.Content = "Processing cancelled";
            }
            else if (e.Error != null)
            {
                Message.Content = e.Error.Message;
            }
            else
            {
                Message.Content = e.Result.ToString();
            }
        }

        private void Printing_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
