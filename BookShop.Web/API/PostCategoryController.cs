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

namespace BookShop.Web.API
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;

        //cach truyen thang tu controller con sang controller cha
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategorySerivce) : base(errorService)
        {
            this._postCategoryService = postCategorySerivce;

        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _postCategoryService.GetAll();

                //Map sang view
                var listCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(listCategory);
              
                //sau khi save xong tao 1 cai response, add xong tra ve 1 doi tuong cho muon lam gi thi lam
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategoryVM);//OK thanhf cong
                return response;
            });

        }
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    //Phuong thuc can truyen vao 2 tham so  kiem tra xem co null cac truong ko
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    //Tao moi mot doi tuong PostCategory để copy từ postCategoryVM từ View nhận về để adđ
                    PostCategory newPostCategory = new PostCategory();

                    //Cần using phần mở rộng của folder mới dùng dc pt này EntiryExtensions để copy sang model gốc.
                    newPostCategory.UpdatePostCategory(postCategoryVM);
                    //using xong phần newPostCategory sẽ tự nhận phương thức mở rộng UpdatePostCategory

                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();

                    //sau khi save xong tao 1 cai response, add xong tra ve 1 doi tuong cho muon lam gi thi lam
                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });

        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    //Phuong thuc can truyen vao 2 tham so , để kiêm tra lỗi nhập dữ liệu có trống
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDB = _postCategoryService.GetById(postCategoryVM.ID);
                    postCategoryDB.UpdatePostCategory(postCategoryVM);
                    _postCategoryService.Update(postCategoryDB);
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