using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

using NewsAgencyApp.Helper;

namespace NewsAgencyApp.Models
{
    class Article : Model
    {
        private int id;
        private string title;
        private string content;
        private User user;
        private Category category;
        private int numberOfViews;
        private string createdAt;
        private string updatedAt;
        private string keywords;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        internal User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        internal Category Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public int NumberOfViews
        {
            get
            {
                return numberOfViews;
            }

            set
            {
                numberOfViews = value;
            }
        }

        public string CreatedAt
        {
            get
            {
                return createdAt;
            }

            set
            {
                createdAt = value;
            }
        }

        public string UpdatedAt
        {
            get
            {
                return updatedAt;
            }

            set
            {
                updatedAt = value;
            }
        }

        public string Keywords
        {
            get
            {
                return keywords;
            }

            set
            {
                keywords = value;
            }
        }

        public Article()
        {
        }

        public Article(string title, string content, User user, Category category, string keywords)
        {
            this.title = title;
            this.content = content;
            this.user = user;
            this.category = category;
            this.keywords = keywords;
        }

        private static string buildWhereCluase(IDictionary<string, FilterItem> filters)
        {
            string whereCluase = "";

            if (filters != null && filters.Count > 0)
            {
                foreach (var filter in filters)
                {
                    whereCluase += (whereCluase.Length == 0) ? "WHERE " : " AND ";
                    whereCluase += filter.Value.Cluase(filter.Key);
                }

            }

            return whereCluase;
        }

        private static void addCommandParameters(IDictionary<string, FilterItem> filters, SqlCommand query)
        {
            if (filters != null && filters.Count > 0)
            {
                foreach (var filter in filters)
                    query.Parameters.AddWithValue(string.Format("@{0}", filter.Key), filter.Value.Value);
            }
        }

        public static List<Article> FindAll(IDictionary<string, FilterItem> filters = null)
        {
            string whereCluase = buildWhereCluase(filters);

            Console.WriteLine(whereCluase);

            SqlCommand query = new SqlCommand
            {
                CommandText = string.Format(@"SELECT a.Id, a.Title, a.Content, a.NumberOfViews, a.CreatedAt, a.UpdatedAt, a.Keywords,
                                    c.Id as CategoryId, c.Name as CategoryName,
                                    u.Id as UserId, u.FullName as UserFullName, u.Username as UserUserName

                                    FROM [Article] AS a

                                    INNER JOIN [Category] as c
	                                    ON a.CategoryId = c.Id

                                    INNER JOIN [User] as u
	                                    ON a.UserId = u.Id
                                    
                                    {0}

                                    ORDER BY createdAt DESC;", whereCluase),
                Connection = DBMgr.DatabaseFactory().Connection(),
                CommandType = CommandType.Text,
            };

            addCommandParameters(filters, query);

            SqlDataReader sdr = query.ExecuteReader();

            List<Article> articles = parseArticles(sdr);

            sdr.Close(); // Close SqlDataReader

            return articles;
        }

        public override bool Create()
        {
            SqlCommand query = new SqlCommand
            {
                CommandText = "INSERT INTO [Article] (Title, Content, UserId, CategoryId, Keywords) VALUES (@title, @content, @userId, @categoryId, @keywords);",
                Connection = DBMgr.DatabaseFactory().Connection(),
                CommandType = CommandType.Text,
            };

            query.Parameters.AddWithValue("@title", title);
            query.Parameters.AddWithValue("@content", content);
            query.Parameters.AddWithValue("@userId", user.Id);
            query.Parameters.AddWithValue("@categoryId", category.Id);
            query.Parameters.AddWithValue("@keywords", keywords);


            int affectedRows = query.ExecuteNonQuery();

            return affectedRows > 0;
        }

        public override bool Update()
        {
            SqlCommand query = new SqlCommand
            {
                CommandText = @"UPDATE [Article] SET
                                Title = @title, Content = @content, CategoryId = @categoryId, Keywords = @keywords, UpdatedAt = CURRENT_TIMESTAMP
                                WHERE Id = @id;",
                Connection = DBMgr.DatabaseFactory().Connection(),
                CommandType = CommandType.Text,
            };

            query.Parameters.AddWithValue("@id", id);
            query.Parameters.AddWithValue("@title", title);
            query.Parameters.AddWithValue("@content", content);
            query.Parameters.AddWithValue("@categoryId", category.Id);
            query.Parameters.AddWithValue("@keywords", keywords);


            int affectedRows = query.ExecuteNonQuery();

            return affectedRows > 0;
        }

        public override bool Remove()
        {
            SqlCommand query = new SqlCommand
            {
                CommandText = @"DELETE FROM [Article] WHERE Id = @id;",
                Connection = DBMgr.DatabaseFactory().Connection(),
                CommandType = CommandType.Text,
            };

            query.Parameters.AddWithValue("@id", id);


            int affectedRows = query.ExecuteNonQuery();

            return affectedRows > 0;
        }

        public void Viewed()
        {
            SqlCommand query = new SqlCommand
            {
                CommandText = "IncreaseArticleViewCount",
                Connection = DBMgr.DatabaseFactory().Connection(),
                CommandType = CommandType.StoredProcedure,
            };

            query.Parameters.Add(new SqlParameter("@articleId", id));

            query.ExecuteNonQuery();

            this.numberOfViews++;

            return;
        }

        /**
         * Generate keywords for this article
        */
        public void GenerateKeywords()
        {
            this.keywords = string.Format("{0} {1} {2} {3}", title.ToLower(), category.Name.ToLower(), user.FullName.ToLower(), content.ToLower());
        }

        private static List<Article> parseArticles(SqlDataReader sdr)
        {
            List<Article> articles = new List<Article>();

            while (sdr.Read())
            {
                User user = new User
                {
                    Id = Int32.Parse(sdr["UserId"].ToString()),
                    Username = sdr["UserUserName"].ToString(),
                    FullName = sdr["UserFullName"].ToString(),
                    Email = null,
                };
                Category category = new Category
                {
                    Id = Int32.Parse(sdr["CategoryId"].ToString()),
                    Name = sdr["CategoryName"].ToString(),
                };
                Article article = new Article
                {
                    id = Int32.Parse(sdr["Id"].ToString()),
                    title = sdr["Title"].ToString(),
                    content = sdr["Content"].ToString(),
                    user = user,
                    category = category,
                    numberOfViews = Int32.Parse(sdr["NumberOfViews"].ToString()),
                    createdAt = sdr["CreatedAt"].ToString(),
                    updatedAt = sdr["UpdatedAt"].ToString(),
                    keywords = sdr["Keywords"].ToString()
                };

                articles.Add(article);
            }

            return articles;
        }
    }
}
