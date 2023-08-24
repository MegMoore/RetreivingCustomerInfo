using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data.Common;

namespace CustomerController
{

    public class CustController
    {
        public SqlConnection sqlConnection { get; set; }

        public CustController(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;


        }

        public void InsertCustomer(Customer customer) // inserting data
        {
            var sql = " INSERT Customers " +
                " (Name, City, State, Sales, Active) VALUES " +
                " (@Name, @City, @State, @Sales, @Active) ";
            var cmd = new SqlCommand(sql, sqlConnection);
            //cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@State", customer.State);
            cmd.Parameters.AddWithValue("@Sales", customer.Sales);
            cmd.Parameters.AddWithValue("@Active", customer.Active);
            var rowsAffected = cmd.ExecuteNonQuery();
            if(rowsAffected != 1) 
            {
                throw new Exception($"Insert failed. RA is {rowsAffected}");
            }
        }
        
        public void InsertOrder(Order order)
        {
            var sql = " INSERT Orders " +
                " (Id, CustomerId, Date, Description) VALUES " +
                " (@Id, @CustomerId, @Date, @Description) ";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            cmd.Parameters.AddWithValue("@Date", order.Date);
            cmd.Parameters.AddWithValue("Description", order.Description);
            var rowsAffected = cmd.ExecuteNonQuery();
            if(rowsAffected != 1)
            {
                throw new Exception($"Insert failed. RA is {rowsAffected}");
            }

        }

        public void UpdateCustomer(Customer customer) //updating data
        {
            var sql = " UPDATE Customers Set " +
                " Name = @Name, " +
                " City = @City, " +
                " State = @State, " +
                " Sales = @Sales, " +
                " Active = @Active " +
                " Where Id = @Id; ";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", customer.Id);
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@State", customer.State);
            cmd.Parameters.AddWithValue("@Sales", customer.Sales);
            cmd.Parameters.AddWithValue("@Active", customer.Active);
            var rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                throw new Exception($"Update failed. RA is {rowsAffected}");
            }
        }

        public void UpdateOrder(Order order)
        {
            var sql = " UPDATE Order Set " +
                " CustomerId = @CustomerId, " +
                " Date = @Date, " +
                " Description = @Description, " +
                " Where Id = @Id; ";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", order.Id);
            cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            cmd.Parameters.AddWithValue("@Date", order.Date);
            cmd.Parameters.AddWithValue("@Description", order.Description);
            var rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                throw new Exception($"Update Failed. RA is {rowsAffected}");
            }
        }

        public void DeleteCustomer(int id)
        {
            var sql = " DELETE Customers " +
               " Where Id = @Id; ";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);
           
            var rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                throw new Exception($"Delete failed. RA is {rowsAffected}");
            }
        }

        public void DeleteOrder(int id)
        {
            var sql = " DELETE Orders " +
                " Where Id = @Id;";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            var rowsAffected = cmd.ExecuteNonQuery();
            if(rowsAffected != 1)
            {
                throw new Exception($"Delete Failed. RA are {rowsAffected}");
            }
        }

        public void FindCustomer(String substr)
        {

            var sql = " SELECT * from Customers Where Name Like '%'+@substr+'%' order by Sales Desc ";
               
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@substr", substr);
            var reader = cmd.ExecuteReader();
            if(!reader.HasRows)
            {
                reader.Close();
                return;
            }
            reader.Read();
            var cust = new Customer();
            cust.Id = Convert.ToInt32(reader["Id"]);
            cust.Name = Convert.ToString(reader["Name"]);
            cust.City = Convert.ToString(reader["City"]);
            cust.State = Convert.ToString(reader["State"]);
            cust.Sales = Convert.ToDecimal(reader["Sales"]);
            cust.Active = Convert.ToBoolean(reader["Active"]);
            reader.Close();
            return;
 

        }

        public Customer GetCustomerById(int id)
        {
            var sql = "Select * from Customers where Id = @Id";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("Id", id);
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            reader.Read();

            var cust = new Customer();
            cust.Id = Convert.ToInt32(reader["Id"]);
            cust.Name = Convert.ToString(reader["Name"]);
            cust.City = Convert.ToString(reader["City"]);
            cust.State = Convert.ToString(reader["State"]);
            cust.Sales = Convert.ToDecimal(reader["Sales"]);
            cust.Active = Convert.ToBoolean(reader["Active"]);
            reader.Close();
            return cust;
        }

        public List<Customer> GetAllCustomers()
        {
            var sql = "SELECT * from Customers";
            var cmd = new SqlCommand(sql, sqlConnection); //This is what causes the statement to be executed.

            var reader = cmd.ExecuteReader();// only for a "select" command.
            var customers = new List<Customer>();
            while (reader.Read())
            {


                var cust = new Customer();
                var Id = Convert.ToInt32(reader["Id"]);
                var Name = Convert.ToString(reader["Name"]);
                var City = Convert.ToString(reader["City"]);
                var State = Convert.ToString(reader["State"]);
                var Sales = Convert.ToDecimal(reader["Sales"]);
                var Active = Convert.ToBoolean(reader["Active"]);
                customers.Add(cust);
            }


            reader.Close();
            return customers;

        }

    }
}