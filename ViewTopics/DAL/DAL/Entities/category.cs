using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class category
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public string Category_Description { get; set; }
        public string Category_Date { get; set; }
        public List<topic> Topics { get; set; }
    }
}
