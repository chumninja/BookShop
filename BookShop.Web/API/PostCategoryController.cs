using BookShop.Model.Models;
using BookShop.Service;
using BookShop.Web.Infastucture.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShop.Web.API
{
    [RoutePrefix("api/ProductCategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;

        //cach truyen thang tu controller con sang controller cha
        public PostCategoryController(IErrorService errorService,IPostCategoryService postCategorySerivce):base(errorService)
        {
            this._postCategoryService = postCategorySerivce;

        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    //Phuong thuc can truyen vao 2 tham so 
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listCategory = _postCategoryService.GetAll();
                    _postCategoryService.Save();

                    //sau khi save xong tao 1 cai response, add xong tra ve 1 doi tuong cho muon lam gi thi lam
                    response = request.CreateResponse(HttpStatusCode.OK, listCategory);//OK thanhf cong
                }
                return response;
            });

        }

        public HttpResponseMessage Post(HttpRequestMessage request,PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    //Phuong thuc can truyen vao 2 tham so 
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var category = _postCategoryService.Add(postCategory);
                    _postCategoryService.Save();

                    //sau khi save xong tao 1 cai response, add xong tra ve 1 doi tuong cho muon lam gi thi lam
                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });
            
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    //Phuong thuc can truyen vao 2 tham so 
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();

                    //sau khi save xong tao 1 cai response, add xong tra ve 1 doi tuong cho muon lam gi thi lam
                    response = request.CreateResponse(HttpStatusCode.OK);//OK thanhf cong
                }
                return response;
            });

        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int IdPostCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    //Phuong thuc can truyen vao 2 tham so 
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(IdPostCategory);
                    _postCategoryService.Save();

                    //sau khi save xong tao 1 cai response, add xong tra ve 1 doi tuong cho muon lam gi thi lam
                    response = request.CreateResponse(HttpStatusCode.OK);//OK thanhf cong
                }
                return response;
            });

        }

        
    }
}