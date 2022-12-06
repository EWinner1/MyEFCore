using MyEFCore.Infrastrcture.Common.Enums;
using System.Text.Json.Serialization;

namespace MyEFCore.Infrastrcture.Models
{
    [Serializable]
    public class People
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public PeopleType PeopleType { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }
        public Dictionary<string, int>? Skills { get; set; }

        [JsonConstructor]
        public People() { }
        public People(int id, string name, PeopleType peopleType, string sex, int age, Dictionary<string, int> skills)
        {
            Id = id;
            Name = name;
            PeopleType = peopleType;
            Sex = sex;
            Age = age;
            Skills = skills;
        }
    }
}
