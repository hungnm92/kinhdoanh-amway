﻿using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;//chứa các đối tượng dataset.
using System.Data.SqlClient;//chứa các đối tượng SqlConnection, SqlCommand.
namespace webdoan
{
    public class Tinh
    {
        public string MaTinh;
        public string TenTinh;
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlDataAdapter XeTai = new SqlDataAdapter("Tinh_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class Huyen
    {
        public string MaHuyen;
        public string TenHuyen;
        public string MaTinh;
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlDataAdapter XeTai = new SqlDataAdapter("Huyen_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class XaPhuong
    {
        public string MaXa;
        public string TenXa;
        public string MaHuyen;
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlDataAdapter XeTai = new SqlDataAdapter("XaPhuong_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class Duong
    {
        public string MaDuong;
        public string TenDuong;
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlDataAdapter XeTai = new SqlDataAdapter("Duong_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class LoaiMH
    {
        public int MaLMH;
        public string TenLMH;
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlDataAdapter XeTai = new SqlDataAdapter("LoaiMH_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class CapDo
    {
        public int MaCD;
        public string TenCD;
        public string NoiDung;
        public string AnhCD;
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlDataAdapter XeTai = new SqlDataAdapter("CapDo_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class MatHang
    {
        public string MaMH;
        public int MaLMH;
        public string TenMH;
        public string TenLMH;
        public string ChiTiet;
        public string CachSuDung;
        public string AnhMH;
        public double Gia;
        public string ThongBao;
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlCommand Lenh = new SqlCommand("MatHang_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@MaMH", MaMH);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)//nếu có dữ liệu để đọc
            {
                MaMH = DocDL["MaMH"].ToString();
                MaLMH = int.Parse(DocDL["MaLMH"].ToString());
                TenMH = DocDL["TenMH"].ToString();
                TenLMH = DocDL["TenLMH"].ToString();
                ChiTiet = DocDL["ChiTiet"].ToString();
                CachSuDung = DocDL["CachSuDung"].ToString();
                AnhMH = DocDL["AnhMH"].ToString();
                Gia = double.Parse(DocDL["Gia"].ToString());
            }
            BaoVe.Close();
        }
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlDataAdapter XeTai = new SqlDataAdapter("MatHang_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("MatHang_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaMH", MaMH);
                ThamSo = Lenh.Parameters.AddWithValue("@MaLMH", MaLMH);
                ThamSo = Lenh.Parameters.AddWithValue("@TenMH", TenMH);
                ThamSo = Lenh.Parameters.AddWithValue("@ChiTiet", ChiTiet);
                ThamSo = Lenh.Parameters.AddWithValue("@CachSuDung", CachSuDung);
                ThamSo = Lenh.Parameters.AddWithValue("@AnhMH", AnhMH);
                ThamSo = Lenh.Parameters.AddWithValue("@Gia", Gia);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("MatHang_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaMH", MaMH);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("MatHang_Sua", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaMH", MaMH);
                ThamSo = Lenh.Parameters.AddWithValue("@MaLMH", MaLMH);
                ThamSo = Lenh.Parameters.AddWithValue("@TenMH", TenMH);
                ThamSo = Lenh.Parameters.AddWithValue("@ChiTiet", ChiTiet);
                ThamSo = Lenh.Parameters.AddWithValue("@CachSuDung", CachSuDung);
                ThamSo = Lenh.Parameters.AddWithValue("@AnhMH", AnhMH);
                ThamSo = Lenh.Parameters.AddWithValue("@Gia", Gia);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Sửa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public DataTable MatHang_DS_TheoLoaiMH(int MaLMH)
        {
            string SelectSQL = "SELECT MaMH, MH.MaLMH, TenMH, TenLMH, ChiTiet, CachSuDung, AnhMH, Gia FROM MatHang MH, LoaiMH LMH WHERE MH.MaLMH = LMH.MaLMH AND MH.MaLMH = @MaLMH";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaLMH", SqlDbType.Int).Value = MaLMH;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
    }
    public class ChuongTrinh
    {
        public string MaCT;
        public string TenCT;
        public string ThongBao;
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("ChuongTrinh_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaCT", MaCT);
                ThamSo = Lenh.Parameters.AddWithValue("@TenCT", TenCT);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCoDngVan");
                SqlCommand Lenh = new SqlCommand("ChuongTrinh_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaCT", MaCT);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("ChuongTrinh_Sua", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaCT", MaCT);
                ThamSo = Lenh.Parameters.AddWithValue("@TenCT", TenCT);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Sửa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlCommand Lenh = new SqlCommand("ChuongTrinh_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@MaCT", MaCT);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)//nếu có dữ liệu để đọc
            {
                MaCT = DocDL["MaCT"].ToString();
                TenCT = DocDL["TenCT"].ToString();
            }
            BaoVe.Close();
        }
        public DataTable DS()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlDataAdapter XeTai = new SqlDataAdapter("ChuongTrinh_DS", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class KhachHang
    {
        public string MaKH;
        public string HoKH;
        public string TenKH;
        public string NgaySinh;
        public bool GioiTinh;
        public string CMND;
        public string SoDT;
        public string Email;
        public bool Loai;
        public string SoNhaKHLL;
        public string SoNhaKHTT;
        public string MaDuongKHLL;
        public string MaDuongKHTT;
        public string MaXaKHLL;
        public string MaXaKHTT;
        public string ThongBao;
        public string TenDuongKHLL;
        public string TenDuongKHTT;
        public string TenXaKHLL;
        public string TenXaKHTT;
        public string TenHuyen;
        public string TenTinh;
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("KhachHang_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@HoKH", HoKH);
                ThamSo = Lenh.Parameters.AddWithValue("@TenKH", TenKH);
                ThamSo = Lenh.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                ThamSo = Lenh.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                ThamSo = Lenh.Parameters.AddWithValue("@CMND", CMND);
                ThamSo = Lenh.Parameters.AddWithValue("@SoDT", SoDT);
                ThamSo = Lenh.Parameters.AddWithValue("@Email", Email);
                ThamSo = Lenh.Parameters.AddWithValue("@SoNhaKHLL", SoNhaKHLL);
                ThamSo = Lenh.Parameters.AddWithValue("@SoNhaKHTT", SoNhaKHTT);
                ThamSo = Lenh.Parameters.AddWithValue("@MaDuongKHLL", MaDuongKHLL);
                ThamSo = Lenh.Parameters.AddWithValue("@MaDuongKHTT", MaDuongKHTT);
                ThamSo = Lenh.Parameters.AddWithValue("@MaXaKHLL", MaXaKHLL);
                ThamSo = Lenh.Parameters.AddWithValue("@MaXaKHTT", MaXaKHTT);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("KhachHang_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaKH", MaKH);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("KhachHang_Sua", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaKH", MaKH);
                ThamSo = Lenh.Parameters.AddWithValue("@HoKH", HoKH);
                ThamSo = Lenh.Parameters.AddWithValue("@TenKH", TenKH);
                ThamSo = Lenh.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                ThamSo = Lenh.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                ThamSo = Lenh.Parameters.AddWithValue("@CMND", CMND);
                ThamSo = Lenh.Parameters.AddWithValue("@SoDT", SoDT);
                ThamSo = Lenh.Parameters.AddWithValue("@Email", Email);
                ThamSo = Lenh.Parameters.AddWithValue("@Loai", Loai);
                ThamSo = Lenh.Parameters.AddWithValue("@SoNhaKHLL", SoNhaKHLL);
                ThamSo = Lenh.Parameters.AddWithValue("@SoNhaKHTT", SoNhaKHTT);
                ThamSo = Lenh.Parameters.AddWithValue("@MaDuongKHLL", MaDuongKHLL);
                ThamSo = Lenh.Parameters.AddWithValue("@MaDuongKHTT", MaDuongKHTT);
                ThamSo = Lenh.Parameters.AddWithValue("@MaXaKHLL", MaXaKHLL);
                ThamSo = Lenh.Parameters.AddWithValue("@MaXaKHTT", MaXaKHTT);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Lưu thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlCommand Lenh = new SqlCommand("KhachHang_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@MaKH", MaKH);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)
            {
                MaKH = DocDL["MaKH"].ToString();
                HoKH = DocDL["HoKH"].ToString();
                TenKH = DocDL["TenKH"].ToString();
                NgaySinh = DocDL["NgaySinh"].ToString();
                GioiTinh = bool.Parse(DocDL["GioiTinh"].ToString());
                CMND = DocDL["CMND"].ToString();
                SoDT = DocDL["SoDT"].ToString();
                Email = DocDL["Email"].ToString();
                SoNhaKHTT = DocDL["SoNhaKHTT"].ToString();
                SoNhaKHLL = DocDL["SoNhaKHLL"].ToString();
                MaDuongKHLL = DocDL["MaDuongKHLL"].ToString();
                TenDuongKHLL = DocDL["TenDuongKHLL"].ToString();
                MaDuongKHTT = DocDL["MaDuongKHTT"].ToString();
                TenDuongKHTT = DocDL["TenDuongKHTT"].ToString();
                MaXaKHLL = DocDL["MaXaKHLL"].ToString();
                TenXaKHLL = DocDL["TenXaKHLL"].ToString();
                MaXaKHTT = DocDL["MaXaKHTT"].ToString();
                TenXaKHTT = DocDL["TenXaKHTT"].ToString();
                TenHuyen = DocDL["TenHuyen"].ToString();
                TenTinh = DocDL["TenTinh"].ToString();
            }
            BaoVe.Close();
        }
        public DataTable KhachHang_DS_TheoTheLoai(string MaNPP, bool Loai)
        {
            string SelectSQL = "SELECT KH.MaKH,HoKH,TenKH,KH.NgaySinh,KH.GioiTinh,KH.CMND,KH.SoDT,KH.Email,SoNhaKHTT, SoNhaKHLL,MaDuongKHLL,TenDuong AS TenDuongKHLL, MaDuongKHTT,TenDuong AS TenDuongKHTT, MaXaKHLL, TenXa AS TenXaKHLL, MaXaKHTT,TenXa AS TenXaKHTT, TenHuyen, TenTinh FROM KhachHang KH, Duong D, XaPhuong XP, Huyen H, Tinh T, KHSuDung,ChamSoc, NhaPhanPhoi NPP WHERE KH.MaDuongKHTT = D.MaDuong AND KH.MaDuongKHLL = D.MaDuong AND KH.MaXaKHLL = XP.MaXa AND KH.MaXaKHTT = XP.MaXa AND XP.MaHuyen = H.MaHuyen AND H.MaTinh = T.MaTinh  AND Loai = @Loai AND ((KHSuDung.MaKH = KH.MaKH AND KHSuDung.MaNPP = NPP.MaNPP AND KHSuDung.MaNPP = @MaNPP) OR (ChamSoc.MaKH = KH.MaKH AND ChamSoc.MaNPP = NPP.MaNPP AND ChamSoc.MaNPP = @MaNPP))";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaNPP", SqlDbType.Int).Value = MaNPP;
                Lenh.Parameters.Add("@Loai", SqlDbType.Int).Value = Loai;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }            
     }
    public class NhaPhanPhoi
        {
            public string MaNPP;
            public string HoNPP;
            public string TenNPP;
            public string HoTenNPP;
            public string NgaySinh;
            public bool GioiTinh;
            public string AnhNPP;
            public string CMND;
            public string SoDT;
            public string Email;
            public string MatKhau;
            public string NgayKyThe;
            public string SoNhaNPPLL;
            public string SoNhaNPPTT;
            public int MaCD;
            public string HuyHieu;
            public string MaDuongNPPLL;
            public string MaDuongNPPTT;
            public string MaXaNPPLL;
            public string MaXaNPPTT;
            public string MaNBT;
            public string ThongBao;
            public string TenDuongNPPLL;
            public string TenDuongNPPTT;
            public string TenXaNPPLL;
            public string TenXaNPPTT;
            public string TenHuyen;
            public string TenTinh;
            public string MatKhauCu;
            public string MatKhauMoi;
            public string MatKhauXN;
            public string HoNBT;
            public string TenNBT;
            public bool DangNhap()
            {
                try
                {
                    SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                    SqlCommand Lenh = new SqlCommand("NhaPhanPhoi_DangNhap", BaoVe);
                    Lenh.CommandType = CommandType.StoredProcedure;
                    SqlParameter ThamSo = new SqlParameter();
                    ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@MatKhau", MatKhau);
                    SqlDataReader DocDL;
                    BaoVe.Open();
                    DocDL = Lenh.ExecuteReader();
                    if (DocDL.Read() == true)
                    {
                        MaNPP = DocDL["MaNPP"].ToString();
                        HoNPP = DocDL["HoNPP"].ToString();
                        TenNPP = DocDL["TenNPP"].ToString();
                        NgaySinh = DocDL["NgaySinh"].ToString();
                        GioiTinh = bool.Parse(DocDL["GioiTinh"].ToString());
                        AnhNPP = DocDL["AnhNPP"].ToString();
                        CMND = DocDL["CMND"].ToString();
                        SoDT = DocDL["SoDT"].ToString();
                        Email = DocDL["Email"].ToString();
                        MatKhau = DocDL["MatKhau"].ToString();
                        NgayKyThe = DocDL["NgayKyThe"].ToString();
                        SoNhaNPPLL = DocDL["SoNhaNPPLL"].ToString();
                        SoNhaNPPTT = DocDL["SoNhaNPPTT"].ToString();
                        MaCD = int.Parse(DocDL["MaCD"].ToString());
                        MaDuongNPPLL = DocDL["MaDuongNPPLL"].ToString();
                        MaDuongNPPTT = DocDL["MaDuongNPPTT"].ToString();
                        MaXaNPPLL = DocDL["MaXaNPPLL"].ToString();
                        MaXaNPPTT = DocDL["MaXaNPPTT"].ToString();
                        MaNBT = DocDL["MaNBT"].ToString();
                        BaoVe.Close();
                        return true;
                    }
                    else
                    {
                        BaoVe.Close();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ThongBao = ex.Message;
                }
                return false;
            }
            public void DoiMatKhau()
            {
                try
                {
                    SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                    SqlCommand Lenh = new SqlCommand("NhaPhanPhoi_DoiMatKhau", BaoVe);
                    Lenh.CommandType = CommandType.StoredProcedure;
                    SqlParameter ThamSo = new SqlParameter();
                    ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@MatKhauCu", MatKhauCu);
                    ThamSo = Lenh.Parameters.AddWithValue("@MatKhauMoi", MatKhauMoi);
                    ThamSo = Lenh.Parameters.AddWithValue("@MatKhauXN", MatKhauXN);
                    BaoVe.Open();
                    Lenh.ExecuteNonQuery();
                    BaoVe.Close();
                    ThongBao = "Đổi thành công!.";
                }
                catch (Exception ex)
                {
                    ThongBao = ex.Message;
                }
            }
            public void Them()
            {
                try
                {
                    SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAnĐoAno");
                    SqlCommand Lenh = new SqlCommand("NhaPhanPhoi_Them", BaoVe);
                    Lenh.CommandType = CommandType.StoredProcedure;
                    SqlParameter ThamSo = new SqlParameter();
                    ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@HoNPP", HoNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@TenNPP", TenNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                    ThamSo = Lenh.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                    ThamSo = Lenh.Parameters.AddWithValue("@AnhNPP", AnhNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@CMND", CMND);
                    ThamSo = Lenh.Parameters.AddWithValue("@SoDT", SoDT);
                    ThamSo = Lenh.Parameters.AddWithValue("@Email", Email);
                    ThamSo = Lenh.Parameters.AddWithValue("@SoNhaNPPLL", SoNhaNPPLL);
                    ThamSo = Lenh.Parameters.AddWithValue("@SoNhaNPPTT", SoNhaNPPTT);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaCD", MaCD);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaDuongNPPLL", MaDuongNPPLL);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaDuongNPPTT", MaDuongNPPTT);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaXaNPPLL", MaXaNPPLL);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaXaNPPTT", MaXaNPPTT);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaNBT", MaNBT);
                    BaoVe.Open();
                    Lenh.ExecuteNonQuery();
                    BaoVe.Close();
                    ThongBao = "Thêm thành công!.";
                }
                catch (Exception ex)
                {
                    ThongBao = ex.Message;
                }
            }
            public void Xoa()
            {
                try
                {
                    SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                    SqlCommand Lenh = new SqlCommand("NhaPhanPhoi_Xoa", BaoVe);
                    Lenh.CommandType = CommandType.StoredProcedure;
                    SqlParameter ThamSo = new SqlParameter();
                    ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                    BaoVe.Open();
                    Lenh.ExecuteNonQuery();
                    BaoVe.Close();
                    ThongBao = "Xóa thành công!.";
                }
                catch (Exception ex)
                {
                    ThongBao = ex.Message;
                }
            }
            public void Sua()
            {
                try
                {
                    SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                    SqlCommand Lenh = new SqlCommand("NhaPhanPhoi_Sua", BaoVe);
                    Lenh.CommandType = CommandType.StoredProcedure;
                    SqlParameter ThamSo = new SqlParameter();
                    ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@HoNPP", HoNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@TenNPP", TenNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                    ThamSo = Lenh.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                    ThamSo = Lenh.Parameters.AddWithValue("@AnhNPP", AnhNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@SoDT", SoDT);
                    ThamSo = Lenh.Parameters.AddWithValue("@Email", Email);
                    ThamSo = Lenh.Parameters.AddWithValue("@SoNhaNPPLL", SoNhaNPPLL);
                    ThamSo = Lenh.Parameters.AddWithValue("@SoNhaNPPTT", SoNhaNPPTT);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaCD", MaCD);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaDuongNPPLL", MaDuongNPPLL);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaDuongNPPTT", MaDuongNPPTT);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaXaNPPLL", MaXaNPPLL);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaXaNPPTT", MaXaNPPTT);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaNBT", MaNBT);
                    BaoVe.Open();
                    Lenh.ExecuteNonQuery();
                    BaoVe.Close();
                    ThongBao = "Lưu thành công!.";
                }
                catch (Exception ex)
                {
                    ThongBao = ex.Message;
                }
            }
            public void CT()
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("NhaPhanPhoi_CT", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                SqlDataReader DocDL;
                BaoVe.Open();
                DocDL = Lenh.ExecuteReader();
                if (DocDL.Read() == true)
                {
                    MaNPP = DocDL["MaNPP"].ToString();
                    HoNPP = DocDL["HoNPP"].ToString();
                    TenNPP = DocDL["TenNPP"].ToString();
                    NgaySinh = DocDL["NgaySinh"].ToString();
                    GioiTinh = bool.Parse(DocDL["GioiTinh"].ToString());
                    AnhNPP = DocDL["AnhNPP"].ToString();
                    CMND = DocDL["CMND"].ToString();
                    SoDT = DocDL["SoDT"].ToString();
                    Email = DocDL["Email"].ToString();
                    MatKhau = DocDL["MatKhau"].ToString();
                    NgayKyThe = DocDL["NgayKyThe"].ToString();
                    SoNhaNPPTT = DocDL["SoNhaNPPTT"].ToString();
                    SoNhaNPPLL = DocDL["SoNhaNPPLL"].ToString();
                    MaCD = int.Parse(DocDL["MaCD"].ToString());
                    HuyHieu = DocDL["HuyHieu"].ToString();
                    MaDuongNPPLL = DocDL["MaDuongNPPLL"].ToString();
                    TenDuongNPPLL = DocDL["TenDuongNPPLL"].ToString();
                    MaDuongNPPTT = DocDL["MaDuongNPPTT"].ToString();
                    TenDuongNPPTT = DocDL["TenDuongNPPTT"].ToString();
                    MaXaNPPLL = DocDL["MaXaNPPLL"].ToString();
                    TenXaNPPLL = DocDL["TenXaNPPLL"].ToString();
                    MaXaNPPTT = DocDL["MaXaNPPTT"].ToString();
                    TenXaNPPTT = DocDL["TenXaNPPTT"].ToString();
                    HoNBT = DocDL["HoNBT"].ToString();
                    TenNBT = DocDL["TenNBT"].ToString();
                    TenHuyen = DocDL["TenHuyen"].ToString();
                    TenTinh = DocDL["TenTinh"].ToString();
                }
                BaoVe.Close();
            }
            public DataTable DS()
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlDataAdapter XeTai = new SqlDataAdapter("NhaPhanPhoi_DS", BaoVe);
                DataTable ThungChua = new DataTable();
                BaoVe.Open();
                XeTai.Fill(ThungChua);
                BaoVe.Close();
                return ThungChua;
            }
            public DataTable NhaPhanPhoi_DS_TheoCapDo(string MaNPP, int MaCD)
            {
                string SelectSQL = "SELECT MaNPP,HoNPP,TenNPP,NgaySinh,GioiTinh,AnhNPP,CMND,SoDT,Email,MatKhau,NgayKyThe,SoNhaNPPTT,SoNhaNPPLL,CD.MaCD, HuyHieu, NPP.MaDuongNPPLL,TenDuong AS TenDuongNPPLL, NPP.MaDuongNPPTT,TenDuong AS TenDuongNPPTT, NPP.MaXaNPPLL, TenXa AS TenXaNPPLL, NPP.MaXaNPPTT,TenXa AS TenXaNPPTT, MaNBT, HoNPP AS HoNBT, TenNPP AS TenNBT, TenHuyen, TenTinh FROM NhaPhanPhoi NPP, Duong D, XaPhuong XP, Huyen H, Tinh T, CapDo CD WHERE NPP.MaDuongNPPTT = D.MaDuong AND NPP.MaDuongNPPLL = D.MaDuong AND NPP.MaXaNPPLL = XP.MaXa AND NPP.MaXaNPPTT = XP.MaXa AND MaNBT = NPP.MaNPP AND XP.MaHuyen = H.MaHuyen AND H.MaTinh = T.MaTinh AND NPP.MaCD = CD.MaCD AND NPP.MaCD = @MaCD AND MaNPP = @MaNPP";
                SqlConnection BaoVe = new SqlConnection("workstation  id=DoAn.mssql.somee.com;packet size=4096;user id=DoAn;pwd=12345678;data source=DoAn.mssql.somee.com;persist security info=False;initial catalog=DoAn");
                DataTable ThungChua = new DataTable();
                BaoVe.Open();
                if (BaoVe.State == ConnectionState.Open)
                {
                    SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                    Lenh.Parameters.Add("@MaNPP", SqlDbType.Int).Value = MaNPP;
                    Lenh.Parameters.Add("@MaCD", SqlDbType.Int).Value = MaCD;
                    SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                    XeTai.Fill(ThungChua);
                    BaoVe.Close();
                }
                return ThungChua;
            }
            public DataTable DS_NhaPhanPhoi(string MaNBT)
            {
                string SelectSQL = "SELECT MaNPP, HoNPP + ''+ TenNPP AS HoTenNPP	FROM NhaPhanPhoi WHERE MaNBT = @MaNBT";
                SqlConnection BaoVe = new SqlConnection("workstation  id=DoAn.mssql.somee.com;packet size=4096;user id=DoAn;pwd=12345678;data source=DoAn.mssql.somee.com;persist security info=False;initial catalog=DoAn");
                DataTable ThungChua = new DataTable();
                BaoVe.Open();
                if (BaoVe.State == ConnectionState.Open)
                {
                    SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                    Lenh.Parameters.Add("@MaNBT", SqlDbType.Int).Value = MaNBT;
                    SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                    XeTai.Fill(ThungChua);
                    BaoVe.Close();
                }
                return ThungChua;
            }                                            
        }
    public class DoanhThu
        {
            public string ThangNam;
            public string MaNPP;
            public int Diem;
            public string ThongBao;
            public void Them()
            {
                try
                {
                    SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                    SqlCommand Lenh = new SqlCommand("DoanhThu_Them", BaoVe);
                    Lenh.CommandType = CommandType.StoredProcedure;
                    SqlParameter ThamSo = new SqlParameter();
                    ThamSo = Lenh.Parameters.AddWithValue("@ThangNam", ThangNam);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@Diem", Diem);
                    BaoVe.Open();
                    Lenh.ExecuteNonQuery();
                    BaoVe.Close();
                    ThongBao = "Thêm thành công!.";
                }
                catch (Exception ex)
                {
                    ThongBao = ex.Message;
                }
            }
            public void Xoa()
            {
                try
                {
                    SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                    SqlCommand Lenh = new SqlCommand("DoanhThu_Xoa", BaoVe);
                    Lenh.CommandType = CommandType.StoredProcedure;
                    SqlParameter ThamSo = new SqlParameter();
                    ThamSo = Lenh.Parameters.AddWithValue("@ThangNam", ThangNam);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                    BaoVe.Open();
                    Lenh.ExecuteNonQuery();
                    BaoVe.Close();
                    ThongBao = "Xóa thành công!.";
                }
                catch (Exception ex)
                {
                    ThongBao = ex.Message;
                }
            }
            public void Sua()
            {
                try
                {
                    SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                    SqlCommand Lenh = new SqlCommand("DoanhThu_Sua", BaoVe);
                    Lenh.CommandType = CommandType.StoredProcedure;
                    SqlParameter ThamSo = new SqlParameter();
                    ThamSo = Lenh.Parameters.AddWithValue("@ThangNam", ThangNam);
                    ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                    ThamSo = Lenh.Parameters.AddWithValue("@Diem", Diem);
                    BaoVe.Open();
                    Lenh.ExecuteNonQuery();
                    BaoVe.Close();
                    ThongBao = "Sửa thành công!.";
                }
                catch (Exception ex)
                {
                    ThongBao = ex.Message;
                }
            }
            public void CT()
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("DoanhThu_CT", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@ThangNam", ThangNam);
                ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                SqlDataReader DocDL;
                BaoVe.Open();
                DocDL = Lenh.ExecuteReader();
                if (DocDL.Read() == true)//nếu có dữ liệu để đọc
                {
                    ThangNam = DocDL["ThangNam"].ToString();
                    MaNPP = DocDL["MaNPP"].ToString();
                    Diem = int.Parse(DocDL["Diem"].ToString());
                }
                BaoVe.Close();
            }
            public DataTable DS(string MaNPP)
            {
                string SelectSQL = "SELECT ThangNam, Diem FROM DoanhThu	WHERE MaNPP = @MaNPP";
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                DataTable ThungChua = new DataTable();
                BaoVe.Open();
                if (BaoVe.State == ConnectionState.Open)
                {
                    SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                    Lenh.Parameters.Add("@MaNPP", SqlDbType.Int).Value = MaNPP;
                    SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                    XeTai.Fill(ThungChua);
                    BaoVe.Close();
                }
                return ThungChua;
            }
        }
    public class ChamSoc
    {
        public bool ThamDu;
        public string MaCT;
        public string MaKH;
        public string MaNPP;
        public string MaCS;
        public string ThoiGian;
        public int SoLan;
        public string TenCT;
        public string ThongBao;
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("ChamSoc_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@ThamDu", ThamDu);
                ThamSo = Lenh.Parameters.AddWithValue("@MaCT", MaCT);
                ThamSo = Lenh.Parameters.AddWithValue("@MaKH", MaKH);
                ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }        
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("ChamSoc_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaCS", MaCS);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("ChamSoc_Sua", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@ThamDu", ThamDu);
                ThamSo = Lenh.Parameters.AddWithValue("@MaCT", MaCT);
                ThamSo = Lenh.Parameters.AddWithValue("@MaCS", MaCS);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Lưu thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public DataTable DS(string MaNPP, string MaKH)
        {
            string SelectSQL = "SELECT MaCS, ThoiGian, SoLan,ThamDu,CS.MaCT, TenCT FROM ChamSoc CS,ChuongTrinh CT WHERE MaNPP = @MaNPP AND MaKH = @MaKH AND CS.MaCT = CT.MaCT";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaNPP", SqlDbType.Int).Value = MaNPP;
                Lenh.Parameters.Add("@MaKH", SqlDbType.Int).Value = MaKH;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlCommand Lenh = new SqlCommand("ChamSoc_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@MaCS", MaCS);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)
            {
                MaCS = DocDL["MaCS"].ToString();
                ThoiGian = DocDL["ThoiGian"].ToString();
                SoLan = int.Parse(DocDL["SoLan"].ToString());
                ThamDu = bool.Parse(DocDL["ThamDu"].ToString());
                MaCT = DocDL["MaCT"].ToString();
                TenCT = DocDL["TenCT"].ToString();
            }
            BaoVe.Close();
        }
    }
    public class DaoTao
    {
        public string MaNPP;
        public string MaCT;
        public string TenCT;
        public string MaDaoTao;
        public string NgayThamDu;
        public int SoLan;
        public string ThongBao;
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("DaoTao_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaCT", MaCT);
                ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("DaoTao_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaDaoTao", MaDaoTao);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("DaoTao_Sua", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaCT", MaCT);
                ThamSo = Lenh.Parameters.AddWithValue("@MaDaoTao", MaDaoTao);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Lưu thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlCommand Lenh = new SqlCommand("DaoTao_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@MaDaoTao", MaDaoTao);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)
            {
                MaDaoTao = DocDL["MaDaoTao"].ToString();
                NgayThamDu = DocDL["NgayThamDu"].ToString();
                SoLan = int.Parse(DocDL["SoLan"].ToString());
                MaCT = DocDL["MaCT"].ToString();
                TenCT = DocDL["TenCT"].ToString();
            }
            BaoVe.Close();
        }
        public DataTable DS(string MaNPP)
        {
            string SelectSQL = "SELECT MaDaoTao, NgayThamDu, CT.MaCT,TenCT, SoLan FROM DaoTao DT, ChuongTrinh CT WHERE MaNPP = @MaNPP AND DT.MaCT = CT.MaCT";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaNPP", SqlDbType.Int).Value = MaNPP;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
    }
    public class NPPSuDung
    {
        public string MaMH;
        public string TenMH;
        public string ThoiGian;
        public int SoLuong;
        public bool MinhHoa;
        public string MaNPP;
        public string MaNPPSD;
        public double Gia;
        public int MaLMH;
        public string CachSuDung;
        public string ChiTiet;
        public string TenLMH;
        public string AnhMH;
        public string ThongBao;
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("NPPSuDung_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaMH", MaMH);
                ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                ThamSo = Lenh.Parameters.AddWithValue("@SoLuong", SoLuong);
                ThamSo = Lenh.Parameters.AddWithValue("@MinhHoa", MinhHoa);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("NPPSuDung_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaNPPSD", MaNPPSD);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("NPPSuDung_Sua", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaNPPSD", MaNPPSD);
                ThamSo = Lenh.Parameters.AddWithValue("@SoLuong", SoLuong);
                ThamSo = Lenh.Parameters.AddWithValue("@MinhHoa", MinhHoa);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Lưu thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public DataTable DS(string MaNPP)
        {
            string SelectSQL = "SELECT MaNPPSD, ThoiGian, SoLuong, MinhHoa, NPPSuDung.MaMH, TenMH FROM NPPSuDung ,MatHang MH WHERE MaNPP = @MaNPP AND NPPSuDung.MaMH = MH.MaMH";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaNPP", SqlDbType.Int).Value = MaNPP;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlCommand Lenh = new SqlCommand("NPPSuDung_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@MaNPPSD", MaNPPSD);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)
            {
                MaNPPSD = DocDL["MaNPPSD"].ToString();
                MaMH = DocDL["MaMH"].ToString();
                TenMH = DocDL["TenMH"].ToString();
                MaNPP = DocDL["MaNPP"].ToString();
                SoLuong = int.Parse(DocDL["SoLuong"].ToString());
                MinhHoa = bool.Parse(DocDL["MinhHoa"].ToString());
                Gia = double.Parse(DocDL["Gia"].ToString());
                CachSuDung = DocDL["CachSuDung"].ToString();
                ChiTiet = DocDL["ChiTiet"].ToString();
                MaLMH = int.Parse(DocDL["MaLMH"].ToString());
                TenLMH = DocDL["TenLMH"].ToString();
                AnhMH = DocDL["AnhMH"].ToString();
            }
            BaoVe.Close();
        }
        public DataTable MatHang_DaDung(string MaNPP)
        {
            string SelectSQL = "SELECT MH.MaMH, MH.MaLMH, TenMH, TenLMH, ChiTiet, CachSuDung, AnhMH, Gia, SoLuong, Minhhoa, NPPSuDung.MaNPPSD FROM MatHang MH, LoaiMH LMH, NPPSuDung WHERE MH.MaLMH = LMH.MaLMH AND NPPSuDung.MaMH = MH.MaMH AND NPPSuDung.MaNPP = @MaNPP";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaNPP", SqlDbType.Int).Value = MaNPP;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable MatHang_ChuaDung(string MaNPP)
        {
            string SelectSQL = "SELECT MH.MaMH, MH.MaLMH, TenMH, TenLMH, ChiTiet, CachSuDung, AnhMH, Gia FROM MatHang MH, LoaiMH LMH WHERE MH.MaMH not in (SELECT MH.MaMH	FROM MatHang MH, LoaiMH LMH, NPPSuDung	WHERE MH.MaLMH = LMH.MaLMH AND NPPSuDung.MaMH = MH.MaMH AND NPPSuDung.MaNPP = @MaNPP)";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaNPP", SqlDbType.Int).Value = MaNPP;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }            
    }
    public class KHSuDung
    {
        public string MaMH;
        public string MaKH;
        public string MaNPP;
        public int SoLuong;
        public bool MinhHoa;
        public string MaKHSD;
        public string TenMH;
        public double Gia;
        public int MaLMH;
        public string CachSuDung;
        public string ChiTiet;
        public string TenLMH;
        public string AnhMH;
        public string ThoiGian;
        public string ThongBao;
        public void Them()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("KHSuDung_Them", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaMH", MaMH);
                ThamSo = Lenh.Parameters.AddWithValue("@MaKH", MaKH);
                ThamSo = Lenh.Parameters.AddWithValue("@MaNPP", MaNPP);
                ThamSo = Lenh.Parameters.AddWithValue("@SoLuong", SoLuong);
                ThamSo = Lenh.Parameters.AddWithValue("@MinhHoa", MinhHoa);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Thêm thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Xoa()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("KHSuDung_Xoa", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaKHSD", MaKHSD);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Xóa thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void Sua()
        {
            try
            {
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("KHSuDung_Sua", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaKHSD", MaKHSD);
                ThamSo = Lenh.Parameters.AddWithValue("@SoLuong", SoLuong);
                ThamSo = Lenh.Parameters.AddWithValue("@MinhHoa", MinhHoa);
                BaoVe.Open();
                Lenh.ExecuteNonQuery();
                BaoVe.Close();
                ThongBao = "Lưu thành công!.";
            }
            catch (Exception ex)
            {
                ThongBao = ex.Message;
            }
        }
        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            SqlCommand Lenh = new SqlCommand("KHSuDung_CT", BaoVe);
            Lenh.CommandType = CommandType.StoredProcedure;
            SqlParameter ThamSo = new SqlParameter();
            ThamSo = Lenh.Parameters.AddWithValue("@MaKHSD", MaKHSD);
            SqlDataReader DocDL;
            BaoVe.Open();
            DocDL = Lenh.ExecuteReader();
            if (DocDL.Read() == true)
            {
                MaKHSD = DocDL["MaKHSD"].ToString();
                MaMH = DocDL["MaMH"].ToString();
                TenMH = DocDL["TenMH"].ToString();
                MaNPP = DocDL["MaNPP"].ToString();
                MaKH = DocDL["MaKH"].ToString();
                SoLuong = int.Parse(DocDL["SoLuong"].ToString());
                MinhHoa = bool.Parse(DocDL["MinhHoa"].ToString());
                Gia = double.Parse(DocDL["Gia"].ToString());
                CachSuDung = DocDL["CachSuDung"].ToString();
                ChiTiet = DocDL["ChiTiet"].ToString();
                MaLMH = int.Parse(DocDL["MaLMH"].ToString());
                TenLMH = DocDL["TenLMH"].ToString();
                AnhMH = DocDL["AnhMH"].ToString();
            }
            BaoVe.Close();
        }
        public DataTable DS(string MaNPP, string MaKH)
        {
            string SelectSQL = "SELECT MaKHSD, ThoiGian, SoLuong, MinhHoa, KHSuDung.MaMH, TenMH FROM KHSuDung ,MatHang MH WHERE MaNPP = @MaNPP AND MaKH = @MaKH AND KHSuDung.MaMH = MH.MaMH";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaNPP", SqlDbType.Int).Value = MaNPP;
                Lenh.Parameters.Add("@MaKH", SqlDbType.Int).Value = MaKH;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable MatHang_ChuaDung(string MaNPP, string MaKH)
        {
            string SelectSQL = "SELECT MH.MaMH, MH.MaLMH, TenMH, TenLMH, ChiTiet, CachSuDung, AnhMH, Gia FROM MatHang MH, LoaiMH LMH WHERE MH.MaMH not in (SELECT KHSuDung.MaMH FROM MatHang MH, LoaiMH LMH, KHSuDung WHERE MH.MaLMH = LMH.MaLMH AND KHSuDung.MaMH = MH.MaMH AND KHSuDung.MaKH = @MaKH AND KHSuDung.MaNPP = @MaNPP)";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaNPP", SqlDbType.Int).Value = MaNPP;
                Lenh.Parameters.Add("@MaKH", SqlDbType.Int).Value = MaKH;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }
        public DataTable MatHang_DaDung(string MaNPP, string MaKH)
        {
            string SelectSQL = "SELECT MH.MaMH, MH.MaLMH, TenMH, TenLMH, ChiTiet, CachSuDung, AnhMH, Gia, SoLuong, MinhHoa,KHSuDung.MaKHSD FROM MatHang MH, LoaiMH LMH, KHSuDung WHERE MH.MaLMH = LMH.MaLMH AND KHSuDung.MaMH = MH.MaMH AND KHSuDung.MaKH = @MaKH AND KHSuDung.MaNPP = @MaNPP";
            SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            if (BaoVe.State == ConnectionState.Open)
            {
                SqlCommand Lenh = new SqlCommand(SelectSQL, BaoVe);
                Lenh.Parameters.Add("@MaNPP", SqlDbType.Int).Value = MaNPP;
                Lenh.Parameters.Add("@MaKH", SqlDbType.Int).Value = MaKH;
                SqlDataAdapter XeTai = new SqlDataAdapter(Lenh);
                XeTai.Fill(ThungChua);
                BaoVe.Close();
            }
            return ThungChua;
        }       
    }
    public class WebMsgBox
        {
            protected Hashtable handlerPages = new Hashtable();

            protected void CurrentPageUnload(object sender, EventArgs e)
            {
                Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
                if (queue != null)
                {
                    StringBuilder builder = new StringBuilder();
                    int iMsgCount = queue.Count;
                    builder.Append("<script language='javascript'>");
                    string sMsg;
                    while ((iMsgCount > 0))
                    {
                        iMsgCount = iMsgCount - 1;
                        sMsg = System.Convert.ToString(queue.Dequeue());
                        sMsg = sMsg.Replace("\"", "'");
                        builder.Append("alert( \"" + sMsg + "\" );");
                    }
                    builder.Append("</script>");
                    handlerPages.Remove(HttpContext.Current.Handler);
                    HttpContext.Current.Response.Write(builder.ToString());
                }
            }

            public void Show(string Message)
            {
                if (!(handlerPages.Contains(HttpContext.Current.Handler)))
                {
                    Page currentPage = (Page)HttpContext.Current.Handler;
                    if (!((currentPage == null)))
                    {
                        Queue messageQueue = new Queue();
                        messageQueue.Enqueue(Message);
                        handlerPages.Add(HttpContext.Current.Handler, messageQueue);
                        currentPage.Unload += new EventHandler(CurrentPageUnload);
                    }
                }
                else
                {
                    Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
                    queue.Enqueue(Message);
                }
            }

            public void ShowAndRedirect(string Message)
            {
                HttpContext.Current.Response.Write("<script>alert('" + Message + "') ; window.location.href='" + HttpContext.Current.Request.Url.PathAndQuery + "'</script>");
            }
        }
    public class Menu
        {
            public string MaNPP;
            public string TenNPP;
            public string MaNBT;

            public string LoadMenu(int Me, int level)
            {
                string KetQua = string.Empty;
                SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=DoAn");
                SqlCommand Lenh = new SqlCommand("Menu_Lay", BaoVe);
                Lenh.CommandType = CommandType.StoredProcedure;
                SqlParameter ThamSo = new SqlParameter();
                ThamSo = Lenh.Parameters.AddWithValue("@MaNBT", MaNBT);
                SqlDataReader DocDL;
                BaoVe.Open();
                DocDL = Lenh.ExecuteReader();
                if (!DocDL.HasRows)
                {
                    return KetQua;
                }
                else
                {
                    if (level == 0)
                    {
                        KetQua = "<ul id='nav'>";
                    }
                    else
                        KetQua += "<ul>";
                    while (DocDL.Read())
                    {
                        KetQua += "<li><a href='" + DocDL[""] + "'><span>" + DocDL["TenNPP"] + "</span></a>";
                        KetQua += LoadMenu(Convert.ToInt32(DocDL["MaNPP"]), level + 1);
                        KetQua += "</li>";
                    }
                    KetQua += "</ul>";
                    BaoVe.Close();
                }
                return KetQua;
            }

        }
    }