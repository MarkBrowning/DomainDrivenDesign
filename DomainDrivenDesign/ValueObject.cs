using System;
using System.Collections.Generic;
using System.Text;
using RSIComposite;
using System.Linq;

namespace DomainDrivenDesign
{
    public class ValueObject : Composite
    {
       public new readonly String Name;
       public new readonly String Value;

        public ValueObject() : base() { }
        public ValueObject(String name) : base() { this.Type = "ValueObject"; this.Name = name; }
        public ValueObject(String name, String value) : base() { this.Type = "ValueObject"; this.Name = name; this.Value = value; }
    
        #region ValueObjects
        public IList<ValueObject> ValueObjects { get { return this.getType<ValueObject>().AsReadOnly(); } }

        public ValueObject addValueObject(String name)
        {
            ValueObject vObject = this.getType<ValueObject>().FirstOrDefault(e => e.Name == name);

            if (vObject == null)
                vObject = (ValueObject) this.addChild(new ValueObject(name));

            return vObject;
        }

        public ValueObject addValueObject(String name, String value)
        {
            ValueObject vObject = this.getType<ValueObject>().FirstOrDefault(e => e.Name == name);

            if (vObject == null)
            {
                vObject = new ValueObject(name, value);
                this.addChild(vObject);
            }

            return vObject;
        }

        public void addValueObject(ValueObject vObj)
        {            
            if (this.getType<ValueObject>().FirstOrDefault(e => e.Name == vObj.Name) == null)            
                this.addChild(vObj);                        
        }

        public void removeValueObject(String name)
        {
            ValueObject vObj = this.getType<ValueObject>().FirstOrDefault(e => e.Name == name);

            if (vObj != null)
                this.removeChild(vObj);
        }

        public ValueObject getValueObject(String name)
        {
            return this.getType<ValueObject>().FirstOrDefault(e => e.Name == name);
        }

        #endregion

        #region Attributes
        public IList<IComposite> Attributes { get { return this.getType("Attribute").ToList().AsReadOnly(); } }

        public Composite getAttribute(String name)
        { return (Composite)this.getType("Attribute").FirstOrDefault(e => e.Name == name); }

        public void addAttribute(String name, String value)
        {
            if (this.getType("Attribute").FirstOrDefault(e => e.Name == name) == null)
                this.addChild(new Composite("Attribute", name, value));
        }

        public void addAttribute(Composite attribute)
        {
            if (attribute.Type == "Attribute" && !String.IsNullOrEmpty(attribute.Name) && !String.IsNullOrEmpty(attribute.Value)
            && (this.getType("Attribute").FirstOrDefault(e => e.Name == attribute.Name && e.Type == "Attribute") == null))
                this.addChild(attribute);
        }
        public void removeAttribute(String name)
        {
            Composite attribute = (Composite)this.getType("Attribute").FirstOrDefault(e => e.Name == name);

            if (attribute != null)
                this.removeChild(attribute);
        }

        #endregion
    }
}
