using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Lesson74Data.Entities;

public enum EUserRole
{
    [EnumMember(Value = "Admin")]
    Admin,
    [EnumMember(Value = "User")]
    User,
    [EnumMember(Value = "Teacher")]
    Teacher,
    [EnumMember(Value = "Student")]
    Student
}