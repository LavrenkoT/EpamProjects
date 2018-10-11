using Blog.DB.Context;
using Blog.DB.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Blog.DB
{
    class BlogContextInitializer : CreateDatabaseIfNotExists<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var articles = new List<Article>
            {
                new Article(
                    Guid.NewGuid(),
                    "Hello World",
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    "Test author"
                )
            };
            var feedbacks = new List<Feedback>
            {
                new Feedback(
                    Guid.NewGuid(),
                    "Alex," +
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    )
            };
            var questionaries = new List<Questionary>
            {
                new Questionary(
                    Guid.NewGuid(),
                    "Alex",
                    "Male"
                    )
            };
        }
    }
}