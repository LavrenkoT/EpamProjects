using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DB.Entities
{
    class Feedback:EntitiesBase<Guid>
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Text { get; set; }
        DateTime CreationDate { get; set; }
        public Feedback(Guid id,string name, string text)
        {
            Id = id;
            Name = name;
            Text = text;
            CreationDate = DateTime.Now;
        }
    }
}
