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
        /// <summary>
        /// Method for displaying progress bar work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
            Percentage.Content = e.ProgressPercentage.ToString() + "%";
        }


        /// <summary>
        /// Method for calculating the percentage of completion and creating files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            bool a = int.TryParse(this.number, out int number);
            
            int percentage;
            int sum = 0;


            for (int i = 1; i <= number; i++)
            {
                Thread.Sleep(1000);
                percentage = 100 / number;
                sum = sum + percentage;
                worker.ReportProgress(sum);

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    worker.ReportProgress(0);
                                   
                
                return;
                }


                string path = "../../" + i + "." + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute;


                File.WriteAllText(path, print);
            }

            e.Result = sum;
            


        }
        /// <summary>
        /// Method for displaying result message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Label.Content = "Processing cancelled";
            }
            else if (e.Error != null)
            {
                Label.Content = e.Error.Message;
            }
            else
            {
                Label.Content = e.Result.ToString();
            }
        }
        /// <summary>
        /// Method for Printing button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Printing_Click(object sender, RoutedEventArgs e)
        {

            if (!worker.IsBusy)
            {

                worker.RunWorkerAsync();
            }
            else
            {
                Label.Content = "Printer is busy, please wait.";
            }
        }

        /// <summary>
        /// Method for Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (worker.IsBusy)
            {

                worker.CancelAsync();
            }
        }

        /// <summary>
        /// Method for entering text for printing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            print = objTextBox.Text;
            if (print != null && number != null)
            {
                Printing.IsEnabled = true;
            }
        }

        /// <summary>
        /// Copy number method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChanged_2(object sender, TextChangedEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            number = objTextBox.Text;

            if (print != null && number != null)
            {
                if (int.TryParse(number, out int num))
                {
                    Printing.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Please enter number");
                }
            }
        }
    }
    }

