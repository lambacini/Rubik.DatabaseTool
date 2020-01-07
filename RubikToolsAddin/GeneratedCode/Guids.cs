using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubikToolsAddin
{
    static class GuidList
    {
        public const string guidRubikToolsAddinPkgString = "df45ada6-0b61-46cd-8167-e4fa55d2f8d4";
        public const string guidCommandSetString = "d6da2261-b1bc-456d-aa45-9b51efe65721";

        public static readonly Guid guidRubikToolsAddinCmdSet = new Guid(guidCommandSetString);
    };
}
