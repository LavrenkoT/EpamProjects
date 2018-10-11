using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Blog.DB.Context
{
    class BlogContext:DbContext
    {
        public BlogContext() : base("BlogContext") { }

        static BlogContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BlogContext>());
        }

    }
}
