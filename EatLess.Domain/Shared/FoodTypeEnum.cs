using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.Shared
{
        public abstract class FoodTypeEnum : Enumeration<FoodTypeEnum>
        {
            public static readonly FoodTypeEnum Protein = new ProteinFoodType();
            public static readonly FoodTypeEnum Carb = new CarbFoodType();
            public static readonly FoodTypeEnum Fat = new FatFoodType();

            protected FoodTypeEnum(int value, string name)
                : base(value, name)
            {
            }

            //public abstract double Discount { get; }

            private sealed class ProteinFoodType : FoodTypeEnum
            {
                public ProteinFoodType()
                    : base(1, "Protein")
                {
                }

                //public override double Discount => 0.01;
            }

            private sealed class CarbFoodType : FoodTypeEnum
            {
                public CarbFoodType()
                    : base(2, "Carb")
                {
                }

                //public override double Discount => 0.05;
            }

            private sealed class FatFoodType : FoodTypeEnum
            {
                public FatFoodType()
                    : base(3, "Fat")
                {
                }

                //public override double Discount => 0.1;
            }
        }
}
