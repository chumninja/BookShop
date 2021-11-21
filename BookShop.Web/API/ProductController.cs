using AutoMapper;
using BookShop.Model.Models;
using BookShop.Service;
using BookShop.Web.Infastucture.Core;
using BookShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookShop.Web.Infastucture.Extension;
using System.Web.Script.Serialization;

namespace BookShop.Web.API
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiControllerBase
    {
        IProductService _productService;

        //cach truyen thang tu controller con sang controller cha
        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;

        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                int totalCountCurent = 0;
                var model = _productService.GetAll(keyword);

                var query = model.OrderByDescending(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);//take lấy ra
                totalRow = model.Count();
                totalCountCurent = query.Count();
                var reponseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query);

                //chua tra ve nua ma tao 1 doi tuong PaginationSet
                var paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = reponseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalCountCunrent = totalCountCurent,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)//lam tron tong so page
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }


        

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetDetails(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {

                var model = _productService.GetById(id);
                var reponseData = Mapper.Map<Product, ProductViewModel>(model);//tra về 1 đối tượng
                var response = request.CreateResponse(HttpStatusCode.OK, reponseData);
                return response;
            });
        }
        [Route("create_product")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel ProductVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadGateway, ModelState);
                    //ném lỗi 400 ra ngoài.
                    //reponse ném ra ngoài view thông qua controller js đó
                }
                else
                {

                    var newProduct = new Product();
                    newProduct.UpdateProduct(ProductVM);// truyên vào view model nó sẽ copy giá trị sang newProdcuctCategory.
                    newProduct.CreateDate = DateTime.Now;
                    _productService.Add(newProduct);
                    _productService.Save();
                    var responsedata = Mapper.Map<Product, ProductViewModel>(newProduct);// truyền vào cái kiểu gì thì mapp sang kiểu đo
                    response = request.CreateResponse(HttpStatusCode.Created, responsedata);
                }
                return response;
            });

        }

        [Route("edit_product")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel ProductVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadGateway, ModelState);
                    //ném lỗi 400 ra ngoài.
                    //reponse ném ra ngoài view thông qua controller js đó
                }
                else
                {
                    ProductVM.UpdateDate = DateTime.Now;
                    var updateProduct = _productService.GetById(ProductVM.ID);
                    updateProduct.UpdateProduct(ProductVM);// truyên vào view model nó sẽ copy giá trị sang newProdcuctCategory.
                    _productService.Update(updateProduct);
                    _productService.Save();
                    var responsedata = Mapper.Map<Product, ProductViewModel>(updateProduct);// truyền vào cái kiểu gì thì mapp sang kiểu đo
                    response = request.CreateResponse(HttpStatusCode.Created, responsedata);
                }
                return response;
            });

        }
        [Route("delete_product")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadGateway, ModelState);
                    //ném lỗi 400 ra ngoài.
                    //reponse ném ra ngoài view thông qua controller js đó
                }
                else
                {

                    var oldProduct = _productService.Delete(id);
                    _productService.Save();
                    var responsedata = Mapper.Map<Product, ProductViewModel>(oldProduct);//vẫn muốn trả về thì ném ra đây
                    response = request.CreateResponse(HttpStatusCode.Created, responsedata);
                }
                return response;
            });

        }
        [Route("deletemulti_product")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, string checkedListProduct)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadGateway, ModelState);
                    //ném lỗi 400 ra ngoài.
                    //reponse ném ra ngoài view thông qua controller js đó
                }
                else
                {

                    var listID = new JavaScriptSerializer().Deserialize<List<int>>(checkedListProduct);
                    foreach (var itemID in listID)
                    {
                        _productService.Delete(itemID);

                    }
                    _productService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, listID.Count());
                }
                return response;
            });

        }


    }
}