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
            public static readonly FoodTypeEnum Fiber = new FiberFoodType();

            protected FoodTypeEnum(int value, string name)
                : base(value, name)
            {
            }

            private sealed class ProteinFoodType : FoodTypeEnum
            {
                public ProteinFoodType()
                    : base(1, "Protein")
                {
                }

            }

            private sealed class CarbFoodType : FoodTypeEnum
            {
                public CarbFoodType()
                    : base(2, "Carb")
                {
                }

            }

            private sealed class FatFoodType : FoodTypeEnum
            {
                public FatFoodType()
                    : base(3, "Fat")
                {
                }

            }

            private sealed class FiberFoodType : FoodTypeEnum
            {
                public FiberFoodType()
                    : base(4, "Fiber")
                {
                }

            }
    }
}
