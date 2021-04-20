using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Content_Upload_Model.Models.DAL;

namespace Content_Upload_Model.Models
{
    public class category
    {
        int categoryCode;
        string categoryName;
        string description;
        string photoPath;

        public category() { }

        public category(int categoryCode, string categoryName, string description, string photoPath)
        {
            CategoryCode = categoryCode;
            CategoryName = categoryName;
            Description = description;
            PhotoPath = photoPath;
        }

        public int CategoryCode { get => categoryCode; set => categoryCode = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string Description { get => description; set => description = value; }
        public string PhotoPath { get => photoPath; set => photoPath = value; }

        public List<category> getcategories()
        {
            DBServices dbs = new DBServices();
            List<category> categoryList = dbs.getcategories();
            return categoryList;
        }

        public string Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.InsertCategory(this);
        }

    }
}