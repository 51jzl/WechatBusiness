using HN.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace HN.DAL
{
    public class Tools
    {
        #region 获取自增长表中当前添加数据ID GetCurrentID(object tran)
        /// <summary>
        /// 获取自增长表中当前添加数据ID
        /// </summary>
        /// <param name="tran"></param>
        /// <returns></returns>
        public int GetCurrentID(object tran)
        {
            string strSql = "SELECT @@IDENTITY AS ID";
            object obj = SQLHelper.ExecuteScalar((SqlTransaction)tran, strSql);
            return int.Parse(obj.ToString());
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
            string strSql = "Select RL.FUN_GETFIRSTPY('" + strName + "') py";
            object obj = SQLHelper.ExecuteScalar(strSql);
            return obj.ToString();
        }
        #endregion

        #region Sql语句分页查询 GetList_N(object trans, string strSql, string strWhere, SqlParameter[] param, string strOrderBy, int? iPageSize, int? iPageIndex)
        public static DataTable GetList_N(object trans, string strSql, string strWhere, SqlParameter[] param, string strOrderBy, int? iPageSize, int? iPageIndex)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string text = strSql + ((strWhere != null && strWhere != "") ? (" Where " + strWhere) : "");
                text = string.Format(text, "@");
                string text2 = (iPageSize.HasValue && iPageIndex.HasValue) ? string.Concat(new object[]
				{
					"RowNumTemp>=",
					(iPageIndex.Value-1) * iPageSize.Value + 1,
					" And RowNumTemp<=",
					iPageIndex.Value * iPageSize.Value
				}) : "";
                string cmdText = "Select Count(*) From (" + text + ")  TempTableForPage";
                if (text2 != "")
                {
                    text = string.Concat(new string[]
					{
						"Select * From (Select TempTableForPage.*,ROW_NUMBER() Over( Order By ",
						strOrderBy,
						") As RowNumTemp From (",
						text,
						")  TempTableForPage) TempOrderByTable Where ",
						text2
					});
                }
                else
                {
                    text += ((strOrderBy != null && strOrderBy.Trim() != "") ? (" Order By " + strOrderBy) : "");
                }
                dataTable = SQLHelper.GetDataSet((SqlTransaction)trans, CommandType.Text, text, param).Tables[0];
                DataTable dataTable2 = new DataTable();
                dataTable2.TableName = "Page_TotalCount";
                dataTable2.Columns.Add("Page_TotalCount", typeof(int));
                object obj = SQLHelper.ExecuteScalar((SqlTransaction)trans, CommandType.Text, cmdText, param);
                if (obj != null)
                {
                    dataTable2.Rows.Add(dataTable2.NewRow());
                    dataTable2.Rows[0]["Page_TotalCount"] = Convert.ToInt32(obj);
                }
                dataTable.DataSet.Tables.Add(dataTable2);
            }
            catch
            {
                dataTable = null;
                throw;
            }
            return dataTable;
        }
        #endregion

        #region Sql语句分页查询 GetPagerList(object trans, string strSql, string strWhere, List<SqlParameter>, string strOrderBy, int? iPageSize, int? iPageIndex)
        public static DataTable GetPagerList(object trans, string strSql, string strWhere, List<SqlParameter> param, string strOrderBy, int? iPageSize, int? iPageIndex)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string text = strSql + ((strWhere != null && strWhere != "") ? (" Where " + strWhere) : "");
                text = string.Format(text, "@");
                string text2 = (iPageSize.HasValue && iPageIndex.HasValue) ? string.Concat(new object[]
				{
					"RowNumTemp>=",
					(iPageIndex.Value-1) * iPageSize.Value + 1,
					" And RowNumTemp<=",
					iPageIndex.Value * iPageSize.Value
				}) : "";
                string cmdText = "Select Count(*) From (" + text + ")  TempTableForPage";
                if (text2 != "")
                {
                    text = string.Concat(new string[]
					{
						"Select * From (Select TempTableForPage.*,ROW_NUMBER() Over( Order By ",
						strOrderBy,
						") As RowNumTemp From (",
						text,
						")  TempTableForPage) TempOrderByTable Where ",
						text2
					});
                }
                else
                {
                    text += ((strOrderBy != null && strOrderBy.Trim() != "") ? (" Order By " + strOrderBy) : "");
                }
                dataTable = SQLHelper.GetDataSet((SqlTransaction)trans, CommandType.Text, text, param.ToArray()).Tables[0];
                DataTable dataTable2 = new DataTable();
                dataTable2.TableName = "Page_TotalCount";
                dataTable2.Columns.Add("Page_TotalCount", typeof(int));
                object obj = SQLHelper.ExecuteScalar((SqlTransaction)trans, CommandType.Text, cmdText, param.ToArray());
                if (obj != null)
                {
                    dataTable2.Rows.Add(dataTable2.NewRow());
                    dataTable2.Rows[0]["Page_TotalCount"] = Convert.ToInt32(obj);
                }
                dataTable.DataSet.Tables.Add(dataTable2);
            }
            catch
            {
                dataTable = null;
                throw;
            }
            return dataTable;
        }
        #endregion

    }
}
