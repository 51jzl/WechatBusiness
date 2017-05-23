using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace HN.UI.App_Start
{
    public static class ResponseExtend
    {
        public static void ToExcel(this HttpResponseBase response,string fileName, MemoryStream ms)
        {
            response.ContentType = "application/vnd.ms-excel;charset=utf-8";
            response.HeaderEncoding = Encoding.UTF8;
            response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName) + ".xls");
            response.Clear();
            response.BinaryWrite(ms.GetBuffer());
            response.End();
        }
    }
}