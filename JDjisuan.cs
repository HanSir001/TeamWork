using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace TeamWork
{
    public partial class JDjisuan : Form
    {
        double chengji;

        public JDjisuan()
        {
            InitializeComponent();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 单科目计算ToolStripMenuItem_Click(object sender, EventArgs e)//计算器菜单---单科目计算
        {
            panel2.Hide();
            //panel1.Show();          
        }

        private void 多科目计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //panel1.Hide();
            panel2.Show();
        }

        private void JDjisuan_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            comboBox1.Text = "--请选择--";
            comboBox2.Text = "--请选择--";
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//确认按钮
        {
            chengji = double.Parse(textBox1.Text);
            if (chengji < 0||chengji > 100)
            {
                MessageBox.Show("成绩输入错误");
            }
            if (chengji >= 0 && chengji < 60)
            {
                textBox2.Text = "0";
                textBox3.Text = "不及格";
            }
            if (chengji >= 60 && chengji <= 63.9)
            {
                textBox2.Text = "1.0";
                textBox3.Text = "及格";
            }
            if (chengji >= 64 && chengji <= 65.9)
            {
                textBox2.Text = "1.5";
                textBox3.Text = "及格";
            }
            if (chengji >= 66 && chengji <= 67.9)
            {
                textBox2.Text = "1.7";
                textBox3.Text = "及格";
            }
            if (chengji >= 68 && chengji <= 71.9)
            {
                textBox2.Text = "2.0";
                textBox3.Text = "重点";
            }
            if (chengji >= 72 && chengji <= 74.9)
            {
                textBox2.Text = "2.3";
                textBox3.Text = "重点";
            }
            if (chengji >= 75 && chengji <= 77.9)
            {
                textBox2.Text = "2.7";
                textBox3.Text = "重点";
            }
            if (chengji >= 78 && chengji <= 81.9)
            {
                textBox2.Text = "3.0";
                textBox3.Text = "良好";
            }
            if (chengji >= 82 && chengji <= 84.9)
            {
                textBox2.Text = "3.3";
                textBox3.Text = "良好";
            }
            if (chengji >= 85 && chengji <= 89.9)
            {
                textBox2.Text = "3.7";
                textBox3.Text = "良好";
            }
            if (chengji >= 90 && chengji <= 100)
            {
                textBox2.Text = "4.0";
                textBox3.Text = "优秀";
            }
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)//帮助按钮
        {
            MessageBox.Show("单科目计算时：请在成绩一栏中输入成绩，成绩范围是0-100，点击确认按钮输出绩点与等级\r\n多科目计算时：对院系设置和专业设置进行选择，当专业设置选择完毕后，会弹出本专业大学四年所有的学位课，在对应的后边输入成绩，完毕后点击确认按钮会计算出绩点");
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//combobox选择控制
        {
            if (comboBox1.Text == "信息科学与技术学院")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("计算机科学与技术");
                comboBox2.Items.Add("软件工程");
                comboBox2.Items.Add("信息工程");
                comboBox2.Items.Add("网络工程");
                comboBox2.Items.Add("教育技术学");
                comboBox2.Items.Add("数字与媒体");
            }

            if (comboBox1.Text == "经济管理学院")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("金融");
                comboBox2.Items.Add("国际贸易");
                comboBox2.Items.Add("工程管理");
            }
        }

        private void button2_Click(object sender, EventArgs e)//查询课程按钮
        {

            for (int k = 0; k < 4; k++)
            {
                Label labe = new Label();
                labe.ForeColor = Color.Red;//改变字体颜色
                if (k == 0)
                {
                    labe.Text = "一年级";
                }
                if (k == 1)
                {
                    labe.Text = "二年级";
                }
                if (k == 2)
                {
                    labe.Text = "三年级";
                }
                if (k == 3)
                {
                    labe.Text = "四年级";
                }
                labe.Location = new Point(80 + k * 171, 50);
                panel2.Controls.Add(labe);
            }
            for (int j = 0; j < 4; j++)
            {
                Label labe = new Label();
                labe.ForeColor = Color.Lime;//改变字体颜色
                labe.Text = "上学期";
                labe.Location = new Point(80 + j * 171, 73);
                panel2.Controls.Add(labe);
            }
            for (int i = 0; i < 4; i++)
            {
                Label labe = new Label();
                labe.Text = "下学期";
                labe.Location = new Point(80 + i * 171, 208);
                panel2.Controls.Add(labe);
            }
            for (int i = 0; i < 3; i++)
            {
                Label labe = new Label();
                if (i == 0)
                {
                    labe.Text = "课程名称";
                }
                if (i == 1)
                {
                    labe.Text = "学分";
                }
                if (i == 2)
                {
                    labe.Text = "总学时";
                }
                labe.Location = new Point(40 + i * 100, 96);
                panel2.Controls.Add(labe);
            }
           
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            strConnection += @"Data Source=major.mdb";

            OleDbConnection objConnection = new OleDbConnection(strConnection);  //建立连接  
            objConnection.Open();  //打开连接  
            OleDbCommand sqlcmd = new OleDbCommand();
            if (comboBox2.Text == "计算机科学与技术")
            {
                sqlcmd.CommandText = "select * from major1";//sql语句
                sqlcmd.Connection = objConnection;
                OleDbDataReader result = sqlcmd.ExecuteReader();

                Object[] dataRow = new Object[result.FieldCount];//定义以字段个数为长度Object数组
                int a = 0;
                while (result.Read() == true)//每循环一次，指针后移一次
                {
                    result.GetValues(dataRow); //获取当前行所有字段内容，保存到数组中
                    for (int b = 1; b < result.FieldCount;b++ )
                    {
                        Label lab = new Label();
                        lab.Text = dataRow[b].ToString();
                        int c ;
                        c= (int)result.FieldCount;
                        if (b == 1)
                        {
                            lab.Location = new Point(40, 119 + a);
                        }
                        if (b == 2)
                        {
                            lab.Location = new Point(140, 119 + a);
                        }
                        if (b == 3)
                        {
                            lab.Location = new Point(240, 119 + a);
                        }
                        panel2.Controls.Add(lab);
                    }
                    a = a+23;
                }
                result.Close();
            }
            
            objConnection.Close();



        }


        


       

       
    }
}
