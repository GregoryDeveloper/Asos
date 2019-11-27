using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace App.Enumerations
{
    public enum CompanyName
    {
        [Description("VeryImportantClient")]
        VeryImportantClient,
        [Description("ImportantClient")]
        ImportantClient

    }
}
