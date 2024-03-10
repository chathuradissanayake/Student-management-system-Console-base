using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKD3910
{
    public class Module
    {

        public string ModuleID { get; set; }

        public string ModuleName { get; set; }

        public double Grade_Point { get; set; }

        public int Credit_Point{ get; set; }

        public char Grade { get; set; }


        public Module(string moduleid, string modulename, double gradepoint, int creditpoint, char grade)

        {
            ModuleID= moduleid;
            ModuleName = modulename;
            Grade_Point = gradepoint;
            Credit_Point = creditpoint;
            Grade = grade;
            
            
            
            //Console.WriteLine("Available Modules are");
            //Console.WriteLine("# 3305 Signal and Systems");
            //Console.WriteLine("# 3301 Analog Electronics");
            //Console.WriteLine("# 3302 Data Structures and Algorithems");
            //Console.WriteLine("# 3203 Measurement");
            //Console.WriteLine("# 3251 GUI Prgramming");
            //Console.WriteLine("# 3250 Programming  Project");

        }
    }
}

