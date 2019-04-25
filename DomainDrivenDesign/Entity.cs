using System;
using System.Collections.Generic;
using System.Text;
using RSIComposite;
using System.Linq;

namespace DomainDrivenDesign
{
    public class Entity : Composite
    {
        public Entity() : base() { }
        public Entity(String name) : base() { this.Type = "Entity"; this.Name = name; }
        public Entity(String name, String value) : base() { this.Type = "Entity"; this.Name = name; this.Value = value; }


        #region Attributes
        public IList<IComposite> Attributes { get { return this.getType("Attribute").ToList().AsReadOnly(); } }

        public Composite getAttribute(String name)
        { return (Composite) this.getType("Attribute").FirstOrDefault(e => e.Name == name); }

        public void addAttribute(String name, String value)
        {
            if (this.getType("Attribute").FirstOrDefault(e => e.Name == name) == null)
                this.addChild(new Composite("Attribute", name, value));
        }

        public void addAttribute(Composite attribute)
        {
            if(attribute.Type == "Attribute"  && !String.IsNullOrEmpty(attribute.Name) && !String.IsNullOrEmpty(attribute.Value) 
            && (this.getType("Attribute").FirstOrDefault(e => e.Name == attribute.Name && e.Type == "Attribute") == null  ))
                this.addChild(attribute);
        }
        public void removeAttribute(String name)
        {
            Composite attribute = (Composite) this.getType("Attribute").FirstOrDefault(e => e.Name == name);

            if (attribute != null)
                this.removeChild(attribute);
        }

        #endregion


        #region ValueObjects
        public List<ValueObject> ValueObjects { get { return this.getType<ValueObject>(); } }

        public ValueObject getValueObject(String name)
        { return this.getType<ValueObject>().FirstOrDefault(e => e.Name == name); }

        public void addValueObject(String name)
        {
            if (this.getType<ValueObject>().FirstOrDefault(e => e.Name == name) == null)
                this.addChild(new ValueObject(name));
        }

        public void addValueObject(ValueObject valueObject)
        {
            if (this.getType<ValueObject>().FirstOrDefault(e => e.Name == valueObject.Name) == null)
                this.addChild(valueObject);
        }
        public void removeValueObject(String name)
        {
            ValueObject valueObject = this.getType<ValueObject>().FirstOrDefault(e => e.Name == name);

            if (valueObject != null)
                this.removeChild(valueObject);
        }

        #endregion


    }
}
