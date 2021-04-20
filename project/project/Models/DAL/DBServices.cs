using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using Content_Upload_Model.Models;
using Kaatsu.Models;
using FinalProj.Models;

namespace Content_Upload_Model.Models.DAL
{
    public class DBServices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        public DBServices()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        //---------------------------------------------------------------------------------

        // Create the SqlCommand
        //---------------------------------------------------------------------------------
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }


        public List<customer> getcustomer()
        {
            SqlConnection con = null;
            List<customer> customerList = new List<customer>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from [User]";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    if (dr["firstName"] != DBNull.Value)
                    {
                        customer c = new customer();
                        c.Id = Convert.ToInt32(dr["userId"]);
                        c.Email = (string)dr["mail"];
                        c.Password = (string)dr["password"];
                        c.FirstName = (string)dr["firstName"];
                        c.SurName = (string)dr["lastName"];
                        c.ActiveLastYear = (bool)dr["activeLastYear"];
                        customerList.Add(c);
                    }
                    else
                    {
                        customer c = new customer();
                        c.Id = Convert.ToInt32(dr["userId"]);
                        c.Email = (string)dr["mail"];
                        c.Password = (string)dr["password"];
                        customerList.Add(c);
                    }

                }
                return customerList;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }


        public List<Tag> gettags()
        {
            SqlConnection con = null;
            List<Tag> tagList = new List<Tag>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Tags";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Tag t = new Tag();
                    t.Tagcode = Convert.ToInt32(dr["tagcode"]);
                    t.Tagname = (string)dr["tagname"];

                    tagList.Add(t);

                }

                return tagList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }



        //data reader all highlights
        public List<category> getcategories()
        {
            SqlConnection con = null;
            List<category> categoryList = new List<category>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Category";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    category c = new category();
                    c.CategoryCode = Convert.ToInt32(dr["categoryCode"]);
                    c.CategoryName = (string)dr["categoryName"];
                    c.Description = (string)dr["description"];
                    c.PhotoPath = (string)dr["PhotoPath"];

                    categoryList.Add(c);
  
                }

                return categoryList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        public List<category> GetAllCategories()
        {
            SqlConnection con = null;
            List<category> categoryList = new List<category>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Category";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    category c = new category();
                    c.CategoryCode = Convert.ToInt32(dr["categoryCode"]);
                    c.CategoryName = (string)dr["categoryName"];
                    c.Description = (string)dr["description"];
                    c.PhotoPath = (string)dr["PhotoPath"];

                    categoryList.Add(c);

                }

                return categoryList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        //data reader category name
        public int getCategoryCode(Content content)
        {
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Category";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                int categoryCode = 0;

                while (dr.Read())
                {   // Read till the end of the data into a row
                    categoryCode = Convert.ToInt32(dr["categoryCode"]);

                }

                return categoryCode;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }


        //post content
        public string InsertContent(Content content)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("failed to connect to the server", ex);
            }

      
            String cStr = BuildInsertContentCommand(content);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                var exeCmd = cmd.ExecuteScalar(); // execute the command
                int videoCode = Convert.ToInt32(exeCmd);

                if (exeCmd != null)
                {
                    foreach (var item in content.TagsArray)
                    {
                        InsertTagsOfVideo(videoCode, item.Tagcode, con);
                    }
                }
                   else
                    throw new Exception("no content was inserted");

                return content.Caption;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);

            }



            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        //post category
        public void InsertTagsOfVideo(int videoCode, int tagCode, SqlConnection con)
        {
            SqlCommand cmd;

            String cStr = BuildInsertTagsOfVideoCommand(videoCode, tagCode);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected == 0)
                    throw new Exception("no combination was inserted");
              
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

        }


        private String BuildInsertTagsOfVideoCommand(int videoCode, int tagCode)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat(" Values({0}, {1})", tagCode, videoCode);
            String prefix = "insert into Tags_of_Video " + "(tagcode, VideoCode) ";
            command = prefix + sb.ToString();

            return command;
        }




        //post category
        public string InsertCategory(category category)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("failed to connect to the server", ex);
            }

            String cStr = BuildInsertCategoryCommand(category);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected == 0)
                    throw new Exception("no category was inserted");
                    return category.CategoryName;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        private String BuildInsertContentCommand(Content content)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat(" Values('{0}', '{1}', '{2}', {3})", content.Description, content.Caption, content.Subtitlepath, content.CategoryCode);
            String prefix = "insert into Video " + "([description],caption, subtitlepath, categoryCode) output inserted.VideoCode ";
            command = prefix + sb.ToString();

            return command;
        }

        //post  User
        public string InsertProfile(Profile profile)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("failed to connect to the server", ex);
            }

            String cStr = BuildInsertProfileCommand(profile);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected == 0)
                    throw new Exception("no user was inserted");
                return profile.Mail;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        private String BuildInsertProfileCommand(Profile profile)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}')", profile.Mail, profile.Password);
            String prefix = "insert into [User]" + "(mail, [password])";
            command = prefix + sb.ToString();

            return command;
        }

        //post  RankUser
        public string InsertRank(Rank rank)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("failed to connect to the server", ex);
            }

            String cStr = BuildInsertRankCommand(rank);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected == 0)
                    throw new Exception("no user was inserted");
                return rank.RankValue;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        private String BuildInsertRankCommand(Rank rank)
        {
            String command; 

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values({0}, {1}, '{2}', '{3}', '{4}')", rank.UseruserId, rank.VideoCode, rank.RankDate, rank.RankValue, rank.RankLike);
            String prefix = "insert into [Rank]" + "(CustomerUseruserId, VideoVideoCode, rankDate, RankValue, RankLike)";
            command = prefix + sb.ToString();

            return command;
        }

        private String BuildInsertCategoryCommand(category category)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}')", category.CategoryName, category.Description, category.PhotoPath);
            String prefix = "insert into Category" + "(categoryName, [description], PhotoPath)";
            command = prefix + sb.ToString();

            return command;
        }



        public List<Content> getContents()
        {
            SqlConnection con = null;
            List<Content> contentsList = new List<Content>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            }
            catch (Exception ex)
            {
                throw new Exception("failed to connect to the server", ex);
            }

            String selectSTR = "Select * from Video ";

            SqlCommand cmd = new SqlCommand(selectSTR, con);
            List<Tag> tagsList = new List<Tag>();
            try
            {
                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                //highLightList = getHighLightById(Convert.ToInt32(dr["id"]));
                while (dr.Read())
                {   // Read till the end of the data into a row
                    int VideoCode = Convert.ToInt32(dr["VideoCode"]);
                    tagsList = getTagsByVideoId(VideoCode);
                    Content c = new Content();
                    c.VideoCode = Convert.ToInt32(dr["VideoCode"]);
                    c.Description = (string)dr["description"];
                    c.Caption = (string)dr["caption"];
                    c.Subtitlepath = (string)dr["subtitlepath"];
                    c.CategoryCode = Convert.ToInt32(dr["categoryCode"]);
                    c.TagsArray = tagsList;
                    //List<string>
                    //string listStrLineElements = (string)dr["highlights"];
                    //c.ListHighlights = listStrLineElements.Split(',').ToList();
                    contentsList.Add(c);
                }
                return contentsList;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        //get highlight by id customer
        public List<Tag> getTagsByVideoId(int videoId)
        {
            SqlConnection con = null;
       

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            }
            catch (Exception ex)
            {
                throw new Exception("failed to connect to the server", ex);
            }

            String selectSTR = "select b.* from Tags_of_Video a inner join Tags b on a.tagcode = b.tagcode where VideoCode = " + videoId;


            SqlCommand cmd = new SqlCommand(selectSTR, con);

            try
            {
                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                List<Tag> tagsList = new List<Tag>();
                while (dr.Read())
                {   // Read till the end of the data into a row

                    Tag g = new Tag();
                    g.Tagcode = Convert.ToInt32(dr["tagcode"]);
                    g.Tagname = (string)dr["tagname"];
                    tagsList.Add(g);
               
                }
                return tagsList;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        //------------------------------
        //החלק של ליטל

        public customer checkUser(customer customer)
        {
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("checkUserLog", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@password", customer.Password);
                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        var result = returnParameter.Value;
                        if (result.Equals(1))
                        {
                            while (dr.Read())
                            {
                                if (dr["firstName"] != DBNull.Value)
                                {
                                    customer.Id = Convert.ToInt32(dr["userId"]);
                                    customer.FirstName = (string)dr["firstName"];
                                    customer.SurName = (string)dr["lastName"];
                                    customer.Gender = (string)dr["gender"];
                                    //customer.Birthdate = (string)dr["dateOfBirth"];
                                    //customer.Birthdate = Convert.ToDateTime(dr["dateOfBirth"]);
                                    customer.Email = (string)dr["mail"];
                                    customer.Password = (string)dr["password"];
                                    customer.CategoryType = Convert.ToInt32(dr["CategorycategoryCode"]);
                                    customer.Weight = Convert.ToDouble(dr["weight"]);
                                    customer.Height = Convert.ToInt32(dr["height"]);

                                    //customer.TrainingProggram.Tcode = Convert.ToInt32(dr["TrainingProgramTcode"]);
                                }
                                else
                                {
                                    customer.Id = Convert.ToInt32(dr["userId"]);
                                    customer.Email = (string)dr["mail"];
                                    customer.Password = (string)dr["password"];
                                }
                            }
                        }
                        if (result.Equals(2))
                        {
                            while (dr.Read())
                            {
                                customer.Email = (string)dr["mail"];
                                customer.Password = (string)dr["password"];
                            }
                        }

                        if (result.Equals(3))
                        {

                            customer.Email = "null";
                            customer.Password = "null";
                            customer.FirstName = "not exist";
                        }


                    }

                    return customer;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public customer addNewCustomer(customer newCustomer)
        {
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("addCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", newCustomer.Email);
                    cmd.Parameters.AddWithValue("@firstName", newCustomer.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", newCustomer.SurName);
                    cmd.Parameters.AddWithValue("@gender", newCustomer.Gender);
                    cmd.Parameters.AddWithValue("@password", newCustomer.Password);
                    cmd.Parameters.AddWithValue("@birthdate", newCustomer.Birthdate);
                    cmd.Parameters.AddWithValue("@weight", newCustomer.Weight);
                    cmd.Parameters.AddWithValue("@height", newCustomer.Height);
                    cmd.Parameters.AddWithValue("@activeLastYear", newCustomer.ActiveLastYear);
                    cmd.Parameters.AddWithValue("@trainKaatsu", newCustomer.TrainKaatsu);
                    cmd.Parameters.AddWithValue("@sportInj", newCustomer.SportInj);
                    cmd.Parameters.AddWithValue("@accident", newCustomer.Accident);
                    cmd.Parameters.AddWithValue("@metadises", newCustomer.Metadises);
                    cmd.Parameters.AddWithValue("@sportType", newCustomer.SportType);

                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;

                    if (result.Equals(1))
                    {
                        using (SqlCommand cmd1 = new SqlCommand("categoryTypeCustomer", con))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@email", newCustomer.Email);
                            cmd1.Parameters.AddWithValue("@categoryType", newCustomer.CategoryType);
                            cmd1.ExecuteNonQuery();
                        }
                    }


                }

                return newCustomer;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public void updateCustomerDet(customer updateCustomerDet)
        {

            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("updateCust", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", updateCustomerDet.Email);
                    cmd.Parameters.AddWithValue("@firstName", updateCustomerDet.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", updateCustomerDet.SurName);
                    cmd.Parameters.AddWithValue("@gender", updateCustomerDet.Gender);
                    cmd.Parameters.AddWithValue("@password", updateCustomerDet.Password);
                    cmd.Parameters.AddWithValue("@birthdate", updateCustomerDet.Birthdate);
                    cmd.Parameters.AddWithValue("@weight", updateCustomerDet.Weight);
                    cmd.Parameters.AddWithValue("@height", updateCustomerDet.Height);
                    cmd.Parameters.AddWithValue("@activeLastYear", updateCustomerDet.ActiveLastYear);
                    cmd.Parameters.AddWithValue("@trainKaatsu", updateCustomerDet.TrainKaatsu);
                    cmd.Parameters.AddWithValue("@sportInj", updateCustomerDet.SportInj);
                    cmd.Parameters.AddWithValue("@accident", updateCustomerDet.Accident);
                    cmd.Parameters.AddWithValue("@metadises", updateCustomerDet.Metadises);
                    cmd.Parameters.AddWithValue("@sportType", updateCustomerDet.SportType);

                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;

                    if (result.Equals(1))
                    {
                        using (SqlCommand cmd1 = new SqlCommand("categoryTypeCustomer", con))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@email", updateCustomerDet.Email);
                            cmd1.Parameters.AddWithValue("@categoryType", updateCustomerDet.CategoryType);
                            cmd1.ExecuteNonQuery();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public List<recommendedTrainingProgram> getRTP(int id)
        {
            SqlConnection con = null;
            List<recommendedTrainingProgram> recommendedTrainingProgramList = new List<recommendedTrainingProgram>();

            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("matchTraningProgramForUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            recommendedTrainingProgram rt = new recommendedTrainingProgram();

                            rt.Tcode = Convert.ToInt32(dr["Tcode"]);
                            rt.Tname = (string)dr["Tname"];
                            rt.Instuction = (string)dr["instructions"];
                            rt.LevelType = (string)dr["levelType"];
                            rt.IsForStrengthening = (bool)dr["isForStrengthening"];
                            rt.IsForRehabilitation = (bool)dr["isForRehabilitation"];
                            rt.IsForImproveSport = (bool)dr["isForImproveSport"];
                            rt.Pic = (string)dr["pic"];

                            recommendedTrainingProgramList.Add(rt);
                        }

                        //customerRTP.RecommendedTrainingPrograms = recommendedTrainingProgramList;

                    }
                }

                return recommendedTrainingProgramList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public List<video> postTPC(recommendedTrainingProgram tPC, int id)
        {
            SqlConnection con = null;
            List<video> videoList = new List<video>();

            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("PostTP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", tPC.CustomerId);
                    cmd.Parameters.AddWithValue("@TPC", tPC.Tcode);
                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    //var result = returnParameter.Value;


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {


                        while (dr.Read())
                        {
                            video v = new video();
                            v.VideoId = Convert.ToInt32(dr["VideoCode"]);
                            v.Description = (string)dr["description"];
                            v.Caption = (string)dr["caption"];
                            v.Subtitlepath = (string)dr["subtitlepath"];
                            videoList.Add(v);
                        }
                    }

                }

                return videoList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

    }

}
