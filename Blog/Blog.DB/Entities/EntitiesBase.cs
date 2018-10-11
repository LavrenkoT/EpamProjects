using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.DB.Entities
{
    abstract class EntitiesBase<T>
    {
        public T Id { get; set; }
    }
}
