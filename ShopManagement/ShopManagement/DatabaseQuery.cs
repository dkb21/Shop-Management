using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ShopManagement
{
    public class DatabaseQuery
    {
        static SqlConnection cnn = new SqlConnection(@"Data Source=LAPTOP-88O6FK8N\INSTANCE1;Initial Catalog=ShopManagement;Integrated Security=True");

        public static DataTable getAccountByUsername(string username)
        {
            cnn.Open();
            string sql = "SELECT * FROM Account where username='" + username + "'";
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable addAccount(string username, string password)
        {
            cnn.Open();
            string sql = "insert into Account values('" + username + "', '" + password + "')";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;

        }

        public static DataTable getAllItems()
        {
            cnn.Open();
            string sql = "select * from Item order by itemID asc";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable addItem(string id, string name, string size, int price)
        {
            cnn.Open();
            string sql = "insert into Item values('" + id + "', N'" + name + "', '" + size + "', " + price + ")";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable getAllAgents()
        {
            cnn.Open();
            string sql = "select * from Agent";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable addAgent(string name, string phone, string address)
        {
            string id = "";

            if (getBiggestAgentID().Rows.Count == 0) id = "A0001";
            else
            {
                id = getBiggestAgentID().Rows[0][0].ToString();

                int currentIndex = Int32.Parse(id.Substring(1, id.Length - 1)) + 1;
                if (currentIndex > 0 && currentIndex < 10)
                {
                    id = "A000" + currentIndex;
                }
                else if (currentIndex >= 10 && currentIndex < 100)
                {
                    id = "A00" + currentIndex;
                }
                else if (currentIndex >= 100 && currentIndex < 1000)
                {
                    id = "A0" + currentIndex;
                }
                else if (currentIndex >= 1000 && currentIndex < 10000)
                {
                    id = "A" + currentIndex;
                }
                else MessageBox.Show("Out of memories!");
            }

            cnn.Open();
            string sql = "insert into Agent values('" + id + "', N'" + name + "', '" + phone + "', N'" + address + "')";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable getBiggestAgentID()
        {
            cnn.Open();
            string sql = "SELECT top 1 * FROM Agent ORDER BY agentID DESC";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable getBiggestOrderID()
        {
            cnn.Open();
            string sql = "SELECT top 1 * FROM OrderInfo ORDER BY orderID DESC";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable addNewOrder(string agentID)
        {
            string id = "";

            if (getBiggestOrderID().Rows.Count == 0) id = "O0001";
            else
            {
                id = getBiggestOrderID().Rows[0][0].ToString();

                int currentIndex = Int32.Parse(id.Substring(1, id.Length - 1)) + 1;
                if (currentIndex > 0 && currentIndex < 10)
                {
                    id = "O000" + currentIndex;
                }
                else if (currentIndex >= 10 && currentIndex < 100)
                {
                    id = "O00" + currentIndex;
                }
                else if (currentIndex >= 100 && currentIndex < 1000)
                {
                    id = "O0" + currentIndex;
                }
                else if (currentIndex >= 1000 && currentIndex < 10000)
                {
                    id = "O" + currentIndex;
                }
                else MessageBox.Show("Out of memories!");
            }

            cnn.Open();
            string sql = "insert into OrderInfo values('" + id + "', '" + DateTime.Now.ToString("yyyy/MM/dd") + "', '" + agentID + "')";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable getAgentByID(string id)
        {
            cnn.Open();
            string sql = "SELECT * FROM Agent where agentID='" + id + "'";
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable addOrderItem(string orderID, string id, string itemID, int quantity)
        {
            int price = Int32.Parse(getPriceByID(itemID).Rows[0][0].ToString());

            cnn.Open();
            string sql = "insert into OrderItem values('" + orderID + "', '" + id + "', '" + itemID + "', '" + quantity.ToString() + "', '" + (quantity * price).ToString() + "')";  
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable getPriceByID(string itemID)
        {
            cnn.Open();
            string sql = "select itemPrice from Item where itemID = '" + itemID + "'";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable getOrderdetailsByOrderID(string orderID)
        {
            cnn.Open();
            string sql = "select * from OrderItem where orderID = '" + orderID + "'";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable getOrderByOrderID(string orderID)
        {
            cnn.Open();
            string sql = "select * from OrderInfo where orderID = '" + orderID + "'";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }

        public static DataTable getAllOrderByAgentID(string agentID)
        {
            cnn.Open();
            string sql = "select * from OrderInfo where agentID = '" + agentID + "'";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            return dt;
        }
    }
}
