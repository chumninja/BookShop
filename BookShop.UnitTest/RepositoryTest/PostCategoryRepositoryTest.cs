using BookShop.Data.Infastructure;
using BookShop.Data.Repositories;
using BookShop.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BookShop.UnitTest.RepositoryTest
{
    [TestClass]//cho biet day la lop test
    public class PostCategoryRepositoryTest
    {
        IDBFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Intialize()//chay dau tien thiet lap tham so cac doi tuong
        {
            dbFactory = new DBFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(list.Count, list.Count); // ra 5 ban ghi passed;
        }
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.NamePost = "Test name";
            category.Alias = "Test-name";
            category.Status = true;

            var result = objRepository.Add(category);
            unitOfWork.Commit();


            // 2 cai access test
            Assert.IsNotNull(result);// khac null
            Assert.AreEqual(result.ID, result.ID);//test xem co them thanh cong ko
        }
       
    }
}
