using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BlogParkTestPro.Model;
using BlogParkTestPro.DAL;

namespace BlogParkTestPro.BLL
{
    public class CategoryOperateBLL
    {
        CategoryOperateDAL dal = new CategoryOperateDAL();
        public List<LogCategory> GetMinCategory()
        {
            DataTable categorytable = dal.GetMainCategory();
            List<LogCategory> model = new List<LogCategory>();
            foreach (DataRow item in categorytable.Rows)
            {
                LogCategory mo = new LogCategory();
                mo.CategoryID = int.Parse(item["CategoryID"].ToString());
                mo.CategoryName = item["CategoryName"].ToString();
                model.Add(mo);
            }
            return model;
        }
        public List<LogCategory> GetSubCategory(int fatherid)
        {
            DataTable categorytable = dal.GetSubCategory(fatherid);
            List<LogCategory> model = new List<LogCategory>();
            foreach (DataRow item in categorytable.Rows)
            {
                LogCategory mo = new LogCategory();
                mo.CategoryID = int.Parse(item["CategoryID"].ToString());
                mo.CategoryName = item["CategoryName"].ToString();
                model.Add(mo);
            }
            return model;
        }
    }
}
