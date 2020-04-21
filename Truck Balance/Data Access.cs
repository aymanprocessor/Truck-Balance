using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_Balance
{
    public class Data_Access
    {
        private common com;
        private int iid;

        public Data_Access(int _iid)
        {
            iid = _iid;
            com = new common();
        }

        public DataTable getReportData()
        {
            using (SqlConnection conn = new SqlConnection(com.connstr()))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(string.Format("select Wieghts.*,Customers.name,Customers.address,Customers.government from Wieghts INNER JOIN Customers ON Wieghts.customerId = Customers.Id where Wieghts.id = {0}", iid), conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable getReportBetweenTwoDate(DateTimePicker fromDate, DateTimePicker toDate, string sql_type)
        {
            using (SqlConnection conn = new SqlConnection(com.connstr()))
            {
                conn.Open();
                string sql = "";
                if (sql_type.Equals("قطاعات الومنيوم"))
                {
                    sql = "select Wieghts.*,Customers.name,Customers.address,Customers.government from Wieghts INNER JOIN Customers ON Wieghts.customerId = Customers.Id WHERE Wieghts.product = @type and Wieghts.date >= CONVERT(datetime,@fromDate,101) and Wieghts.date <=CONVERT(datetime,@toDate,101)";
                }
                else if (sql_type.Equals("اخرى"))
                {
                    sql = "select Wieghts.*,Customers.name,Customers.address,Customers.government from Wieghts INNER JOIN Customers ON Wieghts.customerId = Customers.Id WHERE Wieghts.product != @type and Wieghts.date >= CONVERT(datetime,@fromDate,101) and Wieghts.date <=CONVERT(datetime,@toDate,101)";
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand.Parameters.AddWithValue("@type", "قطاعات الومنيوم");
                    adapter.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate.Value.ToShortDateString() + " 11:59 PM");
                    adapter.SelectCommand.Parameters.AddWithValue("@toDate", toDate.Value.ToShortDateString() + " 11:59 PM");
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}