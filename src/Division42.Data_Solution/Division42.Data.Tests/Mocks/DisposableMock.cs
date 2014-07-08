using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division42.Data.Tests.Mocks
{
    public class DisposableMock : DisposableBase
    {
        public void DoNothing()
        {
            CheckIfDisposed();
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
        }
    }
}
