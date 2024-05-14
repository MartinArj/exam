using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
  public  class Subquestion
    {
       private  int _SubQustionNumber;

        public int SubQustionNumber
        {
            get { return _SubQustionNumber; }
            set { _SubQustionNumber = value; }
        }
        private string _Qustion;

        public string Qustion
        {
            get { return _Qustion; }
            set { _Qustion = value; }
        }
        private int _SubTotal;

        public int SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }
        public Subquestion()
        { }
        public Subquestion(int number, string qustion, int mark)
        {
            this._SubQustionNumber = number;
            this._Qustion = qustion;
            this._SubTotal = mark;
        }
    }
}
