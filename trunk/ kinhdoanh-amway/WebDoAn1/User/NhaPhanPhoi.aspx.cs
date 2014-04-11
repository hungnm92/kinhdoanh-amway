using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_NhaPhanPhoi : System.Web.UI.Page
{
    lanhnt.NhaPhanPhoi npp = new lanhnt.NhaPhanPhoi();
    lanhnt.CapDo cd = new lanhnt.CapDo();
    lanhnt.Duong d = new lanhnt.Duong();
    lanhnt.XaPhuong xp = new lanhnt.XaPhuong();
    lanhnt.Huyen h = new lanhnt.Huyen();
    lanhnt.Tinh t = new lanhnt.Tinh();
    lanhnt.NPPSuDung nppsd = new lanhnt.NPPSuDung();
    lanhnt.KHSuDung khsd = new lanhnt.KHSuDung();
    lanhnt.DaoTao dt = new lanhnt.DaoTao();
    lanhnt.ChamSoc cs = new lanhnt.ChamSoc();
    lanhnt.DoanhThu dthu = new lanhnt.DoanhThu();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));//có tham số truyền vào.
            griNhaPhanPhoi.DataBind();
            droCapDo.DataSource = cd.DS();
            droCapDo.DataBind();
            droDuongNPPLL.DataSource = d.DS();
            droDuongNPPLL.DataBind();
            droDuongNPPTT.DataSource = d.DS();
            droDuongNPPTT.DataBind();
            droXaNPPLL.DataSource = xp.DS();
            droXaNPPLL.DataBind();
            droXaNPPTT.DataSource = xp.DS();
            droXaNPPTT.DataBind();
            droHuyenNPPLL.DataSource = h.DS();
            droHuyenNPPLL.DataBind();
            droHuyenNPPTT.DataSource = h.DS();
            droHuyenNPPTT.DataBind();
            droTinhNPPLL.DataSource = t.DS();
            droTinhNPPLL.DataBind();
            droTinhNPPTT.DataSource = t.DS();
            droTinhNPPTT.DataBind();
        }
    }
    protected void griNhaPhanPhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietNPP.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = false;
        btnXoa.Visible = true;
        btnSua.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        npp.MaADA = griNhaPhanPhoi.SelectedValue.ToString();
        npp.CT();
        txtMaADA.Text = npp.MaADA;
        txtMaADA.ReadOnly = true;
        txtHoNPP.Text = npp.HoNPP;
        txtTenNPP.Text = npp.TenNPP;
        imgAnhNPP.ImageUrl = npp.AnhNPP;// m không biết lele.
        cd.MaCD = npp.MaCD;
        droCapDo.SelectedValue = cd.MaCD.ToString();
        txtNgaySinh.Text = npp.NgaySinh;
        if (npp.GioiTinh == true)
        {
            rdoNam.Checked = true;
        }
        else
            rdoNu.Checked = true;
        txtCMND.Text = npp.CMND;
        txtSoDT.Text = npp.SoDT;
        txtEmail.Text = npp.Email;
        txtNgayKyThe.Text = npp.NgayKyThe;
        txtNgayKyThe.ReadOnly = true;
        txtSoNhaNPPTT.Text = npp.SoNhaNPPTT;
        txtSoNhaNPPLL.Text = npp.SoNhaNPPLL;
        d.MaDuong = npp.MaDuongNPPTT;
        droDuongNPPTT.SelectedValue = d.MaDuong.ToString();
        d.MaDuong = npp.MaDuongNPPLL;
        droDuongNPPLL.SelectedValue = d.MaDuong.ToString();
        xp.MaXa = npp.MaXaNPPTT;
        droXaNPPTT.SelectedValue = xp.MaXa.ToString();
        xp.MaXa = npp.MaXaNPPLL;
        droXaNPPLL.SelectedValue = xp.MaXa.ToString();
        xp.MaXa = npp.MaXaNPPTT;///////////// đúng không???.
        h.MaHuyen = xp.MaHuyen;
        droHuyenNPPTT.SelectedValue = h.MaHuyen.ToString();
        xp.MaXa = npp.MaXaNPPLL;///////////// đúng không???.
        h.MaHuyen = xp.MaHuyen;
        droHuyenNPPLL.SelectedValue = h.MaHuyen.ToString();
        xp.MaHuyen = npp.MaXaNPPTT;///////////// đúng không???.
        h.MaHuyen = xp.MaHuyen;
        t.MaTinh = h.MaTinh;
        droHuyenNPPTT.SelectedValue = t.MaTinh.ToString();
        xp.MaHuyen = npp.MaXaNPPLL;///////////// đúng không???.
        h.MaHuyen = xp.MaHuyen;
        t.MaTinh = h.MaTinh;
        droHuyenNPPLL.SelectedValue = t.MaTinh.ToString();
    }
    protected void griNhaPhanPhoi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griNhaPhanPhoi.PageIndex = e.NewPageIndex;
        griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));// sửa có tham số truyền vào???.
        griNhaPhanPhoi.DataBind();
    }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {
        //sp.GetID();
       // Session["URL"] = "SP_" + sp.TempID + "file";
        pnlChiTietNPP.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = true;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        txtMaADA.Text = "";
        txtHoNPP.Text = "";
        txtTenNPP.Text = "";
       // fileAnhNPP.HasFile = false;
        txtNgaySinh.Text = "";
        txtCMND.Text = "";
        txtSoDT.Text = "";
        txtEmail.Text = "";
        txtNgayKyThe.Text = "";
        txtSoNhaNPPTT.Text = "";
        txtSoNhaNPPLL.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool bMaADA = string.IsNullOrWhiteSpace(txtMaADA.Text);
        bool bHoNPP = string.IsNullOrWhiteSpace(txtHoNPP.Text);
        bool bTenNPP = string.IsNullOrWhiteSpace(txtTenNPP.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bCMND = string.IsNullOrWhiteSpace(txtCMND.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        bool bEmail = string.IsNullOrWhiteSpace(txtEmail.Text);
        if (bHoNPP == false && bTenNPP == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == true)
        {
            npp.MaADA = txtMaADA.Text;
            npp.HoNPP = txtHoNPP.Text;
            npp.TenNPP = txtTenNPP.Text;
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
            npp.Email = txtEmail.Text;
            npp.SoNhaNPPTT = txtSoNhaNPPTT.Text;
            npp.SoNhaNPPLL = txtSoNhaNPPLL.Text;     
            npp.MaCD = int.Parse(droCapDo.SelectedValue);
            npp.MaDuongNPPTT = droDuongNPPTT.SelectedValue;
            npp.MaDuongNPPLL = droDuongNPPLL.SelectedValue;
            npp.MaXaNPPTT = droXaNPPTT.SelectedValue;
            npp.MaXaNPPLL = droXaNPPLL.SelectedValue;
            npp.MaNBT = Session["MaNBT"].ToString();//mã người đang login hoặc click
            npp.Them();
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;
            griNhaPhanPhoi.DataSource = npp.DS();
            griNhaPhanPhoi.DataBind();
            pnlChiTietNPP.Visible = false;
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
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        btnChuyenMacDinh.Visible = true;
        btnChuyenTheoYeuCau.Visible = true;       
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietNPP.Visible = false;
        lbtThemMoi.Visible = true;
        lblTB.Visible = false;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bHoNPP = string.IsNullOrWhiteSpace(txtHoNPP.Text);
        bool bTenNPP = string.IsNullOrWhiteSpace(txtTenNPP.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bCMND = string.IsNullOrWhiteSpace(txtCMND.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        bool bEmail = string.IsNullOrWhiteSpace(txtEmail.Text);
        if (bHoNPP == false && bTenNPP == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == true)
        {
            npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
            npp.HoNPP = txtHoNPP.Text;
            npp.TenNPP = txtTenNPP.Text;
            npp.NgaySinh = txtNgaySinh.Text;
            if(rdoNam.Checked == true)
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
            npp.Email = txtEmail.Text;
            npp.SoNhaNPPTT = txtSoNhaNPPTT.Text;
            npp.SoNhaNPPLL = txtSoNhaNPPLL.Text;
            npp.MaDuongNPPTT = droDuongNPPTT.SelectedValue;
            npp.MaDuongNPPLL = droDuongNPPLL.SelectedValue;
            npp.MaXaNPPTT = droXaNPPTT.SelectedValue;
            npp.MaXaNPPLL = droXaNPPLL.SelectedValue;
            /*npp.MaHuyenNPPTT = droHuyenNPPTT.SelectedValue;
            npp.MaHuyenNPPLL = droHuyenNPPLL.SelectedValue;
            npp.MaTinhNPPTT = droTinhNPPTT.SelectedValue;
            npp.MaTinhNPPLL = droTinhNPPLL.SelectedValue;*/
            npp.MaCD = int.Parse(droCapDo.SelectedValue);
            npp.Sua();//bên sql m khai báo bnhiu tham số thì bên này khai báo lại hếết ???
            griNhaPhanPhoi.DataSource = npp.DS();
            griNhaPhanPhoi.DataBind();
            pnlChiTietNPP.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
            if (bHoNPP == false && bTenNPP == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == false)
            {
                npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
                npp.CT();
                string temp = npp.AnhNPP.ToString();
                npp.HoNPP = txtHoNPP.Text;
                npp.TenNPP = txtTenNPP.Text;
                npp.NgaySinh = txtNgaySinh.Text;
                if (rdoNam.Checked == true)
                    npp.GioiTinh = true;
                else
                    npp.GioiTinh = false;
                npp.AnhNPP = temp;
                npp.CMND = txtCMND.Text;
                npp.SoDT = txtSoDT.Text;
                npp.Email = txtEmail.Text;
                npp.SoNhaNPPTT = txtSoNhaNPPTT.Text;
                npp.SoNhaNPPLL = txtSoNhaNPPLL.Text;
                npp.MaDuongNPPTT = droDuongNPPTT.SelectedValue;
                npp.MaDuongNPPLL = droDuongNPPLL.SelectedValue;
                npp.MaXaNPPTT = droXaNPPTT.SelectedValue;
                npp.MaXaNPPLL = droXaNPPLL.SelectedValue;
                 /*npp.MaHuyenNPPTT = droHuyenNPPTT.SelectedValue;
                npp.MaHuyenNPPLL = droHuyenNPPLL.SelectedValue;
                npp.MaTinhNPPTT = droTinhNPPTT.SelectedValue;
                npp.MaTinhNPPLL = droTinhNPPLL.SelectedValue;*/
                npp.MaCD = int.Parse(droCapDo.SelectedValue);
                npp.Sua();//bên sql m khai báo bnhiu tham số thì bên này khai báo lại hếết ???
                griNhaPhanPhoi.DataSource = npp.DS();
                griNhaPhanPhoi.DataBind();
                pnlChiTietNPP.Visible = false;
                lbtThemMoi.Visible = true;
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = "Các vị trí * là bắt buộc bạn nhập.";
            }
    }
    protected void btnChuyenMacDinh_Click(object sender, EventArgs e)
    {
        npp.MaNPP = Session["MaNPP"].ToString();
        //npp.MaNPP = Session["MaNPPClick"].ToString();
        npp.CT();
        //sửa mã nhà bảo trợ cho tất cả các nhà phân phối tuyến dưới nó. với mã nhà bảo trợ là mã nhà bảo trợ vừa tìm được trong npp.CT();
        //string MaNBTMoi = npp.MaNBT;
       //npp.Sua(); chắc sẽ có vòng lặp danh sách các nhà phân phối có mã bảo trợ là nó, rồi thay thế mã nhà bảo trợ.npp.DS_NhaPhanPhoi();
        //while  ()
        npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
        nppsd.Xoa();
        khsd.Xoa();
        dthu.Xoa();
        dt.Xoa();
        cs.Xoa();
        //ghép các nhà phân phối cấp dưới lên nhà phân phối cấp trên: 1. ghép theo yêu cầu vợ chồng, 2 ghép theo mặc định cho nhà bảo trợ tuyến trên.
        npp.Xoa();
        lblTB.Visible = true;
        lblTB.Text = npp.ThongBao;
        txtMaADA.Text = "";
        txtHoNPP.Text = "";
        txtTenNPP.Text = "";
        //fileAnhNPP.HasFile = false;
        txtNgaySinh.Text = "";
        txtCMND.Text = "";
        txtSoDT.Text = "";
        txtEmail.Text = "";
        txtNgayKyThe.Text = "";
        txtSoNhaNPPTT.Text = "";
        txtSoNhaNPPLL.Text = "";
        pnlChiTietNPP.Visible = false;
        lbtThemMoi.Visible = true;
    }
    protected void btnChuyenTheoYeuCau_Click(object sender, EventArgs e)
    {
        npp.MaNPP = Session["MaNPP"].ToString();
        //npp.MaNPP = Session["MaNPPClick"].ToString();
        npp.CT();
        //sửa mã nhà bảo trợ cho tất cả các nhà phân phối tuyến dưới nó. với mã nhà bảo trợ là mã nhà bảo trợ vừa tìm được trong npp.CT();
        //string MaNBTMoi = npp.MaNBT;
        //npp.Sua(); chắc sẽ có vòng lặp danh sách các nhà phân phối có mã bảo trợ là nó, rồi thay thế mã nhà bảo trợ.npp.DS_NhaPhanPhoi();
        //while  ()NhaPhanPhoi_ChuyenNBT();
        npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
        nppsd.Xoa();
        khsd.Xoa();
        dthu.Xoa();
        dt.Xoa();
        cs.Xoa();
        //ghép các nhà phân phối cấp dưới lên nhà phân phối cấp trên: 1. ghép theo yêu cầu vợ chồng, 2 ghép theo mặc định cho nhà bảo trợ tuyến trên.
        npp.Xoa();
        lblTB.Visible = true;
        lblTB.Text = npp.ThongBao;
        txtMaADA.Text = "";
        txtHoNPP.Text = "";
        txtTenNPP.Text = "";
        //fileAnhNPP.HasFile = false;
        txtNgaySinh.Text = "";
        txtCMND.Text = "";
        txtSoDT.Text = "";
        txtEmail.Text = "";
        txtNgayKyThe.Text = "";
        txtSoNhaNPPTT.Text = "";
        txtSoNhaNPPLL.Text = "";
        pnlChiTietNPP.Visible = false;
        lbtThemMoi.Visible = true;
    }
}