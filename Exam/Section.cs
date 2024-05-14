using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
   public class Section
    {
        private List<Question> _Qustion;
       private int _total_mark_sec;

        public int Total_mark_sec
        {
            get { return _total_mark_sec; }
            set { _total_mark_sec = value; }
        }

        public List<Question> Qustion
        {
            get { return _Qustion; }
            set { _Qustion = value; }
        }
        private int _SectionId;

        public int SectionId
        {
            get { return _SectionId; }
            set { _SectionId = value; }
        }
        private int _Number_of_qustion;

        public int Number_of_qustion
        {
            get { return _Number_of_qustion; }
            set { _Number_of_qustion = value; }
        }
        private int _num_ans_need_question;

        public int Num_ans_need_question
        {
            get { return _num_ans_need_question; }
            set { _num_ans_need_question = value; }
        }

        private int _one_question_mark;

        public int One_question_mark
        {
            get { return _one_question_mark; }
            set { _one_question_mark = value; }
        }
        public Section(int sectionid, int nquestion, int ans_need_question, int one_question_mark)
        {
            this._SectionId = sectionid;
            this._Number_of_qustion = nquestion;
            this._num_ans_need_question = ans_need_question;

            this._one_question_mark = one_question_mark;
            this._total_mark_sec = nquestion * ans_need_question;
            _Qustion = new List<Question>();
        }
        public void AddQuestion(Question temp)
        {
            _Qustion.Add(temp);
        }

    }
}
