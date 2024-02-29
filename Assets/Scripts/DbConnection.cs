
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Data.SqlClient;
using System;


//Data Source = DESKTOP - 9DIBJRQ;User ID = LeaderBoard; Password=********;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
public class DbConnection : MonoBehaviour
{
    private string connectionstring;
    private string sqlString;
    private string test = "Ryan";
    private int test1 = 25;
    // Start is called before the first frame update
    void Start()
    { 
        Debug.Log("Connecting to database...");
        //connectionstring = @"Data Source = DESKTOP-9DIBJRQ;User ID = LeaderBoard; Password=LeaderBoard;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //connectionstring = @"Data Source = DESKTOP-9DIBJRQ; User ID = LeaderBoard; Password = LeaderBoard; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        connectionstring = @"Data Source = DESKTOP-9DIBJRQ; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        /*@"Data Source = 127.0.0.1; 
    user id = LeaderBoard;
    password = sLeaderBoard;
    Initial Catalog = login;";
        SqlConnection dbConnection = new SqlConnection(connectionstring);


            try
            {

                dbConnection.Open();
            SqlCommand command = new SqlCommand("Select * from [LEADERBOARD]", dbConnection);
            // int result = command.ExecuteNonQuery();
            /*
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine();
                }
            }
            
            Debug.Log("Connected to database.");
            sqlString = "INSERT INTO [dbo.LEADERBOARD] (PLAYER_NAME) VALUES (@name)";
            SqlCommand cmd = new SqlCommand(sqlString, dbConnection);
            cmd.Parameters.Add("@name", SqlDbType.VarChar);
            cmd.Parameters["@name"].Value = test;
            Debug.Log("Reached");
            cmd.ExecuteNonQuery();
            Debug.Log("Reached");
            SqlDataAdapter cmd1 = new SqlDataAdapter("Select * from LEADERBOARD", dbConnection);
            Debug.Log("Hi");
        }
            catch (SqlException _exception)
            {
            string msg = "Insert Error:";
            Debug.Log(msg += _exception.Message);
            }


            //  conn.Close();
        }

        // Update is called once per frame
        void Update()
        {
      
        }
    }



*/