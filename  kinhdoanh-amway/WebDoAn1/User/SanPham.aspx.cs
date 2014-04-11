using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_SanPham : System.Web.UI.Page
{
    lanhnt.MatHang mh = new lanhnt.MatHang();
    lanhnt.LoaiMH lmh = new lanhnt.LoaiMH();
    lanhnt.NPPSuDung nppsd = new lanhnt.NPPSuDung();
    lanhnt.KHSuDung khsd = new lanhnt.KHSuDung();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH(int.Parse(Session["MaLMH"].ToString()));//có tham số truyền vào
            griMatHang.DataBind();
            droLoaiMH.DataSource = lmh.DS();
            droLoaiMH.DataBind();
        }
    }

    protected void griMatHang_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlChiTietMH.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = false;
        btnXoa.Visible = true;
        btnSua.Visible = true;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        mh.MaMH = int.Parse(griMatHang.SelectedValue.ToString());
        mh.CT();
        txtMaMH.Text = mh.MaMH.ToString();
        txtMaMH.ReadOnly = true;
        txtTenMH.Text = mh.TenMH;
        txtGia.Text = mh.Gia.ToString();
        txtChiTiet.Text = mh.ChiTiet;
        //fckChiTiet.Text = mh.ChiTiet;
        txtCachSuDung.Text = mh.CachSuDung.ToString();
        lmh.MaLMH = mh.MaLMH;
        droLoaiMH.SelectedValue = lmh.MaLMH.ToString();
    }
    protected void griMatHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griMatHang.PageIndex = e.NewPageIndex;
        griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH(int.Parse(Session["MaLMH"].ToString()));// sửa có tham số truyền vào???.
        griMatHang.DataBind();
    }
    protected void lbtThemMoi_Click(object sender, EventArgs e)
    {
        //sp.GetID();
        //Session["URL"] = "SP_" + sp.TempID + "file";
        pnlChiTietMH.Visible = true;
        lbtThemMoi.Visible = false;
        btnThem.Visible = true;
        btnSuDung.Visible = false;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        btnIn.Visible = true;
        btnThoat.Visible = true;
        lblTB.Visible = false;
        txtMaMH.Enabled = true;
        txtMaMH.Text = "";
        txtTenMH.Text = "";
        txtGia.Text = "";
        txtChiTiet.Text = "";
        //fckChiTiet.Text = "";//nếu là fck
        txtCachSuDung.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool bMaMH = string.IsNullOrWhiteSpace(txtMaMH.Text);
        bool bTenMH = string.IsNullOrWhiteSpace(txtTenMH.Text);
        bool bGia = string.IsNullOrWhiteSpace(txtGia.Text);
        if (bTenMH == false && bGia == false && fileAnhMH.HasFile == true)
        {
            mh.MaMH = int.Parse(txtMaMH.Text);
            mh.TenMH = txtTenMH.Text;
            string DuongDan = "";
            DuongDan = Server.MapPath("~/src/product/");
            DuongDan = DuongDan + fileAnhMH.FileName;
            fileAnhMH.SaveAs(DuongDan);
            mh.AnhMH = fileAnhMH.FileName;
            mh.ChiTiet = txtChiTiet.Text;
            //mh.ChiTiet = fckChiTiet.Text;
            mh.CachSuDung = txtCachSuDung.Text;
            mh.Gia = float.Parse(txtGia.Text);
            mh.MaLMH = int.Parse(Session["MaLMHClick"].ToString()); ;//lấy mã loại mặt hàng đang được click.
            mh.Them();
            lblTB.Visible = true;
            lblTB.Text = mh.ThongBao;
            griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH(int.Parse(Session["MaLMH"].ToString()));
            griMatHang.DataBind();
            pnlChiTietMH.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
        {
            if (fileAnhMH.HasFile == false)
            {
                lblTB.Visible = true;
                lblTB.Text = "Bạn phải chọn ảnh sản phẩm.";
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
        mh.MaMH = int.Parse(griMatHang.SelectedValue.ToString());
        mh.Xoa();
        lblTB.Visible = true;
        lblTB.Text = mh.ThongBao;
        griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH(int.Parse(Session["MaLMH"].ToString()));
        griMatHang.DataBind();
        txtMaMH.Text = "";
        txtTenMH.Text = "";
        txtGia.Text = "";
        txtChiTiet.Text = "";
        //fckChiTiet.Text = "";
        txtCachSuDung.Text = "";      
        pnlChiTietMH.Visible = false;
        lbtThemMoi.Visible = true;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool bTenMH = string.IsNullOrWhiteSpace(txtTenMH.Text);
        bool bGia = string.IsNullOrWhiteSpace(txtGia.Text);
        bool bCachSuDung = string.IsNullOrWhiteSpace(txtCachSuDung.Text);
        bool bChiTiet = string.IsNullOrWhiteSpace(txtChiTiet.Text);
        if (bTenMH == false && bGia == false && bCachSuDung == false && bChiTiet == false && fileAnhMH.HasFile == true)
        {
            mh.MaMH = int.Parse(griMatHang.SelectedValue.ToString());
            mh.TenMH = txtTenMH.Text;
            string DuongDan = "";
            DuongDan = Server.MapPath("~/src/product/");
            DuongDan = DuongDan + fileAnhMH.FileName;
            fileAnhMH.SaveAs(DuongDan);
            mh.AnhMH = fileAnhMH.FileName;
            mh.Gia = double.Parse(txtGia.Text);
            mh.CachSuDung = txtCachSuDung.Text;
            mh.ChiTiet = txtChiTiet.Text;
            //mh.ChiTiet = fckChiTiet.Text;
            mh.MaLMH = int.Parse(droLoaiMH.SelectedValue);
            mh.Sua();//bên sql m khai báo bnhiu tham số thì bên này khai báo lại hếết ???
            lblTB.Visible = true;
            lblTB.Text = mh.ThongBao;
            griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH(int.Parse(Session["MaLMH"].ToString()));
            griMatHang.DataBind();
            pnlChiTietMH.Visible = false;
            lbtThemMoi.Visible = true;
        }
        else
            if (bTenMH == false && bGia == false && bCachSuDung == false && bChiTiet == false && fileAnhMH.HasFile == false)
            {
                mh.MaMH = int.Parse(griMatHang.SelectedValue.ToString());
                mh.CT();
                string temp = mh.AnhMH.ToString();
                mh.TenMH = txtTenMH.Text;
                mh.AnhMH = temp;
                mh.Gia = double.Parse(txtGia.Text);
                mh.CachSuDung = txtCachSuDung.Text;
                mh.ChiTiet = txtChiTiet.Text;
                //mh.ChiTiet = fckChiTiet.Text;
                mh.MaLMH = int.Parse(droLoaiMH.SelectedValue);
                mh.Sua();
                lblTB.Visible = true;
                lblTB.Text = mh.ThongBao;
                griMatHang.DataSource = mh.DS();
                griMatHang.DataBind();
                pnlChiTietMH.Visible = false;
                lbtThemMoi.Visible = true;
            }
            else
            {
                lblTB.Visible = true;
                lblTB.Text = "Các vị trí * là bắt buộc nhập.";
            }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        pnlChiTietMH.Visible = false;
        lbtThemMoi.Visible = true;
        lblTB.Visible = false;
    }
    protected void btnSuDung_Click(object sender, EventArgs e)
    {
        txtSoLuong.Visible = true;
        chkMinhHoa.Visible = true;
        if (Session["MaKH"].ToString() == null)//???nếu không chọn khách hàng thì sử dụng này là nhà phân phối sử dụng
        {
            nppsd.MaMH = int.Parse(griMatHang.SelectedValue.ToString());
            nppsd.MaNPP = Session["MaNPP"].ToString();
            nppsd.SoLuong = int.Parse(txtSoLuong.Text);
            if (chkMinhHoa.Checked == true)
                nppsd.MinhHoa = true;
            else
                nppsd.MinhHoa = false;
            nppsd.Them();
            lblTB.Visible = true;
            lblTB.Text = nppsd.ThongBao;
        }
        else
        {
            khsd.MaMH = int.Parse(griMatHang.SelectedValue.ToString());
            khsd.MaKH = Session["MaKH"].ToString();
            khsd.MaNPP = Session["MaNPP"].ToString();
            khsd.SoLuong = int.Parse(txtSoLuong.Text);
            if (chkMinhHoa.Checked == true)
                khsd.MinhHoa = true;
            else
                khsd.MinhHoa = false;
            khsd.Them();
            lblTB.Visible = true;
            lblTB.Text = khsd.ThongBao;
        }
        txtSoLuong.Visible = false;
        chkMinhHoa.Visible = false;
    }
}
