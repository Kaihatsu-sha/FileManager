﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Services
{
    public interface INavigationHistoryService
    {
        public bool CanOpenPrevious { get; }
        public void OpenPrevious();
    }
}