using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MultiUserBloggingPlatform.Models;

namespace MultiUserBloggingPlatform

{
    public class DataLayer
    {
        private readonly IConfiguration _configuration;
        public DataLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// User Methods
        public void CreateUser(string username, string password, string email)
        {
            
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("CreateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PassWd", password);
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(int userId, string username, string password, string email)
        {

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("UpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UID", userId);
                    command.Parameters.AddWithValue("@Uname", username);
                    command.Parameters.AddWithValue("@UPassWd", password);
                    command.Parameters.AddWithValue("@UEmail", email);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(int UserID)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("DeleteUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", UserID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public User GetUser(int UserID)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("GetUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UID", UserID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString(),
                                Email = reader["Email"].ToString(),
                                PassWd = reader["PassWd"].ToString()
                            };
                        }
                    }
                }
            }
            return user;
        }

        /// Post Methods
        public void CreatePost(string postText, int CatID, int userID)
        {

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("CreatePost", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PText", postText);
                    command.Parameters.AddWithValue("@CatID", CatID);
                    command.Parameters.AddWithValue("@UID", userID);

                    connection.Open(); 
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePost(int postID, string postText, int catID, int userID)
        {

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("UpdatePost", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PID", postID);
                    command.Parameters.AddWithValue("@PText", postText);
                    command.Parameters.AddWithValue("@CatID", catID);
                    command.Parameters.AddWithValue("@UID", userID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePost(int postID)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("DeletePost", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PID", postID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Post GetPost(int postID)
        {
            Post post = null;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("GetPost", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PID", postID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            post = new Post
                            {
                                PostID = Convert.ToInt32(reader["PostID"]),
                                PostText = reader["PostText"].ToString(),
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),

                            };
                        }

                    }
                }
            }
            return post;
        }

        /// Comment Methods
        public void CreateComment(string commentText, int userID, int postID)
        {

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("CreateComment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CText", commentText);
                    command.Parameters.AddWithValue("@UID", userID);
                    command.Parameters.AddWithValue("@PID", postID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateComment(int commentID, string commentText, int userID, int postID)
        {

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("UpdateComment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CID", commentID);
                    command.Parameters.AddWithValue("@CText", commentText);
                    command.Parameters.AddWithValue("@UID", userID);
                    command.Parameters.AddWithValue("@PID", postID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteComment(int commentID)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("DeleteComment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CId", commentID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Comment GetComment(int commentID)
        {
            Comment comment = null;
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("GetComment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CID", commentID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            comment = new Comment
                            {
                                CommentID = Convert.ToInt32(reader["CommentID"]),
                                CommentText = reader["CommentText"].ToString(),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                PostID = Convert.ToInt32(reader["PostID"]),
                            };
                        }
                    }
                }
            }
            return comment;
        }

        ///Category Methods
        public void CreateCategory(string categoryText)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("CreateCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CatText", categoryText);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCategory(int CategoryID, string CategoryText)
        {

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("UpdateCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CatID", CategoryID);
                    command.Parameters.AddWithValue("@CatText", CategoryText);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Category GetCategory(int CategoryID)
        {
            Category category = null;
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("GetCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CatID", CategoryID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category = new Category
                            {
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                CategoryName = reader["Category"].ToString()
                            };
                        }

                    }
                }
            }
            return category;
        }

        public void DeleteCategory(int CategoryID)
        {

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("DeleteCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CatId", CategoryID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //complex query methods

        public List<Comment> GetPostWithComments(int PostID) 
        {
            List<Comment> postWithComments = new List<Comment>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("GetPostsWithComments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PID", PostID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Post post = new Post
                            {
                                PostID = Convert.ToInt32(reader["PostID"]),
                                PostText = reader["PostText"].ToString(),
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                UserID = Convert.ToInt32(reader["UserID"])
                            };
                            while (reader.Read())
                            {
                                Comment comment = new Comment
                                {
                                    CommentID = Convert.ToInt32(reader["CommentID"]),
                                    CommentText = reader["CommentText"].ToString(),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    PostID = Convert.ToInt32(reader["PostID"])
                                };

                                // Add the comment to the Comments collection in PostWithComments
                                postWithComments.Add(comment);
                            }
                        }
                    }
                }
            }
            return postWithComments;
        }

        public List<Post> GetPostsByCategory(int CategoryID)
        {
            List<Post> postFromCategory = new List<Post>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("GetPostsByCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CID", CategoryID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Category category = new Category
                            {
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                CategoryName = reader["Category"].ToString()
                            };
                            while (reader.Read())
                            {
                                Post post = new Post
                                {
                                    PostID = Convert.ToInt32(reader["PostID"]),
                                    PostText = reader["PostText"].ToString(),
                                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                    UserID = Convert.ToInt32(reader["UserID"])
                                };

                                postFromCategory.Add(post);
                            }
                        }
                    }
                }
            }
            return postFromCategory;
        }

        public List<Post> GetPostsByUser(int Userid)
        {
            List<Post> postFromUser = new List<Post>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
            {
                using (SqlCommand command = new SqlCommand("GetPostsByUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UID", Userid);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString(),
                                Email = reader["Email"].ToString(),
                                PassWd = reader["PassWd"].ToString()
                            };
                            while (reader.Read())
                            {
                                Post post = new Post
                                {
                                    PostID = Convert.ToInt32(reader["PostID"]),
                                    PostText = reader["PostText"].ToString(),
                                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                    UserID = Convert.ToInt32(reader["UserID"])
                                };

                                postFromUser.Add(post);
                            }
                        }
                    }
                }
            }
            return postFromUser;
        }

    }
}
