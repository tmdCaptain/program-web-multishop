using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Xml.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Multi_Shop.Models
{
    public class Common
    {
        static DbContext cn = new DbContext("name=MultiShopOnlineEntities");

        // Method dùng để lấy ra tất cả những sản phẩm có trong Database
        public static List<SanPham>  getProducts()
        {
            
            List<SanPham> y = new List<SanPham>();
            // Khai báo đối tượng đại diện cho database
            DbContext sp = new DbContext("name=MultiShopOnlineEntities");
            // Lấy dữ liệu
            y = sp.Set<SanPham>().Where(m => m.daDuyet == true).ToList<SanPham>();
            return y;

        }

        // Method dùng để lấy ra tất cả các sản phẩm theo mã loại
        public static List<SanPham> getProductsByCategories(int maLoai)
        {
            List<SanPham> l = new List<SanPham>();
            DbContext sp = new DbContext("name=MultiShopOnlineEntities");
            // Lấy dữ liệu
            l = sp.Set<SanPham>().Where(x => x.maLoai == maLoai&& x.daDuyet==true).ToList<SanPham>();
            return l;
        }


        // Method dùng để truy xuất những sản phẩm theo điều kiện được giảm giá ( theo % )
        public static List<SanPham> getProductsSale()
        {
            List<SanPham> l = new List<SanPham>();
            DbContext sp = new DbContext("name=MultiShopOnlineEntities");
            // Lấy dữ liệu
            l = sp.Set<SanPham>().Where(x => x.giamGia >=10 && x.giamGia <=20 && x.daDuyet == true).ToList<SanPham>();
            return l;
        }


        // Method dùng để truy xuất các loại hàng sản phẩm

        public static List<LoaiSP> getCategories()
        {
            return new DbContext("name=MultiShopOnlineEntities").Set<LoaiSP>().ToList<LoaiSP>();
        }

        // Method dùng để lấy ra ra bài viết có trong Database

        public static List<BaiViet> getArticle(int x)
        {
            List<BaiViet> bv = new List<BaiViet>();
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();

            bv = db.BaiViets.Where(m => m.daDuyet == true).OrderByDescending(j => j.ngayDang).Take(x).ToList<BaiViet>();
            return bv;
        }

        // Method dùng để lấy ra bài viết theo mã bài viết
        public static List<BaiViet> getArticlebyMaBv(string Mabv)
        {
            List<BaiViet> bv = new List<BaiViet>();
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();

            bv = db.BaiViets.Where(x => x.maBV==Mabv).ToList<BaiViet>();
            return bv;
        }

        // Method dùng để lấy thông tin một sản phẩm dựa vào mã sản phẩm đó 
        public static SanPham getProductsByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP);
        }

        // Method dùng để lấy những bình luận sau khi khách hàng bình luận theo mã sản phẩm
        public static List<Comment> getCommentofMaSP(string maSP)
        {
            List<Comment> l = new List<Comment>();
            DbContext sp = new DbContext("name=MultiShopOnlineEntities");
            // Lấy dữ liệu
            l = sp.Set<Comment>().Where(x => x.maSP.Equals(maSP)).ToList<Comment>();
            return l;
        }


        // Method dùng để lấy những bình luận sau khi khách hàng bình luận theo mã bài viết
        public static List<CommentArticle> getCommentofMaBV(string maBV)
        {
            List<CommentArticle> l = new List<CommentArticle>();
            DbContext sp = new DbContext("name=MultiShopOnlineEntities");
            // Lấy dữ liệu
            l = sp.Set<CommentArticle>().Where(x => x.maBV.Equals(maBV)).ToList<CommentArticle>();
            return l;
        }


        public static List<KhachHang> getCustomers()
        {

            List<KhachHang> y = new List<KhachHang>();
            // Khai báo đối tượng đại diện cho database
            DbContext sp = new DbContext("name=MultiShopOnlineEntities");
            // Lấy dữ liệu
            y = sp.Set<KhachHang>().ToList<KhachHang>();
            return y;
        }

        public static List<DonHang> getOders()
        {

            List<DonHang> y = new List<DonHang>();
            // Khai báo đối tượng đại diện cho database
            DbContext sp = new DbContext("name=MultiShopOnlineEntities");
            // Lấy dữ liệu
            y = sp.Set<DonHang>().ToList<DonHang>();
            return y;
        }

        public static List<CtDonHang> getListOders()
        {

            List<CtDonHang> y = new List<CtDonHang>();
            // Khai báo đối tượng đại diện cho database
            DbContext sp = new DbContext("name=MultiShopOnlineEntities");
            // Lấy dữ liệu
            y = sp.Set<CtDonHang>().ToList<CtDonHang>();
            return y;
        }
    }
}