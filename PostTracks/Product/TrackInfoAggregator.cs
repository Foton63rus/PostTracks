using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTracks.Product
{
    public class ProductInfoGettedEventArgs
    {
        private ProductClass _prod;
        public ProductInfoGettedEventArgs()   
        {
            
        }
    }
    public delegate void TrackInfoGettedEventHandler(object sender, ProductInfoGettedEventArgs e);
    public class TrackInfoAggregator
    {

        public event TrackInfoGettedEventHandler ProductInfoGetted;
        public void TrackInfoAvailable()
        {
            if (ProductInfoGetted != null)
            {
                ProductInfoGetted(this, new ProductInfoGettedEventArgs());
            }
        }
    }
}
