using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyShop.Models
{
    public partial class ClientService
    {
        public TimeSpan InTime { get => this.StartTime - DateTime.Now; }

        public bool Soon { get
            {
                if(InTime.TotalHours < 1)
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
