using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linqtest.Model
{
    public class borrowing
    {
        public int BorrowingId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ? Returndate { get; set; }
    }
}
