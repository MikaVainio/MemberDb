﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Classes for SQL Data and management
using System.Data;
using System.Data.SqlClient;

namespace DbConsole
{
    class Association
    {
        /* Fields are public to simplify getting and setting
         object properties without setters or getters */

        public uint associationId;
        public string name;

        // Default constructor
        public Association()
        {
            this.associationId = 0;
            this.name = "N/A";
        }

        // Constructor with all arguments
        public Association(uint id, string name)
        {
            this.associationId = id;
            this.name = name;
        }

    
    }

    class Member
    {
        public uint memberId;
        public string firstName;
        public string lastName;
        public DateTime joined;

        // Default constructor
        public Member()
        {
            this.memberId = 0;
            this.firstName = "N/A";
            this.lastName = "N/A";
            this.joined = DateTime.Now;
        }

        // Constructor with all arguments
        public Member(uint id, string first, string last, DateTime joined)
        {
            this.memberId = id;
            this.firstName = first;
            this.lastName = last;
            this.joined = joined;
        }
    }

    class Membership
    {
        public uint membershipId;
        public uint associationNumber;
        public uint memberNumber;

        Membership(uint id, uint aNumber, uint mNumber)
        {
            this.membershipId = id;
            this.associationNumber = aNumber;
            this.memberNumber = mNumber;

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.Write("Yhdistyksen nimi: ");
            name = Console.ReadLine();

            Association association = new Association(0, name);
            

            /*----------------------------------
             SQL SERVER CONNECTION DEFINITIONS
             ----------------------------------*/

            // Connection String
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=localhost\\SQLEXPRESS; Initial Catalog=Members; Integrated Security=true"))
            {
                sqlConnection.Open();

                // SQL Clause for inserting an Association

                string command = "INSERT INTO dbo.Association (name) VALUES (";
                string parameters = "'" + association.name + "');";
                SqlCommand sqlCommand = new SqlCommand(command + parameters, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                // Console.WriteLine(sqlConnection.ServerVersion);
                sqlConnection.Close();

            }
            Console.ReadLine();
        }
    }
}
