using System;
using System.Data;
using System.Data.Common;
using Npgsql;


class Sample
{
    static void Main(string[] args)
    {
        // Connect to a PostgreSQL database
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1:5432;User Id=postgres; " +
       "Password=heyDas;Database=prods;");
        conn.Open();

        // Define a query returning a single row result set

        // 7) Display the id, the description, and the number of items for each product that has between 12 and 30 items.Perform this query two different ways.
        NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM product", conn);

        // Execute the query and obtain the value of the first column of the first row
        //Int64 count = (Int64)command.ExecuteScalar();
        NpgsqlDataReader reader = command.ExecuteReader();

        DataTable dt = new DataTable();
        dt.Load(reader);

        Console.WriteLine("prod_id     prod_desc             prod_quantity"); //show the name of the columns
        foreach (DataRow row in dt.Rows)
        {
            if ((Int16)row["prod_quantity"] <= 30 && (Int16)row["prod_quantity"] >= 12)
            {
                Console.WriteLine(row["prod_id"] + "     " + (string)row["prod_desc"] + "             " + row["prod_quantity"]);
            }
        }
        conn.Close();
    }
}