using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Exam_repository
    {
         string path = @"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=question;Integrated Security=True";
        private List<QuestionPaper> _Exam;
        private Dictionary<int, QuestionPaper> _ExamDic;
        private List<list_one_exam> _rdlc;

        public List<list_one_exam> Rdlc
        {
            get { return _rdlc; }
            set { _rdlc = value; }
        }
        public Dictionary<int, QuestionPaper> ExamDic
        {
            get { return _ExamDic; }
            set { _ExamDic = value; }
        }
        public List<QuestionPaper> Exam
        {
            get { return _Exam; }
            set { _Exam = value; }
        }
        public Exam_repository()
        {
            _Exam = new List<QuestionPaper>();
            _ExamDic = new Dictionary<int, QuestionPaper>();

            _rdlc = new List<list_one_exam>();

        }
        public void AddExam(QuestionPaper temp)
        {
           
            insert(temp);
            _Exam.Add(temp);
            _ExamDic[temp.ExamId] = temp;
        }
       
         public  void  Get_One_Exam_Question( int id)
        {
        
         using( SqlConnection con=new SqlConnection(path))
         {
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = con;
             con.Open();
             cmd.CommandText = "select e.examid,e.title,e.examtype,e.subjuctcode,e.class,e.batch,e.maxmark,s.sectionid,s.one_question_mark,s.ans_need_question,q.qid,q.num_sub_qus,sq.sub_mark,sq.subid,sq.qustion from exam e left join section s on e.examid=s.eid join qustion q on s.eid=q.eid join subqustions sq on q.eid=sq.eid where e.examid=" + id + ";";
             SqlDataReader dr;
             dr = cmd.ExecuteReader();
             while (dr.Read())
             {
                
                 int eid = Convert.ToInt32(dr["examid"]);
                 string subj_t=dr["title"].ToString();
                 string exam_t = dr["examtype"].ToString();
                 string subject_code = dr["subjuctcode"].ToString();
                 int Class = Convert.ToInt32(dr["class"]);
                 string batch=dr["batch"].ToString();
                 int max_mark = Convert.ToInt32(dr["maxmark"]);
               
                 int section_id = Convert.ToInt32(dr["sectionid"]);
                 int o_q_mark = Convert.ToInt32(dr["one_question_mark"]);
                 int ans_need_q = Convert.ToInt32(dr["ans_need_question"]);
                 int total_mark_section=o_q_mark*ans_need_q;

                 int num_sub_q= Convert.ToInt32(dr["num_sub_qus"]);;
                 int qnum= Convert.ToInt32(dr["qid"]);

                 int sub_mark = Convert.ToInt32(dr["sub_mark"]);
                int sub_q_num = Convert.ToInt32(dr["subid"]); 
                
                 string qustion=dr["qustion"].ToString();
             list_one_exam Qustion_paper=new list_one_exam          (eid,subj_t,exam_t,subject_code,Class,batch,max_mark,total_mark_section,section_id,o_q_mark,ans_need_q,sub_q_num,num_sub_q,sub_mark,qnum,qustion);
             _rdlc.Add(Qustion_paper);
             }

         }
        
        }
        public void insert(QuestionPaper temp)
        {
            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                connection.Open();
                cmd.CommandText="insert into exam values('"+temp.ExamType+"',"+temp.Class+",'"+temp.Batch+"','"+temp.SubjectCode+"','"+temp.SubjectName+"',"+temp.MaxMark+","+temp.Total_qustion+","+temp.Total_section+");";
                cmd.ExecuteNonQuery();
            }
            int id = GetLostExID();
            using (SqlConnection connection = new SqlConnection(path))
            {
                connection.Open();
                foreach (var item in temp.Section)
	             {  
              
                    string query= "INSERT INTO section  VALUES (@ExID, @SectionId, @Number_of_qustion, @Num_ans_need_question, @One_question_mark)";
                    SqlCommand cmd = new SqlCommand(query,connection);
                    cmd.Parameters.AddWithValue("@ExID", id);
                    cmd.Parameters.AddWithValue("@SectionId", item.SectionId);
                    cmd.Parameters.AddWithValue("@Number_of_qustion", item.Number_of_qustion);
                    cmd.Parameters.AddWithValue("@Num_ans_need_question", item.Num_ans_need_question);
                    cmd.Parameters.AddWithValue("@One_question_mark", item.One_question_mark);
                    cmd.ExecuteNonQuery();
                    foreach (var question in item.Qustion)
                    {
                        string query1 = "INSERT INTO qustion  VALUES (@ExID, @SectionId, @qid, @mark, @one_question)";
                        SqlCommand cmd1 = new SqlCommand(query1, connection);
                        cmd1.Parameters.AddWithValue("@ExID", id);
                        cmd1.Parameters.AddWithValue("@SectionId", item.SectionId);
                        cmd1.Parameters.AddWithValue("@qid", question.QustionNumber);
                        cmd1.Parameters.AddWithValue("@mark", question.TotalMark);
                        cmd1.Parameters.AddWithValue("@one_question", item.One_question_mark);
                        cmd1.ExecuteNonQuery();
                        foreach (var subquestion in question.Qustions)
                        {
                            string query2 = "INSERT INTO subqustions  VALUES (@ExID, @SectionId, @qid, @sqid, @Qustion,@sub_mark)";
                        SqlCommand cmd2 = new SqlCommand(query2, connection);
                        cmd2.Parameters.AddWithValue("@ExID", id);
                        cmd2.Parameters.AddWithValue("@SectionId", item.SectionId);
                        cmd2.Parameters.AddWithValue("@qid", question.QustionNumber);
                        cmd2.Parameters.AddWithValue("@sqid",subquestion.SubQustionNumber);
                        cmd2.Parameters.AddWithValue("@Qustion", subquestion.Qustion);
                        cmd2.Parameters.AddWithValue("@sub_mark", subquestion.SubTotal);
                        cmd2.ExecuteNonQuery();
                        }
                    }

	             }
                temp.ExamId = id;
              
                
                            
            }
          

        }
       
        public int GetLostExID()
        {
            using (SqlConnection connection=new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                connection.Open();
                cmd.CommandText = "select top 1 examid from exam order by examid desc";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                int id = 0;
                if (dr.Read())
                {

                    id = Convert.ToInt32(dr["examid"]);


                }
                return id;
                
            }
        }
        public bool isavl(int id)
        {
            if (_ExamDic.ContainsKey(id))
            { return true; }
            return false;
        }
        public void load()
        {
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select examid, examtype,class,batch,subjuctcode,title,maxmark,total_question,total_section from exam";
                //  cmd.CommandText = "select sectionid,qid,subid,qustion,sub_mark from subqustions where eid=" + id + "";

                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int examid = Convert.ToInt32(dr["examid"]);
                    string examtype = dr["examtype"].ToString();
                    int sclass = Convert.ToInt32(dr["class"]);
                    string batch = dr["batch"].ToString();
                    string subjectcode = dr["subjuctcode"].ToString();
                    string title = dr["title"].ToString();
                    int maxmark = Convert.ToInt32(dr["maxmark"]);
                    int total_qustion = Convert.ToInt32(dr["total_question"]);
                    int total_section = Convert.ToInt32(dr["total_section"]);

                    QuestionPaper exam = new QuestionPaper(examtype, sclass, batch, subjectcode, examid, title, maxmark, total_qustion, total_section);

                    Exam.Add(exam);
                    ExamDic[exam.ExamId] = exam;



                }
                dr.Close();
                foreach (var item in Exam)
                {

                    cmd.CommandText = "select sectionid,num_of_question,ans_need_question,one_question_mark from section where eid=" + item.ExamId + " ";
                    SqlDataReader dr1;
                    dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        int sectionid = Convert.ToInt32(dr1["sectionid"]);
                        int num_of_question = Convert.ToInt32(dr1["num_of_question"]);
                        int ans_need_qustion = Convert.ToInt32(dr1["ans_need_question"]);
                        int one_qustion_mark = Convert.ToInt32(dr1["one_question_mark"]);
                        Section temp = new Section(sectionid, num_of_question, ans_need_qustion, one_qustion_mark);
                        item.Section.Add(temp);
                    }
                    dr1.Close();
                    foreach (var section in item.Section)
                    {


                        cmd.CommandText = "select qid,mark,num_sub_qus from qustion where eid=" + item.ExamId + " and sectionid=" + section.SectionId + " ";
                        SqlDataReader dr2;
                        dr2 = cmd.ExecuteReader();
                        while (dr2.Read())
                        {

                            int qid = Convert.ToInt32(dr2["qid"]);
                            int mark = Convert.ToInt32(dr2["mark"]);
                            int n_sub = Convert.ToInt32(dr2["num_sub_qus"]);
                            Question temp = new Question(qid, n_sub, mark);
                            section.Qustion.Add(temp);
                        }
                        dr2.Close();
                        foreach (var qustion in section.Qustion)
                        {
                            cmd.CommandText = "select subid,qustion,sub_mark from  subqustions where eid=" + item.ExamId + " and  sectionid=" + section.SectionId + " and qid=" + qustion.QustionNumber + "";
                            SqlDataReader dr3;
                            dr3 = cmd.ExecuteReader();
                            while (dr3.Read())
                            {
                                int subid = Convert.ToInt32(dr3["subid"]);
                                string qus = dr3["qustion"].ToString();
                                int sub_mark = Convert.ToInt32(dr3["sub_mark"]);
                                Subquestion temp = new Subquestion(subid, qus, sub_mark);
                                qustion.AddQustion(temp);
                            }
                            dr3.Close();
                        }
                    }


                }
            }
        }
        
    }
}
