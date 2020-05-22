using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public interface IGraphQuery<ResultT>
    {
        dynamic getPayload();

        string endpoint { get; }

        ResultT parseResponse(string responseBody);
    }
}
