using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Multi_Shop.Models
{

    public class DataOfProducts
    {
        static DbContext cn = new DbContext("name=MultiShopOnlineEntities");

        // Method dùng để lấy tên của một sản phẩm dựa trên maSanPham
        public static string getNameOfProductsByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).tenSP;
        }


        // Lấy ảnh của một sản phẩm dựa trên mã sản phẩm
        public static string getImageOfProductsByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).hinhDD;
        }
    }
}