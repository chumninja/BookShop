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
        [Route("create_productcategory")]
        [HttpPost]
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
                    _productCategroryService.Add(newProductCategory);
                    _productCategroryService.Save();
                    var responsedata = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);// truyền vào cái kiểu gì thì mapp sang kiểu đo
                    response = request.CreateResponse(HttpStatusCode.Created, responsedata);
                }
                return response;
            });

        }
    }
}
