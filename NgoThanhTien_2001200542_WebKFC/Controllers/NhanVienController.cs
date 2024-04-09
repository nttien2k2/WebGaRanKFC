using NgoThanhTien_2001200542_WebKFC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgoThanhTien_2001200542_WebKFC.Controllers
{
    public class NhanVienController : Controller
    {
        dbWebGaRanKFCDataContext data = new dbWebGaRanKFCDataContext();

        // GET: NhanVien
        public ActionResult index()
        {
            List<tbl_MonAn> lstma = data.tbl_MonAns.ToList(); 
            return View(lstma);
        }
        public ActionResult CreatesMonAn()
        {
            ViewBag.maLoai = new SelectList(data.tbl_Loais.ToList().OrderBy(n => n.TenLoai), "maLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public ActionResult CreatesMonAn(tbl_MonAn ma, HttpPostedFileBase fileupload)
        {
            var fileName = Path.GetFileName(fileupload.FileName);
            var path = Path.Combine(Server.MapPath("~/Hinhanh"), fileName);
            fileupload.SaveAs(path);
            ma.Images = fileName;
            data.tbl_MonAns.InsertOnSubmit(ma);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMonAn(int id)
        {
            tbl_MonAn ma = data.tbl_MonAns.Single(dk=> dk.id == id);
            data.tbl_MonAns.DeleteOnSubmit(ma);
            data.SubmitChanges();
            return RedirectToAction("index") ;
        }

        public ActionResult UpdateMonAn(int id)
        {
            ViewBag.maLoai = new SelectList(data.tbl_Loais.ToList().OrderBy(n => n.TenLoai), "maLoai", "TenLoai");
            tbl_MonAn ma = data.tbl_MonAns.SingleOrDefault(dk=> dk.id == id);
            return View(ma);
        }
        [HttpPost]
        public ActionResult UpdateMonAn(tbl_MonAn ma, HttpPostedFileBase fileupload)
        {
            if(fileupload == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh bìa";
                return View();
            }    
            var fileName = Path.GetFileName(fileupload.FileName);
            var path = Path.Combine(Server.MapPath("~/Hinhanh"), fileName);
            fileupload.SaveAs(path);
            ma.Images = fileName;
            UpdateModel(ma);
            data.SubmitChanges();
            return RedirectToAction("index");
        }
        public ActionResult QLLoai()
        {
            return View();
        }
    }
}