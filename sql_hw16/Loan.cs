﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_hw16
{
    public class Loan
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }

        public Reader Reader { get; set; }
        public Book Book { get; set; }
    }
}
