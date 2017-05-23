using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HN.DAL;


namespace HN.BLL
{
    public class Tools
    {
        private DAL.Tools dal = new DAL.Tools();

        #region 写错误日志 WriteLog(string _text)
        /// <summary>
        /// 写错误日志 
        /// </summary>
        /// <param name="_text">文本内容</param>
        private void WriteLog(string text)
        {
            string _strFileDirect = AppDomain.CurrentDomain.BaseDirectory + "Log/Error";
            if (!Directory.Exists(_strFileDirect))
            {
                Directory.CreateDirectory(_strFileDirect);
            }
            string _strFileName = _strFileDirect + "/e" + DateTime.Now.ToString("yyyyMMdd") + ".txt";//一天有一个日志文件
            string _message = DateTime.Now + "   " + text + Environment.NewLine + Environment.NewLine;
            File.AppendAllText(_strFileName, _message, Encoding.Default);
        }
        #endregion

        #region 获取错误信息，并且写日志 GetErrorInfo(Exception ex)
        /// <summary>
        /// 获取错误信息，并且写日志 
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns></returns>
        public string GetErrorInfo(Exception ex)
        {
            string strReturn = ex.Message;
            try
            {
                if (ex.Message != "")
                {
                    WriteLog(ex.ToString());
                }
            }
            catch
            {
            }
            return strReturn;
        }
        #endregion

        #region 将json格式字符串转换成标准的json格式 ConvertJsonString(string str)
        public static string ConvertJsonString(string str)
        {
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }
        #endregion

        #region 获取自增长表中当前添加数据ID GetCurrentID(object tran)
        /// <summary>
        /// 获取自增长表中当前添加数据ID
        /// </summary>
        /// <param name="tran"></param>
        /// <returns></returns>
        public int GetCurrentID(object tran)
        {
            return dal.GetCurrentID(tran);
        }
        #endregion

        #region 获取拼音首字母 GetFirstPY(string strName)
        /// <summary>
        /// 获取拼音首字母
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public string GetFirstPY(string strName)
        {
            return dal.GetFirstPY(strName);
        }
        #endregion

    }
}
