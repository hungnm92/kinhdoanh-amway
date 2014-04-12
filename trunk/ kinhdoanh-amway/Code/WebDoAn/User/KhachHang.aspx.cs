using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_KhachHang : System.Web.UI.Page
{
    lanhnt.KhachHang kh = new lanhnt.KhachHang();
    lanhnt.Duong d = new lanhnt.Duong();
    lanhnt.XaPhuong xp = new lanhnt.XaPhuong();
    lanhnt.Huyen h = new lanhnt.Huyen();
    lanhnt.Tinh t = new lanhnt.Tinh();
    lanhnt.NhaPhanPhoi npp = new lanhnt.NhaPhanPhoi();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            griKhachHang.DataSource = kh.KhachHang_DS_TheoTheLoai(Session["MaNPP"].ToString(),bool.Parse(Session["Loai"].ToString()));//có tham số truyền vào.
            griKhachHang.DataBind();
            droDuongKHLL.DataSource = d.DS();
            droDuongKHLL.DataBind();
            droDuongKHTT.DataSource = d.DS();
            droDuongKHTT.DataBind();
            droXaKHLL.DataSource = xp.DS();
            droXaKHLL.DataBind();
            droXaKHTT.DataSource = xp.DS();
            droXaKHTT.DataBind();
            droHuyenKHLL.DataSource = h.DS();
            droHuyenKHLL.DataBind();
            droHuyenKHTT.DataSource = h.DS();
            droHuyenKHTT.DataBind();
            droTinhKHLL.DataSource = t.DS();
            droTinhKHLL.DataBind();
            droTinhKHTT.DataSource = t.DS();
            droTinhKHTT.DataBind();
        }
    }
    protected void griKhachHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griKhachHang.PageIndex = e.NewPageIndex;
        griKhachHang.DataSource = kh.KhachHang_DS_TheoTheLoai(Session["MaNPP"].ToString(), bool.Parse(Session["Loai"].ToString()));// sửa có tham số truyền vào
        griKhachHang.DataBind();
    }
    protected void griKhachHang_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietKH.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = false;
        btnXoa.Visible = true;
        btnSua.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        kh.MaKH = griKhachHang.SelectedValue.ToString();
        kh.CT();
        txtMaKH.Text = kh.MaKH;
        txtMaKH.Enabled = true;
        txtHoKH.Text = kh.HoKH;
        txtTenKH.Text = kh.TenKH;
        txtNgaySinh.Text = kh.NgaySinh;
        if (kh.GioiTinh == true)
        {
            rdoNam.Checked = true;
        }
        else
            rdoNu.Checked = true;
        txtCMND.Text = kh.CMND;
        txtSoDT.Text = kh.SoDT;
        txtCMND.Text = kh.Email;
        txtSoNhaKHTT.Text = kh.SoNhaKHTT;
        txtSoNhaKHLL.Text = kh.SoNhaKHLL;
        d.MaDuong = kh.MaDuongKHTT;
        droDuongKHTT.SelectedValue = d.MaDuong.ToString();
        d.MaDuong = kh.MaDuongKHLL;
        droDuongKHLL.SelectedValue = d.MaDuong.ToString();
        xp.MaXa = kh.MaXaKHTT;
        droXaKHTT.SelectedValue = xp.MaXa.ToString();
        xp.MaXa = kh.MaXaKHLL;
        droXaKHLL.SelectedValue = xp.MaXa.ToString();
        xp.MaXa = kh.MaXaKHTT;///////////// đúng không???.
        h.MaHuyen = xp.MaHuyen;
        droHuyenKHTT.SelectedValue = h.MaHuyen.ToString();
        xp.MaXa = kh.MaXaKHLL;///////////// đúng không???.
        h.MaHuyen = xp.MaHuyen;
        droHuyenKHLL.SelectedValue = h.MaHuyen.ToString();
        xp.MaHuyen = kh.MaXaKHTT;///////////// đúng không???.
        h.MaHuyen = xp.MaHuyen;
        t.MaTinh = h.MaTinh;
        droHuyenKHTT.SelectedValue = t.MaTinh.ToString();
        xp.MaHuyen = kh.MaXaKHLL;///////////// đúng không???.
        h.MaHuyen = xp.MaHuyen;
        t.MaTinh = h.MaTinh;
        droHuyenKHLL.SelectedValue = t.MaTinh.ToString();
    }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {
        //sp.GetID();
        // Session["URL"] = "SP_" + sp.TempID + "file";
        pnlChiTietKH.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = true;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        txtMaKH.Text = "";
        txtHoKH.Text = "";
        txtTenKH.Text = "";
        txtNgaySinh.Text = "";
        txtCMND.Text = "";
        txtSoDT.Text = "";
        txtCMND.Text = "";
        txtSoNhaKHTT.Text = "";
        txtSoNhaKHLL.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool bHoKH = string.IsNullOrWhiteSpace(txtHoKH.Text);
        bool bTenKH = string.IsNullOrWhiteSpace(txtTenKH.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bCMND = string.IsNullOrWhiteSpace(txtCMND.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        bool bEmail = string.IsNullOrWhiteSpace(txtCMND.Text);
        if (bHoKH == false && bTenKH == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == true)
        {
            kh.MaKH = txtMaKH.Text;
            kh.HoKH = txtHoKH.Text;
            kh.TenKH = txtTenKH.Text;
            kh.NgaySinh = txtNgaySinh.Text;//ngày sinh nên làm theo calendar.
            if (rdoNam.Checked == true)
                kh.GioiTinh = true;
            else
                kh.GioiTinh = false; 
            kh.CMND = txtCMND.Text;
            kh.SoDT = txtSoDT.Text;
            kh.Email = txtCMND.Text;
            kh.SoNhaKHTT = txtSoNhaKHTT.Text;
            kh.SoNhaKHLL = txtSoNhaKHLL.Text;
            kh.MaDuongKHTT = droDuongKHTT.SelectedValue;
            kh.MaDuongKHLL = droDuongKHLL.SelectedValue;
            kh.MaXaKHTT = droXaKHTT.SelectedValue;
            kh.MaXaKHLL = droXaKHLL.SelectedValue;
            //kh.MaNPP = Session["MaNPP"].ToString();//mã người đang login hoặc click
            kh.Them();
            lblTB.Visible = true;
            lblTB.Text = kh.ThongBao;
            griKhachHang.DataSource = kh.KhachHang_DS_TheoTheLoai(Session["MaNPP"].ToString(), bool.Parse(Session["Loai"].ToString()));//có tham số truyền vào.
            griKhachHang.DataBind();
            pnlChiTietKH.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
        {
                lblTB.Visible = true;
                lblTB.Text = "Ở các vị trí * bắt buộc bạn phải nhập.";
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        //khsd.Xoa();
        //cs.Xoa(); xóa theo đệ quy, bởi vì xóa tất cả các bản ghi chứa nó.
        kh.MaKH = griKhachHang.SelectedValue.ToString();
        kh.Xoa();
        lblTB.Visible = true;
        lblTB.Text = kh.ThongBao;
        txtMaKH.Text = "";
        txtHoKH.Text = "";
        txtTenKH.Text = "";
        //fileAnhNPP.HasFile = false;
        txtNgaySinh.Text = "";
        txtCMND.Text = "";
        txtSoDT.Text = "";
        txtCMND.Text = "";
        txtSoNhaKHTT.Text = "";
        txtSoNhaKHLL.Text = "";
        pnlChiTietKH.Visible = false;
        lbtThemMoi.Visible = true;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bHoKH = string.IsNullOrWhiteSpace(txtHoKH.Text);
        bool bTenKH = string.IsNullOrWhiteSpace(txtTenKH.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        if (bHoKH == false && bTenKH == false && bNgaySinh == false && bSoDT == false)
        {
            kh.MaKH = griKhachHang.SelectedValue.ToString();
            kh.HoKH = txtHoKH.Text;
            kh.TenKH = txtTenKH.Text;
            kh.NgaySinh = txtNgaySinh.Text;
            if(rdoNam.Checked == true)
                kh.GioiTinh = true;
            else
                kh.GioiTinh = false;
            kh.CMND = txtCMND.Text;
            kh.SoDT = txtSoDT.Text;
            kh.Email = txtCMND.Text;
            kh.SoNhaKHTT = txtSoNhaKHTT.Text;
            kh.SoNhaKHLL = txtSoNhaKHLL.Text;
            kh.MaDuongKHTT = droDuongKHTT.SelectedValue;
            kh.MaDuongKHLL = droDuongKHLL.SelectedValue;
            kh.MaXaKHTT = droXaKHTT.SelectedValue;
            kh.MaXaKHLL = droXaKHLL.SelectedValue;
            /*npp.MaHuyenNPPTT = droHuyenNPPTT.SelectedValue;
            npp.MaHuyenNPPLL = droHuyenNPPLL.SelectedValue;
            npp.MaTinhNPPTT = droTinhNPPTT.SelectedValue;
            npp.MaTinhNPPLL = droTinhNPPLL.SelectedValue;*/
            kh.Sua();//bên sql m khai báo bnhiu tham số thì bên này khai báo lại hếết ???
            lblTB.Visible = true;
            lblTB.Text = kh.ThongBao;
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Các vị trí * là bắt buộc bạn nhập.";
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietKH.Visible = false;
        lbtThemMoi.Visible = true;
        lblTB.Visible = false;
    }
    protected void btnTroThanhNPP_Click(object sender, EventArgs e)
    {
        bool bMaADA = string.IsNullOrWhiteSpace(txtMaADA.Text);
        bool bHoNPP = string.IsNullOrWhiteSpace(txtHoKH.Text);
        bool bTenNPP = string.IsNullOrWhiteSpace(txtTenKH.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bCMND = string.IsNullOrWhiteSpace(txtCMND.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        bool bEmail = string.IsNullOrWhiteSpace(txtCMND.Text);
        if (bHoNPP == false && bTenNPP == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == true)
        {
            npp.MaADA = txtMaADA.Text;
            npp.HoNPP = txtHoKH.Text;
            npp.TenNPP = txtTenKH.Text;
            npp.NgaySinh = txtNgaySinh.Text;//ngày sinh nên làm theo calendar.
            if (rdoNam.Checked == true)
                npp.GioiTinh = true;
            else
                npp.GioiTinh = false;
            string DuongDan = "";
            DuongDan = Server.MapPath("~/src/emp/");
            DuongDan = DuongDan + fileAnhNPP.FileName;
            fileAnhNPP.SaveAs(DuongDan);
            npp.AnhNPP = fileAnhNPP.FileName;
            npp.CMND = txtCMND.Text;
            npp.SoDT = txtSoDT.Text;
            npp.Email = txtCMND.Text;
            npp.SoNhaNPPTT = txtSoNhaKHTT.Text;
            npp.SoNhaNPPLL = txtSoNhaKHLL.Text;
            npp.MaCD = int.Parse(droCapDo.SelectedValue);
            npp.MaDuongNPPTT = droDuongKHTT.SelectedValue;
            npp.MaDuongNPPLL = droDuongKHLL.SelectedValue;
            npp.MaXaNPPTT = droXaKHTT.SelectedValue;
            npp.MaXaNPPLL = droXaKHLL.SelectedValue;
            npp.MaNBT = Session["MaNBT"].ToString();//mã người đang login hoặc click
            npp.Them();
            kh.MaKH = griKhachHang.SelectedValue.ToString();
            kh.Xoa();
            lblTB.Visible = true;
            lblTB.Text = kh.ThongBao;
            txtMaKH.Text = "";
            txtMaADA.Text = "";
            txtHoKH.Text = "";
            txtTenKH.Text = "";
            txtNgaySinh.Text = "";
            txtCMND.Text = "";
            txtSoDT.Text = "";
            txtEmail.Text = "";
            txtNgayKyThe.Text = "";
            txtSoNhaKHTT.Text = "";
            txtSoNhaKHLL.Text = "";
            lblTBKH.Visible = true;
            lblTBKH.Text = npp.ThongBao;
            griKhachHang.DataSource = kh.KhachHang_DS_TheoTheLoai(Session["MaNPP"].ToString(), bool.Parse(Session["Loai"].ToString()));//có tham số truyền vào
            griKhachHang.DataBind();
            pnlChiTietKH.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
        {
            if (fileAnhNPP.HasFile == false)
            {
                lblTB.Visible = true;
                lblTB.Text = "Bạn cần thêm ảnh.";
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = "Ở các vị trí * bắt buộc bạn phải nhập.";
            }
        }
    }
}