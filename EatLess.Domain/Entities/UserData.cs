using EatLess.Domain.Primitives;
using EatLess.Domain.Shared;

namespace EatLess.Domain.Entities
{
    public sealed class UserData : AggregateRoot
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string UserId { get; private set; }
        public decimal Height { get; private set; }
        public decimal Weight { get; private set; }
        public GenderEnum GenderEnum { get; private set; }
        public string Photo { get; private set; }

        private readonly List<UserPlan> _userPlans = new();
        public IReadOnlyCollection<UserPlan> UserPlans => _userPlans;
        private UserData(Guid Id, string name, int age, string userId, decimal height, decimal weight, GenderEnum gender, string photo)
            : base(Id)
        {
            Name = name;
            Age = age;
            UserId = userId;
            Height = height;
            Weight = weight;
            Photo = photo;
            GenderEnum = gender;
        }
        public UserData() : base(Guid.Empty) { }
    }
}
