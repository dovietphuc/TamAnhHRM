using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TamAnhHRM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Utilities.isValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi");
                return;
            }
            if (!Utilities.isValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu phải từ 8 ký tự trở lên," +
                    " chứa ít nhất 1 chữ số, và 1 chữ cái viết hoa", "Lỗi");
                return;
            }

            bool success = tryToLogin(txtEmail.Text, txtPassword.Text);
            MessageBox.Show(success ? "Đăng nhập thành công với tài khoản " + userEmail
                                        : "Sai tên tài khoản hoặc mật khẩu");
        }

        // PhucDV: biến để debug xem hacker đã đăng nhập thành công bởi tài khoản nào
        private string userEmail;

        public bool tryToLogin(string email, string password)
        {
            // PhucDV: Dễ dàng bị lỗi SQL Injection khi sử dụng phương pháp nỗi chuỗi
            string dumQuery = @"select * from tblAccount where sEmail like N'"
                            + email + @"' and sPassword like N'" + password + "'";

            string constr = @"Data Source=DESKTOP-1BI8MPQ;
                            Initial Catalog=TamAnhHRM;
                            Integrated Security=True";

            SqlConnection cnn = new SqlConnection(constr);
            SqlCommand cmd = cnn.CreateCommand();

            // PhucDV: sử dụng phương pháp nối chuỗi
            cmd.CommandText = dumQuery;

            // PhucDV: Sử dụng procedure sẽ là cách tốt nhất để tránh lỗi SQL Injection
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "proc_tryLogin";
            //cmd.Parameters.AddWithValue("@email", email);
            //cmd.Parameters.AddWithValue("@password", password);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();

            int i = ad.Fill(tb);
            foreach(DataRow row in tb.Rows)
            {
                userEmail = row["sEmail"].ToString();
            }
            //PhucDV: Nếu chỉ check có bản ghi thì khả năng cao hacker sẽ lấy được 1 tài khoản nào đó
            return i > 0;

            // PhucDV: Chỉ nên đúng khi trả về 1 bản ghi duy nhất
            //return i == 1;
        }
    }
}
