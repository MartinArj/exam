using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exam
{
    /// <summary>
    /// Interaction logic for CreatePage.xaml
    /// </summary>
    public partial class CreatePage : Page
    {
        public List<string> ExamType = new List<string>() { "Quarterly exams","Midterm exams" };
     public List<int> class_= new List<int>() {1,2,3,4,5,6,7,8,9,10,11,12};
     public List<string> Subject = new List<string>() {"Tamil","English","Maths","physics","chamistry","computer science","social science","science"};
        
        public CreatePage()
        {
            InitializeComponent();
            ExamTypeBox.ItemsSource = ExamType;
            SubjectBox.ItemsSource=Subject;
            ClassBox.ItemsSource = class_;

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
         // MessageBox.Show(  ClassBox.SelectedValue.ToString());
            string Examt = ExamTypeBox.SelectedValue.ToString();
          int c = int.Parse(ClassBox.SelectedValue.ToString());
          string b = Batch.Text;
          string s = subject_code.Text;
          string sub = SubjectBox.SelectedValue.ToString();
          int max = int.Parse(Max_Mark.Text);
          int tsec = int.Parse(total_section.Text);
          QuestionPaper tempqs = new QuestionPaper(Examt, c, b, s, 0, sub, max, 0, tsec);
            this.NavigationService.Navigate(new making(tempqs));
        }

        private void home_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

    }
}
