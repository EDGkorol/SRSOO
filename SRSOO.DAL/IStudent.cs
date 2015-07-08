using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRSOO.IDAL
{

    public interface IStudent
    {
        Student GetStudent(string id);
    }
}
public static IStudent CreateStudentDAO()
{
    string className = AssemblyName + "." + "StudentDAO",
    return(IStudent)Assembly.Load(AssemblyName).CreateInstance(className);
}