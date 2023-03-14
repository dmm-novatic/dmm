using Novatic.Models;
using Novatic.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.Util
{
    public class ViewBagActionFilter : ActionFilterAttribute
    {
        public static List<LanguageConfig> languageConfigs;
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //// for razor pages
            //if (context.Controller is PageModel)
            //{
            //    var controller = context.Controller as PageModel;
            //    //controller.ViewData.Add("Avatar", $"~/avatar/empty.png");
            //    // or
            //    controller.ViewBag.Avatar = $"~/avatar/empty.png";

            //    //also you have access to the httpcontext & route in controller.HttpContext & controller.RouteData
            //}

            // for Razor Views
            if (context.Controller is Controller)
            {
                var controller = context.Controller as Controller;
                //controller.ViewData.Add("Avatar", $"~/avatar/empty.png");
                // or
                if (languageConfigs == null)
                {
                    languageConfigs = controller.ViewBag.LanguageConfigList;
                }
                if(languageConfigs != null)
                {
                    for (int i = 0; i < languageConfigs.Count; i++)
                    {
                        var obj = languageConfigs[i];
                        if (obj.Code == "lblDangNhap") { controller.ViewBag.lblDangNhap = obj.Name; }
                        else { controller.ViewBag.lblDangNhap = LanguageConfigUtil.getLanguageConfigByCode("lblDangNhap", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDangKi") { controller.ViewBag.lblDangKi = obj.Name; }
                        else { controller.ViewBag.lblDangKi = LanguageConfigUtil.getLanguageConfigByCode("lblDangKi", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblXemHet") { controller.ViewBag.lblXemHet = obj.Name; }
                        else { controller.ViewBag.lblXemHet = LanguageConfigUtil.getLanguageConfigByCode("lblXemHet", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblXemThem") { controller.ViewBag.lblXemThem = obj.Name; }
                        else { controller.ViewBag.lblXemThem = LanguageConfigUtil.getLanguageConfigByCode("lblXemThem", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblKhaoSatToanDien") { controller.ViewBag.lblKhaoSatToanDien = obj.Name; }
                        else { controller.ViewBag.lblKhaoSatToanDien = LanguageConfigUtil.getLanguageConfigByCode("lblKhaoSatToanDien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTimHieuThem") { controller.ViewBag.lblTimHieuThem = obj.Name; }
                        else { controller.ViewBag.lblTimHieuThem = LanguageConfigUtil.getLanguageConfigByCode("lblTimHieuThem", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblLuuTaiKhoan") { controller.ViewBag.lblLuuTaiKhoan = obj.Name; }
                        else { controller.ViewBag.lblLuuTaiKhoan = LanguageConfigUtil.getLanguageConfigByCode("lblLuuTaiKhoan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblQuenMatKhau") { controller.ViewBag.lblQuenMatKhau = obj.Name; }
                        else { controller.ViewBag.lblQuenMatKhau = LanguageConfigUtil.getLanguageConfigByCode("lblQuenMatKhau", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTenDangNhap") { controller.ViewBag.lblTenDangNhap = obj.Name; }
                        else { controller.ViewBag.lblTenDangNhap = LanguageConfigUtil.getLanguageConfigByCode("lblTenDangNhap", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMatKhau") { controller.ViewBag.lblMatKhau = obj.Name; }
                        else { controller.ViewBag.lblMatKhau = LanguageConfigUtil.getLanguageConfigByCode("lblMatKhau", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblChuaCoTaiKhoan") { controller.ViewBag.lblChuaCoTaiKhoan = obj.Name; }
                        else { controller.ViewBag.lblChuaCoTaiKhoan = LanguageConfigUtil.getLanguageConfigByCode("lblChuaCoTaiKhoan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblHayDangNhapThanhVien") { controller.ViewBag.lblChuaCoTaiKhoan = obj.Name; }
                        else { controller.ViewBag.lblHayDangNhapThanhVien = LanguageConfigUtil.getLanguageConfigByCode("lblHayDangNhapThanhVien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapTenDangNhap") { controller.ViewBag.lblNhapTenDangNhap = obj.Name; }
                        else { controller.ViewBag.lblNhapTenDangNhap = LanguageConfigUtil.getLanguageConfigByCode("lblNhapTenDangNhap", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapMatKhau") { controller.ViewBag.lblNhapMatKhau = obj.Name; }
                        else { controller.ViewBag.lblNhapMatKhau = LanguageConfigUtil.getLanguageConfigByCode("lblNhapMatKhau", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDangKiNhanThongBao") { controller.ViewBag.lblDangKiNhanThongBao = obj.Name; }
                        else { controller.ViewBag.lblDangKiNhanThongBao = LanguageConfigUtil.getLanguageConfigByCode("lblDangKiNhanThongBao", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblHayDangNhapThanhVien") { controller.ViewBag.lblHayDangNhapThanhVien = obj.Name; }
                        else { controller.ViewBag.lblHayDangNhapThanhVien = LanguageConfigUtil.getLanguageConfigByCode("lblHayDangNhapThanhVien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDangKyThamGia") { controller.ViewBag.lblDangKyThamGia = obj.Name; }
                        else { controller.ViewBag.lblDangKyThamGia = LanguageConfigUtil.getLanguageConfigByCode("lblDangKyThamGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDangKyNhanHoTro") { controller.ViewBag.lblDangKyNhanHoTro = obj.Name; }
                        else { controller.ViewBag.lblDangKyNhanHoTro = LanguageConfigUtil.getLanguageConfigByCode("lblDangKyNhanHoTro", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblKetNoiVoiChungToi") { controller.ViewBag.lblKetNoiVoiChungToi = obj.Name; }
                        else { controller.ViewBag.lblKetNoiVoiChungToi = LanguageConfigUtil.getLanguageConfigByCode("lblKetNoiVoiChungToi", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblXemTiep") { controller.ViewBag.lblXemTiep = obj.Name; }
                        else { controller.ViewBag.lblXemTiep = LanguageConfigUtil.getLanguageConfigByCode("lblXemTiep", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDangKyTaiKhoan") { controller.ViewBag.lblDangKyTaiKhoan = obj.Name; }
                        else { controller.ViewBag.lblDangKyTaiKhoan = LanguageConfigUtil.getLanguageConfigByCode("lblDangKyTaiKhoan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblHoVaTen") { controller.ViewBag.lblHoVaTen = obj.Name; }
                        else { controller.ViewBag.lblHoVaTen = LanguageConfigUtil.getLanguageConfigByCode("lblHoVaTen", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDiaChiEmail") { controller.ViewBag.lblDiaChiEmail = obj.Name; }
                        else { controller.ViewBag.lblDiaChiEmail = LanguageConfigUtil.getLanguageConfigByCode("lblDiaChiEmail", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapLaiMatKhau") { controller.ViewBag.lblNhapLaiMatKhau = obj.Name; }
                        else { controller.ViewBag.lblNhapLaiMatKhau = LanguageConfigUtil.getLanguageConfigByCode("lblNhapLaiMatKhau", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapEmail1") { controller.ViewBag.lblNhapEmail1 = obj.Name; }
                        else { controller.ViewBag.lblNhapEmail1 = LanguageConfigUtil.getLanguageConfigByCode("lblNhapEmail1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDaCoTaiKhoan") { controller.ViewBag.lblDaCoTaiKhoan = obj.Name; }
                        else { controller.ViewBag.lblDaCoTaiKhoan = LanguageConfigUtil.getLanguageConfigByCode("lblDaCoTaiKhoan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNoiDungDangKy") { controller.ViewBag.lblNoiDungDangKy = obj.Name; }
                        else { controller.ViewBag.lblNoiDungDangKy = LanguageConfigUtil.getLanguageConfigByCode("lblNoiDungDangKy", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTimlaiMatKhau") { controller.ViewBag.lblTimlaiMatKhau = obj.Name; }
                        else { controller.ViewBag.lblTimlaiMatKhau = LanguageConfigUtil.getLanguageConfigByCode("lblTimlaiMatKhau", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNoiDungTimLaiMatKhau") { controller.ViewBag.lblNoiDungTimLaiMatKhau = obj.Name; }
                        else { controller.ViewBag.lblNoiDungTimLaiMatKhau = LanguageConfigUtil.getLanguageConfigByCode("lblNoiDungTimLaiMatKhau", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblXacNhan") { controller.ViewBag.lblXacNhan = obj.Name; }
                        else { controller.ViewBag.lblXacNhan = LanguageConfigUtil.getLanguageConfigByCode("lblXacNhan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDocThem") { controller.ViewBag.lblDocThem = obj.Name; }
                        else { controller.ViewBag.lblDocThem = LanguageConfigUtil.getLanguageConfigByCode("lblDocThem", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblXemThemDSSuKien") { controller.ViewBag.lblXemThemDSSuKien = obj.Name; }
                        else { controller.ViewBag.lblXemThemDSSuKien = LanguageConfigUtil.getLanguageConfigByCode("lblXemThemDSSuKien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblQuyDinhVaDieuKhoan") { controller.ViewBag.lblQuyDinhVaDieuKhoan = obj.Name; }
                        else { controller.ViewBag.lblQuyDinhVaDieuKhoan = LanguageConfigUtil.getLanguageConfigByCode("lblQuyDinhVaDieuKhoan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblChinhSachBaoMat") { controller.ViewBag.lblChinhSachBaoMat = obj.Name; }
                        else { controller.ViewBag.lblChinhSachBaoMat = LanguageConfigUtil.getLanguageConfigByCode("lblChinhSachBaoMat", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBanQuyen") { controller.ViewBag.lblBanQuyen = obj.Name; }
                        else { controller.ViewBag.lblBanQuyen = LanguageConfigUtil.getLanguageConfigByCode("lblBanQuyen", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblThongTinNguoiSoHuu") { controller.ViewBag.lblThongTinNguoiSoHuu = obj.Name; }
                        else { controller.ViewBag.lblThongTinNguoiSoHuu = LanguageConfigUtil.getLanguageConfigByCode("lblThongTinNguoiSoHuu", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDiaChiChuSoHuu") { controller.ViewBag.lblDiaChiChuSoHuu = obj.Name; }
                        else { controller.ViewBag.lblDiaChiChuSoHuu = LanguageConfigUtil.getLanguageConfigByCode("lblDiaChiChuSoHuu", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDaoTaoTrucTiep") { controller.ViewBag.lblDaoTaoTrucTiep = obj.Name; }
                        else { controller.ViewBag.lblDaoTaoTrucTiep = LanguageConfigUtil.getLanguageConfigByCode("lblDaoTaoTrucTiep", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTrangChu") { controller.ViewBag.lblTrangChu = obj.Name; }
                        else { controller.ViewBag.lblTrangChu = LanguageConfigUtil.getLanguageConfigByCode("lblTrangChu", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTinTucCapNhat") { controller.ViewBag.lblTinTucCapNhat = obj.Name; }
                        else { controller.ViewBag.lblTinTucCapNhat = LanguageConfigUtil.getLanguageConfigByCode("lblTinTucCapNhat", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTinTuc") { controller.ViewBag.lblTinTuc = obj.Name; }
                        else { controller.ViewBag.lblTinTuc = LanguageConfigUtil.getLanguageConfigByCode("lblTinTuc", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTextBannerHeader") { controller.ViewBag.lblTextBannerHeader = obj.Name; }
                        else { controller.ViewBag.lblTextBannerHeader = LanguageConfigUtil.getLanguageConfigByCode("lblTextBannerHeader", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTinTongHop") { controller.ViewBag.lblTinTongHop = obj.Name; }
                        else { controller.ViewBag.lblTinTongHop = LanguageConfigUtil.getLanguageConfigByCode("lblTinTongHop", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTinNongNhat") { controller.ViewBag.lblTinNongNhat = obj.Name; }
                        else { controller.ViewBag.lblTinNongNhat = LanguageConfigUtil.getLanguageConfigByCode("lblTinNongNhat", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBoKeHoachVaDauTu") { controller.ViewBag.lblBoKeHoachVaDauTu = obj.Name; }
                        else { controller.ViewBag.lblBoKeHoachVaDauTu = LanguageConfigUtil.getLanguageConfigByCode("lblBoKeHoachVaDauTu", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblThongTinTaiKhoan") { controller.ViewBag.lblThongTinTaiKhoan = obj.Name; }
                        else { controller.ViewBag.lblThongTinTaiKhoan = LanguageConfigUtil.getLanguageConfigByCode("lblThongTinTaiKhoan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGioiThieuDuAn") { controller.ViewBag.lblGioiThieuDuAn = obj.Name; }
                        else { controller.ViewBag.lblGioiThieuDuAn = LanguageConfigUtil.getLanguageConfigByCode("lblGioiThieuDuAn", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSuKienDaDuocToChuc") { controller.ViewBag.lblSuKienDaDuocToChuc = obj.Name; }
                        else { controller.ViewBag.lblSuKienDaDuocToChuc = LanguageConfigUtil.getLanguageConfigByCode("lblSuKienDaDuocToChuc", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDonViTuVanTrucTiepChoDoanhNghiep") { controller.ViewBag.lblDonViTuVanTrucTiepChoDoanhNghiep = obj.Name; }
                        else { controller.ViewBag.lblDonViTuVanTrucTiepChoDoanhNghiep = LanguageConfigUtil.getLanguageConfigByCode("lblDonViTuVanTrucTiepChoDoanhNghiep", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblToChucTaiChinhCamKetThamGia") { controller.ViewBag.lblToChucTaiChinhCamKetThamGia = obj.Name; }
                        else { controller.ViewBag.lblToChucTaiChinhCamKetThamGia = LanguageConfigUtil.getLanguageConfigByCode("lblToChucTaiChinhCamKetThamGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDoangNghiepSMEDangKiNhanTuVan") { controller.ViewBag.lblDoangNghiepSMEDangKiNhanTuVan = obj.Name; }
                        else { controller.ViewBag.lblDoangNghiepSMEDangKiNhanTuVan = LanguageConfigUtil.getLanguageConfigByCode("lblDoangNghiepSMEDangKiNhanTuVan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSuKienSapDienRa") { controller.ViewBag.lblSuKienSapDienRa = obj.Name; }
                        else { controller.ViewBag.lblSuKienSapDienRa = LanguageConfigUtil.getLanguageConfigByCode("lblSuKienSapDienRa", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSuKienDangDienRa") { controller.ViewBag.lblSuKienDangDienRa = obj.Name; }
                        else { controller.ViewBag.lblSuKienDangDienRa = LanguageConfigUtil.getLanguageConfigByCode("lblSuKienDangDienRa", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSuKienDaKetThuc") { controller.ViewBag.lblSuKienDaKetThuc = obj.Name; }
                        else { controller.ViewBag.lblSuKienDaKetThuc = LanguageConfigUtil.getLanguageConfigByCode("lblSuKienDaKetThuc", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNgay") { controller.ViewBag.lblNgay = obj.Name; }
                        else { controller.ViewBag.lblNgay = LanguageConfigUtil.getLanguageConfigByCode("lblNgay", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGio") { controller.ViewBag.lblGio = obj.Name; }
                        else { controller.ViewBag.lblGio = LanguageConfigUtil.getLanguageConfigByCode("lblGio", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblPhut") { controller.ViewBag.lblPhut = obj.Name; }
                        else { controller.ViewBag.lblPhut = LanguageConfigUtil.getLanguageConfigByCode("lblPhut", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGiay") { controller.ViewBag.lblGiay = obj.Name; }
                        else { controller.ViewBag.lblGiay = LanguageConfigUtil.getLanguageConfigByCode("lblGiay", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBanDoTaiChinh") { controller.ViewBag.lblBanDoTaiChinh = obj.Name; }
                        else { controller.ViewBag.lblBanDoTaiChinh = LanguageConfigUtil.getLanguageConfigByCode("lblBanDoTaiChinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblHotroDoanhNghiepTrongHoatDong") { controller.ViewBag.lblHotroDoanhNghiepTrongHoatDong = obj.Name; }
                        else { controller.ViewBag.lblHotroDoanhNghiepTrongHoatDong = LanguageConfigUtil.getLanguageConfigByCode("lblHotroDoanhNghiepTrongHoatDong", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTimKiemNguonTaiChinh") { controller.ViewBag.lblTimKiemNguonTaiChinh = obj.Name; }
                        else { controller.ViewBag.lblTimKiemNguonTaiChinh = LanguageConfigUtil.getLanguageConfigByCode("lblTimKiemNguonTaiChinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGioiThieuBanDoTaiChinh") { controller.ViewBag.lblGioiThieuBanDoTaiChinh = obj.Name; }
                        else { controller.ViewBag.lblGioiThieuBanDoTaiChinh = LanguageConfigUtil.getLanguageConfigByCode("lblGioiThieuBanDoTaiChinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNghienCuuChiTiet") { controller.ViewBag.lblNghienCuuChiTiet = obj.Name; }
                        else { controller.ViewBag.lblNghienCuuChiTiet = LanguageConfigUtil.getLanguageConfigByCode("lblNghienCuuChiTiet", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNganHang") { controller.ViewBag.lblNganHang = obj.Name; }
                        else { controller.ViewBag.lblNganHang = LanguageConfigUtil.getLanguageConfigByCode("lblNganHang", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblToChuc") { controller.ViewBag.lblToChuc = obj.Name; }
                        else { controller.ViewBag.lblToChuc = LanguageConfigUtil.getLanguageConfigByCode("lblToChuc", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblQuyDauTu") { controller.ViewBag.lblQuyDauTu = obj.Name; }
                        else { controller.ViewBag.lblQuyDauTu = LanguageConfigUtil.getLanguageConfigByCode("lblQuyDauTu", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNganSach") { controller.ViewBag.lblNganSach = obj.Name; }
                        else { controller.ViewBag.lblNganSach = LanguageConfigUtil.getLanguageConfigByCode("lblNganSach", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDongHanhCungDoanhNghiep") { controller.ViewBag.lblDongHanhCungDoanhNghiep = obj.Name; }
                        else { controller.ViewBag.lblDongHanhCungDoanhNghiep = LanguageConfigUtil.getLanguageConfigByCode("lblDongHanhCungDoanhNghiep", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTinTucCacChinhSachTaiChinhChinhThong") { controller.ViewBag.lblTinTucCacChinhSachTaiChinhChinhThong = obj.Name; }
                        else { controller.ViewBag.lblTinTucCacChinhSachTaiChinhChinhThong = LanguageConfigUtil.getLanguageConfigByCode("lblTinTucCacChinhSachTaiChinhChinhThong", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTinTucDoanhNghiepVaTaiChinh") { controller.ViewBag.lblTinTucDoanhNghiepVaTaiChinh = obj.Name; }
                        else { controller.ViewBag.lblTinTucDoanhNghiepVaTaiChinh = LanguageConfigUtil.getLanguageConfigByCode("lblTinTucDoanhNghiepVaTaiChinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGiaiPhapHoTro") { controller.ViewBag.lblGiaiPhapHoTro = obj.Name; }
                        else { controller.ViewBag.lblGiaiPhapHoTro = LanguageConfigUtil.getLanguageConfigByCode("lblGiaiPhapHoTro", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblCongCuDanhGia") { controller.ViewBag.lblCongCuDanhGia = obj.Name; }
                        else { controller.ViewBag.lblCongCuDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblCongCuDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTinhTrangTaiChinhToanDien") { controller.ViewBag.lblTinhTrangTaiChinhToanDien = obj.Name; }
                        else { controller.ViewBag.lblTinhTrangTaiChinhToanDien = LanguageConfigUtil.getLanguageConfigByCode("lblTinhTrangTaiChinhToanDien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMoTaCongCuDanhGia") { controller.ViewBag.lblMoTaCongCuDanhGia = obj.Name; }
                        else { controller.ViewBag.lblMoTaCongCuDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblMoTaCongCuDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMoTaSurvey") { controller.ViewBag.lblMoTaSurvey = obj.Name; }
                        else { controller.ViewBag.lblMoTaSurvey = LanguageConfigUtil.getLanguageConfigByCode("lblMoTaSurvey", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSuKien") { controller.ViewBag.lblSuKien = obj.Name; }
                        else { controller.ViewBag.lblSuKien = LanguageConfigUtil.getLanguageConfigByCode("lblSuKien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTaiLieuTrucQuanSinhDong") { controller.ViewBag.lblTaiLieuTrucQuanSinhDong = obj.Name; }
                        else { controller.ViewBag.lblTaiLieuTrucQuanSinhDong = LanguageConfigUtil.getLanguageConfigByCode("lblTaiLieuTrucQuanSinhDong", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTimKiemThongTinMoiNhat") { controller.ViewBag.lblTimKiemThongTinMoiNhat = obj.Name; }
                        else { controller.ViewBag.lblTimKiemThongTinMoiNhat = LanguageConfigUtil.getLanguageConfigByCode("lblTimKiemThongTinMoiNhat", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblChuyenGiaHangDauTrongLinhVucChuyenDoiSo") { controller.ViewBag.lblChuyenGiaHangDauTrongLinhVucChuyenDoiSo = obj.Name; }
                        else { controller.ViewBag.lblChuyenGiaHangDauTrongLinhVucChuyenDoiSo = LanguageConfigUtil.getLanguageConfigByCode("lblChuyenGiaHangDauTrongLinhVucChuyenDoiSo", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTaiChinhVungChacChoDoanhNghiepSME") { controller.ViewBag.lblTaiChinhVungChacChoDoanhNghiepSME = obj.Name; }
                        else { controller.ViewBag.lblTaiChinhVungChacChoDoanhNghiepSME = LanguageConfigUtil.getLanguageConfigByCode("lblTaiChinhVungChacChoDoanhNghiepSME", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSoDoWeb") { controller.ViewBag.lblSoDoWeb = obj.Name; }
                        else { controller.ViewBag.lblSoDoWeb = LanguageConfigUtil.getLanguageConfigByCode("lblSoDoWeb", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNoiDungWebsite1") { controller.ViewBag.lblNoiDungWebsite1 = obj.Name; }
                        else { controller.ViewBag.lblNoiDungWebsite1 = LanguageConfigUtil.getLanguageConfigByCode("lblNoiDungWebsite1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNoiDungWebsite2") { controller.ViewBag.lblNoiDungWebsite2 = obj.Name; }
                        else { controller.ViewBag.lblNoiDungWebsite2 = LanguageConfigUtil.getLanguageConfigByCode("lblNoiDungWebsite2", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNoiDungWebsite3") { controller.ViewBag.lblNoiDungWebsite3 = obj.Name; }
                        else { controller.ViewBag.lblNoiDungWebsite3 = LanguageConfigUtil.getLanguageConfigByCode("lblNoiDungWebsite3", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSapXepTheo") { controller.ViewBag.lblSapXepTheo = obj.Name; }
                        else { controller.ViewBag.lblSapXepTheo = LanguageConfigUtil.getLanguageConfigByCode("lblSapXepTheo", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTangDan") { controller.ViewBag.lblTangDan = obj.Name; }
                        else { controller.ViewBag.lblTangDan = LanguageConfigUtil.getLanguageConfigByCode("lblTangDan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGiamDan") { controller.ViewBag.lblGiamDan = obj.Name; }
                        else { controller.ViewBag.lblGiamDan = LanguageConfigUtil.getLanguageConfigByCode("lblGiamDan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNoiDungChiTiet") { controller.ViewBag.lblNoiDungChiTiet = obj.Name; }
                        else { controller.ViewBag.lblNoiDungChiTiet = LanguageConfigUtil.getLanguageConfigByCode("lblNoiDungChiTiet", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSuKienKhac") { controller.ViewBag.lblSuKienKhac = obj.Name; }
                        else { controller.ViewBag.lblSuKienKhac = LanguageConfigUtil.getLanguageConfigByCode("lblSuKienKhac", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTaiLieuKhac") { controller.ViewBag.lblTaiLieuKhac = obj.Name; }
                        else { controller.ViewBag.lblTaiLieuKhac = LanguageConfigUtil.getLanguageConfigByCode("lblTaiLieuKhac", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblCongCuDanhGia1") { controller.ViewBag.lblCongCuDanhGia1 = obj.Name; }
                        else { controller.ViewBag.lblCongCuDanhGia1 = LanguageConfigUtil.getLanguageConfigByCode("lblCongCuDanhGia1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGiupCacDoanhNghiepDinhHinh") { controller.ViewBag.lblGiupCacDoanhNghiepDinhHinh = obj.Name; }
                        else { controller.ViewBag.lblGiupCacDoanhNghiepDinhHinh = LanguageConfigUtil.getLanguageConfigByCode("lblGiupCacDoanhNghiepDinhHinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblXemLichSuDanhGia") { controller.ViewBag.lblXemLichSuDanhGia = obj.Name; }
                        else { controller.ViewBag.lblXemLichSuDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblXemLichSuDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblThucHienDanhGia") { controller.ViewBag.lblThucHienDanhGia = obj.Name; }
                        else { controller.ViewBag.lblThucHienDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblThucHienDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGiupCacDoanhNghiepDinhHinh") { controller.ViewBag.lblGiupCacDoanhNghiepDinhHinh = obj.Name; }
                        else { controller.ViewBag.lblGiupCacDoanhNghiepDinhHinh = LanguageConfigUtil.getLanguageConfigByCode("lblGiupCacDoanhNghiepDinhHinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblCongCuDanhGia1") { controller.ViewBag.lblCongCuDanhGia1 = obj.Name; }
                        else { controller.ViewBag.lblCongCuDanhGia1 = LanguageConfigUtil.getLanguageConfigByCode("lblCongCuDanhGia1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblHowUCanAccept") { controller.ViewBag.lblHowUCanAccept = obj.Name; }
                        else { controller.ViewBag.lblHowUCanAccept = LanguageConfigUtil.getLanguageConfigByCode("lblHowUCanAccept", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNoiDungWebsite4") { controller.ViewBag.lblNoiDungWebsite4 = obj.Name; }
                        else { controller.ViewBag.lblNoiDungWebsite4 = LanguageConfigUtil.getLanguageConfigByCode("lblNoiDungWebsite4", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNoiDungPrivacy1") { controller.ViewBag.lblNoiDungPrivacy1 = obj.Name; }
                        else { controller.ViewBag.lblNoiDungPrivacy1 = LanguageConfigUtil.getLanguageConfigByCode("lblNoiDungPrivacy1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNoiDungPrivacy2") { controller.ViewBag.lblNoiDungPrivacy2 = obj.Name; }
                        else { controller.ViewBag.lblNoiDungPrivacy2 = LanguageConfigUtil.getLanguageConfigByCode("lblNoiDungPrivacy2", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNoiDungPrivacy3") { controller.ViewBag.lblNoiDungPrivacy3 = obj.Name; }
                        else { controller.ViewBag.lblNoiDungPrivacy3 = LanguageConfigUtil.getLanguageConfigByCode("lblNoiDungPrivacy3", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblQuanLySuKien") { controller.ViewBag.lblQuanLySuKien = obj.Name; }
                        else { controller.ViewBag.lblQuanLySuKien = LanguageConfigUtil.getLanguageConfigByCode("lblQuanLySuKien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDoiMatKhau") { controller.ViewBag.lblDoiMatKhau = obj.Name; }
                        else { controller.ViewBag.lblDoiMatKhau = LanguageConfigUtil.getLanguageConfigByCode("lblDoiMatKhau", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTrangQuanTri") { controller.ViewBag.lblTrangQuanTri = obj.Name; }
                        else { controller.ViewBag.lblTrangQuanTri = LanguageConfigUtil.getLanguageConfigByCode("lblTrangQuanTri", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDangXuat") { controller.ViewBag.lblDangXuat = obj.Name; }
                        else { controller.ViewBag.lblDangXuat = LanguageConfigUtil.getLanguageConfigByCode("lblDangXuat", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblLienHe") { controller.ViewBag.lblLienHe = obj.Name; }
                        else { controller.ViewBag.lblLienHe = LanguageConfigUtil.getLanguageConfigByCode("lblLienHe", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDanhMuc") { controller.ViewBag.lblDanhMuc = obj.Name; }
                        else { controller.ViewBag.lblDanhMuc = LanguageConfigUtil.getLanguageConfigByCode("lblDanhMuc", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblThongTinChung") { controller.ViewBag.lblThongTinChung = obj.Name; }
                        else { controller.ViewBag.lblThongTinChung = LanguageConfigUtil.getLanguageConfigByCode("lblThongTinChung", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblHoVaTen") { controller.ViewBag.lblHoVaTen = obj.Name; }
                        else { controller.ViewBag.lblHoVaTen = LanguageConfigUtil.getLanguageConfigByCode("lblHoVaTen", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDiaChiEmail") { controller.ViewBag.lblDiaChiEmail = obj.Name; }
                        else { controller.ViewBag.lblDiaChiEmail = LanguageConfigUtil.getLanguageConfigByCode("lblDiaChiEmail", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNoiDung") { controller.ViewBag.lblNoiDung = obj.Name; }
                        else { controller.ViewBag.lblNoiDung = LanguageConfigUtil.getLanguageConfigByCode("lblNoiDung", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGuiDi") { controller.ViewBag.lblGuiDi = obj.Name; }
                        else { controller.ViewBag.lblGuiDi = LanguageConfigUtil.getLanguageConfigByCode("lblGuiDi", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapHoVaTen") { controller.ViewBag.lblNhapHoVaTen = obj.Name; }
                        else { controller.ViewBag.lblNhapHoVaTen = LanguageConfigUtil.getLanguageConfigByCode("lblNhapHoVaTen", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapEmail") { controller.ViewBag.lblNhapEmail = obj.Name; }
                        else { controller.ViewBag.lblNhapEmail = LanguageConfigUtil.getLanguageConfigByCode("lblNhapEmail", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGioiThieu") { controller.ViewBag.lblGioiThieu = obj.Name; }
                        else { controller.ViewBag.lblGioiThieu = LanguageConfigUtil.getLanguageConfigByCode("lblGioiThieu", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTinTucCarousel") { controller.ViewBag.lblTinTucCarousel = obj.Name; }
                        else { controller.ViewBag.lblTinTucCarousel = LanguageConfigUtil.getLanguageConfigByCode("lblTinTucCarousel", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblEventCarousel") { controller.ViewBag.lblEventCarousel = obj.Name; }
                        else { controller.ViewBag.lblEventCarousel = LanguageConfigUtil.getLanguageConfigByCode("lblEventCarousel", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblThuVienCarousel") { controller.ViewBag.lblThuVienCarousel = obj.Name; }
                        else { controller.ViewBag.lblThuVienCarousel = LanguageConfigUtil.getLanguageConfigByCode("lblThuVienCarousel", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblProjectIntroductionContent1") { controller.ViewBag.lblProjectIntroductionContent1 = obj.Name; }
                        else { controller.ViewBag.lblProjectIntroductionContent1 = LanguageConfigUtil.getLanguageConfigByCode("lblProjectIntroductionContent1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblProjectIntroductionContent2") { controller.ViewBag.lblProjectIntroductionContent2 = obj.Name; }
                        else { controller.ViewBag.lblProjectIntroductionContent2 = LanguageConfigUtil.getLanguageConfigByCode("lblProjectIntroductionContent2", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblIntroductionProjectHeader1") { controller.ViewBag.lblIntroductionProjectHeader1 = obj.Name; }
                        else { controller.ViewBag.lblIntroductionProjectHeader1 = LanguageConfigUtil.getLanguageConfigByCode("lblIntroductionProjectHeader1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblIntroductionProjectHeader2") { controller.ViewBag.lblIntroductionProjectHeader2 = obj.Name; }
                        else { controller.ViewBag.lblIntroductionProjectHeader2 = LanguageConfigUtil.getLanguageConfigByCode("lblIntroductionProjectHeader2", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblContentBanner") { controller.ViewBag.lblContentBanner = obj.Name; }
                        else { controller.ViewBag.lblContentBanner = LanguageConfigUtil.getLanguageConfigByCode("lblContentBanner", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBanner") { controller.ViewBag.lblBanner = obj.Name; }
                        else { controller.ViewBag.lblBanner = LanguageConfigUtil.getLanguageConfigByCode("lblBanner", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblCoverHeaderContent") { controller.ViewBag.lblCoverHeaderContent = obj.Name; }
                        else { controller.ViewBag.lblCoverHeaderContent = LanguageConfigUtil.getLanguageConfigByCode("lblCoverHeaderContent", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblCaNhan") { controller.ViewBag.lblCaNhan = obj.Name; }
                        else { controller.ViewBag.lblCaNhan = LanguageConfigUtil.getLanguageConfigByCode("lblCaNhan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDoanhNghiep") { controller.ViewBag.lblDoanhNghiep = obj.Name; }
                        else { controller.ViewBag.lblDoanhNghiep = LanguageConfigUtil.getLanguageConfigByCode("lblDoanhNghiep", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTenDangNhap1") { controller.ViewBag.lblTenDangNhap1 = obj.Name; }
                        else { controller.ViewBag.lblTenDangNhap1 = LanguageConfigUtil.getLanguageConfigByCode("lblTenDangNhap1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapTenDangNhap1") { controller.ViewBag.lblNhapTenDangNhap1 = obj.Name; }
                        else { controller.ViewBag.lblNhapTenDangNhap1 = LanguageConfigUtil.getLanguageConfigByCode("lblNhapTenDangNhap1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSoDienThoai") { controller.ViewBag.lblSoDienThoai = obj.Name; }
                        else { controller.ViewBag.lblSoDienThoai = LanguageConfigUtil.getLanguageConfigByCode("lblSoDienThoai", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapSoDienThoai") { controller.ViewBag.lblNhapSoDienThoai = obj.Name; }
                        else { controller.ViewBag.lblNhapSoDienThoai = LanguageConfigUtil.getLanguageConfigByCode("lblNhapSoDienThoai", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblChungMinhThu") { controller.ViewBag.lblChungMinhThu = obj.Name; }
                        else { controller.ViewBag.lblChungMinhThu = LanguageConfigUtil.getLanguageConfigByCode("lblChungMinhThu", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapSoChungMinhThu") { controller.ViewBag.lblNhapSoChungMinhThu = obj.Name; }
                        else { controller.ViewBag.lblNhapSoChungMinhThu = LanguageConfigUtil.getLanguageConfigByCode("lblNhapSoChungMinhThu", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTenDoanhNghiep") { controller.ViewBag.lblTenDoanhNghiep = obj.Name; }
                        else { controller.ViewBag.lblTenDoanhNghiep = LanguageConfigUtil.getLanguageConfigByCode("lblTenDoanhNghiep", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapTenDoanhNghiep") { controller.ViewBag.lblNhapTenDoanhNghiep = obj.Name; }
                        else { controller.ViewBag.lblNhapTenDoanhNghiep = LanguageConfigUtil.getLanguageConfigByCode("lblNhapTenDoanhNghiep", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSoDangKyKinhDoanh") { controller.ViewBag.lblSoDangKyKinhDoanh = obj.Name; }
                        else { controller.ViewBag.lblSoDangKyKinhDoanh = LanguageConfigUtil.getLanguageConfigByCode("lblSoDangKyKinhDoanh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapSoDangKyKinhDoanh") { controller.ViewBag.lblNhapSoDangKyKinhDoanh = obj.Name; }
                        else { controller.ViewBag.lblNhapSoDangKyKinhDoanh = LanguageConfigUtil.getLanguageConfigByCode("lblNhapSoDangKyKinhDoanh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDangKyTuVan") { controller.ViewBag.lblDangKyTuVan = obj.Name; }
                        else { controller.ViewBag.lblDangKyTuVan = LanguageConfigUtil.getLanguageConfigByCode("lblDangKyTuVan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblThongTinHoTro") { controller.ViewBag.lblThongTinHoTro = obj.Name; }
                        else { controller.ViewBag.lblThongTinHoTro = LanguageConfigUtil.getLanguageConfigByCode("lblThongTinHoTro", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGiaiDapThacMac") { controller.ViewBag.lblGiaiDapThacMac = obj.Name; }
                        else { controller.ViewBag.lblGiaiDapThacMac = LanguageConfigUtil.getLanguageConfigByCode("lblGiaiDapThacMac", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblHuongDanThamGia") { controller.ViewBag.lblHuongDanThamGia = obj.Name; }
                        else { controller.ViewBag.lblHuongDanThamGia = LanguageConfigUtil.getLanguageConfigByCode("lblHuongDanThamGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblAnhDaiDien") { controller.ViewBag.lblAnhDaiDien = obj.Name; }
                        else { controller.ViewBag.lblAnhDaiDien = LanguageConfigUtil.getLanguageConfigByCode("lblAnhDaiDien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblCapNhatThayDoi") { controller.ViewBag.lblCapNhatThayDoi = obj.Name; }
                        else { controller.ViewBag.lblCapNhatThayDoi = LanguageConfigUtil.getLanguageConfigByCode("lblCapNhatThayDoi", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapMatKhauHienTai") { controller.ViewBag.lblNhapMatKhauHienTai = obj.Name; }
                        else { controller.ViewBag.lblNhapMatKhauHienTai = LanguageConfigUtil.getLanguageConfigByCode("lblNhapMatKhauHienTai", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMatKhauMoi") { controller.ViewBag.lblMatKhauMoi = obj.Name; }
                        else { controller.ViewBag.lblMatKhauMoi = LanguageConfigUtil.getLanguageConfigByCode("lblMatKhauMoi", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapMatKhauMoi") { controller.ViewBag.lblNhapMatKhauMoi = obj.Name; }
                        else { controller.ViewBag.lblNhapMatKhauMoi = LanguageConfigUtil.getLanguageConfigByCode("lblNhapMatKhauMoi", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhapLaiMatKhauMoi") { controller.ViewBag.lblNhapLaiMatKhauMoi = obj.Name; }
                        else { controller.ViewBag.lblNhapLaiMatKhauMoi = LanguageConfigUtil.getLanguageConfigByCode("lblNhapLaiMatKhauMoi", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSuKienDaDangKyThamGia") { controller.ViewBag.lblSuKienDaDangKyThamGia = obj.Name; }
                        else { controller.ViewBag.lblSuKienDaDangKyThamGia = LanguageConfigUtil.getLanguageConfigByCode("lblSuKienDaDangKyThamGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblChiTietSuKien") { controller.ViewBag.lblChiTietSuKien = obj.Name; }
                        else { controller.ViewBag.lblChiTietSuKien = LanguageConfigUtil.getLanguageConfigByCode("lblChiTietSuKien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblFAQ") { controller.ViewBag.lblFAQ = obj.Name; }
                        else { controller.ViewBag.lblFAQ = LanguageConfigUtil.getLanguageConfigByCode("lblFAQ", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBaiKhaoSatDanhGia") { controller.ViewBag.lblBaiKhaoSatDanhGia = obj.Name; }
                        else { controller.ViewBag.lblBaiKhaoSatDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblBaiKhaoSatDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblXemChiTietDanhGia") { controller.ViewBag.lblXemChiTietDanhGia = obj.Name; }
                        else { controller.ViewBag.lblXemChiTietDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblXemChiTietDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDiemCuaBan") { controller.ViewBag.lblDiemCuaBan = obj.Name; }
                        else { controller.ViewBag.lblDiemCuaBan = LanguageConfigUtil.getLanguageConfigByCode("lblDiemCuaBan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDanhGia") { controller.ViewBag.lblDanhGia = obj.Name; }
                        else { controller.ViewBag.lblDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblChiTietDiemTungHangMuc") { controller.ViewBag.lblChiTietDiemTungHangMuc = obj.Name; }
                        else { controller.ViewBag.lblChiTietDiemTungHangMuc = LanguageConfigUtil.getLanguageConfigByCode("lblChiTietDiemTungHangMuc", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblNhanDinh") { controller.ViewBag.lblNhanDinh = obj.Name; }
                        else { controller.ViewBag.lblNhanDinh = LanguageConfigUtil.getLanguageConfigByCode("lblNhanDinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblKhaNangTiepCanVonNganHang") { controller.ViewBag.lblKhaNangTiepCanVonNganHang = obj.Name; }
                        else { controller.ViewBag.lblKhaNangTiepCanVonNganHang = LanguageConfigUtil.getLanguageConfigByCode("lblKhaNangTiepCanVonNganHang", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblKhuyenNghi") { controller.ViewBag.lblKhuyenNghi = obj.Name; }
                        else { controller.ViewBag.lblKhuyenNghi = LanguageConfigUtil.getLanguageConfigByCode("lblKhuyenNghi", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblHoTroTuPhiaChungToi") { controller.ViewBag.lblHoTroTuPhiaChungToi = obj.Name; }
                        else { controller.ViewBag.lblHoTroTuPhiaChungToi = LanguageConfigUtil.getLanguageConfigByCode("lblHoTroTuPhiaChungToi", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDay") { controller.ViewBag.lblDay = obj.Name; }
                        else { controller.ViewBag.lblDay = LanguageConfigUtil.getLanguageConfigByCode("lblDay", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTroVeTrangDanhGia") { controller.ViewBag.lblTroVeTrangDanhGia = obj.Name; }
                        else { controller.ViewBag.lblTroVeTrangDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblTroVeTrangDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBaiKhaoSatDanhGia") { controller.ViewBag.lblBaiKhaoSatDanhGia = obj.Name; }
                        else { controller.ViewBag.lblBaiKhaoSatDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblBaiKhaoSatDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblXemChiTietDanhGia") { controller.ViewBag.lblXemChiTietDanhGia = obj.Name; }
                        else { controller.ViewBag.lblXemChiTietDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblXemChiTietDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblKetQuaDanhGia") { controller.ViewBag.lblKetQuaDanhGia = obj.Name; }
                        else { controller.ViewBag.lblKetQuaDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblKetQuaDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblCamOnBanDaThucHienDanhGia") { controller.ViewBag.lblCamOnBanDaThucHienDanhGia = obj.Name; }
                        else { controller.ViewBag.lblCamOnBanDaThucHienDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblCamOnBanDaThucHienDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTongDiem") { controller.ViewBag.lblTongDiem = obj.Name; }
                        else { controller.ViewBag.lblTongDiem = LanguageConfigUtil.getLanguageConfigByCode("lblTongDiem", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMucDanhGIa") { controller.ViewBag.lblMucDanhGIa = obj.Name; }
                        else { controller.ViewBag.lblMucDanhGIa = LanguageConfigUtil.getLanguageConfigByCode("lblMucDanhGIa", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTyTrong") { controller.ViewBag.lblTyTrong = obj.Name; }
                        else { controller.ViewBag.lblTyTrong = LanguageConfigUtil.getLanguageConfigByCode("lblTyTrong", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTongDiemTamTinh") { controller.ViewBag.lblTongDiemTamTinh = obj.Name; }
                        else { controller.ViewBag.lblTongDiemTamTinh = LanguageConfigUtil.getLanguageConfigByCode("lblTongDiemTamTinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblXemKetQuaDanhGia") { controller.ViewBag.lblXemKetQuaDanhGia = obj.Name; }
                        else { controller.ViewBag.lblXemKetQuaDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblXemKetQuaDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDangKyHoTro") { controller.ViewBag.lblDangKyHoTro = obj.Name; }
                        else { controller.ViewBag.lblDangKyHoTro = LanguageConfigUtil.getLanguageConfigByCode("lblDangKyHoTro", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSoTayTitle") { controller.ViewBag.lblSoTayTitle = obj.Name; }
                        else { controller.ViewBag.lblSoTayTitle = LanguageConfigUtil.getLanguageConfigByCode("lblSoTayTitle", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSoTayBannerTittle2") { controller.ViewBag.lblSoTayBannerTittle2 = obj.Name; }
                        else { controller.ViewBag.lblSoTayBannerTittle2 = LanguageConfigUtil.getLanguageConfigByCode("lblSoTayBannerTittle2", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTraCuuTrucTuyen") { controller.ViewBag.lblTraCuuTrucTuyen = obj.Name; }
                        else { controller.ViewBag.lblTraCuuTrucTuyen = LanguageConfigUtil.getLanguageConfigByCode("lblTraCuuTrucTuyen", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTaiVeSoTay") { controller.ViewBag.lblTaiVeSoTay = obj.Name; }
                        else { controller.ViewBag.lblTaiVeSoTay = LanguageConfigUtil.getLanguageConfigByCode("lblTaiVeSoTay", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblLoiMoDau") { controller.ViewBag.lblLoiMoDau = obj.Name; }
                        else { controller.ViewBag.lblLoiMoDau = LanguageConfigUtil.getLanguageConfigByCode("lblLoiMoDau", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblIntroduction1") { controller.ViewBag.lblIntroduction1 = obj.Name; }
                        else { controller.ViewBag.lblIntroduction1 = LanguageConfigUtil.getLanguageConfigByCode("lblIntroduction1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblIntroduction2") { controller.ViewBag.lblIntroduction2 = obj.Name; }
                        else { controller.ViewBag.lblIntroduction2 = LanguageConfigUtil.getLanguageConfigByCode("lblIntroduction2", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblCucTruong") { controller.ViewBag.lblCucTruong = obj.Name; }
                        else { controller.ViewBag.lblCucTruong = LanguageConfigUtil.getLanguageConfigByCode("lblCucTruong", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMucTieuXayDung") { controller.ViewBag.lblMucTieuXayDung = obj.Name; }
                        else { controller.ViewBag.lblMucTieuXayDung = LanguageConfigUtil.getLanguageConfigByCode("lblMucTieuXayDung", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMucTieuXayDungDes") { controller.ViewBag.lblMucTieuXayDungDes = obj.Name; }
                        else { controller.ViewBag.lblMucTieuXayDungDes = LanguageConfigUtil.getLanguageConfigByCode("lblMucTieuXayDungDes", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMucTieuXayDung1") { controller.ViewBag.lblMucTieuXayDung1 = obj.Name; }
                        else { controller.ViewBag.lblMucTieuXayDung1 = LanguageConfigUtil.getLanguageConfigByCode("lblMucTieuXayDung1", controller.ViewBag.LanguageCode).Name; }

                        if (obj.Code == "lblMucTieuXayDungDes1") { controller.ViewBag.lblMucTieuXayDungDes1 = obj.Name; }
                        else { controller.ViewBag.lblMucTieuXayDungDes1 = LanguageConfigUtil.getLanguageConfigByCode("lblMucTieuXayDungDes1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMucTieuXayDung2") { controller.ViewBag.lblMucTieuXayDung2 = obj.Name; }
                        else { controller.ViewBag.lblMucTieuXayDung2 = LanguageConfigUtil.getLanguageConfigByCode("lblMucTieuXayDung2", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMucTieuXayDungDes2") { controller.ViewBag.lblMucTieuXayDungDes2 = obj.Name; }
                        else { controller.ViewBag.lblMucTieuXayDungDes2 = LanguageConfigUtil.getLanguageConfigByCode("lblMucTieuXayDungDes2", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMucTieuXayDung3") { controller.ViewBag.lblMucTieuXayDung3 = obj.Name; }
                        else { controller.ViewBag.lblMucTieuXayDung3 = LanguageConfigUtil.getLanguageConfigByCode("lblMucTieuXayDung3", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMucTieuXayDungDes3") { controller.ViewBag.lblMucTieuXayDungDes3 = obj.Name; }
                        else { controller.ViewBag.lblMucTieuXayDungDes3 = LanguageConfigUtil.getLanguageConfigByCode("lblMucTieuXayDungDes3", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblPhuongPhapXayDung") { controller.ViewBag.lblPhuongPhapXayDung = obj.Name; }
                        else { controller.ViewBag.lblPhuongPhapXayDung = LanguageConfigUtil.getLanguageConfigByCode("lblPhuongPhapXayDung", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblPhuongPhapXayDungDes") { controller.ViewBag.lblPhuongPhapXayDungDes = obj.Name; }
                        else { controller.ViewBag.lblPhuongPhapXayDungDes = LanguageConfigUtil.getLanguageConfigByCode("lblPhuongPhapXayDungDes", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblHuongDan") { controller.ViewBag.lblHuongDan = obj.Name; }
                        else { controller.ViewBag.lblHuongDan = LanguageConfigUtil.getLanguageConfigByCode("lblHuongDan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSuDungSoTay") { controller.ViewBag.lblSuDungSoTay = obj.Name; }
                        else { controller.ViewBag.lblSuDungSoTay = LanguageConfigUtil.getLanguageConfigByCode("lblSuDungSoTay", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBuoc1") { controller.ViewBag.lblBuoc1 = obj.Name; }
                        else { controller.ViewBag.lblBuoc1 = LanguageConfigUtil.getLanguageConfigByCode("lblBuoc1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBuoc2") { controller.ViewBag.lblBuoc2 = obj.Name; }
                        else { controller.ViewBag.lblBuoc2 = LanguageConfigUtil.getLanguageConfigByCode("lblBuoc2", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBuoc3") { controller.ViewBag.lblBuoc3 = obj.Name; }
                        else { controller.ViewBag.lblBuoc3 = LanguageConfigUtil.getLanguageConfigByCode("lblBuoc3", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBuoc4") { controller.ViewBag.lblBuoc4 = obj.Name; }
                        else { controller.ViewBag.lblBuoc4 = LanguageConfigUtil.getLanguageConfigByCode("lblBuoc4", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBuoc5") { controller.ViewBag.lblBuoc5 = obj.Name; }
                        else { controller.ViewBag.lblBuoc5 = LanguageConfigUtil.getLanguageConfigByCode("lblBuoc5", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblThuVien") { controller.ViewBag.lblThuVien = obj.Name; }
                        else { controller.ViewBag.lblThuVien = LanguageConfigUtil.getLanguageConfigByCode("lblThuVien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTitleThuVien") { controller.ViewBag.lblTitleThuVien = obj.Name; }
                        else { controller.ViewBag.lblTitleThuVien = LanguageConfigUtil.getLanguageConfigByCode("lblTitleThuVien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTextThuVien") { controller.ViewBag.lblTextThuVien = obj.Name; }
                        else { controller.ViewBag.lblTextThuVien = LanguageConfigUtil.getLanguageConfigByCode("lblTextThuVien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTruyCapThuVien") { controller.ViewBag.lblTruyCapThuVien = obj.Name; }
                        else { controller.ViewBag.lblTruyCapThuVien = LanguageConfigUtil.getLanguageConfigByCode("lblTruyCapThuVien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDanhGiaTaiChinh") { controller.ViewBag.lblDanhGiaTaiChinh = obj.Name; }
                        else { controller.ViewBag.lblDanhGiaTaiChinh = LanguageConfigUtil.getLanguageConfigByCode("lblDanhGiaTaiChinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTitleDanhGiaTaiChinh") { controller.ViewBag.lblTitleDanhGiaTaiChinh = obj.Name; }
                        else { controller.ViewBag.lblTitleDanhGiaTaiChinh = LanguageConfigUtil.getLanguageConfigByCode("lblTitleDanhGiaTaiChinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTextDanhGiaTaiChinh") { controller.ViewBag.lblTextDanhGiaTaiChinh = obj.Name; }
                        else { controller.ViewBag.lblTextDanhGiaTaiChinh = LanguageConfigUtil.getLanguageConfigByCode("lblTextDanhGiaTaiChinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblThucHienDanhGia") { controller.ViewBag.lblThucHienDanhGia = obj.Name; }
                        else { controller.ViewBag.lblThucHienDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblThucHienDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSoTayTaiChinh") { controller.ViewBag.lblSoTayTaiChinh = obj.Name; }
                        else { controller.ViewBag.lblSoTayTaiChinh = LanguageConfigUtil.getLanguageConfigByCode("lblSoTayTaiChinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTitleSoTayTaiChinh") { controller.ViewBag.lblTitleSoTayTaiChinh = obj.Name; }
                        else { controller.ViewBag.lblTitleSoTayTaiChinh = LanguageConfigUtil.getLanguageConfigByCode("lblTitleSoTayTaiChinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTextSoTayTaiChinh") { controller.ViewBag.lblTextSoTayTaiChinh = obj.Name; }
                        else { controller.ViewBag.lblTextSoTayTaiChinh = LanguageConfigUtil.getLanguageConfigByCode("lblTextSoTayTaiChinh", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblGioiThieuSotay") { controller.ViewBag.lblGioiThieuSotay = obj.Name; }
                        else { controller.ViewBag.lblGioiThieuSotay = LanguageConfigUtil.getLanguageConfigByCode("lblGioiThieuSotay", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTinTucSuKien") { controller.ViewBag.lblTinTucSuKien = obj.Name; }
                        else { controller.ViewBag.lblTinTucSuKien = LanguageConfigUtil.getLanguageConfigByCode("lblTinTucSuKien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTitleTinTucSuKien") { controller.ViewBag.lblTitleTinTucSuKien = obj.Name; }
                        else { controller.ViewBag.lblTitleTinTucSuKien = LanguageConfigUtil.getLanguageConfigByCode("lblTitleTinTucSuKien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTextTinTucSuKien") { controller.ViewBag.lblTextTinTucSuKien = obj.Name; }
                        else { controller.ViewBag.lblTextTinTucSuKien = LanguageConfigUtil.getLanguageConfigByCode("lblTextTinTucSuKien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTinTucCapNhat") { controller.ViewBag.lblTinTucCapNhat = obj.Name; }
                        else { controller.ViewBag.lblTinTucCapNhat = LanguageConfigUtil.getLanguageConfigByCode("lblTinTucCapNhat", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDanhSachSuKien") { controller.ViewBag.lblDanhSachSuKien = obj.Name; }
                        else { controller.ViewBag.lblDanhSachSuKien = LanguageConfigUtil.getLanguageConfigByCode("lblDanhSachSuKien", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDaoTaoCoBanslide") { controller.ViewBag.lblDaoTaoCoBanslide = obj.Name; }
                        else { controller.ViewBag.lblDaoTaoCoBanslide = LanguageConfigUtil.getLanguageConfigByCode("lblDaoTaoCoBanslide", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDaoTaoNangCaoslide") { controller.ViewBag.lblDaoTaoNangCaoslide = obj.Name; }
                        else { controller.ViewBag.lblDaoTaoNangCaoslide = LanguageConfigUtil.getLanguageConfigByCode("lblDaoTaoNangCaoslide", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDaotaoSmeslide") { controller.ViewBag.lblDaotaoSmeslide = obj.Name; }
                        else { controller.ViewBag.lblDaotaoSmeslide = LanguageConfigUtil.getLanguageConfigByCode("lblDaotaoSmeslide", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDangkyNhanTin") { controller.ViewBag.lblDangkyNhanTin = obj.Name; }
                        else { controller.ViewBag.lblDangkyNhanTin = LanguageConfigUtil.getLanguageConfigByCode("lblDangkyNhanTin", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTaiLieuTrucQuanContext") { controller.ViewBag.lblTaiLieuTrucQuanContext = obj.Name; }
                        else { controller.ViewBag.lblTaiLieuTrucQuanContext = LanguageConfigUtil.getLanguageConfigByCode("lblTaiLieuTrucQuanContext", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTimKiemThongTinContext") { controller.ViewBag.lblTimKiemThongTinContext = obj.Name; }
                        else { controller.ViewBag.lblTimKiemThongTinContext = LanguageConfigUtil.getLanguageConfigByCode("lblTimKiemThongTinContext", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblChuyenGiaHangDauContext") { controller.ViewBag.lblChuyenGiaHangDauContext = obj.Name; }
                        else { controller.ViewBag.lblChuyenGiaHangDauContext = LanguageConfigUtil.getLanguageConfigByCode("lblChuyenGiaHangDauContext", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTaiChinhVungChacContext") { controller.ViewBag.lblTaiChinhVungChacContext = obj.Name; }
                        else { controller.ViewBag.lblTaiChinhVungChacContext = LanguageConfigUtil.getLanguageConfigByCode("lblTaiChinhVungChacContext", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSearch") { controller.ViewBag.lblSearch = obj.Name; }
                        else { controller.ViewBag.lblSearch = LanguageConfigUtil.getLanguageConfigByCode("lblSearch", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTimThay") { controller.ViewBag.lblTimThay = obj.Name; }
                        else { controller.ViewBag.lblTimThay = LanguageConfigUtil.getLanguageConfigByCode("lblTimThay", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblTextResultSearch") { controller.ViewBag.lblTextResultSearch = obj.Name; }
                        else { controller.ViewBag.lblTextResultSearch = LanguageConfigUtil.getLanguageConfigByCode("lblTextResultSearch", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblXemHetBaiViet") { controller.ViewBag.lblXemHetBaiViet = obj.Name; }
                        else { controller.ViewBag.lblXemHetBaiViet = LanguageConfigUtil.getLanguageConfigByCode("lblXemHetBaiViet", controller.ViewBag.LanguageCode).Name; }

                        if (obj.Code == "lblWriteComment") { controller.ViewBag.lblWriteComment = obj.Name; }
                        else { controller.ViewBag.lblWriteComment = LanguageConfigUtil.getLanguageConfigByCode("lblWriteComment", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblSendComment") { controller.ViewBag.lblSendComment = obj.Name; }
                        else { controller.ViewBag.lblSendComment = LanguageConfigUtil.getLanguageConfigByCode("lblSendComment", controller.ViewBag.LanguageCode).Name; }


                        // Bổ sung một vài cái cũ bị thiếu 
                        if (obj.Code == "lblTitleBinhLuan") { controller.ViewBag.lblTitleBinhLuan = obj.Name; }
                        else { controller.ViewBag.lblTitleBinhLuan = LanguageConfigUtil.getLanguageConfigByCode("lblTitleBinhLuan", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblBaiVietPhoBien") { controller.ViewBag.lblBaiVietPhoBien = obj.Name; }
                        else { controller.ViewBag.lblBaiVietPhoBien = LanguageConfigUtil.getLanguageConfigByCode("lblBaiVietPhoBien", controller.ViewBag.LanguageCode).Name; }

                        if (obj.Code == "lblCoSponsoring") { controller.ViewBag.lblCoSponsoring = obj.Name; }
                        else { controller.ViewBag.lblCoSponsoring = LanguageConfigUtil.getLanguageConfigByCode("lblCoSponsoring", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblCongCuTaiChinh1") { controller.ViewBag.lblCongCuTaiChinh1 = obj.Name; }
                        else { controller.ViewBag.lblCongCuTaiChinh1 = LanguageConfigUtil.getLanguageConfigByCode("lblCongCuTaiChinh1", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMieuTaBannerCongCuDanhGia") { controller.ViewBag.lblMieuTaBannerCongCuDanhGia = obj.Name; }
                        else { controller.ViewBag.lblMieuTaBannerCongCuDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblMieuTaBannerCongCuDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblCongCuTaiChinh1") { controller.ViewBag.lblCongCuTaiChinh1 = obj.Name; }
                        else { controller.ViewBag.lblMieuTaChoAnhCongCuDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblMieuTaChoAnhCongCuDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblMoiLamBaiDanhGia") { controller.ViewBag.lblMoiLamBaiDanhGia = obj.Name; }
                        else { controller.ViewBag.lblMoiLamBaiDanhGia = LanguageConfigUtil.getLanguageConfigByCode("lblMoiLamBaiDanhGia", controller.ViewBag.LanguageCode).Name; }
                        if (obj.Code == "lblDangKi1") { controller.ViewBag.lblDangKi1 = obj.Name; }
                        else { controller.ViewBag.lblDangKi1 = LanguageConfigUtil.getLanguageConfigByCode("lblDangKi1", controller.ViewBag.LanguageCode).Name; }
                    }
                }
                //also you have access to the httpcontext & route in controller.HttpContext & controller.RouteData
            }
            base.OnResultExecuting(context);
        }
    }
}
