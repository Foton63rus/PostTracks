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
        private List<ProductClass> _products = new List<ProductClass>();
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
        public void addProduct(ProductClass product)
        {
            if (!_products.Contains(product))
            {
                _products.Add(product);
            }
        }
        public ProductClass this[int i]
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
        public Order(string order_id, DateTime order_date, string store_name, double order_amount, params ProductClass[] products)
        {
            OrderId = order_id;
            OrderDate = order_date;
            StoreName = store_name;
            OrderAmount = order_amount;
            foreach (ProductClass product in products)
            {
                addProduct(product);
            }
        }
        public override string ToString()
        {
            string ProductListString = "";
            foreach (ProductClass product in _products)
            {
                ProductListString += String.Format("({0})", product);
            }
            return String.Format("[Order:{0}, {1}, Store:\"{2}\", Amount:{3}, Products:{4}]",
                OrderId,
                OrderDate,
                StoreName,
                OrderAmount,
                ProductListString);
        }
    }//class Order
}
