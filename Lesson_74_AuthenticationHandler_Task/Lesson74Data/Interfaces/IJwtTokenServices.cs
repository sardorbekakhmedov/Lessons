using Lesson74Data.Entities;

namespace Lesson74Data.Interfaces;

public interface IJwtTokenServices
{
    string CreateJwtToken(User user);
}