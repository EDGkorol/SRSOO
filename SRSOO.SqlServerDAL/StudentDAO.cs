using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SRSOO.IDAL;
using SRSOO.Util.Data;
using SRSOO.Util.Extension;

namespace SRSOO.SqlServerDAL
{
   public class StudentDAO: DataBase, IStudent
    {
       public void Insert(Student student)
       {
           throw new NotImplementedException();
       }

       public Student GetStudent(string id)
       {
           string sql = "select * from Student whereid='{0}'".FormatWith(id);
           SqlDataReader dr = SqlHelper.ExecuteReader(ConStr, CommandType.Text, sql);
           if (dr.HasRows == false) return null;
           dr.Read();
           var stu = new Student(dr["Name"].ToString(), dr["Id"].ToString(), dr["Major"].ToString())dr["Degree"].ToString());
           dr.Close();
           dr.Dispose();
           var attends = new List<Section>();
           attends.Add(new Section(0,"","",null,"",0));
           stu.Attends = attends;
           return stu;
       }

       public void GetPreRequisites(Course course)
       {
           string sql = "select * from Prerequisite where CourseNumber='{0}'".FormatWith(course.CourseNumber);
           DataTable dt = SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql).Tables[0];
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               course.AddPrerequisite(GetCourse(dt.Rows[i]["Prerequisite"].ConvertToString()));
           }
       }
    }
}
