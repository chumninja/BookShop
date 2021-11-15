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
    public interface IPostService {
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pagesize, out int totalRow);
        Post GetById(int id);
        IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pagesize, out int totalRow);
        void SaveChanges();
    }
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _uniOfWork;

        // Muon dung Service o ngoai can truyen vao 2 interface
        public PostService(IPostRepository postRepository , IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._uniOfWork = unitOfWork;
        }
        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            //Lay dc ca mang danh muc id post lien ket
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pagesize, out int totalRow)
        {
            //TODO: Selecto to post by
            return _postRepository.GetMultiPaging(x=>x.Status == true,out totalRow,page,pagesize);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pagesize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status == true, out totalRow, page, pagesize);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _uniOfWork.Commit();//commit vao db
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
