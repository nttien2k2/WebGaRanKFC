using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgoThanhTien_2001200542_WebKFC.Models
{
    public class GioHang
    {
        dbWebGaRanKFCDataContext data = new dbWebGaRanKFCDataContext();
        public int maMonAn { get; set; }
        public string name { get; set; }
        public string images { get; set; }
        public double price { get; set; }
        public int soLuong { get; set; }
        public double thanhTien { get { return soLuong * price; } }
        public GioHang(int id)
        {
            maMonAn = id;
            tbl_MonAn monan = data.tbl_MonAns.FirstOrDefault(dk => dk.id == maMonAn);
            name = monan.Name;
            images = monan.Images;
            price = (double)monan.Price;
            soLuong = 1;
        }
    }
}