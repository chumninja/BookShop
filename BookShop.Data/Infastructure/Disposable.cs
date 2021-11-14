using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Infastructure
{
    public class Disposable : IDisposable // interface mau cai dat casc phuong thuc tu dong huy
    {
        private bool isDispose;
        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if(!isDispose && disposing)
            {
                DisposeCore();
            }
            isDispose = true;
        }

        protected virtual void DisposeCore()
        {

        }
    }
}
