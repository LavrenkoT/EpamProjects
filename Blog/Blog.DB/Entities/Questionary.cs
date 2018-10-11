using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DB.Entities
{
    class Questionary : EntitiesBase<Guid>
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Gender { get; set; }
        public Questionary(Guid id, string name, string gender)
        {
            Id = id;
            Name = name;
            Gender = gender;
        }
        private readonly List<Hobbies> hobbies = new List<Hobbies>();
    }
}
