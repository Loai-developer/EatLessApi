
namespace EatLess.Domain.Shared
{
    public abstract class GenderEnum : Enumeration<GenderEnum>
    {
        public static readonly GenderEnum Male = new MaleType();
        public static readonly GenderEnum Female = new FemaleType();
        protected GenderEnum(int value, string name)
            : base(value, name)
        {
        }

        private sealed class MaleType : GenderEnum
        {
            public MaleType()
                : base(1, "Male")
            {
            }

        }

        private sealed class FemaleType : GenderEnum
        {
            public FemaleType()
                : base(2, "Female")
            {
            }

        }

    }
}
