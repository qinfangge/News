using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace tk.tingyuxuan.utils
{
    public class Category
    {
        public static void unlimitedLayer(DataTable table, int pid, DataTable newTable, string html, int level)
        {
            DataRowCollection rows = table.Rows;

            foreach (DataRow row in rows)
            {
                string name = row["name"].ToString();
                int currentPid = int.Parse(row["pid"].ToString());
                int currentid = int.Parse(row["id"].ToString());
                if (currentPid == pid)
                {

                    DataRow newRow = newTable.NewRow();
                    newRow["id"] = row["id"];
                    newRow["level"] = level + 1;
                    string html2 = "";
                    for (int i = 0; i < level; i++)
                    {
                        html2 += html;
                    }
                    newRow["name"] = html2 + row["name"];
                    newTable.Rows.Add(newRow);

                    unlimitedLayer(table, currentid, newTable, html, int.Parse(newRow["level"].ToString()));

                }
            }


        }

        public static void GetChildren(DataTable table, int pid, DataTable newTable)
        {
            DataRowCollection rows = table.Rows;
            foreach (DataRow row in rows)
            {
                string name = row["name"].ToString();
                int currentPid = int.Parse(row["pid"].ToString());
                int currentid = int.Parse(row["id"].ToString());
                if (currentPid == pid)
                {
                    DataRow newRow = newTable.NewRow();
                    newRow["id"] = row["id"];
                    newRow["name"] = row["name"];
                    newTable.Rows.Add(newRow);
                    GetChildren(table, currentid, newTable);
                }
            }
        }

        public static void GetParents(DataTable table, int id, DataTable newTable)
        {
            DataRowCollection rows = table.Rows;
            foreach (DataRow row in rows)
            {
                string name = row["name"].ToString();
                int currentPid = int.Parse(row["pid"].ToString());
                int currentid = int.Parse(row["id"].ToString());
                if (id == currentid)
                {
                    DataRow newRow = newTable.NewRow();
                    newRow["id"] = row["id"];
                    newRow["name"] = row["name"];
                    newRow["pid"] = row["pid"];
                    newTable.Rows.Add(newRow);
                    GetParents(table, currentPid, newTable);
                }
            }
        }




    }
}
