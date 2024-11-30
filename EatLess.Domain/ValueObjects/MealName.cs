using EatLess.Domain.Primitives;
using EatLess.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.ValueObjects
{
    public sealed class MealName : ValueObject
    {
        public const int MaxLength = 50;
        public MealName(string value) 
        { 
            Value = value;
        }
        public string Value { get; }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static Result<MealName> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<MealName>(new Error("MealName.Empty","Meal Name Is Empty"));
            }
            if(name.Length > MaxLength)
            {
                return Result.Failure<MealName>(new Error("MealName.TooLong", "Meal Name Is Too Long"));
            }
            return new MealName(name);
        }
    }
}
