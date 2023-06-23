using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multi_Shop.Models
{
    public class FavoritedProducts
    {
        public string MaKH { get; set; }
        public string TaiKhoan { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public string DiaChi { get; set; }
        public SortedList<string, CtDonHang> SanPhamYT { get; set; }

        public FavoritedProducts()
        {
            this.MaKH = "";
            this.TaiKhoan = "";
            this.NgayDat = DateTime.Now;
            this.NgayGiao = DateTime.Now.AddDays(2);
            this.DiaChi = "";
            this.SanPhamYT = new SortedList<string, CtDonHang>();
        }

        public bool IsEmpty()
        {
            return (SanPhamYT.Keys.Count == 0);
        }
        // Method dùng để thêm một sản phẩm vào giỏ hàng
        // Chia làm 2 tình huống : 1. Đã có và 2.Chưa có
        public void addItem(string maSP)
        {
            if (SanPhamYT.Keys.Contains(maSP))
            {
                // Lấy sản phẩm từ trong giỏ hàng
                CtDonHang x = SanPhamYT.Values[SanPhamYT.IndexOfKey(maSP)];
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
                SanPhamYT.Add(maSP, y);
            }
        }
        //Method delete Products
        public void deleteItem(string maSP)
        {
            if (SanPhamYT.Keys.Contains(maSP))
                SanPhamYT.Remove(maSP);

        }
        //Method cho phép giảm số lượng hoặc xóa sản phẩm khỏi giỏ hàng
        public void decrease(string maSP)
        {
            if (SanPhamYT.Keys.Contains(maSP))
            {
                CtDonHang x = SanPhamYT.Values[SanPhamYT.IndexOfKey(maSP)];
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

        // Tính trị giá
        public long moneyOfOneProduct(CtDonHang x)
        {
            return (long)(x.giaBan * x.soLuong - (x.giaBan * x.soLuong * x.giamGia / 100));
        }

        // Tính tổng thành tiền cho toàn bộ giỏ hàng

        public long totalCartShop()
        {
            long result = 0;
            foreach (CtDonHang i in SanPhamYT.Values)
                result += moneyOfOneProduct(i);
            return result;
        }

        public void upDateOneItem(CtDonHang x)
        {
            this.SanPhamYT.Remove(x.maSP);
            this.SanPhamYT.Add(x.maSP, x);
        }
    }
}

   
