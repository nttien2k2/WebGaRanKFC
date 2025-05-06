using NgoThanhTien_2001200542_WebKFC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace NgoThanhTien_2001200542_WebKFC.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        dbWebGaRanKFCDataContext data = new dbWebGaRanKFCDataContext();

        private double sumThanhTien()
        {
            double sumtt = 0;
            List<GioHang> lstgiohang = Session["GioHang"] as List<GioHang>;
            if(lstgiohang != null)
            {
                sumtt += lstgiohang.Sum(dk=> dk.thanhTien);
            }    return sumtt;
        }
        public ActionResult MonAn()
        {
            List<tbl_MonAn> lstmonan = data.tbl_MonAns.ToList();
                
            return View(lstmonan);
        }
        public ActionResult DanhMuc()
        {

             List<tbl_Loai> lstloai = data.tbl_Loais.ToList();
            return PartialView(lstloai);
        }
        public ActionResult MonAnTheoLoai(int id)
        {
            List<tbl_MonAn> lstMonAnTheoLoai = data.tbl_MonAns.Where(dk=> dk.maLoai == id).ToList();
            return View("MonAn",lstMonAnTheoLoai);
        }
        //Lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstgiohang = Session["GioHang"] as List<GioHang>;
            if(lstgiohang == null)
            {
                lstgiohang = new List<GioHang>();
                Session["GioHang"] = lstgiohang;
            }    
            return lstgiohang;
        }
        public ActionResult AddGioHang(int id)
        {
            List<GioHang> lstgiohang = LayGioHang();
            GioHang item = lstgiohang.FirstOrDefault(dk => dk.maMonAn == id);
            if(item == null)
            {
                item = new GioHang(id);
                lstgiohang.Add(item);
            }else
            {
                item.soLuong++;
            }
            Session["GioHang"] = lstgiohang;
            return RedirectToAction("MonAn");
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                ViewBag.message = "Bạn chưa chọn món ăn nào trong giỏ hàng";
            }
            List<GioHang> lstgiohang = LayGioHang();
            ViewBag.sumtt = sumThanhTien();
            return View(lstgiohang);
        }
        public ActionResult DeleteGioHang(int id)
        {
            List<GioHang> lstgiohang = LayGioHang();
            GioHang item = lstgiohang.Single(dk=> dk.maMonAn == id);
            if(item != null)
            {
                lstgiohang.Remove(item);
                return RedirectToAction("GioHang", "KhachHang");
            }
            return RedirectToAction("GioHang", "KhachHang");
        }
        public ActionResult DeleteAllGioHang()
        {
            List<GioHang> lstgiohang = LayGioHang();
            lstgiohang.Clear();
            return RedirectToAction("GioHang", "KhachHang");
        }
        [HttpPost]
        public ActionResult UpdateGioHang(FormCollection c)
        {
            List<GioHang> lstgiohang = LayGioHang();
            foreach (var item in lstgiohang)
            {
                int id = item.maMonAn;
                int soLuong = int.Parse(c["soLuong_" + id]);
                GioHang cartitem = lstgiohang.Single(dk => dk.maMonAn == id);
                if (cartitem != null)
                {
                    cartitem.soLuong = soLuong;
                }
            }
            Session["GioHang"] = lstgiohang;
            return RedirectToAction("GioHang");
        }
        public ActionResult DatHang()
        {
            List<GioHang> lstgiohang = LayGioHang();

            if (lstgiohang.Count > 0)
            {
                string path = Server.MapPath("~/App_Data/lichsu_giohang.csv");

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    var ids = lstgiohang.Select(x => x.maMonAn.ToString()).ToList();

                    // Lấy mã khách hàng từ session
                    string userId = "anonymous";
                    if (Session["KhachHang"] != null)
                    {
                        var kh = (tbl_KhachHang)Session["KhachHang"];
                        userId = kh.maKH.ToString(); // hoặc kh.UserName nếu bạn muốn dùng tên đăng nhập
                    }

                    // Ghi theo định dạng: userId;item1,item2,...
                    string line = $"{userId};{string.Join(",", ids)}";
                    sw.WriteLine(line);
                }
            }

            lstgiohang.Clear();
            Session["GioHang"] = null;

            return RedirectToAction("MonAn");
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(tbl_KhachHang kh)
        {

            if (kh != null)
            {
                data.tbl_KhachHangs.InsertOnSubmit(kh);
                data.SubmitChanges();
            }
            Session["KhachHang"] = kh;
            return RedirectToAction("MonAn");
        }
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection c)
        {
            string tk = c["UserName"];
            string mk = c["Password"];

            tbl_KhachHang kh = data.tbl_KhachHangs.SingleOrDefault(dk=> dk.UserName == tk && dk.Password == mk);
            tbl_NhanVien nv = data.tbl_NhanViens.SingleOrDefault(dk => dk.UserName == tk && dk.Password == mk);
            if (kh != null)
            {
                Session["KhachHang"] = kh;
                return RedirectToAction("MonAn");
            }
            if(nv != null)
            {
                Session["Admin"] = nv;
                return RedirectToAction("index", "NhanVien");
            }
            return RedirectToAction("Đăng Nhập");
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("MonAn");
        }
        public ActionResult DetailMonAn(int id)
        {
            tbl_MonAn monan = new tbl_MonAn();
            monan = data.tbl_MonAns.FirstOrDefault(dk=> dk.id == id);
            return View(monan);
        }


    }
}