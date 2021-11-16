using BookShop.Data.Infastructure;
using BookShop.Data.Repositories;
using BookShop.Model.Models;
using BookShop.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        //Mock gia lap thay the cac doi tuong
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listPostCategory;
        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();//gia lap 1 Reposi
            _mockUnitOfWork = new Mock<IUnitOfWork>();//Gia lap 1 unitOfWork
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listPostCategory = new List<PostCategory>()
            {
                new PostCategory() {ID=1,NamePost="DM1",Status=true },
                new PostCategory() {ID=2,NamePost="DM2",Status=true },
                new PostCategory() {ID=3,NamePost="DM3",Status=true },
            };
        }
        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup Method
            // dung mock gan 1 doi 1 list gia lap co 2 query
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listPostCategory);

            //call action
           var result = _categoryService.GetAll() as List<PostCategory>;

            //compare (so sanh Test Case)
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory postCategory = new PostCategory();
            postCategory.NamePost = "Test Service_1";
            postCategory.Alias = "Test-service";
            postCategory.Status = true;

            //Set up goi den repository de add return 1 doi tuong
            //p tra ve co id = 1
            _mockRepository.Setup(m => m.Add(postCategory)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            });
            //call ve action xem no tra ve doi tuong nhu mock kia ko
            var result = _categoryService.Add(postCategory);

            //So sanh(compare)
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}
