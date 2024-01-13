﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Data.Models
{
    public interface IModel<T>
    {
        public Guid Id { get; set; }

        public T ToValue();
    }
}
