using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete // ciplak class kalmasin o yuzden classlari 
{
    public class Category : IEntity // buna isaretleme denir
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
