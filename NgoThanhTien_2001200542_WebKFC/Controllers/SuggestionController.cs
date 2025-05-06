using NgoThanhTien_2001200542_WebKFC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgoThanhTien_2001200542_WebKFC.Controllers
{
    public class SuggestionController : Controller
    {
        // GET: Suggestion
        public ActionResult Index()
        {
            return View();
        }
        dbWebGaRanKFCDataContext data = new dbWebGaRanKFCDataContext();

        //Đơn giản
        //public ActionResult GoiYMonAn()
        //{
        //    var sessionCart = Session["GioHang"] as List<GioHang> ?? new List<GioHang>();
        //    var prefixSpan = new PrefixSpan();

        //    // Lấy danh sách ID món ăn hiện có trong giỏ hàng
        //    List<int> currentCartIds = sessionCart.Select(x => x.maMonAn).ToList();

        //    // Gọi thuật toán PrefixSpan để lấy gợi ý
        //    var suggestions = prefixSpan.GetSuggestions(currentCartIds);

        //    // Truy vấn cơ sở dữ liệu lấy thông tin chi tiết món ăn
        //    var suggestedMonAn = data.tbl_MonAns.Where(m => suggestions.Contains(m.id)).ToList();

        //    return PartialView("_GoiYMonAn", suggestedMonAn);
        //}
        public ActionResult GoiYMonAn()
        {
            var sessionCart = Session["GioHang"] as List<GioHang> ?? new List<GioHang>();

            List<int> currentCartIds = sessionCart.Select(x => x.maMonAn).ToList();

            List<int> suggestedIds = GetSuggestionsFromPython(currentCartIds);

            var suggestedMonAn = data.tbl_MonAns.Where(m => suggestedIds.Contains(m.id)).ToList();

            return PartialView("_GoiYMonAn", suggestedMonAn);
        }
        private List<int> GetSuggestionsFromPython(List<int> currentCartIds)
        {
            string cartItems = string.Join(",", currentCartIds);

            string pythonScriptPath = Server.MapPath("~/App_Data/suggest.py");

            var startInfo = new ProcessStartInfo()
            {
                FileName = "C:\\Users\\Admin\\AppData\\Local\\Microsoft\\WindowsApps\\python.exe", // Đảm bảo rằng Python đã được cài đặt và có sẵn trong hệ thống PATH
                Arguments = $"\"{pythonScriptPath}\" \"{cartItems}\"", // Truyền danh sách món ăn hiện tại vào script
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Khởi tạo và chạy process
            using (var process = Process.Start(startInfo))
            {
                using (var reader = process.StandardOutput)
                {
                    string output = reader.ReadToEnd().Trim();
                    if (string.IsNullOrWhiteSpace(output))
                        return new List<int>();

                    return output.Split(',').Select(s =>
                    {
                        int.TryParse(s, out int val);
                        return val;
                    }).Where(id => id > 0).ToList();

                }
            }
        }
    }
    public class PrefixSpan
    {
        private List<List<int>> transactionHistory;

        public PrefixSpan()
        {
            transactionHistory = new List<List<int>>();
            string path = HttpContext.Current.Server.MapPath("~/App_Data/lichsu_giohang.csv");

            foreach (var line in System.IO.File.ReadLines(path))
            {
                var parts = line.Split(';');
                if (parts.Length == 2)
                {
                    var items = parts[1].Split(',').Select(int.Parse).ToList();
                    transactionHistory.Add(items);
                }
            }
        }

        public List<int> GetSuggestions(List<int> currentCart)
        {
            var result = new Dictionary<int, int>();

            foreach (var transaction in transactionHistory)
            {
                if (currentCart.All(id => transaction.Contains(id)))
                {
                    foreach (var item in transaction)
                    {
                        if (!currentCart.Contains(item))
                        {
                            if (!result.ContainsKey(item))
                                result[item] = 0;
                            result[item]++;
                        }
                    }
                }
            }

            return result.OrderByDescending(x => x.Value).Select(x => x.Key).Take(3).ToList();
        }
    }

}