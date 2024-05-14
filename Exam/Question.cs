using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
   public class Question
    {
        private List<Subquestion> _Qustions = new List<Subquestion>();

        public List<Subquestion> Qustions
        {
            get { return _Qustions; }
            set { _Qustions = value; }
        }
        private int _QustionNumber;

        public int QustionNumber
        {
            get { return _QustionNumber; }
            set { _QustionNumber = value; }
        }
        private int _NumOFSubQustion;

        public int NumOFSubQustion
        {
            get { return _NumOFSubQustion; }
            set { _NumOFSubQustion = value; }
        }
        private int _TotalMark;

        public int TotalMark
        {
            get { return _TotalMark; }
            set { _TotalMark = value; }
        }
        public Question()
        {
           // _Qustions = new List<SubQustion>();
        }
        public Question(int qnum,int subqus,int totalmark)
        { 
        this._QustionNumber=qnum;
        this._NumOFSubQustion=subqus;
        this._TotalMark=totalmark;
       
        }
        public void AddQustion(Subquestion q)
        {
            _Qustions.Add(q);
        }
    }
}
