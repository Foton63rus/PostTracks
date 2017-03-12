using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTracks
{
    class Order
    {
        private string _order_id;
        private DateTime _order_date;
        private string _store_name;
        private double _order_amount;
        private List<Product> _products;
        public int ProductCount => _products.Count();
        public string OrderId
        {
            get
            {
                return _order_id;
            }
            private set
            {
                _order_id = value;
            }
        }
        public DateTime OrderDate
        {
            get
            {
                return _order_date;
            }
            private set
            {
                _order_date = value;
            }
        }
        public string StoreName
        {
            get
            {
                return _store_name;
            }
            private set
            {
                _store_name = value;
            }
        }
        public double OrderAmount
        {
            get
            {
                return _order_amount;
            }
            private set
            {
                _order_amount = value;
            }
        }
        public void addProduct(Product product)
        {
            if (!_products.Contains( product ))
            {
                _products.Add( product );
            }
        }
        public Product this[int i]
        {
            get
            {
                return _products[i];
            }
            set
            {
                _products[i] = value;
            }
        }
        public Order(string order_id, DateTime order_date, string store_name, double order_amount, params Product[] products)
        {
            OrderId = order_id;
            OrderDate = order_date;
            StoreName = store_name;
            OrderAmount = order_amount;
            foreach (Product product in products)
            {
                addProduct(product);
            }
        }
    }//class Order

    internal class Product
    {
        private string _trackcode;
        public string Trackcode
        {
            get
            {
                return _trackcode;
            }
            set
            {
                _trackcode = value;
            }
        }
        private string _name;
        private double _product_amount;
        private int _product_count;
        private string _product_action;
        private string _product_properties;
    }//class Product
}
