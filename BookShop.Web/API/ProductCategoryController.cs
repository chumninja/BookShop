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
    [RoutePrefix("api/poductcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategroryService;
        public ProductCategoryController(IErrorService errorService,IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategroryService = productCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () => {
                var model = _productCategroryService.GetAll();
                var reponseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, reponseData);
                return response;
            });
        }
    }
}
