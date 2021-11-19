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


namespace BookShop.Web.API
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategroryService;
        public ProductCategoryController(IErrorService errorService,IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategroryService = productCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request,int page,int pageSize = 20)
        {
            return CreateHttpResponse(request, () => {
                int totalRow = 0;
                var model = _productCategroryService.GetAll();
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);//take lấy ra
                var reponseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                //chua tra ve nua ma tao 1 doi tuong PaginationSet
                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = reponseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)//lam tron tong so page
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
    }
}
