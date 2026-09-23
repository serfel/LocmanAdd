/*------------------------------------------------------------------------------------------------
** program:			TX Text Control DataSourceManagerSample
** description:	Shows you how to use the DataSourceManager to create your own template designer 
**                  for templates that are compatible with MailMerge.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace DataSourceManagerSample {

    public class Order {
        public int OrderID { get; set;}
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Product {
        public string Name { get; set; }
    }

    public class Customer {
        public string Name { get; set; }
    }
}
