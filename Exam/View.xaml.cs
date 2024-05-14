using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Page
    {
      
        Exam_repository exam;
        public View()
        {
            exam = new Exam_repository();
            exam.load();
            InitializeComponent();

        }
        static public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        private void get_Click_1(object sender, RoutedEventArgs e)
        {
            list_one_exam o = new list_one_exam();
            int eid = int.Parse(Id.Text);
            if (exam.isavl(eid))
            {
                QuestionPaper q = exam.ExamDic[eid];
                this.DataContext = q;
                parent.DataContext = q;
               exam.Get_One_Exam_Question(eid);
                
            }
            else
            {
                Id.Clear();
            }
            DataTable dt1 = new DataTable();
         dt1 = ConvertToDataTable(exam.Rdlc);
         //   dt1 = exam.Rdlc;
           // ReportParameter QuestionParameter = new ReportParameter("ExamQuestionPaperParameter", JsonConvert.SerializeObject(exam.ExamDic[eid]));
            ReportDataSource reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value =dt1;
            ReportViewer reportViewer1 = new ReportViewer();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Exam.Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer1.RefreshReport();
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            Warning[] warnings1;
            string[] streamids1;
            string mimeType1;
            string encoding1;
            string extension1;
            try
            {
                string dir = string.Empty;

                byte[] bytes = reportViewer1.LocalReport.Render("PDF", null, out mimeType1, out encoding1, out extension1, out streamids1, out warnings1);

                dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "REPORTS\\");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                if (Directory.Exists(dir))
                {

                    FileStream fs = new FileStream(dir + "Sample_Sheet_" + DateTime.Now.ToString("dd-MMM-yyyy") + ".pdf", FileMode.Create);

                    var temps = fs.ToString();
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
			
        
        
          
        }

        private void home_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

    }
}
