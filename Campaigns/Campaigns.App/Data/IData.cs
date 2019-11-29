using System;
using System.Collections.Generic;

namespace Campaigns.App.Data
{
    public interface IData
    {
        List<DataModel> Load();

    }
}
