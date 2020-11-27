using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EventsLoggerTests
{
    public class BehaviorTypeTest
    {
        [Fact]
        public void CalculateBehaviorType()
        {
            ProductType product = new ProductType(-1);
            var behavior = product.BehaviorType();
            Console.WriteLine(behavior.Name);
            behavior.CreateContract();
        }
    }


    public class ProductType
    {
        public ProductType(int productTypeId)
        {
            if (productTypeId < 0) throw new ArgumentException("Cannot be less than 0");
            TypeId = productTypeId;
        }

        protected int MaxProductType = 5;
        protected int MinProductType = 0;
        
        public int TypeId { get; private set; }
        public string Name { get; set; }

        public virtual bool Cancel()
        {
            return true;
        }

        public int GenerateBehaviorType()
        {
            return new Random().Next(MinProductType, MaxProductType);
        }


        public virtual BehaviorType BehaviorType()
        {
            var behaviorType = GenerateBehaviorType();
            if (behaviorType == 0)
                return new VscBehavior();
            else if (behaviorType == 1)
                return new GapBehavior();
            else
                return new UnknownBehavior();
        }

    }




    public abstract class BehaviorType
    {
        public abstract string Name { get; }

        public virtual bool CreateContract()
        {
            return true;
        }
    }

    public class VscBehavior : BehaviorType
    {
        public override string Name => "VSC";
    }

    public class GapBehavior : BehaviorType
    {
        public override string Name => "GAP";
    }

    public class UnknownBehavior : BehaviorType
    {
        public override string Name => "Unknown";

        public override bool CreateContract()
        {
            Console.WriteLine("Cannot Create Contract!");
            return false;
        }
    }


    public class ProductTypeRestricted : ProductType
    {
        public ProductTypeRestricted(int productTypeId) : base(productTypeId)
        {
            if (productTypeId > 8) throw new ArgumentException("");
            MaxProductType = 12;
        }
    }
}
