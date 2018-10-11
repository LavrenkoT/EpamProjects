using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DB.Entities
{
    class Article : EntitiesBase<Guid>
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Text { get; set; }
        DateTime CreationDate { get; set; }
        string Author { get; set; }
        public Article(Guid id, string name, string text, string author)
        {
            Id = id;
            Name = name;
            Text = text;
            CreationDate = DateTime.Now;
            Author = author;
        }
    }
}
