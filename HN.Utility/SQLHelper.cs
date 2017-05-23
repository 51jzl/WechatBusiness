using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace HN.Utility
{
    public class SQLHelper
    {
        private static readonly string a1 = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
       
        public static string SysConnStr
        {
            get
            {
                return SQLHelper.a1;
            }
        }

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] commandParameters)
        {
            return SQLHelper.ExecuteNonQuery(null, cmdText, commandParameters);
        }
        public static int ExecuteNonQuery(SqlTransaction trans, string cmdText, params SqlParameter[] commandParameters)
        {
            return SQLHelper.ExecuteNonQuery(trans, CommandType.Text, cmdText, commandParameters);
        }
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlConnection sqlConnection = null;
            int result;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                if (trans != null)
                {
                    sqlConnection = trans.Connection;
                }
                else
                {
                    sqlConnection = new SqlConnection(SQLHelper.SysConnStr);
                }
                SQLHelper.a(sqlCommand, sqlConnection, trans, cmdType, cmdText, commandParameters);
                int num = sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();
                result = num;
            }
            catch
            {
                throw;
            }
            finally
            {
                SQLHelper.a(sqlConnection, trans);
            }
            return result;
        }
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return SQLHelper.ExecuteNonQuery(null, cmdType, cmdText, commandParameters);
        }
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText)
        {
            return SQLHelper.ExecuteNonQuery(trans, cmdType, cmdText, null);
        }
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText)
        {
            return SQLHelper.ExecuteNonQuery(null, cmdType, cmdText, null);
        }
        public static SqlDataReader ExecuteReader(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlConnection sqlConnection = null;
            SqlDataReader result;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                if (trans != null)
                {
                    sqlConnection = trans.Connection;
                }
                else
                {
                    sqlConnection = new SqlConnection(SQLHelper.SysConnStr);
                }
                SQLHelper.a(sqlCommand, sqlConnection, trans, cmdType, cmdText, commandParameters);
                SqlDataReader sqlDataReader;
                if (trans != null)
                {
                    sqlDataReader = sqlCommand.ExecuteReader();
                }
                else
                {
                    sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
                sqlCommand.Parameters.Clear();
                result = sqlDataReader;
            }
            catch
            {
                throw;
            }
            finally
            {
                SQLHelper.a(sqlConnection, trans);
            }
            return result;
        }
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return SQLHelper.ExecuteReader(null, cmdType, cmdText, commandParameters);
        }
        public static SqlDataReader ExecuteReader(SqlTransaction trans, CommandType cmdType, string cmdText)
        {
            return SQLHelper.ExecuteReader(trans, cmdType, cmdText, null);
        }
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText)
        {
            return SQLHelper.ExecuteReader(null, cmdType, cmdText, null);
        }
        public static DataSet GetDataSet(string cmdText, params SqlParameter[] commandParameters)
        {
            return SQLHelper.GetDataSet(null,cmdText, commandParameters);
        }
        public static DataSet GetDataSet(SqlTransaction trans, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlConnection sqlConnection = null;
            DataSet result;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                if (trans != null)
                {
                    sqlConnection = trans.Connection;
                }
                else
                {
                    sqlConnection = new SqlConnection(SQLHelper.SysConnStr);
                }
                SQLHelper.a(sqlCommand, sqlConnection, trans, CommandType.Text, cmdText, commandParameters);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlCommand.Parameters.Clear();
                sqlDataAdapter.Dispose();
                result = dataSet;
            }
            catch
            {
                throw;
            }
            finally
            {
                SQLHelper.a(sqlConnection, trans);
            }
            return result;
        }
        public static DataSet GetDataSet(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlConnection sqlConnection = null;
            DataSet result;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                if (trans != null)
                {
                    sqlConnection = trans.Connection;
                }
                else
                {
                    sqlConnection = new SqlConnection(SQLHelper.SysConnStr);
                }
                SQLHelper.a(sqlCommand, sqlConnection, trans, cmdType, cmdText, commandParameters);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlCommand.Parameters.Clear();
                sqlDataAdapter.Dispose();
                result = dataSet;
            }
            catch
            {
                throw;
            }
            finally
            {
                SQLHelper.a(sqlConnection, trans);
            }
            return result;
        }
        public static DataSet GetDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return SQLHelper.GetDataSet(null, cmdType, cmdText, commandParameters);
        }
        public static DataSet GetDataSet(SqlTransaction trans, CommandType cmdType, string cmdText)
        {
            return SQLHelper.GetDataSet(trans, cmdType, cmdText, null);
        }
        public static DataSet GetDataSet(CommandType cmdType, string cmdText)
        {
            return SQLHelper.GetDataSet(null, cmdType, cmdText, null);
        }
        public static DataSet GetDataSet_Conn(string strSysConnstr, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlConnection sqlConnection = null;
            DataSet result;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlConnection = new SqlConnection(strSysConnstr);
                SQLHelper.a(sqlCommand, sqlConnection, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlCommand.Parameters.Clear();
                sqlDataAdapter.Dispose();
                result = dataSet;
            }
            catch
            {
                throw;
            }
            finally
            {
                SQLHelper.a(sqlConnection, null);
            }
            return result;
        }
        public static DataSet GetDataSet_Conn(string strSysConnstr, CommandType cmdType, string cmdText)
        {
            return SQLHelper.GetDataSet_Conn(strSysConnstr, cmdType, cmdText, null);
        }
        public static object ExecuteScalar(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(null, CommandType.Text, cmdText, commandParameters);
        }
        public static object ExecuteScalar(SqlTransaction trans, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(trans, CommandType.Text, cmdText, commandParameters);
        }
        public static object ExecuteScalar(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlConnection sqlConnection = null;
            object result;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                if (trans != null)
                {
                    sqlConnection = trans.Connection;
                }
                else
                {
                    sqlConnection = new SqlConnection(SQLHelper.SysConnStr);
                }
                SQLHelper.a(sqlCommand, sqlConnection, trans, cmdType, cmdText, commandParameters);
                object obj = sqlCommand.ExecuteScalar();
                sqlCommand.Parameters.Clear();
                result = obj;
            }
            catch
            {
                throw;
            }
            finally
            {
                SQLHelper.a(sqlConnection, trans);
            }
            return result;
        }
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return SQLHelper.ExecuteScalar(null, cmdType, cmdText, commandParameters);
        }
        public static object ExecuteScalar(SqlTransaction trans, CommandType cmdType, string cmdText)
        {
            return SQLHelper.ExecuteScalar(trans, cmdType, cmdText, null);
        }
        public static object ExecuteScalar(CommandType cmdType, string cmdText)
        {
            return SQLHelper.ExecuteScalar(null, cmdType, cmdText, null);
        }
        private static void a(SqlCommand A_0, SqlConnection A_1, SqlTransaction A_2, CommandType A_3, string A_4, SqlParameter[] A_5)
        {
            try
            {
                if (A_1.State != ConnectionState.Open)
                {
                    A_1.Open();
                }
                A_0.Connection = A_1;
                A_0.CommandText = A_4;
                if (A_2 != null)
                {
                    A_0.Transaction = A_2;
                }
                A_0.CommandType = A_3;
                if (A_5 != null)
                {
                    for (int i = 0; i < A_5.Length; i++)
                    {
                        if ((A_5[i].Direction == ParameterDirection.InputOutput || A_5[i].Direction == ParameterDirection.Input) &&(A_5[i].Value == null))
                        {
                            A_5[i].Value = DBNull.Value;
                        }
                        A_0.Parameters.Add( A_5[i]);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static SqlParameter[] GetProduceParameter(string cnString, string proName)
        {
            SqlConnection sqlConnection = new SqlConnection(cnString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = proName;
            SqlCommandBuilder.DeriveParameters(sqlCommand);
            SqlParameter[] array = new SqlParameter[sqlCommand.Parameters.Count];
            for (int i = 0; i < sqlCommand.Parameters.Count; i++)
            {
                array[i] = new SqlParameter();
                array[i].SqlDbType = sqlCommand.Parameters[i].SqlDbType;
                array[i].ParameterName = sqlCommand.Parameters[i].ParameterName;
                array[i].Size = sqlCommand.Parameters[i].Size;
            }
            return array;
        }
        public static SqlTransaction CreatTransaction()
        {
            return SQLHelper.CreatTransaction(SQLHelper.a1);
        }
        public static SqlTransaction CreatTransaction(string strSysConnStr)
        {
            SqlTransaction result;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(strSysConnStr);
                sqlConnection.Open();
                result = sqlConnection.BeginTransaction();
            }
            catch
            {
                throw;
            }
            return result;
        }
        private static void a(SqlConnection A_0, SqlTransaction A_1)
        {
            if (A_0 != null && A_0.State != ConnectionState.Closed && A_1 == null)
            {
                A_0.Close();
            }
        }
    }
}

