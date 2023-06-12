using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyShop.Models
{
    public partial class Client
    {
        public string Name { get => $"{FirstName} {LastName} {Patronymic}"; }
    }
}
