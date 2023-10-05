using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSF.Data
{
    public class CDataAccess
    {

        List<CPlayer> players = new List<CPlayer>();

        public void InsertPlayers(String firstName, String lastName, String username, String email, String password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CHelper.CnnVal("PlayerDB"))) //connecting to the server
            {
                connection.Open();

                players.Add(new CPlayer { FirstName = firstName, LastName = lastName, Username = username, Email = email, Password = password}); //dapper insert query for new employee entry

                using (var transaction = connection.BeginTransaction()) //beginning the transaction
                {
                    try
                    {
                        connection.Execute("AddPlayer @FirstName, @LastName, @Username, @Email, @Password", players, transaction: transaction); //this query runs for every single record on the list

                        transaction.Commit(); //committing the transaction if successful
                    }
                    catch (Exception E) //catching exceptions and rolling back
                    {
                        Console.WriteLine($"Error: {E.Message}");
                        transaction.Rollback();
                        transaction.Dispose();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public bool LoginAuthentication(String userName, String password) //boolean method - returns true if the user exists
        {
            bool IsReal = false;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CHelper.CnnVal("PlayerDB")))
            {
                try
                {
                    connection.Open();

                    var n = connection.Query<CPlayer>("UserLogin @Username, @Password", new { Username = userName, Password = password });
                    if (n.Count() != 0)
                    {
                        IsReal = true;
                    }
                    else
                        IsReal = false;
                }
                catch (Exception E) //catching exceptions and rolling back
                {
                    Console.WriteLine($"Error: {E.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return IsReal;
        }

        public bool UsernameAuthentication(String userName) //boolean method - returns true if the username already exists
        {
            bool IsReal = false;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CHelper.CnnVal("PlayerDB")))
            {
                try
                {
                    connection.Open();
                    var n = connection.Query<CPlayer>("UNAuthenticity @Username", new { Username = userName });

                    if (n.Count() != 0)
                    {
                        IsReal = true;
                    }
                    else
                        IsReal = false;
                }
                catch (Exception E) //catching exceptions and rolling back
                {
                    Console.WriteLine($"Error: {E.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return IsReal;
        }

        public bool EmailAuthentication(String email) //boolean method - returns true if the username already exists
        {
            bool IsReal = false;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CHelper.CnnVal("PlayerDB")))
            {
                try
                {
                    connection.Open();
                    var n = connection.Query<CPlayer>("EmailAuthenticity @Email", new { Email = email });

                    if (n.Count() != 0)
                    {
                        IsReal = true;
                    }
                    else
                        IsReal = false;
                }
                catch (Exception E) //catching exceptions and rolling back
                {
                    Console.WriteLine($"Error: {E.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return IsReal;
        }

        public List<CPlayer> RetrieveInfo(string username)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CHelper.CnnVal("PlayerDB"))) //connecting to the server
            {
                //string sql = @"select * from Players";

                try
                {
                    players = connection.Query<CPlayer>("ViewInformation @Username", new { Username = username }).ToList();
                }
                catch (Exception E)
                {
                    Console.WriteLine($"Error: {E.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return players;
        }
    }
}
