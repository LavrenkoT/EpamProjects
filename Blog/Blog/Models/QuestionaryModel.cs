using System.Collections.Generic;

namespace Blog.Models
{
    public class QuestionaryModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public IEnumerable<string> Sports { get; set; }

        public QuestionaryModel()
        {
            Sports = new List<string>();
        }
    }
}