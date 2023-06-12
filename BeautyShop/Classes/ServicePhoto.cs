using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyShop.Models
{
    public partial class ServicePhoto
    {
        public byte[]? Img { get
            {
                
                if(this.PhotoPath != "")
                {
                    return File.ReadAllBytes(this.PhotoPath);
                }
                else
                {
                    return null;
                }
            } }
    }
}
