﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class CreditCart:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CartNumber { get; set; }
        public string CartName { get; set; }
    }
}
