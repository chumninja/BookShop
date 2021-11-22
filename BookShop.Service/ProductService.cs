using BookShop.Common;
using BookShop.Data.Infastructure;
using BookShop.Data.Repositories;
using BookShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Service
{
    public interface IProductService
    {
        //các phương thức từ repository có sẵn.
        Product Add(Product Product);
        void Update(Product Product);
        Product Delete(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAll(string keyword);
        IEnumerable<Product> GetAllByCategoryID(int categoryID);
        Product GetById(int id);
        void Save();
    }
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;
        private IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, ITagRepository tagRepository, IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._tagRepository = tagRepository;
            this._productTagRepository = productTagRepository;
            this._unitOfWork = unitOfWork;

        }

        public Product Add(Product Product)
        {
            var products = _productRepository.Add(Product);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] tags = Product.Tags.Split(','); //cắt bởi dấu phẩy.
                for (int i = 0; i < tags.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        // tạo các tag chưa có vào bảng tag
                        Tag tagNew = new Tag();
                        tagNew.ID = tagID;
                        tagNew.NameTag = tags[i];
                        tagNew.Type = CommonConstants.ProductTag;
                        //Nó rằng buộc các khóa chính nên thêm vào bên id trc mới thêm đc vào ProductTag
                        _tagRepository.Add(tagNew);
                       
                    }
                    //sau đó add các Tagid và ProductID vào bảng ProductID
                    //1 productID thì có nhiều tag và ngược lại.
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = tagID;
                    _productTagRepository.Add(productTag);
                }
               
            }
            return products;
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _productRepository.GetMulti(x => x.NameProduct.Contains(keyword));
            }
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAllByCategoryID(int categoryID)
        {
            return _productRepository.GetMulti(x => x.Status);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product Product)
        {
            _productRepository.Update(Product);//chỉ cần update trc đó thôi.
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] tags = Product.Tags.Split(','); //cắt bởi dấu phẩy.
                for (int i = 0; i < tags.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        // tạo các tag chưa có vào bảng tag
                        Tag tagNew = new Tag();
                        tagNew.ID = tagID;
                        tagNew.NameTag = tags[i];
                        tagNew.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tagNew);
                       
                    }
                    //sau đó add các Tagid và ProductID vào bảng ProductID
                    //1 productID thì có nhiều tag và ngược lại.

                    //Trước khi update phải xóa productID trong ProductTag đi
                    _productTagRepository.DeleteMulti(x => x.ProductID == Product.ID);
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = tagID;
                    _productTagRepository.Add(productTag);
                }
            }
          

        }
    }
}


