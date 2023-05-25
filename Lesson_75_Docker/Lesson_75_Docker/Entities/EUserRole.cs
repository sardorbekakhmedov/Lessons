
using System.Runtime.Serialization;

namespace Lesson_75_Docker.Entities;

public enum EUserRole
{
    [EnumMember(Value = "Admin")]
    Admin = 1,

    [EnumMember(Value = "User")]
    User
}