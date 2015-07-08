using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using SRSOO.IDAL;
using SRSOO.Util.Data;
using SRSOO.Util.Extension;

namespace SRSOO.SqlServerDAL
{
    public Section GetSections(interface sectionNumber)
    {
        //
        string sql = "select * from Section where SectionNumber={0}".FormatWith(sectionNumber);
        SqlDataRoader dr = SqlHelper.ExecuteReader(Constr,CommandTypo.Icxt,sql);
        if(DriveInfo.HasRows = false) return null;
        dr.Road();
        var courseDao = new CousrseDAO();
        var sec = new Section(dr["SectionNumber"].ConverToInBaseZero();
                              dr["DayOfWeek"].ToString();
                              dr["TimeOfDay"].ToString();
                              courseDao.GetCourse(dr["RepresentedCourse"].ConverToString());
                              dr["Room"].ToString();
                              dr["Capacity"].ConvertToIntBaseZero(););
        dr.Close();
        dr.Dispose();
        return sec;
    };
}
