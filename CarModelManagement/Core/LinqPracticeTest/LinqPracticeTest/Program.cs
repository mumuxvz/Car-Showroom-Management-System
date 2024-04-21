using LinqPracticeTest.Models;
using System.Linq;

List<Category> categories = new List<Category>
{
    new Category { CategoryId = 1, Name = "Electronics" },
    new Category { CategoryId = 2, Name = "Clothing" },
    new Category { CategoryId = 3, Name = "Stationary" },
    new Category { CategoryId = 4, Name = "Grocery" }
};

List<Product> products = new List<Product>
{
    new Product { ProductId = 1, Name = "Laptop", Price = 10000, CategoryId = 1 },
    new Product { ProductId = 2, Name = "T-Shirt", Price = 2000, CategoryId = 2 },
    new Product { ProductId = 3, Name = "Suger", Price = 2000, CategoryId = 4 },
    new Product { ProductId = 4, Name = "Mobile", Price = 9000, CategoryId = 1 }
};

List<Customer> customers = new List<Customer>
{
    new Customer { CustomerId = 1, Name = "Ayush", Email ="customer1@example.com" },
    new Customer { CustomerId = 2, Name = "Jenis", Email ="customer2@example.com" },
    new Customer { CustomerId = 3, Name = "Smit", Email ="customer3@example.com" },
};
List<Order> orders = new List<Order>
{
    new Order { OrderId = 1, CustomerId = 1, OrderDate = new DateTime(2022, 1, 1) },
    new Order { OrderId = 2, CustomerId = 2, OrderDate = new DateTime(2022, 2, 1) },
    new Order { OrderId = 3, CustomerId = 3, OrderDate = DateTime.Now},
    new Order { OrderId = 4, CustomerId = 2, OrderDate = DateTime.Now}
};

List<OrderItem> orderItems = new List<OrderItem>
{
    new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 2 },
    new OrderItem { OrderItemId = 2, OrderId = 1, ProductId = 2, Quantity = 3 },
    new OrderItem { OrderItemId = 3, OrderId = 2, ProductId = 1, Quantity = 1 },
};


//1.Find the customers who ordered any product this year.

var ans1 = customers.GroupJoin(
        orders,
        a => a.CustomerId,
        b => b.CustomerId,
        (a, b) => new
        {
            customername = a.Name,
            odate = b.Any(x => x.OrderDate.Year == DateTime.Now.Year),
        }).Select(x => x.customername);

foreach (var item in ans1)
{
    Console.WriteLine(item);
}

//2.Find the products whose most quantity are ordered.

var ans2 = orders.Join(
    orderItems,
    a => a.OrderId,
    b => b.OrderId,
    (a, b) => new
    {
        orderid = a.OrderId,
        customerid = a.CustomerId,
        quant = b.Quantity
    }).GroupBy(x => x.customerid);

var ans22 = ans2.Select(x => new
{
    customername = x.Key,
    totalamount = x.Sum(x => x.quant),
}).OrderByDescending(x=>x.totalamount).FirstOrDefault();


//Console.WriteLine(ans22);

    foreach (var item1 in customers)
    {
        if (item1.CustomerId == ans22.customername)
        {
            Console.WriteLine(item1.Name+ "   " + ans22.totalamount);
            break;
        }
    }


//3.Find the most expensive product for each category.

//var ans3 = products.Join(
//        categories,
//        a => a.CategoryId,
//        b => b.CategoryId,
//        (a, b) => new
//        {
//            product = a.Name,
//            categoryname = b.Name,
//            price = a.Price,
//        }).GroupBy(x => x.categoryname);

//var ans33 = ans3.Select(x => new
//{
//    groupname = x.Key,
//    ans = x.Max(n=>n.price),
//}).OrderByDescending(m=>m.ans).FirstOrDefault();

//Console.WriteLine(ans33);

//Console.WriteLine(ans33);

//4.Find the average price of products in each category.

//var ans4 = products.Join(
//        categories,
//        a => a.CategoryId,
//        b => b.CategoryId,
//        (a, b) => new
//        {
//            product = a.Name,
//            categoryname = b.Name,
//            price = a.Price,
//        }).GroupBy(x => x.categoryname);

//var ans44 = ans4.Select(x => new
//{
//    groupname=x.Key,
//    avgproductprice=x.Average(m=>m.price),
//});
//foreach (var item in ans44)
//{
//    Console.WriteLine(item.groupname + "  " + item.avgproductprice);
//}

//6.Identify the top 3 customers who made the highest total number of orders.
//var ans6 = customers.Join(
//        orders,
//        a=>a.CustomerId,
//        b=>b.CustomerId,
//        (a, b) => new { 
//            customername=a.Name,
//            orders=b.OrderId,
//        }).GroupBy(x => x.customername).Select(x => new { 
//            customer=x.Key,
//            totalcount=x.Count(),
//        }).OrderByDescending(m=>m.totalcount).Take(1);

//Console.WriteLine(ans6);

//7.For each product, list the customers who purchased it along with the quantity they bought.
//var ans7 = customers.Join(
//        orders,
//        a => a.CustomerId,
//        b => b.CustomerId,
//        (a, b) => new
//        {
//            customername = a.Name,
//            customerid = b.CustomerId,
//            orderid = b.OrderId,
//        }).Join(
//        orderItems,
//        a => a.orderid,
//        b => b.OrderId,
//        (a, b) => new
//        {
//            cust = a.customername,
//            customerid = a.customerid,
//            productid = b.ProductId,
//            quant = b.Quantity,
//        }).
//        Join(
//        products,
//        a => a.productid,
//        b => b.ProductId,
//        (a, b) => new
//        {
//            name = a.cust,
//            custid = a.customerid,
//            quant = a.quant,
//            productname = b.Name,
//        }).GroupBy(x => x.productname);



//foreach (var item in ans7)
//{
//    Console.WriteLine(item.Key);
//    foreach (var item1 in item)
//    {
//        Console.WriteLine(item1.name+"  "+item1.quant);
//    }
//}

//8.Find the category with the highest average order quantity.

//var ans8 = orderItems.Join(
//        products,
//        a=>a.ProductId,
//        b=>b.ProductId,
//        (a, b) => new {
//            productid=a.ProductId,
//            categotyid=b.CategoryId,
//            orederitem=a.Quantity,
//        }).Join(
//        categories,
//        a => a.categotyid,
//        b => b.CategoryId,
//        (a, b) => new
//        {
//            categoryname = b.Name,
//            quantity=a.orederitem,
//        }).GroupBy(x => x.categoryname); 

//var ans88 = ans8.Select(x => new
//{
//    groupname = x.Key,
//    avgquantity = x.Average(m => m.quantity),
//}).OrderByDescending(m => m.avgquantity).FirstOrDefault();

//Console.WriteLine(ans88);

//9.Find the total revenue for each category.

//var ans9 = orderItems.Join(
//        products,
//        a => a.ProductId,
//        b => b.ProductId,
//        (a, b) => new
//        {
//            productid = a.ProductId,
//            categotyid = b.CategoryId,
//            orederitem = a.Quantity,
//            productprice=b.Price
//        }).Join(
//        categories,
//        a => a.categotyid,
//        b => b.CategoryId,
//        (a, b) => new
//        {
//            categoryname = b.Name,
//            quantity = a.orederitem,
//            price=a.productprice
//        }).GroupBy(x => x.categoryname);

//var ans99 = ans9.Select(x => new
//{
//    groupname = x.Key,
//    avgquantity = x.Sum(m => m.quantity*m.price),
//});

//Console.WriteLine(ans99);

//10.Identify the customer with the highest total spending.
//var ans10 = orderItems.Join(
//        orders,
//        a=>a.OrderId,
//        b => b.OrderId,
//        (a, b) => new {
//            orderid=a.OrderId,
//            orderquant=a.Quantity,
//            custid=b.CustomerId,
//            prodid=a.ProductId
//        }).Join(
//        products,
//        a=>a.prodid,
//        b=>b.ProductId,
//        (a, b) => new { 
//            customerid=a.custid,
//            quant=a.orderquant,
//            price=b.Price,
//        }).GroupBy(x=>x.customerid).Select(x => new {
//            customerid=x.Key,
//            spent= x.Sum(m => m.quant * m.price),
//        }).OrderByDescending(y=>y.spent).FirstOrDefault();

//Console.WriteLine(ans10);

//11. For each order, list the products, quantities, and total price.

//var ans11 = orderItems.Join(
//        products,
//        a => a.ProductId,
//        b => b.ProductId,
//        (a, b) => new
//        {
//            prductid = a.ProductId,
//            productname = b.Name,
//            price = b.Price,
//            quantity = a.Quantity,
//        }).GroupBy(x => x.productname).Select(x => new
//        {
//            productname = x.Key,

//            quantity = x.Sum(x => x.quantity),
//            productprice = x.Sum(x => x.price * x.quantity),
//        });

//Console.WriteLine(ans11);



//12.Find the category with the most orders.
//var ans12 = orderItems.Join(
//        products,
//        a=>a.ProductId,
//        b=>b.ProductId,
//        (a, b) => new {
//           quant=a.Quantity,
//           productid=a.ProductId,
//           productcate=b.CategoryId
//        }).Join(
//        categories,
//        a=>a.productcate,
//        b=>b.CategoryId,
//        (a, b) => new {
//            procat=b.Name,
//            quanti=a.quant
//        }).GroupBy(x => x.procat).Select(x => new { 
//            product=x.Key,
//            quantity=x.Sum(x=>x.quanti),
//        }).OrderByDescending(x=>x.quantity).FirstOrDefault();

//Console.WriteLine(ans12);

//13. Identify the most popular product (highest total quantity sold).
//var ans13 = orderItems.Join(
//        products,
//        a => a.ProductId,
//        b => b.ProductId,
//        (a, b) => new
//        {
//            quant = a.Quantity,
//            productid = a.ProductId,
//            productname = b.Name,
//        }).GroupBy(x => x.productname).Select(x => new
//        {
//            product=x.Key,
//            quantity = x.Sum(x => x.quant),
//        }).OrderByDescending(x => x.quantity).FirstOrDefault();
//Console.WriteLine(ans13);

//14 Identify the least popular product (lowest total quantity sold).
//var ans14 = orderItems.Join(
//        products,
//        a => a.ProductId,
//        b => b.ProductId,
//        (a, b) => new
//        {
//            quant = a.Quantity,
//            productid = a.ProductId,
//            productname = b.Name,
//        }).GroupBy(x => x.productname).Select(x => new
//        {
//            product = x.Key,
//            quantity = x.Sum(x => x.quant),
//        }).OrderBy(x => x.quantity).FirstOrDefault();
//Console.WriteLine(ans14);

//15 Find the top 3 products with the highest total revenue.
//var ans15 = orderItems.Join(
//        products,
//        a => a.ProductId,
//        b => b.ProductId,
//        (a, b) => new
//        {
//            prductid = a.ProductId,
//            productname = b.Name,
//            price = b.Price,
//            quantity = a.Quantity,
//        }).GroupBy(x => x.productname).Select(x => new
//        {
//            productname = x.Key,

//            quantity = x.Sum(x => x.quantity),
//            productprice = x.Sum(x => x.price * x.quantity),
//        }).OrderByDescending(x=>x.productprice).Take(3);

//Console.WriteLine(ans15);

//16 Identify the customer with the most diverse shopping experience (purchased from the highest number of categories).

//var ans16 = customers.Join(
//        orders,
//        a=>a.CustomerId,
//        b=>b.CustomerId,
//        (a, b) => new {
//            customername=a.Name,
//            customerid=b.CustomerId,
//            orderid=b.OrderId,
//        }).Join(
//        orderItems,
//        a=>a.orderid,
//        b=>b.OrderId,
//        (a, b) => new {
//            cust=a.customername,
//            customerid=a.customerid,
//            productid=b.ProductId,
//        }).Join(
//        products,
//        a=>a.productid,
//        b=>b.ProductId,
//        (a, b) => new {
//            name=a.cust,
//            custid=a.customerid,
//            categ=b.CategoryId,
//        }).GroupBy(x => x.name).Select(x => new {
//            name=x.Key,
//            cn=x.Distinct().Count(),
//        }).OrderByDescending(x=>x.cn).FirstOrDefault();

//Console.WriteLine(ans16);

