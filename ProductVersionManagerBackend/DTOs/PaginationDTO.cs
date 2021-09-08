﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        private int recordPerPage = 4;
        private readonly int MaxRecordPerPage = 50;
        public int RecordPerPage
        {
            get => recordPerPage;
            set
            {
                recordPerPage = (value > MaxRecordPerPage) ? MaxRecordPerPage : value;
            }
        }
    }
}
