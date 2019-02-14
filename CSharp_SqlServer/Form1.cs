using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CSharp_SqlServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        /// <summary>
        ///连接数据库返回表数据
        /// </summary>
        /// <returns></returns>
        private DataTable GetMessage()
        {
            string ConnectStr = string.Format(@"Data Source=.;Initial Catalog=C#练习使用;User Id=sa;Password=123456;");//数据库连接字符串
            string SqlStr = string.Format("SELECT * FROM dbo.data");//sql字符串
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SqlStr,ConnectStr);//创建数据适配器
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            return dataTable;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetMessage();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                //dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //使得datagridview的列宽自适应，调整后 ，datagridview的宽度无法与窗体的宽度适应
                dataGridView1.RowHeadersVisible = false;//datagridview前面的空白部分去除
                dataGridView1.Width = dataGridView1.Columns[0].HeaderCell.Size.Width * dataGridView1.Columns.Count;
                //dataGridView1.Height=(int)2*(dataGridView1.Columns[0].HeaderCell.Size.Height * dataGridView1.Rows.Count);

            }

        }
    }
}
