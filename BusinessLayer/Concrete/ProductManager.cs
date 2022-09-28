using BusinessLayerApi.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerApi.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal ProductDal)
        {
            _productDal = ProductDal;
        }

        public void TAdd(Product t)
        {
            _productDal.Insert(t);
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public Product TGetByID(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
        public List<Product> ListProduct()
        {
            return _productDal.ListProduct();
        }
    }
}
