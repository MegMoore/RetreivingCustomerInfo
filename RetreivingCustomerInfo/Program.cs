


using CustomerController;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Reflection.PortableExecutable;

var connStr = "server=localhost\\sqlexpress;" + //connection string
    "database=SalesDb;" +
    "trusted_connection=true;" +
    "trustServerCertificate=true;";


var conn = new SqlConnection(connStr);
conn.Open();

if(conn.State != System.Data.ConnectionState.Open)
{
    throw new Exception("Connection did not open!!!");
}

/* ---------------------  DO STUFF ----------------------- */

// CREATE INSTANCE OF CUSTOMERS CONTROLLER TO CALL METHODS ON
var custCtrl = new CustController(conn);

//var newCust = new Customer
//{
//  Id = 0,
//Name = "Acme Mfg",
//City = "Mason",
//State = "OH",
//Sales = 0,
//Active = true
//};
//custCtrl.InsertCustomer(newCust);

//Update Customer


List<Customer> customers = custCtrl.FindCustomer("er");
foreach (var c in customers)
{
    Console.WriteLine(c);

}

/*
custCtrl.DeleteCustomer(43);
Customer? cust = custCtrl.GetCustomerById(43);
if(cust == null)
{
    Console.WriteLine("Customer with id of 43 is not found");
} else
{
    Console.WriteLine(cust);
}
*/
//cust.Name = "Acme Man";
//custCtrl.UpdateCustomer(cust);
//cust = custCtrl.GetCustomerById(10);
//Console.WriteLine(cust);

// RUN METHODS
//Customer? custById = custCtrl.GetCustomerById(10);
//Console.WriteLine($"{custById}");


//List<Customer> customers = custCtrl.GetAllCustomers();
//foreach (var c in customers)
//{
// Console.WriteLine(c);
//}


/* ---------------------  END CONNECTION  ----------------------- */

// CLOSE CONNECTION
conn.Close();