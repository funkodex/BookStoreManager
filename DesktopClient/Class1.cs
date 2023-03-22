using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient
{
    public class Product : BindableBase
    {
        public Product()
        {
            
        }

        public long Id { get; set; }
        public string Label { get; set; }
        public Brand Brand { get; set; }

    }

    public class Brand
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }

    public class Property<T>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public object[] DefaultValues { get; set; }
    }
    public class ProductMetaData
    {
        public long ProductId { get; set; }
        public ICollection<Property<Product>> MyProperty { get; set; }
    }
}
