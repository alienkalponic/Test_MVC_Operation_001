using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Test_MVC_Operation_001.Helper
{
    public class ResponseObj
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public int iSValidToken { get; set; }
        public DataTable dataTable { get; set; }
        public DataSet dataSet { get; set; }
        public object dataList { set; get; }
    }
}