using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorrowMyAngel.View
{

    public class NavMenuMenuItem
    {
        public NavMenuMenuItem()
        {
            TargetType = typeof(NavMenuDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}