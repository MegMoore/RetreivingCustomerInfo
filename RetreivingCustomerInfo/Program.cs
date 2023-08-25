


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
var custOrd = new CustController(conn);

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
void TestOrdersController(SqlConnection conn)
{


    var order = new Order() { Id = 0, Date = DateTime.Now, Description = "Test", CustomerId = 10 };


    order.Id = 27;
    order.CustomerId = 1;
    custOrd.UpdateOrder(order);

    var orders = custOrd.FindOrder();



    orders.ForEach(x => Console.WriteLine(x));

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


//List<Order> orders = custOrd.FindOrder();
//foreach (var o in orders)
//{
  //  Console.WriteLine(o);
//}


/* ---------------------  END CONNECTION  ----------------------- */

// CLOSE CONNECTION
//conn.Close();