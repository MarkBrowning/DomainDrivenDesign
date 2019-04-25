using System;
using System.Collections.Generic;
using System.Text;

namespace RSIComposite
{
    public interface IComposite
    {

        #region Properties

        int ObjectID { get; }

        String Type { get; set; }
        String Name { get; set; }
        String Value { get; set; }

        Boolean LazyLoad { get; set; }       
    
        #endregion

        #region Types

        List<T> getType<T>();
        IList<IComposite> getType(String type);

        #endregion

        #region Parents

        IList<IComposite> Parents { get; }
        void insertParent(IComposite parent);

        void removeChild(IComposite child, Boolean removeParent = true);

        IComposite getParent(int objectId);

        IList<IComposite> getParent(string name, string value);

        IList<IComposite> getParent(string type, string name, string value);

        void clearParentList();

        #endregion

        #region Children
        IList<IComposite> Children { get; }
        IComposite addChild(IComposite child);

        void removeParent(IComposite parent, Boolean removeChild = true);

        void moveChild(IComposite fromParent, IComposite toParent);

        IComposite getChild(int objectId);

   
        IList<IComposite> getChild(string name);

        IList<IComposite> getChild(string name, string value);

        IList<IComposite> getChild(string type, string name, string value);



        void clearChildList();


        #endregion

        #region Persistance
        int Write(IDataTransfer DataTransfer);
        void Read(IDataTransfer DataTransfer, Boolean lazyLoad = true);

        #endregion

    }
}
