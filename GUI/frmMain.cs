﻿using System;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public static string email;
        public static int vaitro = 0; // 0 là nhân viên 1 là quản trị viên
        public static int session = 0; //trạng thái đăng nhập 
        public static int profile = 0; //kiểm tra có cập nhật mk không 

        private void frmMain_Load(object sender, EventArgs e)
        {
            Resetvalue();
            if (profile == 1)
            {
                hồSơNhânViênToolStripMenuItem.Visible = false;
                profile = 0;
            }
        }
        private void Resetvalue()
        {
            if (session == 1)
            {

                thongtinNvToolStripMenuItem.Text = "Chào " + email;
                hồSơNhânViênToolStripMenuItem.Visible = true;
                đăngnhapToolStripMenuItem.Enabled = false;
                đăngxuatToolStripMenuItem.Enabled = true;
                thoátToolStripMenuItem.Enabled = true;

                danhMụcToolStripMenuItem.Visible = true;
                nhânViênToolStripMenuItem.Visible = true;
                sảnPhẩmToolStripMenuItem .Visible = true;
                kháchHàngToolStripMenuItem .Visible = true;

                
                thốngKêToolStripMenuItem.Visible = true;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = true;

                if (vaitro == 0)//nêu la vai tro nhan vien
                {
                    VaiTroNV(); //chuc nang nhan vien bình thường
                }
            }
            else
            {
                đăngnhapToolStripMenuItem.Enabled = true;
                đăngxuatToolStripMenuItem.Enabled = false;
                hồSơNhânViênToolStripMenuItem.Visible = false;

                danhMụcToolStripMenuItem.Visible = false;
                thốngKêToolStripMenuItem.Visible = false;

                thongtinNvToolStripMenuItem.Text = "";
            }
        }
        private void VaiTroNV()
        {
            nhânViênToolStripMenuItem.Visible = false;
            thốngKêToolStripMenuItem.Visible = false;
        }
        bool CheckExistForm(string frmName)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == frmName)
                {
                    return true;
                }
            }
            return false;
        }
        void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }

        }

        private void đăngnhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin dn = new frmLogin();
            if (!CheckExistForm("frmDangNhap"))
            {
                dn.MdiParent = this;
                dn.Show();
                dn.FormClosed += new FormClosedEventHandler(FrmDangNhap_FormClosed);
            }
            else
            {
                ActiveChildForm("frmDangNhap");
            }
        }

        private void hồSơNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinNV profilenv = new frmThongTinNV(email);// khơi tạo FrmThongTinNV với email nv

            if (!CheckExistForm("frmThongTinNV"))
            {
                profilenv.MdiParent = this;
                profilenv.FormClosed += new FormClosedEventHandler(FrmThongTinNV_FormClosed);
                profilenv.Show();
            }
            else
                ActiveChildForm("frmThongTinNV");
        }
        void FrmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed        
            this.Refresh();
            frmMain_Load(sender, e);// load form main again
        }


        void FrmThongTinNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            this.Refresh();

            frmMain_Load(sender, e);// load form main again
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đăngxuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            session = 0;
            Resetvalue();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHang frmHang = new frmHang();
            if(!CheckExistForm("frmHang"))
            {
                frmHang.MdiParent = this;
                frmHang.FormClosed += new FormClosedEventHandler(FrmThongTinNV_FormClosed);
                frmHang.Show();
            }
            else
                ActiveChildForm("frmHang");
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien nhanVien = new frmNhanVien();
            if(!CheckExistForm("frmNhanVien"))
            {
                nhanVien.MdiParent = this;
                nhanVien.FormClosed += new FormClosedEventHandler(FrmThongTinNV_FormClosed);
                nhanVien.Show();
            }
            else
                ActiveChildForm("frmNhanVien");
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhach khach = new frmKhach();
            if(!CheckExistForm("frmKhach"))
            {
                khach.MdiParent = this;
                khach.FormClosed += new FormClosedEventHandler(FrmThongTinNV_FormClosed);
                khach.Show();
            }
            else
                ActiveChildForm("frmKhach");
        }

        private void thốngKêSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe thongKe = new frmThongKe();
            if(!CheckExistForm("frmThongKe"))
            {
                thongKe.MdiParent = this;
                thongKe.FormClosed += new FormClosedEventHandler(FrmThongTinNV_FormClosed);
                thongKe.Show();
            }
            else
                ActiveChildForm("frmThongKe");
        }
    }
}
