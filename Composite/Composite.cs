using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RSIComposite
{
   public class Composite : IComposite
    {
        #region ObjectId
        private static int objectID = 0;
        public static int getObjectId() { return ++Composite.objectID; }
        public static void resetObjectId() { Composite.objectID = 0; }
        #endregion

        #region Properties

        //Composite ID 
        private int _ObjectID;

        public int ObjectID { get { return _ObjectID; } }


        //Type, Name and Value
        virtual public String Type { get; set; }
        virtual public String Name { get; set; }
        virtual public String Value { get; set; }
        
        public Boolean LazyLoad { get; set; } = true;

        #endregion

        #region Constructors

        public Composite() {

            this.Type = this.GetType().Name;
           
            this._ObjectID = ++Composite.objectID;

            this._children = new List<IComposite>();
            this._parents = new List<IComposite>();
           
            
        
        }

        public Composite(String type) : this() { Type = type; }

        public Composite(String type, String name) : this() { this.Type = type; this.Name = name; }

        public Composite(String type, String name, String value) : this() { this.Type = type; this.Name = name; this.Value = value; }

        #endregion

        #region Types
        public List<T> getType<T>()
        {
            List<T> returnList = new List<T>();

            foreach (IComposite child in _children)
                if (child.GetType() == typeof(T))
                    returnList.Add((T)child);

            return returnList;
        }

        public IList<IComposite> getType(String type)
        {
       
            List<IComposite> returnList = new List<IComposite>();

            foreach (IComposite child in _children)
                if (child.Type == type)
                    returnList.Add(child);

            return returnList.AsReadOnly();


        }

        #endregion

        #region Parents

        private List<IComposite> _parents;
        public IList<IComposite> Parents { get { return _parents.AsReadOnly(); } }
        public void insertParent(IComposite parent) { _parents.Add(parent); }

        public void removeChild(IComposite child, Boolean removeParent = true)
        {

            if (_children.Contains(child))
            {
                if (removeParent)
                    child.removeParent(this, false);

                _children.Remove(child);

            }

        }
        public IComposite getParent(int objectId)
        {
            foreach (IComposite parent in _parents)
                if (parent.ObjectID == objectId)
                    return parent;

            return null;
        }

        public IList<IComposite> getParent(string name, string value)
        {
            List<IComposite> returnList = new List<IComposite>();

            foreach (Composite parent in this.Parents)
                if (parent.Name == name && parent.Value == value)
                    returnList.Add(parent);

            return returnList.AsReadOnly();

        }
        public IList<IComposite> getParent(string type, string name, string value)
        {
            List<IComposite> returnList = new List<IComposite>();

            foreach (Composite parent in this.Parents)
                if (parent.Type == type && parent.Name == name && parent.Value == value)
                    returnList.Add(parent);

            return returnList.AsReadOnly();

        }
        public void clearParentList()
        {
            List<IComposite> parents = new List<IComposite>(_parents);
            foreach (IComposite p in parents)
                this.removeParent(p);

        }


        #endregion

        #region Children

        private List<IComposite> _children;

        public IList<IComposite> Children { get { return _children.AsReadOnly(); } }

        public IComposite addChild(IComposite child)
        {

            try
            {
                if (child.Equals(this))
                    return child;

                if (!_children.Contains(child))
                {
                    child.insertParent(this);
                    _children.Add(child);
                    
                }

                return child;

            }
            catch (Exception e) {
                return null;
            }

        }

        public void removeParent(IComposite parent, Boolean removeChild = true)
        {


            try
            {
                if (_parents.Contains(parent))
                {
                    if (removeChild)
                        parent.removeChild(this, false);

                    _parents.Remove(parent);

                }


            }
            catch (Exception e) { }


        }


        public IComposite getChild(int CompositeId)
        {

            foreach (IComposite child in _children)
                if (child.ObjectID == CompositeId)
                    return child;

            return null;

        }


        public IList<IComposite> getChild(string name)
        {
            List<IComposite> returnList = new List<IComposite>();

            foreach (Composite child in this.Children)
                if (child.Name == name)
                    returnList.Add(child);

            return returnList.AsReadOnly();

        }
        public IList<IComposite> getChild(string name, string value)
        {
            List<IComposite> returnList = new List<IComposite>();

            foreach (Composite child in this.Children)
                if (child.Name == name && child.Value == value)
                    returnList.Add(child);

            return returnList.AsReadOnly();

        }

        public IList<IComposite> getChild(string type, string name, string value)
        {
            List<IComposite> returnList = new List<IComposite>();

            foreach (Composite child in this.Children)
                if (child.Type == type && child.Name == name && child.Value == value)
                    returnList.Add(child);

            return returnList.AsReadOnly();

        }

        public void moveChild(IComposite fromParent, IComposite toParent)
        {
            fromParent.removeChild(this);
            toParent.addChild(this);
        }


        public void clearChildList()
        {
            {
                List<IComposite> children = new List<IComposite>(_children);
                foreach (IComposite c in children)
                    this.removeChild(c);

            }
        }



        #endregion

        #region Persistance

        virtual public void Read(IDataTransfer DataTransfer, bool lazyLoad = true) { DataTransfer.readItem(this, lazyLoad); }        
        virtual public int Write(IDataTransfer DataTransfer) { return DataTransfer.writeItem(this); }
        public Boolean written { get; set; }
        public Boolean read { get; set; }
        #endregion


    }
}
