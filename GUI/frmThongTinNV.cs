﻿
using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmThongTinNV : Form
    {
        BUS_NhanVien busNhanVien = new BUS.BUS_NhanVien();
        string email;
        public frmThongTinNV(string email)
        {
            InitializeComponent();
            this.email = email;
            txtemail.Text = email;
            txtemail.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndoimatkhau_Click(object sender, EventArgs e)
        {
            if (txtmatkhaucu.Text.Trim() == "" || txtmatkhaumoi.Text.Trim() == "" || txtmatkhaumoi2.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống dữ liệu");
            }
            else if (txtmatkhaumoi.Text.Trim() != txtmatkhaumoi2.Text.Trim())
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu nhập lại phải giống nhau");
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn cập nhật mật khẩu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mkcu = frmLogin.encryption(txtmatkhaucu.Text);
                    string mkmoi = frmLogin.encryption(txtmatkhaumoi.Text);
                    if (busNhanVien.CapNhatMatKhau(txtemail.Text, mkcu, mkmoi))
                    {
                        frmMain.profile = 1;
                        frmMain.session = 0;
                        MessageBox.Show("Cập nhật mật khẩu thành công. Bạn phải đăng nhập lại");
                        
                        this.Close();
                        OpenNewForm();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật mật khẩu không thành công vui lòng kiểm tra lại mật khẩu");
                        txtmatkhaucu.Text = "";
                        txtmatkhaumoi.Text = "";
                        txtmatkhaumoi2.Text = "";
                        txtmatkhaucu.Focus();
                    }
                }
                else
                {
                    txtmatkhaucu.Text = "";
                    txtmatkhaumoi.Text = "";
                    txtmatkhaumoi2.Text = "";
                }
            }
        }
        private void OpenNewForm()
        {
           frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }
        private void frmThongTinNV_Load(object sender, EventArgs e)
        {
            
        }
    }
}
