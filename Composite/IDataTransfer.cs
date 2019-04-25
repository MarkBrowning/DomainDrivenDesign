
using System;
using System.Collections.Generic;
using System.Text;

namespace RSIComposite
{
    public interface IDataTransfer : IDisposable
    {
        void Open(string file = null);
        void Close();

        void readItem(IComposite obj, Boolean lazyLoad = true);
        int writeItem(IComposite obj);

        int insertItem(IComposite obj);
        int updateItem(IComposite obj);
    }
}
