using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Web;

namespace HN.BLL
{
    public class ExcelHelper
    {
        #region 获取Excel文件流 GetExcelStream(DataTable dt, string[] titles = null, int[] widths = null)
        /// <summary>
        /// 获取Excel文件流
        /// </summary>
        /// <param name="dt">需要导出的数据</param>
        /// <param name="titles">Excel表头 与dt列数对应</param>
        /// <param name="widths">列宽度 与dt列数对应</param>
        /// <returns></returns>
        public static MemoryStream GetExcelStream(DataTable dt, string[] titles = null, int[] widths = null)
        {
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("sheet1");

            #region ICellStyle style 宋体;10号;水平居左;上下居中;黑色边框
            //设置单元格的样式
            ICellStyle style = workbook.CreateCellStyle();
            //新建一个字体样式对象
            IFont font = workbook.CreateFont();
            //字体
            font.FontName = "宋体";
            //字体大小
            font.FontHeightInPoints = 10;
            //使用SetFont方法将字体样式添加到单元格样式中 
            style.SetFont(font);
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style.VerticalAlignment = VerticalAlignment.Center;
            #endregion

            //设置列宽
            if (widths != null)
            {
                for (int i = 0; i < widths.Length; i++)
                {
                    sheet.SetColumnWidth(i, widths[i] * 256);
                }
            }
            //添加表头
            IRow hrow = sheet.CreateRow(0);
            if (titles != null)
            {
                for (int i = 0; i < titles.Length; i++)
                {
                    hrow.CreateCell(i).SetCellValue(titles[i].ToString());
                    hrow.Cells[i].CellStyle = style;
                }
            }
            else
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    hrow.CreateCell(i).SetCellValue(dt.Columns[i].ToString());
                    hrow.Cells[i].CellStyle = style;
                }
            }

            //向Excel中写入数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    row.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                    row.Cells[j].CellStyle = style;
                }
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                return ms;
            }
        }
        #endregion
    }
}
 