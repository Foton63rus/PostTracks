using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTracks
{
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
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        private double _product_amount;
        public double ProductAmount
        {
            get
            {
                return _product_amount;
            }
            set
            {
                _product_amount = value;
            }
        }
        private int _product_count;
        public int ProductCount
        {
            get
            {
                return _product_count;
            }
            set
            {
                _product_count = value;
            }
        }
        private string _product_action;
        public string ProductAction
        {
            get
            {
                return _product_action;
            }
            set
            {
                _product_action = value;
            }
        }
        private string _product_properties;
        public string ProductProperties
        {
            get
            {
                return _product_properties;
            }
            set
            {
                _product_properties = value;
            }
        }

        public Product(
            string trackcode,
            string name,
            double product_amount,
            int product_count,
            string product_action,
            string product_properties
            )
        {
            Trackcode = trackcode;
            Name = name;
            ProductAmount = product_amount;
            ProductCount = product_count;
            ProductAction = product_action;
            ProductProperties = product_properties;
        }
        public override string ToString()
        {
            return String.Format("[Prod:\"{1}\"{0}, Amount:{2:0.00}x{3}{4}{5}]",
                Trackcode == "" ? "" : ", Track:" + Trackcode,
                Name,
                ProductAmount,
                ProductCount,
               ProductAction == "" ? "" : ", Action:" + ProductAction,
               ProductProperties == "" ? "" : ", Properties:" + ProductProperties);
        }
    }//class Product
}
