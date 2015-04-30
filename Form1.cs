using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


//Form1是主页窗体
//Form2是计算器
//Form3是绩点计算

namespace TeamWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //窗体移动问题
        bool formMove = false;//窗体是否移动
        Point formPoint;//记录窗体的位置  
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            formPoint = new Point();
            int xOffset;
            int yOffset;
            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
                formPoint = new Point(xOffset, yOffset);
                formMove = true;//开始移动
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (formMove == true)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(formPoint.X, formPoint.Y);
                Location = mousePos;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键
            {
                formMove = false;//停止移动
            }
        }



        //有关按钮的设置
        private void button1_Click(object sender, EventArgs e)//最小化窗体
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)//关闭窗体
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)//打开计算器
        {
            Calculator child2 = new Calculator();
            child2.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)//打开百度
        {
            Process.Start("http://www.baidu.com");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.sina.com");
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)//鼠标经过按钮时，按钮颜色变化
        {
            button1.ForeColor = Color.Lime;//经过时边框为绿色
            button1.BackColor = Color.LightYellow;//经过时背景变为黄色
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;//经过时边框为绿色
            button1.BackColor = Color.Transparent;//经过时背景变为黄色
        }

        private void button6_Click(object sender, EventArgs e)//打开绩点计算器
        {
            JDjisuan child3 = new JDjisuan();
            child3.Show();
        }

       

        
       
    }
}
