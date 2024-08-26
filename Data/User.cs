using System;
using System.Collections.Generic;

namespace BlazorAuth.Data;

public partial class User
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
}
