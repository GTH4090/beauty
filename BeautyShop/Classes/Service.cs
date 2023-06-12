using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeautyShop.Models

{
    public partial class Service
    {
        public byte[]? Img { get
            {
                try
                {
                    var item = File.ReadAllBytes(this.MainImagePath);
                    return item;
                }
                catch (Exception)
                {
                    return null;
                    
                }
                
                
            } }
        public bool IsDiscount { get
            {
                if(Discount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            } }
    }
}
