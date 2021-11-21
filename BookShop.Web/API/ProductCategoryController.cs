using AutoMapper;
using BookShop.Model.Models;
using BookShop.Service;
using BookShop.Web.Infastucture.Core;
using BookShop.Web.Infastucture.Extension;
using BookShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace BookShop.Web.API
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategroryService;
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategroryService = productCategoryService;
        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                int totalCountCurent = 0;
                var model = _productCategroryService.GetAll(keyword);

                var query = model.OrderByDescending(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);//take lấy ra
                totalRow = model.Count();
                totalCountCurent = query.Count();
                var reponseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                //chua tra ve nua ma tao 1 doi tuong PaginationSet
                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
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


        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAllParent(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {

                var model = _productCategroryService.GetAll();
                var reponseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, reponseData);
                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetAllParent(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {

                var model = _productCategroryService.GetById(id);
                var reponseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);//tra về 1 đối tượng
                var response = request.CreateResponse(HttpStatusCode.OK, reponseData);
                return response;
            });
        }
        [Route("create_productcategory")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategoryVM)
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

                    var newProductCategory = new ProductCategory();
                    newProductCategory.UpdateProductCategory(productCategoryVM);// truyên vào view model nó sẽ copy giá trị sang newProdcuctCategory.
                    newProductCategory.CreateDate = DateTime.Now;
                    _productCategroryService.Add(newProductCategory);
                    _productCategroryService.Save();
                    var responsedata = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);// truyền vào cái kiểu gì thì mapp sang kiểu đo
                    response = request.CreateResponse(HttpStatusCode.Created, responsedata);
                }
                return response;
            });

        }

        [Route("edit_productcategory")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryVM)
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
                    productCategoryVM.UpdateDate = DateTime.Now;
                    var updateProductCategory = _productCategroryService.GetById(productCategoryVM.ID);
                    updateProductCategory.UpdateProductCategory(productCategoryVM);// truyên vào view model nó sẽ copy giá trị sang newProdcuctCategory.
                    _productCategroryService.Update(updateProductCategory);
                    _productCategroryService.Save();
                    var responsedata = Mapper.Map<ProductCategory, ProductCategoryViewModel>(updateProductCategory);// truyền vào cái kiểu gì thì mapp sang kiểu đo
                    response = request.CreateResponse(HttpStatusCode.Created, responsedata);
                }
                return response;
            });

        }
        [Route("delete_productcategory")]
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

                    var oldProductCategory = _productCategroryService.Delete(id);
                    _productCategroryService.Save();
                    var responsedata = Mapper.Map<ProductCategory, ProductCategoryViewModel>(oldProductCategory);//vẫn muốn trả về thì ném ra đây
                    response = request.CreateResponse(HttpStatusCode.Created, responsedata);
                }
                return response;
            });

        }
        [Route("deletemulti_productcategory")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, string listID)
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
                    var ids = new JavaScriptSerializer().Deserialize<List<int>>(listID);
                    foreach (var itemID in ids)
                    {
                        _productCategroryService.Delete(itemID);
                    }
                    _productCategroryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, true);
                }
                return response;
            });

        }

    }
}
