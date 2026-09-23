using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace LocmanWebServer
{
    // Формирование отчётов: Excel 2003 XML Spreadsheet (.xls), CSV, TXT.
    // Excel-экспорт не требует внешних библиотек — открывается в Excel 2003+.
    public static class Reports
    {
        static string Safe(string s)
        {
            if (s == null) return "";
            return s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;")
                    .Replace("\"", "&quot;");
        }

        // rows[0] — заголовок.
        public static byte[] ToExcelXml(List<string[]> rows, string title)
        {
            var sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
            sb.Append("<?mso-application progid=\"Excel.Sheet\"?>\r\n");
            sb.Append("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" ");
            sb.Append("xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
            sb.Append("xmlns:x=\"urn:schemas-microsoft-com:office:excel\" ");
            sb.Append("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">\r\n");
            sb.Append("<Styles><Style ss:ID=\"hdr\"><Font ss:Bold=\"1\"/>");
            sb.Append("<Interior ss:Color=\"#D9E1F2\" ss:Pattern=\"Solid\"/></Style></Styles>\r\n");
            sb.Append("<Worksheet ss:Name=\"" + Safe(title) + "\"><Table>\r\n");
            bool first = true;
            foreach (var row in rows)
            {
                sb.Append("<Row>");
                foreach (var cell in row)
                {
                    double numVal = 0;
                    bool isNum = !first && double.TryParse(cell, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out numVal);
                    sb.Append("<Cell" + (first ? " ss:StyleID=\"hdr\"" : "") + "><Data ss:Type=\"");
                    if (isNum) sb.Append("Number\">" + numVal.ToString(CultureInfo.InvariantCulture));
                    else sb.Append("String\">" + Safe(cell));
                    sb.Append("</Data></Cell>");
                }
                sb.Append("</Row>\r\n");
                first = false;
            }
            sb.Append("</Table></Worksheet></Workbook>");
            return Encoding.UTF8.GetPreamble().ConcatBytes(Encoding.UTF8.GetBytes(sb.ToString()));
        }

        public static byte[] ToCsv(List<string[]> rows)
        {
            var sb = new StringBuilder();
            foreach (var row in rows)
            {
                var cells = new List<string>();
                foreach (var c in row)
                    cells.Add("\"" + (c ?? "").Replace("\"", "\"\"") + "\"");
                sb.AppendLine(string.Join(";", cells));
            }
            return Encoding.UTF8.GetPreamble().ConcatBytes(Encoding.UTF8.GetBytes(sb.ToString()));
        }

        public static byte[] ToTxt(List<string[]> rows)
        {
            var sb = new StringBuilder();
            foreach (var row in rows)
                sb.AppendLine(string.Join("\t", row));
            return Encoding.UTF8.GetPreamble().ConcatBytes(Encoding.UTF8.GetBytes(sb.ToString()));
        }
    }

    static class TinyLinq
    {
        public static byte[] ConcatBytes(this byte[] a, byte[] b)
        {
            var r = new byte[a.Length + b.Length];
            Buffer.BlockCopy(a, 0, r, 0, a.Length);
            Buffer.BlockCopy(b, 0, r, a.Length, b.Length);
            return r;
        }
    }
}
