//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Multi_Shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CommentArticle
    {
        public string tenKH { get; set; }
        public string maBV { get; set; }
        public string noidung { get; set; }
    
        public virtual BaiViet BaiViet { get; set; }
    }
}
