﻿using ErrorOr;

namespace BuberBreakfast.ServiceErrors
{
    public static class Errors
    {
        public static class Breakfast
        {
            public static Error NotFound => Error.NotFound("Breakfast.NotFound", "Breakfast not found");
        }
    }
}
