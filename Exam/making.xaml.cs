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
    /// Interaction logic for making.xaml
    /// </summary>
    public partial class making : Page
    {  QuestionPaper Temp;
    int Subquestion_number = 1;
    int QuestionCount = 0;
    int section_number = 1;
    Section tempsec;
    Exam_repository store = new Exam_repository();
        public making(QuestionPaper temp)
        {
            Temp = temp;
            InitializeComponent();
            section_number_block.Text = (section_number).ToString();
            part1.Visibility = Visibility.Visible;
            grid2.IsEnabled = false;
            grid3.IsEnabled = false;

        }
        int sectioncountq = 0;
        private void genrate_section_Click_1(object sender, RoutedEventArgs e)
        {
        
            sectioncountq = 1;
            grid1.IsEnabled = false;
            part1.Visibility = Visibility.Hidden;
            grid2.IsEnabled = true;
            part2.Visibility = Visibility.Visible;
            if (section_number <= Temp.Total_section)
            {
                tempsec = new Section(section_number, int.Parse(num_question.Text), int.Parse(num_ans_question.Text), int.Parse(one_question_mark.Text));
                Temp.AddSection(tempsec);
                sectioncountq = tempsec.Number_of_qustion;
                QNum.Text =( ++QuestionCount).ToString();
                OneQN.Text = tempsec.One_question_mark.ToString();

            }
           

        }
        Question tempq;
        private void make_Click(object sender, RoutedEventArgs e)
        {

            
            grid2.IsEnabled = false;
            part2.Visibility = Visibility.Hidden;
            Subquestion_number = 1;
            if (sectioncountq--!=0)
            {
                grid3.IsEnabled = true;
                part3.Visibility = Visibility.Visible;
                tempq = new Question(int.Parse(QNum.Text), int.Parse(NSubQ.Text), int.Parse(OneQN.Text));
                tempsec.AddQuestion(tempq);
              
              
             
            }
          
            if (tempq.NumOFSubQustion == 1)
            {
                sub_qustion_number.Text = QuestionCount.ToString();
                MarkBox.Text = tempq.TotalMark.ToString();
            }
            else
            {
                sub_qustion_number.Text = QuestionCount.ToString()+"."+Subquestion_number.ToString();
            }
           
                
        }
        Subquestion temps; 
        private void next_ques_btn_Click_1(object sender, RoutedEventArgs e)
        {
            if (Subquestion_number <= tempq.NumOFSubQustion)
            {
                temps = new Subquestion(Subquestion_number, QuestionBox.Text, int.Parse(MarkBox.Text.ToString()));
                tempq.AddQustion(temps);
                QuestionBox.Clear();
                MarkBox.Clear();
                if ( tempq.NumOFSubQustion>1)
                    sub_qustion_number.Text = QuestionCount + "." + (Subquestion_number+1).ToString();
                if (Subquestion_number == tempq.NumOFSubQustion)
                {
                    sub_qustion_number.Text = "";
                    grid3.IsEnabled = false;
                    part3.Visibility = Visibility.Hidden;
                    if (0!= sectioncountq)
                    {
                        OneQN.Text = tempsec.One_question_mark.ToString();

                        grid2.IsEnabled =true ;
                        part2.Visibility = Visibility.Visible;
                        QNum.Text = (++QuestionCount).ToString();
                        NSubQ.Clear();
                       

                    }
                    else
                    {
                        if (section_number != Temp.Total_section)
                        {
                            grid1.IsEnabled = true;
                            part1.Visibility = Visibility.Visible;

                            section_number_block.Text = (++section_number).ToString();

                            num_question.Clear();
                            num_ans_question.Clear();
                            one_question_mark.Clear();
                            NSubQ.Clear();
                          
                        }
                        else
                        {
                            store.AddExam(Temp);
                            MessageBox.Show("  ***completed****");
                            this.NavigationService.Navigate(new CreatePage());
                        }

                    }
                  
                }
                Subquestion_number++;
              
               
               
            }
           
        }

        
    }
}
