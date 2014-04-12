using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_SanPham : System.Web.UI.Page
{
    lanhnt.MatHang mh = new lanhnt.MatHang();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH();//có tham số truyền vào
            griMatHang.DataBind();
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
    }
    protected void griMatHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griMatHang.PageIndex = e.NewPageIndex;
        griMatHang.DataSource = mh.MatHang_DS_TheoLoaiMH();// sửa có tham số truyền vào???.
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
        txtMaMH.Text = "";
        txtMaMH.ReadOnly = true;//nếu nhập thì bỏ???.
        txtTenMH.Text = "";
        txtGia.Text = "";
        txtChiTiet.Text = "";
        //fckChiTiet.Text = "";//nếu là fck
        txtCachSuDung.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
       // bool bMaMH = string.IsNullOrWhiteSpace(txtMaMH.Text);
        bool bTenMH = string.IsNullOrWhiteSpace(txtTenMH.Text);
        bool bGia = string.IsNullOrWhiteSpace(txtGia.Text);
        if (bTenMH == false && bGia == false && fileAnhMH.HasFile == true)
        {
            //mh.MaMH = int.Parse(txtMaMH.Text);
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
            mh.MaLMH = ;//lấy mã loại mặt hàng đang được click.
            mh.Them();
            lblTB.Visible = true;
            lblTB.Text = mh.ThongBao;
            griMatHang.DataSource = mh.DS();
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
}
