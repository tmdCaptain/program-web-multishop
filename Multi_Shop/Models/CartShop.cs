using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multi_Shop.Models
{
    public class CartShop
    {
        public string MaKH { get;set; }
        public string TaiKhoan { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public string DiaChi { get; set; }
        public SortedList<string , CtDonHang> SanPhamDC { get; set; }

        // Khởi tạo lớp CartShop
        public CartShop()
        {
            this.MaKH = "";
            this.TaiKhoan = "";
            this.NgayDat = DateTime.Now;
            this.NgayGiao = DateTime.Now.AddDays(2);
            this.DiaChi = "";
            this.SanPhamDC = new SortedList<string, CtDonHang>();
        }

        // Phương thức kiểm tra CartShop có rỗng không
        public bool IsEmpty()
        {
            return (SanPhamDC.Keys.Count == 0);
        }
        // Method dùng để thêm một sản phẩm vào giỏ hàng
        // Chia làm 2 tình huống : 1. Đã có và 2.Chưa có
        public void addItem(string maSP)
        {
            if (SanPhamDC.Keys.Contains(maSP))
            {
                // Lấy sản phẩm từ trong giỏ hàng
                CtDonHang x = SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)];
                // Tăng số lượng lên 1
                x.soLuong++;
                // Thêm trở lại giỏ hàng sau khi cập nhật số lượng
                upDateOneItem(x);
            }
            else
            {
                // Create 1 object new Products
                CtDonHang y = new CtDonHang();
                // Update information 
                y.maSP = maSP;
                y.soLuong = 1;
                // Lấy giá bán và giảm giá từ table Sản Phẩm
                SanPham z = Common.getProductsByID(maSP);
                y.giaBan = z.giaBan;
                y.giamGia = z.giamGia;

                // Đưa vào danh sách các sản phẩm đã chọn mua trong giỏ hàng của mình
                SanPhamDC.Add(maSP, y);
            }
        }
        //Method để xóa sản phẩm
        public void deleteItem(string maSP)
        {
            if (SanPhamDC.Keys.Contains(maSP))
                SanPhamDC.Remove(maSP);
            
        }

        //Method dùng để  giảm bớt sản phẩm , khi sản phẩm < 1 thì sẽ xóa
        public void decrease(string maSP)
        {
            if (SanPhamDC.Keys.Contains(maSP)) 
            {
                CtDonHang x = SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)];
                if (x.soLuong > 1)
                {
                    x.soLuong--;
                    upDateOneItem(x);
                }
                else
                {
                    deleteItem(maSP);
                }
            }
            
        }

        // Method Tính trị giá của một sản phẩm
        public long moneyOfOneProduct(CtDonHang x)
        {
            return (long)(x.giaBan * x.soLuong - (x.giaBan * x.soLuong * x.giamGia / 100));
        }

        // Tính tổng thành tiền cho toàn bộ giỏ hàng

        public long totalCartShop()
        {
            long result = 0;
            foreach (CtDonHang i in SanPhamDC.Values)
                result += moneyOfOneProduct(i);
            return result;
        }

        // Cập nhật lại đơn hàng khi xóa hoặc thêm số lượng sản phẩm
        public void upDateOneItem(CtDonHang x)
        {
            this.SanPhamDC.Remove(x.maSP);
            this.SanPhamDC.Add(x.maSP, x);
        }

        
    }
}