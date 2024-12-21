
namespace EatLess.Domain.Shared
{
    public abstract class BulkOrCutEnum : Enumeration<FoodTypeEnum>
    {
        public static readonly BulkOrCutEnum Bulk = new BulkType();
        public static readonly BulkOrCutEnum Cut = new CutType();

        protected BulkOrCutEnum(int value, string name)
                : base(value, name)
        {
        }

        private sealed class CutType : BulkOrCutEnum
        {
            public CutType()
                : base(1, "Cut")
            {
            }

        }

        private sealed class BulkType : BulkOrCutEnum
        {
            public BulkType()
                : base(2, "Bulk")
            {
            }

        }
    }
}
