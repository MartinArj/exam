using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
  public  class list_one_exam
    {
        private int _Eid;

        public int Eid
        {
            get { return _Eid; }
            set { _Eid = value; }
        }
        private string _Subj_Title;

        public string Subj_Title
        {
            get { return _Subj_Title; }
            set { _Subj_Title = value; }
        }
        private string _Exam_Type;

        public string Exam_Type
        {
            get { return _Exam_Type; }
            set { _Exam_Type = value; }
        }
        private string _Subcode;

        public string Subcode
        {
            get { return _Subcode; }
            set { _Subcode = value; }
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
        private int _Max_mark;

        public int Max_mark
        {
            get { return _Max_mark; }
            set { _Max_mark = value; }
        }

      
        private int _Total_Mark_Section;

        public int Total_Mark_Section
        {
            get { return _Total_Mark_Section; }
            set { _Total_Mark_Section = value; }
        }
        private int _Setion_Id;

        public int Setion_Id
        {
            get { return _Setion_Id; }
            set { _Setion_Id = value; }
        }
        private int _One_Question_mar;

        public int One_Question_mar
        {
            get { return _One_Question_mar; }
            set { _One_Question_mar = value; }
        }
        private int _Answer_Need_Question;

        public int Answer_Need_Question
        {
            get { return _Answer_Need_Question; }
            set { _Answer_Need_Question = value; }
        }

        private int _Sub_Question_number;

        public int Sub_Question_number
        {
            get { return _Sub_Question_number; }
            set { _Sub_Question_number = value; }
        }
        private int _Number_Of_sub_Question;

        public int Number_Of_sub_Question
        {
            get { return _Number_Of_sub_Question; }
            set { _Number_Of_sub_Question = value; }
        }
        private int _Question_Number;

        public int Question_Number
        {
            get { return _Question_Number; }
            set { _Question_Number = value; }
        }
        int _Sub_q_mark;
        

public int Sub_q_mark
{
  get { return _Sub_q_mark; }
  set { _Sub_q_mark = value; }
}private string _Sub_Question;

        public string Sub_Question
        {
            get { return _Sub_Question; }
            set { _Sub_Question = value; }
        }

        public list_one_exam()
        { 
        
        }
        public list_one_exam(int eid,string sub_t,string exam_t,string subj_code,int Class,string Batch,int max_mark,int total_mark_section,int section_id,int one_q_mark,int ans_need_question,int sub_q_num,int num_of_sub_q,int sub_mark,int qnum,string subqustion)
        {
            this._Sub_q_mark = sub_mark;
            this._Eid = eid;
            this._Subj_Title = sub_t;
            this._Exam_Type = exam_t;
            this._Subcode = subj_code;
            this._Class = Class;
            this._Batch = Batch;
            this._Max_mark = max_mark;
            this._Total_Mark_Section = total_mark_section;
            this._Setion_Id = section_id;
            this._One_Question_mar = one_q_mark;
            this._Answer_Need_Question = ans_need_question;
            this._Sub_Question_number = sub_q_num;
            this._Number_Of_sub_Question = num_of_sub_q;
            this._Question_Number = qnum;
            this._Sub_Question = subqustion;
        }
      
    }
}
