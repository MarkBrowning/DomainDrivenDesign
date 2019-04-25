using System;
using System.Collections.Generic;
using System.Text;
using RSIComposite;
using System.Linq;

namespace DomainDrivenDesign
{
    public class Service : Composite
    {
        public Service() : base() { }
        public Service(String name) : base() { this.Type = "Service"; this.Name = name; }
        public Service(String name, String value) : base() { this.Type = "Service"; this.Name = name; this.Value = value; }

        #region Aggregates
        public List<Aggregate> Aggregates { get { return this.getType<Aggregate>(); } }

        public Aggregate getAggregate(String name)
        { return this.getType<Aggregate>().FirstOrDefault(e => e.Name == name); }

        public void addAggregate(String name)
        {
            if (this.getType<Aggregate>().FirstOrDefault(e => e.Name == name) == null)
                this.addChild(new Aggregate(name));
        }

        public void addAggregate(Aggregate aggregate)
        {
            if (this.getType<Aggregate>().FirstOrDefault(e => e.Name == aggregate.Name) == null)
                this.addChild(aggregate);
        }
        public void removeAggregate(String name)
        {
            Aggregate aggregate = this.getType<Aggregate>().FirstOrDefault(e => e.Name == name);

            if (aggregate != null)
                this.removeChild(aggregate);
        }

        #endregion

        #region Entities
        public List<Entity> Entities { get { return this.getType<Entity>(); } }

        public Entity getEntity(String name)
        { return this.getType<Entity>().FirstOrDefault(e => e.Name == name); }

        public void addEntity(String name)
        {
            if (this.getType<Entity>().FirstOrDefault(e => e.Name == name) == null)
                this.addChild(new Entity(name));
        }

        public void addEntity(Entity entity)
        {
            if (this.getType<Entity>().FirstOrDefault(e => e.Name == entity.Name) == null)
                this.addChild(entity);
        }
        public void removeEntity(String name)
        {
            Entity entity = this.getType<Entity>().FirstOrDefault(e => e.Name == name);

            if (entity != null)
                this.removeChild(entity);
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
