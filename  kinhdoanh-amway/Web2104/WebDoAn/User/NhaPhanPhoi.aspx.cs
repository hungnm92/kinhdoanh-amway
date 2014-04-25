using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class User_NhaPhanPhoi : System.Web.UI.Page
{
    webdoan.NhaPhanPhoi npp = new webdoan.NhaPhanPhoi();
    webdoan.CapDo cd = new webdoan.CapDo();
    webdoan.Duong dll = new webdoan.Duong();
    webdoan.Duong dtt = new webdoan.Duong();
    webdoan.XaPhuong xpll = new webdoan.XaPhuong();
    webdoan.XaPhuong xptt = new webdoan.XaPhuong();
    webdoan.Huyen hll = new webdoan.Huyen();
    webdoan.Huyen htt = new webdoan.Huyen();
    webdoan.Tinh tll = new webdoan.Tinh();
    webdoan.Tinh ttt = new webdoan.Tinh();
    webdoan.NPPSuDung nppsd = new webdoan.NPPSuDung();
    webdoan.KHSuDung khsd = new webdoan.KHSuDung();
    webdoan.DaoTao dt = new webdoan.DaoTao();
    webdoan.ChamSoc cs = new webdoan.ChamSoc();
    webdoan.DoanhThu dthu = new webdoan.DoanhThu();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Request.QueryString["MaADA"] != null)
                Session["MaNPPClick"] = Request.QueryString["MaADA"];
            if (Session["MaNPPClick"] == null)
            {
                griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
            }
            else
                griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPPClick"].ToString(), int.Parse(Session["MaCD"].ToString()));
            griNhaPhanPhoi.DataBind();
            droCapDo.DataSource = cd.DS();
            droCapDo.DataBind();
            droDuongNPPLL.DataSource = dll.DS();
            droDuongNPPLL.DataBind();
            droDuongNPPTT.DataSource = dtt.DS();
            droDuongNPPTT.DataBind();
            droXaNPPLL.DataSource = xpll.DS();
            droXaNPPLL.DataBind();
            droXaNPPTT.DataSource = xptt.DS();
            droXaNPPTT.DataBind();
            droHuyenNPPLL.DataSource = hll.DS();
            droHuyenNPPLL.DataBind();
            droHuyenNPPTT.DataSource = htt.DS();
            droHuyenNPPTT.DataBind();
            droTinhNPPLL.DataSource = tll.DS();
            droTinhNPPLL.DataBind();
            droTinhNPPTT.DataSource = ttt.DS();
            droTinhNPPTT.DataBind();
            droNhaBaoTro.DataSource = npp.DS();
            droNhaBaoTro.DataBind();
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
        btnChuyenMacDinh.Visible = false;
        btnChuyenTheoYeuCau.Visible = false;
        npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
        npp.CT();
        txtMaNPP.Text = npp.MaNPP;
        txtMaNPP.Enabled = false;
        txtHoNPP.Text = npp.HoNPP;
        txtTenNPP.Text = npp.TenNPP;
        txtNgaySinh.Text = npp.NgaySinh;
        txtNgaySinh.Enabled = false;
        /*if (npp.GioiTinh == true)
            rdoNam.Checked = npp.GioiTinh;
        else
            rdoNu.Checked = npp.GioiTinh;*/
        /*if (griNhaPhanPhoi.Rows[griNhaPhanPhoi.SelectedIndex].Cells[4]. == true)
            rdoNam.Checked = true;
        else
            rdoNu.Checked = true;*/
        if (npp.GioiTinh == null)
        {rdoNu.Checked = true ;
            rdoNam.Checked = false;}
        else
            rdoNam.Checked = npp.GioiTinh;
        imgAnhNPP.ImageUrl = "~/src/emp/" + npp.AnhNPP;
        txtCMND.Text = npp.CMND;
        txtCMND.Enabled = false;
        txtSoDT.Text = npp.SoDT;
        txtEmail.Text = npp.Email;
        txtNgayKyThe.Text = npp.NgayKyThe;
        txtNgayKyThe.Enabled = false;
        txtSoNhaNPPLL.Text = npp.SoNhaNPPLL;
        txtSoNhaNPPTT.Text = npp.SoNhaNPPTT;
        cd.MaCD = npp.MaCD;
        droCapDo.SelectedValue = cd.MaCD.ToString();
        dll.MaDuong = npp.MaDuongNPPLL;
        droDuongNPPLL.SelectedValue = dll.MaDuong.ToString();
        dtt.MaDuong = npp.MaDuongNPPTT;
        droDuongNPPTT.SelectedValue = dtt.MaDuong.ToString();
        xpll.MaXa = npp.MaXaNPPLL;
        droXaNPPLL.SelectedValue = xpll.MaXa.ToString();
        xptt.MaXa = npp.MaXaNPPTT;
        droXaNPPTT.SelectedValue = xptt.MaXa.ToString();
        hll.MaHuyen = npp.MaHuyenNPPLL;
        droHuyenNPPLL.SelectedValue = hll.MaHuyen.ToString();
        htt.MaHuyen = npp.MaHuyenNPPTT;
        droHuyenNPPTT.SelectedValue = htt.MaHuyen.ToString();
        tll.MaTinh = npp.MaTinhNPPLL;
        droTinhNPPLL.SelectedValue = tll.MaTinh.ToString();
        ttt.MaTinh = npp.MaTinhNPPTT;
        droTinhNPPTT.SelectedValue = ttt.MaTinh.ToString();
    }
    protected void griNhaPhanPhoi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griNhaPhanPhoi.PageIndex = e.NewPageIndex;
        if (Request.QueryString["MaADA"] != null)
            Session["MaNPPClick"] = Request.QueryString["MaADA"];
        if (Session["MaNPPClick"] == null)
        {
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
        }
        else
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPPClick"].ToString(), int.Parse(Session["MaCD"].ToString()));
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
        btnChuyenMacDinh.Visible = false;
        btnChuyenTheoYeuCau.Visible = false;
        txtMaNPP.Text = "";
        txtMaNPP.Enabled = true;
        txtHoNPP.Text = "";
        txtTenNPP.Text = "";
       // fileAnhNPP.HasFile = false;
        txtNgaySinh.Text = "";
        txtNgaySinh.Enabled = true;
        txtCMND.Text = "";
        txtCMND.Enabled = true;
        txtSoDT.Text = "";
        txtEmail.Text = "";
        txtNgayKyThe.Text = "";
        txtNgayKyThe.Enabled = true;
        txtSoNhaNPPTT.Text = "";
        txtSoNhaNPPLL.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool bMaADA = string.IsNullOrWhiteSpace(txtMaNPP.Text);
        bool bHoNPP = string.IsNullOrWhiteSpace(txtHoNPP.Text);
        bool bTenNPP = string.IsNullOrWhiteSpace(txtTenNPP.Text);
        bool bNgaySinh = string.IsNullOrWhiteSpace(txtNgaySinh.Text);
        bool bCMND = string.IsNullOrWhiteSpace(txtCMND.Text);
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        bool bEmail = string.IsNullOrWhiteSpace(txtEmail.Text);
        bool bNgayKyThe = string.IsNullOrWhiteSpace(txtNgayKyThe.Text);
        if (bMaADA == false && bHoNPP == false && bTenNPP == false && bNgaySinh == false && bCMND == false && bSoDT == false && bEmail == false && bNgayKyThe == false && fileAnhNPP.HasFile == true)
        {
            npp.MaNPP = txtMaNPP.Text;
            npp.HoNPP = txtHoNPP.Text;
            npp.TenNPP = txtTenNPP.Text;
            npp.NgaySinh = txtNgaySinh.Text;
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
            npp.NgayKyThe = txtNgayKyThe.Text;
            npp.SoNhaNPPTT = txtSoNhaNPPTT.Text;
            npp.SoNhaNPPLL = txtSoNhaNPPLL.Text;     
            npp.MaCD = int.Parse(droCapDo.SelectedValue);
            npp.MaDuongNPPTT = droDuongNPPTT.SelectedValue;
            npp.MaDuongNPPLL = droDuongNPPLL.SelectedValue;
            npp.MaXaNPPTT = droXaNPPTT.SelectedValue;
            npp.MaXaNPPLL = droXaNPPLL.SelectedValue;
            npp.MaNBT = Session["MaNPP"].ToString();//mã người đang login hoặc click
            //npp.MaNBT = Session["MaNPPClick"].ToString();
            npp.Them();
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
            pnlChiTietNPP.Visible = false;
            lbtThemMoi.Visible = true;
            //Response.Redirect("~/User/NhaPhanPhoi.aspx");
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
        if (npp.SL_NhaPhanPhoi(griNhaPhanPhoi.SelectedValue.ToString()) == 0)
        {
            npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
            nppsd.MaNPP = npp.MaNPP;
            nppsd.Xoa_DS();
            khsd.MaNPP = npp.MaNPP;
            khsd.MaNPPMoi = npp.MaNBT;
            khsd.Sua_NPP();
            dthu.MaNPP = npp.MaNPP;
            dthu.Xoa_DS();
            dt.MaNPP = npp.MaNPP;
            dt.Xoa_DS();
            cs.MaNPP = npp.MaNPP;
            cs.MaNPPMoi = npp.MaNBT;
            cs.Sua_NPP();
            npp.Xoa();
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
            griNhaPhanPhoi.DataBind();
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;// không thực hiện được tại vì nó đã response.
            txtMaNPP.Text = "";
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
            //Response.Redirect("~/User/NhaPhanPhoi.aspx");
        }
        else
        {
            btnChuyenMacDinh.Visible = true;
            btnChuyenTheoYeuCau.Visible = true;
            droNhaBaoTro.Visible = true;
        }
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
        bool bSoDT = string.IsNullOrWhiteSpace(txtSoDT.Text);
        bool bEmail = string.IsNullOrWhiteSpace(txtEmail.Text);
        if (bHoNPP == false && bTenNPP == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == true)
        {
            npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
            npp.HoNPP = txtHoNPP.Text;
            npp.TenNPP = txtTenNPP.Text;
            if(rdoNam.Checked == true)
                npp.GioiTinh = true;
            else
                npp.GioiTinh = false;
            string DuongDan = "";
            DuongDan = Server.MapPath("~/src/emp/");
            DuongDan = DuongDan + fileAnhNPP.FileName;
            fileAnhNPP.SaveAs(DuongDan);
            npp.AnhNPP = fileAnhNPP.FileName;
            npp.SoDT = txtSoDT.Text;
            npp.Email = txtEmail.Text;
            npp.SoNhaNPPTT = txtSoNhaNPPTT.Text;
            npp.SoNhaNPPLL = txtSoNhaNPPLL.Text;
            npp.MaDuongNPPTT = droDuongNPPTT.SelectedValue;
            npp.MaDuongNPPLL = droDuongNPPLL.SelectedValue;
            npp.MaXaNPPTT = droXaNPPTT.SelectedValue;
            npp.MaXaNPPLL = droXaNPPLL.SelectedValue;
            npp.MaHuyenNPPTT = droHuyenNPPTT.SelectedValue;
            npp.MaHuyenNPPLL = droHuyenNPPLL.SelectedValue;
            npp.MaTinhNPPTT = droTinhNPPTT.SelectedValue;
            npp.MaTinhNPPLL = droTinhNPPLL.SelectedValue;
            npp.MaCD = int.Parse(droCapDo.SelectedValue);
            npp.MaNBT = Session["MaNPP"].ToString();
            npp.Sua();
            lblTB.Visible = true;
            lblTB.Text = npp.ThongBao;
            griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
            griNhaPhanPhoi.DataBind();
            pnlChiTietNPP.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
            if (bHoNPP == false && bTenNPP == false && bSoDT == false && bEmail == false && fileAnhNPP.HasFile == false)
            {
                npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
                npp.CT();
                string temp = npp.AnhNPP.ToString();
                npp.HoNPP = txtHoNPP.Text;
                npp.TenNPP = txtTenNPP.Text;
                if (rdoNam.Checked == true)
                    npp.GioiTinh = true;
                else
                    npp.GioiTinh = false;
                npp.AnhNPP = temp;
                npp.SoDT = txtSoDT.Text;
                npp.Email = txtEmail.Text;
                npp.SoNhaNPPTT = txtSoNhaNPPTT.Text;
                npp.SoNhaNPPLL = txtSoNhaNPPLL.Text;
                npp.MaDuongNPPTT = droDuongNPPTT.SelectedValue;
                npp.MaDuongNPPLL = droDuongNPPLL.SelectedValue;
                npp.MaXaNPPTT = droXaNPPTT.SelectedValue;
                npp.MaXaNPPLL = droXaNPPLL.SelectedValue;
                npp.MaHuyenNPPTT = droHuyenNPPTT.SelectedValue;
                npp.MaHuyenNPPLL = droHuyenNPPLL.SelectedValue;
                npp.MaTinhNPPTT = droTinhNPPTT.SelectedValue;
                npp.MaTinhNPPLL = droTinhNPPLL.SelectedValue;
                npp.MaCD = int.Parse(droCapDo.SelectedValue);
                npp.MaNBT = Session["MaNPP"].ToString();
                npp.Sua();
                lblTB.Visible = true;
                lblTB.Text = npp.ThongBao;
                griNhaPhanPhoi.DataSource = npp.NhaPhanPhoi_DS_TheoCapDo(Session["MaNPP"].ToString(), int.Parse(Session["MaCD"].ToString()));
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
        npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
        npp.CT();
        npp.Sua_NhaBaoTro();
        nppsd.MaNPP = npp.MaNPP;
        nppsd.Xoa_DS();
        khsd.MaNPP = npp.MaNPP;
        khsd.MaNPPMoi = npp.MaNBT;
        khsd.Sua_NPP();
        dthu.MaNPP = npp.MaNPP;
        dthu.Xoa_DS();
        dt.MaNPP = npp.MaNPP;
        dt.Xoa_DS();
        cs.MaNPP = npp.MaNPP;
        cs.MaNPPMoi = npp.MaNBT;
        cs.Sua_NPP();
        npp.Xoa();
        lblTB.Visible = true;
        lblTB.Text = npp.ThongBao;
        txtMaNPP.Text = "";
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
        Response.Redirect("~/User/NhaPhanPhoi.aspx");
    }
    protected void btnChuyenTheoYeuCau_Click(object sender, EventArgs e)
    {
        npp.MaNPP = griNhaPhanPhoi.SelectedValue.ToString();
        npp.CT();
        npp.MaNBT = droNhaBaoTro.SelectedValue;
        npp.Sua_NhaBaoTro();
        nppsd.MaNPP = npp.MaNPP;
        nppsd.Xoa_DS();
        khsd.MaNPP = npp.MaNPP;
        khsd.MaNPPMoi = droNhaBaoTro.SelectedValue;
        khsd.Sua_NPP();
        dthu.MaNPP = npp.MaNPP;
        dthu.Xoa_DS();
        dt.MaNPP = npp.MaNPP;
        dt.Xoa_DS();
        cs.MaNPP = npp.MaNPP;
        cs.MaNPPMoi = droNhaBaoTro.SelectedValue;
        cs.Sua_NPP();
        npp.Xoa();
        lblTB.Visible = true;
        lblTB.Text = npp.ThongBao;
        txtMaNPP.Text = "";
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
        Response.Redirect("~/User/NhaPhanPhoi.aspx");
    }
}