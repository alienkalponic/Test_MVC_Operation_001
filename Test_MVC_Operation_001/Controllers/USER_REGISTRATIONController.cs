using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Test_MVC_Operation_001.Models;
using Test_MVC_Operation_001.Helper;
using System.Net.Security;

namespace Test_MVC_Operation_001.Controllers
{
    public class USER_REGISTRATIONController : ApiController
    {
        [HttpPost]
        [Route("api/Test_MVC_Operation_001/SaveUser")]
        public HttpResponseMessage SaveUser(List<Information_Model> RequestData)
        {
            HttpResponseMessage hrm = new HttpResponseMessage();
            ResponseObj ro = new ResponseObj();
            try
            {
                if (RequestData.Count == 0)
                {
                    ro.Status = 0;
                    ro.Message = "pass proper data!!";
                }
                else {
                    SqlParameter[] prm = new SqlParameter[]
                        {
                            new SqlParameter("@TYPE","INSERT"),
                            new SqlParameter("@NAME",RequestData[0].NAME),
                            new SqlParameter("@ADDRESS",RequestData[0].ADDRESS),
                            new SqlParameter("@EMAIL_ID",RequestData[0].EMAIL_ID),
                            new SqlParameter("@PHONE_NO",RequestData[0].PHONE_NO),
                            new SqlParameter("@CITY",RequestData[0].CITY),
                            new SqlParameter("@GENDER",RequestData[0].GENDER)
                        };
                    string MSG = Convert.ToString(new SQLHelper().ExecuteScalar("SP_INFORMATION", prm, CommandType.StoredProcedure));
                    if (MSG == "SUCCESSFYLL")
                    {
                        ro.Status = 1;
                        ro.Message = "INSERT SUCCESSFULLY";
                    }
                    else {
                        ro.Status = 0;
                        ro.Message = "NO DATA INSERT";
                    }
                }
                hrm = new GenLib().RecvAPIData(ro);
                return hrm;
            }
            catch (Exception ex)
            {
                hrm = new GenLib().WriteErrorLog(ex);
                return hrm;
            }
        }

        [HttpGet]
        [Route("api/Test_MVC_Operation_001/AllSearch")]
        public HttpResponseMessage AllSearch()
        {
            HttpResponseMessage hrm = new HttpResponseMessage();
            ResponseObj ro = new ResponseObj();
            try
            {
                SqlParameter[] prm = new SqlParameter[]
                    {
                        new SqlParameter("@TYPE","ALL_SEARCH")
                    };
                DataTable DT = new SQLHelper().ExecuteDataTable("SP_INFORMATION", prm, CommandType.StoredProcedure);
                if (DT.Rows.Count > 0)
                {
                    ro.Status = 1;
                    ro.Message = "SUCCESS";
                    ro.dataTable = DT;
                }
                hrm = new GenLib().RecvAPIData(ro);
                return hrm;
            }
            catch (Exception ex) {
                hrm = new GenLib().WriteErrorLog(ex);
                return hrm;
            }
        }
        [HttpPost]
        [Route("api/Test_MVC_Operation_001/Mail_Search")]
        public HttpResponseMessage Mail_Search(List<Information_Model> RequestData)
        {
            HttpResponseMessage hrm = new HttpResponseMessage();
            ResponseObj ro = new ResponseObj();
            DataTable DT = new DataTable();
            try
            {
                if (RequestData.Count == 0)
                {
                    ro.Status = 0;
                    ro.Message = "PASS PROPER DATA!!";
                }
                else
                {
                    SqlParameter[] prm = new SqlParameter[]
                        {
                            new SqlParameter("@TYPE","SEARCH_MAIL"),
                            new SqlParameter("@EMAIL_ID",RequestData[0].EMAIL_ID)
                        };
                    DT = new SQLHelper().ExecuteDataTable("SP_INFORMATION", prm, CommandType.StoredProcedure);
                    if (DT.Rows.Count > 0)
                    {
                        ro.Status = 1;
                        ro.Message = "SECCESS";
                        ro.dataTable = DT;
                    }
                }
                hrm = new GenLib().RecvAPIData(ro);
                return hrm;
            }
            catch (Exception ex)
            {
                hrm = new GenLib().WriteErrorLog(ex);
                return hrm;
            }
        }
    }
}
