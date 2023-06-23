using Multi_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Multi_Shop.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        [HttpGet]
        public ActionResult Index()
        {
            KhachHang x = new KhachHang();
            CartShop gh = Session["GioHang"] as CartShop;
            // Thêm sản phẩm vừa chọn 
            ViewData["Cart"] = gh;
            // Cập nhật lại giỏ hàng vào trong Sesstion
            return View(x);
        }

        [HttpPost]

        public ActionResult SaveToDataBase(KhachHang x)
        {
            //Sử dụng trang transaction để lưu dữ liệu đồng thời trên table khác nhau
            using(var context = new MultiShopOnlineEntities())
            {
                using(DbContextTransaction trans = context.Database.BeginTransaction())
                {
                    try
                    {

                        // Table Khách hàng-----------------------------
                        x.maKH = x.soDT;
                        // Thêm khách hàng vào data model
                        context.KhachHangs.Add(x);
                        // Lưu lại khách hàng
                        context.SaveChanges();

                        // Tạo mới một đối tượng khách hàng và thêm đơn hàng
                        DonHang d  = new DonHang();
                        d.soDH = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                        d.maKH = x.maKH;
                        d.ngayGH = DateTime.Now;
                        d.ngayGH = DateTime.Now.AddDays(2);
                        d.taiKhoan = "tran minh duc";
                        d.diaChiGH = x.diaChi;
                        // Table[Đơn Hàng]-----------------------------
                        // Thêm đơn hàng vào data
                        context.DonHangs.Add(d);
                        // Lưu lại
                        context.SaveChanges();

                        // Lấy các đơn hàng trong ShoppingCart
                        CartShop gh = Session["GioHang"] as CartShop;
                        // Cập nhật thông tin đơn hàng
                        foreach(CtDonHang i in gh.SanPhamDC.Values) {
                            i.soDH = d.soDH;
                            context.CtDonHangs.Add(i);
                        }
                        // Lưu lại chi tiết đơn hàng vào database
                        context.SaveChanges();

                        // Finish and commit all  of action above
                        trans.Commit();
                        // Chuyển đến trang thông báo đã đặt hàng thành công
                        return RedirectToAction("Index", "CheckoutSuccess");
                    }catch(Exception e)
                    {
                        trans.Rollback();
                    }
                }
            }
            // Nếu bị lỗi sẽ chuyển ra trang Checkout 
            return RedirectToAction("Index" , "Checkout");
        }
    }
}