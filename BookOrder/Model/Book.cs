using BookOrder.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookOrder.Model
{
    public class Book
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Pay { get; set; }
        public string Transfer { get; set; }
        public string Deliver { get; set; }

        public Book()
        {

        }
        public Book(int ID)
        {
            this.ID = ID;
        }

        #region Insert
        public static string InsertCommand()
        {
            return @"INSERT INTO [Book]
                                   ([Name]
                                   ,[Price]
                                   ,[Amount]
                                   ,[Status]
                                   ,[Date]
                                   ,[Pay]
                                   ,[Transfer]
                                   ,[Deliver])
                             VALUES
                                    (@Name
                                    ,@Price
                                    ,@Amount
                                   ,@Status
                                    ,@Date
                                    ,@Pay
                                    ,@Transfer
                                    ,@Deliver)";
        }

        public int Insert()
        {
            int count = -1;
            using (SqlConnection connection = new SqlConnection(DBhelper.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(InsertCommand(), connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@Name", this.Name);
                        cmd.Parameters.AddWithValue("@Price", this.Price);
                        cmd.Parameters.AddWithValue("@Amount", this.Amount);
                        cmd.Parameters.AddWithValue("@Status", this.Status);
                        cmd.Parameters.AddWithValue("@Date", this.Date);
                        cmd.Parameters.AddWithValue("@Pay", this.Pay);
                        cmd.Parameters.AddWithValue("@Transfer", this.Transfer);
                        cmd.Parameters.AddWithValue("@Deliver", this.Deliver);
                        count = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
            return count;
        }
        #endregion

        #region delete
        private static string DeleteCommand()
        {
            return @"Delete 
                     From [Book]
                     Where ID = @ID
                    ";
        }

        internal int Delete(List<Book> list)
        {
            DBhelper dbHelper = new DBhelper();
            int count = -1;
            for (int i = 0; i < list.Count; i++)
            {
                SqlCommand cmd = new SqlCommand(DeleteCommand());
                cmd.Parameters.AddWithValue("@ID", list[i].ID);
                count = dbHelper.ExecuteNonQuery(cmd);
            }
            return count;
        }
        #endregion

        #region Update
        private static string UpdateCommand()
        {
            return @"UPDATE [Book]
                         SET [Name] = @Name   
                           ,[Price] = @Price   
                           ,[Amount] = @Amount  
                           ,[Status] = @Status 
                           ,[Date] = @Date   
                           ,[Pay] = @Pay     
                           ,[Transfer] = @Transfer 
                           ,[Deliver] = @Deliver
                     Where ID = @ID
                    ";
        }

        public int Update()
        {
            DBhelper dbhelper = new DBhelper();
            SqlCommand cmd = new SqlCommand(UpdateCommand());
            cmd.Parameters.AddWithValue("@ID", this.ID);
            cmd.Parameters.AddWithValue("@Name", this.Name);
            cmd.Parameters.AddWithValue("@Price", this.Price);
            cmd.Parameters.AddWithValue("@Amount", this.Amount);
            cmd.Parameters.AddWithValue("@Status", this.Status);
            cmd.Parameters.AddWithValue("@Date", this.Date);
            cmd.Parameters.AddWithValue("@Pay", this.Pay);
            cmd.Parameters.AddWithValue("@Transfer", this.Transfer);
            cmd.Parameters.AddWithValue("@Deliver", this.Deliver);
            int count = dbhelper.ExecuteNonQuery(cmd);
            return count;
        }
        #endregion

        #region SelectById
        private static string SelectByIdCommand()
        {
            return @"select [ID]
                            ,[Name]
                            ,[Price]
                            ,[Amount]
                            ,[Status]
                            ,[Date]
                            ,[Pay]
                            ,[Transfer]
                            ,[Deliver]
                        from Book AS b
                        where b.ID = @ID";
        }

        public Book SelectById()
        {
            using (SqlConnection connection = new SqlConnection(DBhelper.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SelectByIdCommand()))
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@ID", this.ID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book(reader.GetInt32(0));
                            book.Name = reader.GetString(1);
                            book.Price = reader.GetString(2);
                            book.Amount = reader.GetString(3);
                            book.Status = reader.GetString(4);
                            book.Date =  reader.GetDateTime(5);
                            book.Pay = reader.GetString(6);
                            book.Transfer = reader.GetString(7);
                            book.Deliver = reader.GetString(8);
                            return book;
                        }
                    }
                }
            }
            return null;
        }
        #endregion
    }
}