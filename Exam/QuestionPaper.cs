using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
  public  class QuestionPaper
    {
         private List<Section> _section;

        public List<Section> Section
        {
            get { return _section; }
            set { _section = value; }
        }
       
        private string _ExamType;

        public string ExamType
        {
            get { return _ExamType; }
            set { _ExamType = value; }
        }
        private int _Class;

        public int Class
        {
            get { return _Class; }
            set { _Class = value; }
        }
        private string _Batch;

        public string Batch
        {
            get { return _Batch; }
            set { _Batch = value; }
        }
        private string _SubjectCode;

        public string SubjectCode
        {
            get { return _SubjectCode; }
            set { _SubjectCode = value; }
        }
        private string _SubjectName;

        public string SubjectName
        {
            get { return _SubjectName; }
            set { _SubjectName = value; }
        }
        private int _ExamId;

        public int ExamId
        {
            get { return _ExamId; }
            set { _ExamId = value; }
        }
        private int _MaxMark;

        public int MaxMark
        {
            get { return _MaxMark; }
            set { _MaxMark = value; }
        }
        private int _Total_qustion;

        public int Total_qustion
        {
            get { return _Total_qustion; }
            set { _Total_qustion = value; }
        }
        private int _total_section;

        public int Total_section
        {
            get { return _total_section; }
            set { _total_section = value; }
        }
        public QuestionPaper()
        {
           
        }
        public QuestionPaper(string examtype, int _class, string batch, string subjectcode, int examid, string subjectname, int maximum_mark, int totalquestion, int total_section)
        { 
        this._ExamType=examtype;
        this._Class=_class;
        this._Batch=batch;
        this._SubjectCode=subjectcode;
        this._ExamId=examid;
        this._SubjectName=subjectname;
        this.MaxMark=maximum_mark;
        this._Total_qustion = totalquestion;
        this._total_section = total_section;
        Section = new List<Section>();
        
        }
        public void AddSection(Section temp)
        {
            Section.Add(temp);
        }
    }
}
