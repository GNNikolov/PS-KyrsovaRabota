using KursovaRabota.Properties;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace KursovaRabota
{

    public partial class MainWindow : Window
    {
        private Dictionary<string, string> results = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
            DataLoader loader = new DataLoader();
            MlistBox.ItemsSource = loader.items;
            FilterButtonReuslts();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer mTimer = new DispatcherTimer();
            mTimer.Interval = TimeSpan.FromSeconds(1);
            mTimer.Tick += UpdateUI;
            mTimer.Start();

        }
        private int seconds = 45;
        private void UpdateUI(object sender, EventArgs mArgs)
        {
            DispatcherTimer mTimer = sender as DispatcherTimer;
            seconds--;
            Timer.Content = string.Format("{0:00}:{1:00}", seconds / 60, seconds % 60);
            if (seconds == 0)
            {
                if (results.Keys.Count < 7)
                {
                    ShowDissapointingMessage();
                }
                else
                {
                    computeResult();
                }
                mTimer.Stop();
            }
        }

        private void Checked_Event(object sender, RoutedEventArgs e)
        {
            // ... Get RadioButton reference.
            var button = sender as RadioButton;
            var parrentButtonGrid = button.Parent as Grid;
            var groupGrid = parrentButtonGrid.Parent as Grid;
            var groupBox = groupGrid.Parent as GroupBox;
            foreach (TextBlock item in FindVisualChildren<TextBlock>(groupBox))
            {
                if (item.Name.Equals("QuestionContent"))
                {
                    // MessageBox.Show(item.Text);
                    if (results.ContainsKey(item.Text))
                    {
                        results[item.Text] = button.Content.ToString();
                    }
                    else
                    {
                        results.Add(item.Text, button.Content.ToString());
                    }
                }
            }
        }

        private void FilterButtonReuslts()
        {
            ListBox questions = MlistBox;

        }
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public void ReadyBtn_CLicked(object sender, RoutedEventArgs e)
        {
            computeResult();
        }

        private void computeResult()
        {
            int resolvedQuestions = results.Keys.Count;
            foreach (TestQuestion item in MlistBox.Items)
            {
                if (results.ContainsKey(item.Question) && !results[item.Question].Equals(item.RightAnswer) && resolvedQuestions > 0)
                {
                    resolvedQuestions--;
                }
            }
            MessageBox.Show("Решени вярно: " + resolvedQuestions.ToString() + "/7");
        }
        private void ShowDissapointingMessage()
        {
            MessageBox.Show("Тестът не бе решен за време...", "Грандиозен провал !!!");
        }
    }

    public class TestQuestion
    {
        public string Question { get; set; }
        public string QuestionNumber { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string RightAnswer { get; set; }
    }
}
