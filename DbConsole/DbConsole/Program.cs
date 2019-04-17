using System;

// Classes for SQL Data and management
using System.Data.SqlClient;

namespace DbConsole
{
    // Class for constructing SQL Clauses
    class Parameter
    {
        public string parameterValue;
        public string parameterType;

        // Constructor with all parameters
        public Parameter(string paramValue, string paramType)
        {
            this.parameterValue = paramValue;
            this.parameterType = paramType;
        }

        // Method to construct SQL values
        public string constructSqlValue()
        {
            if(parameterType == "Text")
            {
                return "'" + this.parameterValue.ToString() + "'";
            }
            else
            {
                return this.parameterValue.ToString();
            }
            
        }
    }

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
        

        // Default constructor
        public Member()
        {
            this.memberId = 0;
            this.firstName = "N/A";
            this.lastName = "N/A";
        }

        // Constructor with all arguments
        public Member(uint id, string first, string last)
        {
            this.memberId = id;
            this.firstName = first;
            this.lastName = last;  
        }
    }

    class Membership
    {
        public uint membershipId;
        public uint associationNumber;
        public uint memberNumber;
        public DateTime joined;

        public Membership(uint id, uint aNumber, uint mNumber)
        {
            this.membershipId = id;
            this.associationNumber = aNumber;
            this.memberNumber = mNumber;
            this.joined = DateTime.Now;

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            ///* Create an new association */
            //string name;
            //Console.Write("Yhdistyksen nimi: ");
            //name = Console.ReadLine();

            //Association association = new Association(0, name);

            ///* Create a new member */
            //string givenname;
            //string surname;
            //Console.Write("Etunimi: ");
            //givenname = Console.ReadLine();
            //Console.Write("Sukunimi: ");
            //surname = Console.ReadLine();
            //Member member = new Member(0, givenname, surname);

            ///* Create a new membership */
            //string associdStr;
            //string memberidStr;
            //uint associd;
            //uint memberid;
            //Console.WriteLine("Lisätään jäsen yhdistykseen");
            //Console.Write("Yhdistysnumero on ");
            //associdStr = Console.ReadLine();
            //Console.Write("Jäsennumero on ");
            //memberidStr = Console.ReadLine();
            //associd = Convert.ToUInt32(associdStr);
            //memberid = Convert.ToUInt32(memberidStr);

            //Membership membership = new Membership(0, associd, memberid);

            //Console.WriteLine(membership.joined.ToString("yyyy-MM-dd"));

            /*----------------------------------
             SQL SERVER CONNECTION DEFINITIONS
             ----------------------------------*/

            // Connection String
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=localhost\\SQLEXPRESS; Initial Catalog=Members; Integrated Security=true"))
            {
                sqlConnection.Open();

                //// SQL Clause for inserting an Association

                //string command = "INSERT INTO dbo.Association (name) VALUES (";
                //string parameters = "'" + association.name + "');";
                //SqlCommand sqlCommand = new SqlCommand(command + parameters, sqlConnection);
                //sqlCommand.ExecuteNonQuery();

                ///* SQL Clause for inserting a Member */
                //string command2 = "INSERT INTO dbo.member (first_name, last_name) VALUES (";
                //string parameters2 = "'" + member.firstName + "', '" + member.lastName + "');";
                ////Console.WriteLine(command2 + parameters2);
                //SqlCommand sqlCommand2 = new SqlCommand(command2 + parameters2, sqlConnection);
                //sqlCommand2.ExecuteNonQuery();

                ///* SQL Clause for defining a Membership 
                // Ids should be in the database. Use existing ids only */

                //string command3 = "INSERT INTO dbo.membership (memberid, association_id, joined) VALUES (" + membership.memberNumber.ToString() + ", " + membership.associationNumber.ToString() + ", '" + membership.joined.ToString("yyyy-MM-dd") + "');";
                //// string parameters3 = " membership.memberNumber + ", " + membership.associationNumber + ", " + membership.joined + "');";
                //SqlCommand sqlCommand3 = new SqlCommand(command3, sqlConnection);
                //sqlCommand3.ExecuteNonQuery();

                // Read data from member table

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = "SELECT first_name, last_name FROM dbo.member;";
                sqlCommand.CommandTimeout = 3;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                // Write rows to console
                while (sqlDataReader.Read())
                {
                    Console.WriteLine("{0}\t{1}", sqlDataReader.GetString(0), sqlDataReader.GetString(1));
                }

                sqlDataReader.Close();

                // Console.WriteLine(sqlConnection.ServerVersion);
                sqlConnection.Close();

            }
            Console.ReadLine();
        }
    }
}
